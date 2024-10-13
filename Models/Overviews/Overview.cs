using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Overviews
{
    public class Overview : INotifyPropertyChanged
    {
        private int id;
        private uint latestBlock;
        private TimeSpan blockTime;
        private string? chain;
        private string? proposerAddress;

        [PrimaryKey]
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
        public uint LatestBlock
        {
            get { return latestBlock; }
            set
            {
                if (latestBlock == value) { return; }
                latestBlock = value;
                OnPropertyChanged(nameof(LatestBlock));
            }
        }

        [JsonProperty("time")]
        public TimeSpan BlockTime
        {
            get { return blockTime; }
            set
            {
                if (blockTime == value) { return; }
                blockTime = value;
                OnPropertyChanged(nameof(BlockTime));
            }
        }

        [JsonProperty("chain_id")]
        public string? Chain
        {
            get { return chain; }
            set
            {
                if (chain == value) { return; }
                chain = value;
                OnPropertyChanged(nameof(Chain));
            }
        }

        [JsonProperty("proposer_address")]
        public string? ProposerAddress
        {
            get { return proposerAddress; }
            set
            {
                if (proposerAddress == value) { return; }
                proposerAddress = value;
                OnPropertyChanged(nameof(ProposerAddress));
            }
        }

        [Ignore]
        public string BlockTimeShow
        {
            get
            {
                return blockTime.ToString(@"ss\.fff") + "s";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "") { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}