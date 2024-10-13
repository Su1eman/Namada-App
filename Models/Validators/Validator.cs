using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Validators
{
    public class Validator : ValidatorBase
    {
        private string? id;
        private int rating;
        private string? moniker;
        private string? address;
        private long votingPower;
        private double votingPercentage;
        private string? proposerPriority;
        private ObservableCollection<ValidatorSignature> validatorSignatures = new ObservableCollection<ValidatorSignature>();

        [PrimaryKey]
        public string? Id
        {
            get { return id; }
            set
            {
                if (id == value) { return; }
                id = value;
            }
        }

        [Ignore]
        public int Rating
        {
            get { return rating; }
            set
            {
                if (rating == value) { return; }
                rating = value;
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

        [JsonProperty("address")]
        public string? Address
        {
            get { return address; }
            set
            {
                if (address == value) { return; }
                id = value;
                address = value;
            }
        }

        [JsonProperty("voting_power")]
        public long VotingPower
        {
            get { return votingPower; }
            set
            {
                if (votingPower == value) { return; }
                votingPower = value;
            }
        }

        public double VotingPercentage
        {
            get { return votingPercentage; }
            set
            {
                if (votingPercentage == value) { return; }
                votingPercentage = value;
            }
        }

        [JsonProperty("proposer_priority")]
        public string? ProposerPriority
        {
            get { return proposerPriority; }
            set
            {
                if (proposerPriority == value) { return; }
                proposerPriority = value;
            }
        }

        [Ignore]
        public ObservableCollection<ValidatorSignature> ValidatorSignatures
        {
            get { return validatorSignatures; }
            set
            {
                if (validatorSignatures == value) { return; }
                validatorSignatures = value;
            }
        }
    }
}