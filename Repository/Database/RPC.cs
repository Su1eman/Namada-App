using Microsoft.Maui.Animations;
using Namada_Maui.Models.Blocks;
using Namada_Maui.Models.Overviews;
using Namada_Maui.Models.Settings;
using Namada_Maui.Models.Validators;
using Namada_Maui.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Repository.Database
{
    public class RPC
    {
        private uint latestBlock;

        private static HttpClient PreparedClient()
        {
            HttpClientHandler handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssPolicyError) =>
            {
                return true;
            };

            HttpClient client = new HttpClient(handler);

            return client;
        }

        public static async Task<uint?> LatestBlock()
        {
            uint? latestBlock = null;

            HttpClient client = PreparedClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.OverviewUri());

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    latestBlock = (uint?)jsonObject["result"]?["header"]?["height"];
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            client.Dispose();

            return latestBlock;
        }

        #region Overview

        public static async Task<Overview> Overview()
        {
            string content;

            HttpClient client = PreparedClient();

            Overview? overviewCloud = null;

            DateTime currentBlockTime = DateTime.Now;

            DateTime previousBlockTime = DateTime.Now;

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.OverviewUri());

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    overviewCloud = new Overview
                    {
                        Chain = (string)jsonObject["result"]["header"]["chain_id"],
                        LatestBlock = (uint)jsonObject["result"]["header"]["height"],
                        ProposerAddress = (string)jsonObject["result"]["header"]["proposer_address"]
                    };

                    currentBlockTime = (DateTime)jsonObject["result"]["header"]["time"];
                }

                response = await client.GetAsync(AppConfig.OverviewUri(--overviewCloud.LatestBlock));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    previousBlockTime = (DateTime)jsonObject["result"]["header"]["time"];
                }

                overviewCloud.BlockTime = (currentBlockTime - previousBlockTime);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            client.Dispose();

            return overviewCloud;
        }

        #endregion

        #region Validators

        public static async Task<List<Validator>> Validators()
        {
            ushort total = default;

            ushort page = default;

            List<Validator> validatorsCloud = new List<Validator>();

            string content;

            HttpClient client = PreparedClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.ValidatorsUri());

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    validatorsCloud = jsonObject["result"]["validators"].ToObject<List<Validator>>();
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            client.Dispose();















            #region ValidatorBase

            List<ValidatorBase> ValidatorBases = new List<ValidatorBase>();

            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("validatorsList.json");

                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();

                JObject jsonObject = JObject.Parse(contents);

                ValidatorBases = jsonObject["validatorsList"].ToObject<List<ValidatorBase>>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            #endregion

            foreach (var signatures in validatorsCloud)
            {
                var matchingPerson = ValidatorBases.FirstOrDefault(p => p.Address == signatures.Address);

                if (matchingPerson != null)
                {
                    signatures.Moniker = matchingPerson.Moniker;

                    if (matchingPerson.Icon != String.Empty)
                    {
                        signatures.Icon = matchingPerson.Icon;
                    }
                }
            }

            DBSQLite database = new DBSQLite();

            try { await database.DeleteAllValidator(); }
            catch (Exception) { }

            try { await database.InsertAllValidator(validatorsCloud); }
            catch (Exception) { }

            return validatorsCloud;
        }

        public static async Task<List<Validator>> TopValidators()
        {
            List<Validator> validatorsCloud = new List<Validator>();

            string content;

            HttpClient client = PreparedClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.ValidatorsUri(1,5));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    validatorsCloud = jsonObject["result"]["validators"].ToObject<List<Validator>>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            client.Dispose();

            #region ValidatorBase

            List<ValidatorBase> ValidatorBases = new List<ValidatorBase>();

            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("validatorsList.json");

                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();

                JObject jsonObject = JObject.Parse(contents);

                ValidatorBases = jsonObject["validatorsList"].ToObject<List<ValidatorBase>>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            #endregion

            foreach (var signatures in validatorsCloud)
            {
                var matchingPerson = ValidatorBases.FirstOrDefault(p => p.Address == signatures.Address);

                if (matchingPerson != null)
                {
                    signatures.Moniker = matchingPerson.Moniker;

                    if (matchingPerson.Icon != String.Empty)
                    {
                        signatures.Icon = matchingPerson.Icon;
                    }
                }
            }

            return validatorsCloud;
        }

        public static async Task<List<ValidatorSignature>> ValidatorSignatures(string? validatorAddress)
        {
            #region Block Cloud

            uint? latestBlock = await LatestBlock();

            uint? minLatestBlock = latestBlock - 19;

            List<Block> blocksCloud = new List<Block>();

            HttpClient client = PreparedClient();

            string content;

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.BlocksUri(minLatestBlock, latestBlock));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    foreach (var item in jsonObject["result"]["block_metas"])
                    {
                        Block blockTemp = new Block()
                        {
                            Height = (uint)item["header"]["height"],
                            Proposer = (string?)item["header"]?["proposer_address"],
                            Hash = (string?)item["header"]?["data_hash"],
                            Time = (DateTime)item["header"]["time"],
                            NumTxs = (ushort)item["num_txs"]
                        };

                        blocksCloud.Add(blockTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            #endregion

            #region ValidatorSignature

            List<ValidatorSignature> validatorSignatureCloud = new List<ValidatorSignature>();

            foreach (var block in blocksCloud)
            {
                //  proposer = true, active = false, inactive = null

                bool? status = null;

                if (block.Proposer == validatorAddress)
                {
                    status = true;
                }
                else
                {
                    List<Signature> signaturesCloud = new List<Signature>();

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(AppConfig.SignaturesUri(block.Height));

                        if (response.IsSuccessStatusCode)
                        {
                            content = await response.Content.ReadAsStringAsync();

                            JObject jsonObject = JObject.Parse(content);

                            signaturesCloud = jsonObject["result"]["signed_header"]["commit"]["signatures"].ToObject<List<Signature>>().Where(signature => !string.IsNullOrEmpty(signature.ValidatorAddress)).ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(@"\tERROR {0}", ex.Message);
                    }

                    foreach (var signature in signaturesCloud)
                    {
                        if (signature.ValidatorAddress == validatorAddress)
                        {
                            status = false;
                            break;
                        }
                    }
                }

                validatorSignatureCloud.Add(new ValidatorSignature() { Height = block.Height, Status = status });
            }

            #endregion

            client.Dispose();

            return validatorSignatureCloud;
        }

        public static async Task<ValidatorSignature> ValidatorSignature(string? validatorAddress, uint? latestBlock)
        {
            Block blockCloud = new Block();

            HttpClient client = PreparedClient();

            string content;

            #region Block Cloud

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.BlockUri(latestBlock));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    foreach (var item in jsonObject["result"]["block_metas"])
                    {
                        blockCloud = new Block()
                        {
                            Height = (uint)item["header"]["height"],
                            Proposer = (string?)item["header"]?["proposer_address"],
                            Hash = (string?)item["header"]?["data_hash"],
                            Time = (DateTime)item["header"]["time"],
                            NumTxs = (ushort)item["num_txs"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            #endregion

            #region ValidatorSignature

            ValidatorSignature validatorSignatureCloud = new ValidatorSignature();

            //  proposer = true, active = false, inactive = null

            bool? status = null;

            if (blockCloud.Proposer == validatorAddress)
            {
                status = true;
            }
            else
            {
                List<Signature> signaturesCloud = new List<Signature>();

                try
                {
                    HttpResponseMessage response = await client.GetAsync(AppConfig.SignaturesUri(blockCloud.Height));

                    if (response.IsSuccessStatusCode)
                    {
                        content = await response.Content.ReadAsStringAsync();

                        JObject jsonObject = JObject.Parse(content);

                        signaturesCloud = jsonObject["result"]["signed_header"]["commit"]["signatures"].ToObject<List<Signature>>().Where(signature => !string.IsNullOrEmpty(signature.ValidatorAddress)).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }

                foreach (var signature in signaturesCloud)
                {
                    if (signature.ValidatorAddress == validatorAddress)
                    {
                        status = false;
                        break;
                    }
                }
            }

            validatorSignatureCloud = new ValidatorSignature() { Height = blockCloud.Height, Status = status };

            #endregion

            client.Dispose();








            //#region Block Cloud

            ////uint? latestBlock = await LatestBlock();

            ////uint? minLatestBlock = latestBlock - 19;

            ////List<Block> blocksCloud = new List<Block>();

            ////HttpClient client = PreparedClient();

            ////string content;

            //try
            //{
            //    HttpResponseMessage response = await client.GetAsync(AppConfig.BlocksUri(minLatestBlock, latestBlock));

            //    if (response.IsSuccessStatusCode)
            //    {
            //        content = await response.Content.ReadAsStringAsync();

            //        JObject jsonObject = JObject.Parse(content);

            //        foreach (var item in jsonObject["result"]["block_metas"])
            //        {
            //            Block blockTemp = new Block()
            //            {
            //                Height = (uint)item["header"]["height"],
            //                Proposer = (string?)item["header"]?["proposer_address"],
            //                Hash = (string?)item["header"]?["data_hash"],
            //                Time = (DateTime)item["header"]["time"],
            //                NumTxs = (ushort)item["num_txs"]
            //            };

            //            blocksCloud.Add(blockTemp);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //}

            //#endregion

            //#region ValidatorSignature

            //List<ValidatorSignature> validatorSignatureCloud = new List<ValidatorSignature>();

            //foreach (var block in blocksCloud)
            //{
            //    //  proposer = true, active = false, inactive = null

            //    bool? status = null;

            //    if (block.Proposer == validatorAddress)
            //    {
            //        status = true;
            //    }
            //    else
            //    {
            //        List<Signature> signaturesCloud = new List<Signature>();

            //        try
            //        {
            //            HttpResponseMessage response = await client.GetAsync(AppConfig.SignaturesUri(block.Height));

            //            if (response.IsSuccessStatusCode)
            //            {
            //                content = await response.Content.ReadAsStringAsync();

            //                JObject jsonObject = JObject.Parse(content);

            //                signaturesCloud = jsonObject["result"]["signed_header"]["commit"]["signatures"].ToObject<List<Signature>>().Where(signature => !string.IsNullOrEmpty(signature.ValidatorAddress)).ToList();
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //        }

            //        foreach (var signature in signaturesCloud)
            //        {
            //            if (signature.ValidatorAddress == validatorAddress)
            //            {
            //                status = false;
            //                break;
            //            }
            //        }
            //    }

            //    validatorSignatureCloud.Add(new ValidatorSignature() { Height = block.Height, Status = status });
            //}

            //#endregion

            //client.Dispose();

            return validatorSignatureCloud;
        }

        #endregion

        #region Signatures

        public static async Task<List<Signature>> Signatures(uint? latestBlock)
        {
            List<Signature> signaturesCloud = new List<Signature>();

            HttpClient client = PreparedClient();

            string content;

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.SignaturesUri(latestBlock));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    signaturesCloud = jsonObject["result"]["signed_header"]["commit"]["signatures"].ToObject<List<Signature>>().Where(signature => !string.IsNullOrEmpty(signature.ValidatorAddress)).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            client.Dispose();

            #region ValidatorBase

            List<ValidatorBase> validatorBases = new List<ValidatorBase>();

            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("validatorsList.json");

                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();

                JObject jsonObject = JObject.Parse(contents);

                validatorBases = jsonObject["validatorsList"].ToObject<List<ValidatorBase>>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            #endregion

            foreach (var signatures in signaturesCloud)
            {
                var matchingPerson = validatorBases.FirstOrDefault(p => p.Address == signatures.ValidatorAddress);

                if (matchingPerson != null)
                {
                    signatures.Moniker = matchingPerson.Moniker;

                    if (matchingPerson.Icon != String.Empty)
                    {
                        signatures.Icon = matchingPerson.Icon;
                    }
                }
            }

            return signaturesCloud;
        }

        #endregion

        #region Blocks

        public static async Task<List<Block>> Blocks()
        {
            Block? block = null;

            DBSQLite database = new DBSQLite();

            try { block = database.QueryFirstBlock().Result; }
            catch (Exception) { }

            #region Block Cloud

            uint? latestBlock = await LatestBlock();

            //uint? minLatestBlock = block == null ? latestBlock - 10 : block.Height;

            uint? minLatestBlock = latestBlock - 10;

            List<Block> blocksCloud = new List<Block>();

            HttpClient client = PreparedClient();

            string content;

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.BlocksUri(minLatestBlock, latestBlock));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    foreach (var item in jsonObject["result"]["block_metas"])
                    {
                        Block blockTemp = new Block()
                        {
                            Height = (uint)item["header"]["height"],
                            Proposer = (string?)item["header"]?["proposer_address"],
                            Hash = (string?)item["header"]?["data_hash"],
                            Time = (DateTime)item["header"]["time"],
                            NumTxs = (ushort)item["num_txs"]
                        };

                        await database.InsertBlock(blockTemp);

                        blocksCloud.Add(blockTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            client.Dispose();

            #endregion







            return blocksCloud;
        }

        public static async Task<List<Block>> TopBlocks()
        {
            #region Block Cloud

            uint? latestBlock = await LatestBlock();

            List<Block> blocksCloud = new List<Block>();

            List<Block> blocksLocal = new List<Block>();

            //uint? minLatestBlock = block == null ? latestBlock - 10 : block.Height;

            uint? minLatestBlock = latestBlock - 2;

            HttpClient client = PreparedClient();

            string content;

            try
            {
                HttpResponseMessage response = await client.GetAsync(AppConfig.BlocksUri(minLatestBlock, latestBlock));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(content);

                    foreach (var item in jsonObject["result"]["block_metas"])
                    {
                        Block blockTemp = new Block()
                        {
                            Height = (uint)item["header"]["height"],
                            Proposer = (string?)item["header"]?["proposer_address"],
                            Hash = (string?)item["header"]?["data_hash"],
                            Time = (DateTime)item["header"]["time"],
                            NumTxs = (ushort)item["num_txs"]
                        };

                        blocksCloud.Add(blockTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            client.Dispose();

            #endregion

            return blocksCloud;
        }

        #endregion
    }
}