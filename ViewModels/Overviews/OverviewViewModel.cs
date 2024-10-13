using Namada_Maui.Models.Blocks;
using Namada_Maui.Models.Overviews;
using Namada_Maui.Models.Validators;
using Namada_Maui.Repository.Database;
using Namada_Maui.ViewModels.Validators;
using Namada_Maui.Views.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Namada_Maui.ViewModels.Overviews
{
    public class OverviewViewModel : INotifyPropertyChanged
    {
        private int indexMin = default;

        private int indexMax = default;

        private int firstSize = 10;

        private int size = 1;

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

            LoadingOverview();
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

            LoadingOverview();

            //LoadingDatabase();

            IsRefreshing = false;

            return Task.CompletedTask;
        }

        #endregion

        private Overview overview;

        public Overview Overview
        {
            get { return overview; }
            set
            {
                if (overview == value) { return; }

                overview = value;

                OnPropertyChanged(nameof(Overview));
            }
        }


        private List<Validator> validators = new List<Validator>();

        public List<Validator> Validators
        {
            get { return validators; }
            set
            {
                if (validators == value) { return; }
                validators = value;
                OnPropertyChanged(nameof(Validators));
            }
        }

        public Command<Validator> ValidatorTapped { get; }


        private List<Block> blocks = new List<Block>();

        public List<Block> Blocks
        {
            get { return blocks; }
            set
            {
                if (blocks == value) { return; }
                blocks = value;
                OnPropertyChanged(nameof(Blocks));
            }
        }

        public Command<Block> BlockTapped { get; }

        public ICommand SelectTargetsCommand => new Command(OnSelectTargetsClicked);

        private void OnSelectTargetsClicked()
        {
        }

        public OverviewViewModel()
        {
            LoadingDatabase();

            ValidatorTapped = new Command<Validator>(OnValidatorSelected);

            BlockTapped = new Command<Block>(OnBlockSelected);
        }


        public void LoadInitialData()
        {
            //indexMax = firstSize < signaturesTemp.Count ? firstSize : signaturesTemp.Count;

            //while (indexMin < indexMax)
            //{
            //    Signatures.Add(signaturesTemp[indexMin]);
            //    indexMin++;
            //}
        }

        public void LoadMore()
        {
            //indexMax = indexMax + size < signaturesTemp.Count ? indexMax + size : signaturesTemp.Count;

            //while (indexMin < indexMax)
            //{
            //    Signatures.Add(signaturesTemp[indexMin]);
            //    indexMin++;
            //}
        }

        public async void LoadingDatabase()
        {
            Validators = await RPC.TopValidators();

            Blocks = await RPC.TopBlocks();
        }

        public async void LoadingOverview()
        {
            Overview? overviewCloud = await RPC.Overview();

            Blocks = await RPC.TopBlocks();

            Overview? overviewLocal = null;

            DBSQLite database = new DBSQLite();

            try
            {
                overviewLocal = database.QueryOverview(100).Result;
            }
            catch (Exception) { }

            if (overviewCloud != null)
            {
                if (overviewLocal == null)
                {
                    overviewCloud.Id = 100;
                    await database.InsertOverview(overviewCloud);
                }
                else
                {
                    if (overviewCloud.LatestBlock > overviewLocal.LatestBlock)
                    {
                        await database.UpdateOverview(overviewCloud);
                    }
                }

                Overview = overviewCloud;
            }
            else
            {
                Overview = overviewLocal;
            }
        }

        private async void OnValidatorSelected(Validator validator)
        {
            if (validator == null)
                return;

            await Shell.Current.GoToAsync($"/{nameof(InfoValidatorsPage)}?{nameof(InfoValidatorsViewModel.Id)}={validator.Id}");
        }

        private async void OnBlockSelected(Block block)
        {
            if (block == null)
                return;

            //await Shell.Current.GoToAsync($"/{nameof(InfoBlocksPage)}?{nameof(InfoBlocksViewModel.Id)}={block.Id}");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}