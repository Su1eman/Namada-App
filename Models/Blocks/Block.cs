using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Blocks
{
    public class Block
    {
        private uint id;
        private uint height;
        private string? moniker;
        private string? proposer;
        private string? hash;
        private DateTime time;
        private ushort numTxs;

        [PrimaryKey]
        public uint Id
        {
            get { return id; }
            set
            {
                if (id == value) { return; }
                id = value;
            }
        }

        [JsonProperty("height")]
        public uint Height
        {
            get { return height; }
            set
            {
                if (height == value) { return; }
                id = value;
                height = value;
            }
        }

        public string? Moniker
        {
            get { return moniker; }
            set
            {
                if (moniker == value) { return; }
                moniker = value;
            }
        }

        [JsonProperty("proposer_address")]
        public string? Proposer
        {
            get { return proposer; }
            set
            {
                if (proposer == value) { return; }
                proposer = value;
            }
        }

        [JsonProperty("data_hash")]
        public string? Hash
        {
            get { return hash; }
            set
            {
                if (hash == value) { return; }
                hash = value;
            }
        }

        [JsonProperty("time")]
        public DateTime Time
        {
            get { return time; }
            set
            {
                if (time == value) { return; }
                time = value;
            }
        }

        [JsonProperty("num_txs")]
        public ushort NumTxs
        {
            get { return numTxs; }
            set
            {
                if (numTxs == value) { return; }
                numTxs = value;
            }
        }
    }
}