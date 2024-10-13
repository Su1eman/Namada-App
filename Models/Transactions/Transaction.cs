using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Transactions
{
    public class Transaction
    {
        private uint height;
        private string? hash;
        private string? time;

        [JsonProperty("header_height")]
        public uint Height
        {
            get { return height; }
            set
            {
                if (height == value) { return; }
                height = value;
            }
        }

        [JsonProperty("block_id")]
        public string? Hash
        {
            get { return hash; }
            set
            {
                if (hash == value) { return; }
                hash = value;
            }
        }

        [JsonProperty("header_time")]
        public string? Time
        {
            get { return time; }
            set
            {
                if (time == value) { return; }
                time = value;
            }
        }
    }
}