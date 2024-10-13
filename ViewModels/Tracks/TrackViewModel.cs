using CommunityToolkit.Maui.Core;
using Namada_Maui.Models.Validators;
using Namada_Maui.Repository.Database;
using Namada_Maui.ViewModels.Validators;
using Namada_Maui.Views.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;

namespace Namada_Maui.ViewModels.Tracks
{
    public class TrackViewModel : INotifyPropertyChanged
    {
        private string search;

        public string Search
        {
            get { return search; }
            set
            {
                if (search != value)
                {
                    search = value;

                    if (search == String.Empty) { IsVisibleTrash = false; Validators = new ObservableCollection<Validator>(); }
                    else { IsVisibleTrash = true; }

                    OnPropertyChanged(nameof(Search));
                }
            }
        }


        private bool isVisibleTrash;

        public bool IsVisibleTrash
        {
            get { return isVisibleTrash; }
            set
            {
                if (isVisibleTrash != value)
                {
                    isVisibleTrash = value;

                    OnPropertyChanged(nameof(IsVisibleTrash));
                }
            }
        }

        public ICommand TrashCommand => new Command(OnTrashClicked);

        private void OnTrashClicked()
        {
            Search = String.Empty;

            IsVisibleTrash = false;
        }

        public ICommand PasteCommand => new Command(OnPasteClicked);

        private async void OnPasteClicked()
        {
            if (Clipboard.Default.HasText) { Search = await Clipboard.Default.GetTextAsync(); }
        }

        public ICommand SearchCommand => new Command(OnSearchClicked);


        public List<Validator> validatorsTemp = new List<Validator>();

        private async void OnSearchClicked()
        {
            if (Search != String.Empty)
            {
                DBSQLite database = new DBSQLite();
                try { validatorsTemp = database.QueryValidator().Result; }
                catch (Exception) { }

                Validators = new ObservableCollection<Validator>();

                foreach (var item in validatorsTemp)
                {
                    if (Search != null && item.Moniker == Search || item.Address == Search)
                    {
                        Validators.Add(item);

                        uint? latestBlock = await RPC.LatestBlock();

                        for (int i = 0; i < 10; i++)
                        {
                            var validatorSignatures = await RPC.ValidatorSignature(item.Address, latestBlock);

                            Validators.Last().ValidatorSignatures.Add(validatorSignatures);

                            latestBlock--;
                        }
                    }
                }
            }
        }

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

            // Здесь можно добавить другие действия при получении фокуса
        }

        // Метод вызываемый когда страница теряет фокус
        public void PageUnfocused()
        {
            IsPageFocused = false;
            // Здесь можно добавить другие действия при потере фокуса
        }

        #endregion

        #region Refreshing

        int itemCount = 10;
        const int MaximumItemCount = 50;
        const int PageSize = 10;
        const int RefreshDuration = 1;
        bool isRefreshing = false;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    OnPropertyChanged(nameof(IsRefreshing));
                }
            }
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());

        async Task RefreshDataAsync()
        {
            IsRefreshing = true;

            //await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));

            IsRefreshing = false;
        }

        #endregion

        public ObservableCollection<Validator> validators = new ObservableCollection<Validator>();

        public ObservableCollection<Validator> Validators
        {
            get { return validators; }
            set
            {
                if (validators == value) { return; }

                validators = value;

                OnPropertyChanged(nameof(Validators));
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

        public Command<Validator> ItemTapped { get; }

        public TrackViewModel()
        {
            //LoadingDatabase();

            ItemTapped = new Command<Validator>(OnItemSelected);
        }

        public async void LoadingDatabase()
        {
            //DBSQLite database = new DBSQLite();
            //try { Validators = database.QueryValidator().Result; }
            //catch (Exception) { }
        }

        private async void OnItemSelected(Validator validator)
        {
            if (validator == null)
                return;

            await Shell.Current.GoToAsync($"/{nameof(InfoValidatorsPage)}?{nameof(InfoValidatorsViewModel.Id)}={validator.Id}");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}