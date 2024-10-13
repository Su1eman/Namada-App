using CommunityToolkit.Maui.Core;
using Namada_Maui.Models.Validators;
using Namada_Maui.Repository.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;

namespace Namada_Maui.ViewModels.Validators
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class InfoValidatorsViewModel : INotifyPropertyChanged
    {
        #region PageFocused

        private bool isPageFocused;

        public bool IsPageFocused
        {
            get { return isPageFocused; }
            set
            {
                if (isPageFocused != value)
                {
                    isPageFocused = value;

                    OnPropertyChanged(nameof(IsPageFocused));
                }
            }
        }

        // Метод вызываемый когда страница получает фокус
        public void PageFocused()
        {
            IsPageFocused = true;
        }

        // Метод вызываемый когда страница теряет фокус
        public void PageUnfocused()
        {
            IsPageFocused = false;
        }

        #endregion

        #region Refreshing

        bool isRefreshing = false;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());

        Task RefreshDataAsync()
        {
            IsRefreshing = true;

            LoadingValidators();

            IsRefreshing = false;

            return Task.CompletedTask;
        }

        #endregion

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

            try { Validator = database.QueryValidator(id).Result; }
            catch (Exception) { return; }

            uint? latestBlock = await RPC.LatestBlock();

            for (int i = 0; i < 20; i++)
            {
                var item = await RPC.ValidatorSignature(Validator.Address, latestBlock);

                ValidatorSignatures.Add(item);

                latestBlock--;
            }
        }









        //private async Task LoadItemsAsync()
        //{
        //    // Здесь может быть асинхронный вызов к сервису или базе данных
        //    // В примере просто добавим некоторые тестовые данные с задержкой

        //    IsBusy = true; // Устанавливаем флаг, что идет загрузка данных



        //    Items.Clear();

        //    // Добавляем тестовые элементы
        //    Items.Add(new Item { Name = "Item 1", Description = "Description 1" });
        //    Items.Add(new Item { Name = "Item 2", Description = "Description 2" });
        //    Items.Add(new Item { Name = "Item 3", Description = "Description 3" });

        //    IsBusy = false; // Говорим, что загрузка завершена
        //}






        public Validator validator = new Validator();

        public Validator Validator
        {
            get { return validator; }
            set
            {
                if (validator == value) { return; }

                validator = value;

                OnPropertyChanged(nameof(Validator));
            }
        }


        public ObservableCollection<ValidatorSignature> validatorSignatures = new ObservableCollection<ValidatorSignature>();

        public ObservableCollection<ValidatorSignature> ValidatorSignatures
        {
            get { return validatorSignatures; }
            set
            {
                if (validatorSignatures == value) { return; }
                validatorSignatures = value;
                OnPropertyChanged(nameof(ValidatorSignatures));
            }
        }

        public ICommand CopyCommand => new Command<string>(OnCopyClicked);

        private void OnCopyClicked(string parameter)
        {
            switch (parameter)
            {
                case "moniker":
                    Clipboard.Default.SetTextAsync(Validator.Moniker);
                    break;
                case "address":
                    Clipboard.Default.SetTextAsync(Validator.Address);
                    break;
                case "votingPower":
                    Clipboard.Default.SetTextAsync(Validator.VotingPower.ToString());
                    break;
                case "votingPercentage":
                    Clipboard.Default.SetTextAsync(Validator.VotingPercentage.ToString());
                    break;
                case "proposerPriority":
                    Clipboard.Default.SetTextAsync(Validator.ProposerPriority);
                    break;
            }

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "Copied";

            ToastDuration duration = ToastDuration.Short;

            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            toast.Show(cancellationTokenSource.Token);
        }

        public InfoValidatorsViewModel()
        {
            //LoadingValidators();

            //  proposer = true, active = false, inactive = null
        }

        public async void LoadingValidators()
        {
            DBSQLite database = new DBSQLite();

            try { Validator = database.QueryValidator(id).Result; }
            catch (Exception) { return; }

            uint? latestBlock = await RPC.LatestBlock();

            ValidatorSignatures = new ObservableCollection<ValidatorSignature>();

            for (int i = 0; i < 20; i++)
            {
                var item = await RPC.ValidatorSignature(Validator.Address, latestBlock);

                ValidatorSignatures.Add(item);

                latestBlock--;
            }


            //DBSQLite database = new DBSQLite();

            //try { Validator = database.QueryValidator(id).Result; }
            //catch (Exception) { return; }

            //ValidatorSignatures = await RPC.ValidatorSignatures(Validator.Address);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}