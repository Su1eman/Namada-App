using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Validators
{

    public class ValidatorBase
    {
        private string? address;
        private string? moniker;
        private string? icon;
        private string? mail;
        private string? website;

        [JsonProperty("address")]
        public string? Address
        {
            get { return address; }
            set
            {
                if (address == value) { return; }
                address = value;
            }
        }

        [JsonProperty("moniker")]
        public string? Moniker
        {
            get { return moniker; }
            set
            {
                if (moniker == value) { return; }
                moniker = value;
            }
        }

        [JsonProperty("icon")]
        public string? Icon
        {
            get { return icon; }
            set
            {
                if (icon == value) { return; }
                icon = value;
            }
        }

        [JsonProperty("mail")]
        public string? Mail
        {
            get { return mail; }
            set
            {
                if (mail == value) { return; }
                mail = value;
            }
        }

        [JsonProperty("website")]
        public string? Website
        {
            get { return website; }
            set
            {
                if (website == value) { return; }
                website = value;
            }
        }
    }
}