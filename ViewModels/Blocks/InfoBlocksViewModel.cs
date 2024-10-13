using CommunityToolkit.Maui.Core;
using Namada_Maui.Models.Blocks;
using Namada_Maui.Repository.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.Maui.ApplicationModel;

namespace Namada_Maui.ViewModels.Blocks
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class InfoBlocksViewModel : INotifyPropertyChanged
    {
        private int indexMin = default;

        private int indexMax = default;

        private int firstSize = 10;

        private int size = 1;

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string id)
        {
            DBSQLite database = new DBSQLite();

            try { Block = database.QueryBlock(uint.Parse(id)).Result; }
            catch (Exception) { return; }

            signaturesTemp = new ObservableCollection<Signature>(await RPC.Signatures(Block.Height));

            LoadInitialData();
        }

        public Block block = new Block();

        public Block Block
        {
            get { return block; }
            set
            {
                if (block == value) { return; }

                block = value;

                OnPropertyChanged(nameof(Block));
            }
        }

        public ObservableCollection<Signature> signaturesTemp = new ObservableCollection<Signature>();

        public ObservableCollection<Signature> signatures = new ObservableCollection<Signature>();

        public ObservableCollection<Signature> Signatures
        {
            get { return signatures; }
            set
            {
                if (signatures == value) { return; }
                signatures = value;
                OnPropertyChanged(nameof(Signatures));
            }
        }

        public ICommand CopyCommand => new Command<string>(OnCopyClicked);

        private void OnCopyClicked(string parameter)
        {
            switch (parameter)
            {
                case "height":
                    Clipboard.Default.SetTextAsync(Block.Height.ToString());
                    break;
                case "proposer":
                    Clipboard.Default.SetTextAsync(Block.Proposer);
                    break;
                case "hash":
                    Clipboard.Default.SetTextAsync(Block.Hash);
                    break;
                case "time":
                    Clipboard.Default.SetTextAsync(Block.Time.ToString());
                    break;
                case "numTxs":
                    break;
            }

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "Copied";

            ToastDuration duration = ToastDuration.Short;

            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            toast.Show(cancellationTokenSource.Token);
        }

        public ICommand LoadMoreCommand => new Command(LoadMore);

        //public ICommand LoadMoreCommand { get; }

        public InfoBlocksViewModel()
        {
            //LoadMoreCommand = new Command(LoadMore);
        }

        public void LoadInitialData()
        {
            indexMax = firstSize < signaturesTemp.Count ? firstSize : signaturesTemp.Count;

            while (indexMin < indexMax)
            {
                Signatures.Add(signaturesTemp[indexMin]);
                indexMin++;
            }
        }

        public void LoadMore()
        {
            indexMax = indexMax + size < signaturesTemp.Count ? indexMax + size : signaturesTemp.Count;

            while (indexMin < indexMax)
            {
                Signatures.Add(signaturesTemp[indexMin]);
                indexMin++;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}