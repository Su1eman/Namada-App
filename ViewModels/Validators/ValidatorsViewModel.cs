using Namada_Maui.Models.Validators;
using Namada_Maui.Repository.Database;
using Namada_Maui.Views.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Namada_Maui.ViewModels.Validators
{
    public class ValidatorsViewModel : INotifyPropertyChanged
    {
        private int indexMin = default;

        private int indexMax = default;

        private int firstSize = 20;

        private int size = 10;





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
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());

        public Command<Validator> ItemTapped { get; }

        public ICommand LoadMoreCommand => new Command(LoadMore);

        public async Task RefreshDataAsync()
        {
            IsRefreshing = true;

            LoadingValidators();

            IsRefreshing = false;
        }

        public List<Validator> validators = new List<Validator>();

        public List<Validator> Validators
        {
            get { return validators; }
            set
            {
                if (validators == value) { return; }
                validators = value;
                IsRefreshing = false;
                OnPropertyChanged(nameof(Validators));
            }
        }

        public ValidatorsViewModel()
        {
            LoadInitialData();

            LoadingValidators();

            ItemTapped = new Command<Validator>(OnItemSelected);
        }

        private void LoadInitialData()
        {
            // Load initial data here
            // For example:
            //for (int i = 0; i < 10; i++)
            //{
            //    Items.Add(new object()); // Add your actual items here
            //}
        }

        private void LoadMore()
        {
            // Load more data when remaining items threshold reached
            // For example:
            //for (int i = 0; i < 5; i++)
            //{
            //    Items.Add(new object()); // Add your actual items here
            //}
        }

        public async void LoadingDatabase()
        {
            DBSQLite database = new DBSQLite();
            try { Validators = database.QueryValidator().Result; }
            catch (Exception) { }
        }

        public async void LoadingValidators()
        {
            Validators = await RPC.Validators();
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