using Namada_Maui.Models.Blocks;
using Namada_Maui.Repository.Database;
using Namada_Maui.Views.Blocks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Namada_Maui.ViewModels.Blocks
{
    public class BlocksViewModel : INotifyPropertyChanged
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

            LoadingDatabase();

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

            LoadingDatabase();

            //await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));

            IsRefreshing = false;
        }

        #endregion

        public ICommand LoadMoreCommand { get; }

        public Command<Block> ItemTapped { get; }


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

        public BlocksViewModel()
        {
            LoadInitialData();

            LoadMoreCommand = new Command(LoadMore);

            LoadingDatabase();

            ItemTapped = new Command<Block>(OnItemSelected);
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

            try { Blocks = (database.QueryBlock().Result).OrderByDescending(i => i.Height).ToList(); }
            catch (Exception) { }

            Blocks.AddRange(await RPC.Blocks());

            //await Device.InvokeOnMainThreadAsync(async () =>
            //{
            //    // Убеждаемся, что вызываем это из основного потока UI
            //    // Обновляем коллекцию, чтобы отобразить новые элементы
            //    
            //});



            //DBSQLite database = new DBSQLite();
            //try { blocks = (database.QueryBlock().Result).OrderByDescending(i => i.Height).ToList(); }
            //catch (Exception) { }
        }

        //public async void LoadingBlocks()
        //{
        //    #region Overview

        //    uint latestBlock = default;

        //    string content;

        //    Uri overviewUri = new Uri("https://namadexer.palamar.io/block/last");

        //    HttpClient client = new HttpClient();

        //    try
        //    {
        //        HttpResponseMessage response = await client.GetAsync(overviewUri);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            content = await response.Content.ReadAsStringAsync();

        //            JObject jsonObject = JObject.Parse(content);

        //            var ordersArray = jsonObject["header"];

        //            latestBlock = (uint)ordersArray["height"];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    #endregion

        //    #region Block

        //    if (latestBlock != 0)
        //    {
        //        Block? block = null;

        //        DBSQLite database = new DBSQLite();

        //        try { block = database.QueryFirstBlock().Result; }
        //        catch (Exception) { }

        //        //uint minRecord = block != null ? block.Height : latestBlock - 10;

        //        ushort maxRecords = 6;

        //        uint minRecord;

        //        if (block != null)
        //        {
        //            if (latestBlock <= (block.Height + maxRecords))
        //            {
        //                minRecord = block.Height;
        //            }
        //            else
        //            {
        //                minRecord = latestBlock - maxRecords;
        //            }
        //        }
        //        else
        //        {
        //            minRecord = latestBlock - maxRecords;
        //        }

        //        Uri blocksUri = new Uri("https://namadexer.palamar.io/block/height/");

        //        List<Block> blocksTemp = new List<Block>();

        //        for (uint i = minRecord; i <= latestBlock; i++)
        //        {
        //            try
        //            {
        //                HttpResponseMessage response = await client.GetAsync(blocksUri.ToString() + i);

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    content = await response.Content.ReadAsStringAsync();

        //                    JObject jsonObject = JObject.Parse(content);

        //                    var ordersArray = jsonObject["header"];

        //                    Block blockTemp = new Block()
        //                    {
        //                        Height = (uint)ordersArray["height"],
        //                        Proposer = (string)ordersArray["proposer_address"],
        //                        Time = (DateTime)ordersArray["time"],
        //                        Hash = (string)ordersArray["data_hash"],
        //                    };

        //                    database.InsertBlock(blockTemp);

        //                    blocksTemp.Add(blockTemp);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //            }
        //        }

        //        client.Dispose();

        //        Blocks = blocksTemp.OrderByDescending(i => i.Height).ToList();
        //    }

        //    #endregion
        //}

        private async void OnItemSelected(Block block)
        {
            if (block == null)
                return;

            await Shell.Current.GoToAsync($"/{nameof(InfoBlocksPage)}?{nameof(InfoBlocksViewModel.Id)}={block.Id}");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}