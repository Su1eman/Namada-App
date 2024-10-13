using Namada_Maui.Models.Blocks;
using Namada_Maui.Models.Overviews;
using Namada_Maui.Models.Settings;
using Namada_Maui.Models.Validators;
using Namada_Maui.Repository.Database;
using Newtonsoft.Json.Linq;
using Plugin.LocalNotification.iOSOption;
using Plugin.LocalNotification;
using System.Diagnostics;
using System.Globalization;

namespace Namada_Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            LoadingAppConfig();
        }

        //private System.Timers.Timer timer;

        //private void StartTimer()
        //{
        //    // Создаем новый таймер
        //    timer = new System.Timers.Timer();

        //    // Устанавливаем интервал выполнения в миллисекундах (например, 10 минут)
        //    timer.Interval = TimeSpan.FromMinutes(10).TotalMilliseconds;

        //    // Устанавливаем обработчик события таймера
        //    timer.Elapsed += Timer_Elapsed;

        //    // Запускаем таймер
        //    timer.Start();
        //}

        //private void StopTimer()
        //{
        //    // Останавливаем таймер
        //    timer?.Stop();
        //}

        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    // Обработка события истечения времени таймера
        //    // В этом методе можно выполнять необходимые действия, например, отправлять уведомления
        //    // Обратите внимание, что этот метод будет вызываться в потоке таймера, так что при необходимости
        //    // обновления пользовательского интерфейса необходимо использовать Dispatcher
        //    Console.WriteLine("Timer elapsed. Perform your action here.");
        //}













        protected override void OnStart()
        {
            // Выполнить действия при запуске приложения

            Loading();

            LoadingValidators();

            //StopTimer();
        }

        protected async override void OnSleep()
        {
            // Выполнить действия при сворачивании приложения

            //if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            //{
            //    await LocalNotificationCenter.Current.RequestNotificationPermission();
            //}


            //if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            //{
            //    await LocalNotificationCenter.Current.RequestNotificationPermission(new NotificationPermission
            //    {
            //        IOS = { LocationAuthorization = iOSLocationAuthorization.WhenInUse }
            //    });
            //}

            //var request = new NotificationRequest
            //{
            //    NotificationId = 1337,
            //    Title = "111",
            //    Subtitle = "111",
            //    Description = "111",
            //    BadgeNumber = 1,
            //    Schedule = new NotificationRequestSchedule
            //    {
            //        NotifyTime = DateTime.Now.AddSeconds(2),
            //        NotifyRepeatInterval = TimeSpan.FromSeconds(2),
            //    },
            //    Android = new Plugin.LocalNotification.AndroidOption.AndroidOptions
            //    {

            //    },
            //    iOS = new Plugin.LocalNotification.iOSOption.iOSOptions
            //    {

            //    }

            //};

            //await LocalNotificationCenter.Current.Show(request);

            //StartTimer();
        }

        protected override void OnResume()
        {
            // Выполнить действия при возвращении в приложение

            //StartTimer();
        }


        #region Overview

        public async void Loading()
        {
            Overview? overviewCloud = await RPC.Overview();

            List<Block> blocks = await RPC.TopBlocks();

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
            }
            else
            {
            }



            //#region Overview

            //uint latestBlock = default;

            //string content;

            //Uri overviewUri = new Uri("https://namadexer.palamar.io/block/last");

            //HttpClient client = new HttpClient();

            //try
            //{
            //    HttpResponseMessage response = await client.GetAsync(overviewUri);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        content = await response.Content.ReadAsStringAsync();

            //        JObject jsonObject = JObject.Parse(content);

            //        var ordersArray = jsonObject["header"];

            //        latestBlock = (uint)ordersArray["height"];
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

            //#endregion

            //#region Block

            //if (latestBlock != 0)
            //{
            //    Block? block = null;

            //    DBSQLite database = new DBSQLite();

            //    try { block = database.QueryFirstBlock().Result; }
            //    catch (Exception) { }

            //    try
            //    {
            //        int count = database.QueryBlockCount().Result;

            //        if (count > 50)
            //        {
            //            try { await database.DeleteAllBlock(); }
            //            catch (Exception) { }
            //        }
            //    }
            //    catch (Exception) { }

            //    //uint minRecord = block != null ? block.Height : latestBlock - 10;

            //    ushort maxRecords = 6;

            //    uint minRecord;

            //    if (block != null)
            //    {
            //        if (latestBlock <= (block.Height + maxRecords))
            //        {
            //            minRecord = block.Height;
            //        }
            //        else
            //        {
            //            minRecord = latestBlock - maxRecords;
            //        }
            //    }
            //    else
            //    {
            //        minRecord = latestBlock - maxRecords;
            //    }

            //    Uri blocksUri = new Uri("https://namadexer.palamar.io/block/height/");

            //    for (uint i = minRecord; i <= latestBlock; i++)
            //    {
            //        try
            //        {
            //            HttpResponseMessage response = await client.GetAsync(blocksUri.ToString() + i);

            //            if (response.IsSuccessStatusCode)
            //            {
            //                content = await response.Content.ReadAsStringAsync();

            //                JObject jsonObject = JObject.Parse(content);

            //                var ordersArray = jsonObject["header"];

            //                Block blockTemp = new Block()
            //                {
            //                    Height = (uint)ordersArray["height"],
            //                    Proposer = (string)ordersArray["proposer_address"],
            //                    Time = (DateTime)ordersArray["time"],
            //                    Hash = (string)ordersArray["data_hash"],
            //                };

            //                database.InsertBlock(blockTemp);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //        }
            //    }

            //    client.Dispose();
            //}

            //#endregion
        }

        #endregion

        #region Validator

        public async void LoadingValidators()
        {
            await RPC.Validators();

            //List<Validator> validators = new List<Validator>();

            //await Task.Run(async () =>
            //{
            //    string content;

            //    Uri validatorsUri = new Uri("https://namada-explorer-api.stakepool.dev.br/node/validators/list");

            //    HttpClientHandler handler = new HttpClientHandler();

            //    handler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssPolicyError) =>
            //    {
            //        return true;
            //    };

            //    HttpClient client = new HttpClient(handler);

            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync(validatorsUri);

            //        if (response.IsSuccessStatusCode)
            //        {
            //            content = await response.Content.ReadAsStringAsync();

            //            JObject jsonObject = JObject.Parse(content);

            //            validators = jsonObject["currentValidatorsList"].ToObject<List<Validator>>();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //    }

            //    client.Dispose();
            //});

            //DBSQLite database = new DBSQLite();

            //try { await database.DeleteAllValidator(); }
            //catch (Exception) { }

            //try { await database.InsertAllValidator(validators); }
            //catch (Exception) { }
        }

        #endregion

        #region AppConfig

        public async void LoadingAppConfig()
        {
            DBSQLite database = new DBSQLite();

            AppConfig appConfig = null;

            try
            {
                appConfig = database.QueryAppConfig(100).Result;
            }
            catch (Exception) { }

            if (appConfig == null)
            {
                #region Language

                string currentLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;       // Получить текущий язык (например, "en" или "fr")
                //string currentRegion = RegionInfo.CurrentRegion.TwoLetterISORegionName;           // Получить текущий регион (например, "US" или "FR")
                //string currentLocalization = CultureInfo.CurrentCulture.Name;

                #endregion

                appConfig = new AppConfig()
                {
                    Id = 100,
                    Language = "en",
                    Theme = 0,
                    Version = 0
                };

                try { database.InsertAppConfig(appConfig); }
                catch (Exception) { }
            }

            #region Localization

            var cultureInfo = new CultureInfo(appConfig.Language ?? "en");

            Thread.CurrentThread.CurrentCulture = cultureInfo;

            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            #endregion

            #region Theme

            switch (appConfig.Theme)
            {
                case 0:
                    ThemeManager.SetAppTheme(Theme.Default);
                    break;
                case 1:
                    ThemeManager.SetAppTheme(Theme.Light);
                    break;
                case 2:
                    ThemeManager.SetAppTheme(Theme.Dark);
                    break;
            }

            #endregion
        }

        #endregion
    }
}