using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Namada_Maui.ViewModels.Settings
{
    public class ApiViewModel : INotifyPropertyChanged
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

                    if (search == String.Empty) { IsVisibleTrash = false; }
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

        private async void OnSearchClicked()
        {
            //if (Search != String.Empty)
            //{
            //    DBSQLite database = new DBSQLite();
            //    try { validatorsTemp = database.QueryValidator().Result; }
            //    catch (Exception) { }

            //    Validators = new ObservableCollection<Validator>();

            //    foreach (var item in validatorsTemp)
            //    {
            //        if (item.Moniker == Search || item.Address == Search)
            //        {
            //            Validators.Add(item);
            //        }
            //    }
            //}
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
                isRefreshing = value;

                OnPropertyChanged(nameof(IsRefreshing));
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}