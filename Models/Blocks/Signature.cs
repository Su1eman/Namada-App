using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Blocks
{
    public class Signature
    {
        private int id;
        private uint height;
        private string? moniker;
        private string? icon;
        private string? validatorAddress;
        private DateTime timestamp;

        [PrimaryKey, AutoIncrement]
        public int Id
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

        public string? Icon
        {
            get { return icon; }
            set
            {
                if (icon == value) { return; }
                icon = value;
            }
        }

        [JsonProperty("validator_address")]
        public string? ValidatorAddress
        {
            get { return validatorAddress; }
            set
            {
                if (validatorAddress == value) { return; }
                validatorAddress = value;
            }
        }

        [JsonProperty("timestamp")]
        public DateTime Timestamp
        {
            get { return timestamp; }
            set
            {
                if (timestamp == value) { return; }
                timestamp = value;
            }
        }
    }
}