using Namada_Maui.Models.Settings;
using Namada_Maui.Repository.Database;
using Namada_Maui.Views.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.ViewModels.Settings
{
    public class SettingViewModel : INotifyPropertyChanged
    {
        public AppConfig appConfig = new AppConfig();

        private string language;

        private string theme;

        public string Language
        {
            get { return language; }
            set
            {
                if (language != value)
                {
                    language = value;

                    OnPropertyChanged(nameof(Language));
                }
            }
        }

        public string Theme
        {
            get { return theme; }
            set
            {
                if (theme != value)
                {
                    theme = value;

                    OnPropertyChanged(nameof(Theme));
                }
            }
        }

        public string AppVersion { get; set; } = AppInfo.VersionString;

        public string AppBuild { get; set; } = AppInfo.BuildString;

        // Метод вызываемый когда страница получает фокус
        public void PageFocused()
        {
            LoadingAppConfig();

            // Здесь можно добавить другие действия при получении фокуса
        }

        #region Command

        public Command ApiCommand { get; }

        public Command LocalizationCommand { get; }

        public Command ThemeCommand { get; }

        public Command WriteReviewCommand { get; }

        public Command PutRatingCommand { get; }

        public Command ShareWithFriendsCommand { get; }

        public Command WriteDeveloperCommand { get; }

        public Command PrivacyPolicyCommand { get; }

        #endregion

        public SettingViewModel()
        {
            //LoadingAppConfig();

            ApiCommand = new Command(OnApiClicked);

            LocalizationCommand = new Command(OnLocalizationClicked);

            ThemeCommand = new Command(OnThemeClicked);

            WriteReviewCommand = new Command(OnWriteReviewClicked);

            PutRatingCommand = new Command(OnPutRatingClicked);

            ShareWithFriendsCommand = new Command(OnShareWithFriendsClicked);

            WriteDeveloperCommand = new Command(OnWriteDeveloperClicked);

            PrivacyPolicyCommand = new Command(OnPrivacyPolicyClicked);
        }

        public async void LoadingAppConfig()
        {
            DBSQLite database = new DBSQLite();

            try { appConfig = database.QueryAppConfig(100).Result; }
            catch (Exception) { }

            if (appConfig == null)
            {
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

            Language = appConfig.Language;

            #endregion

            #region Theme

            Theme = appConfig.Theme.ToString();

            #endregion
        }

        #region Command

        private async void OnApiClicked(object obj)
        {
            await Shell.Current.GoToAsync($"/{nameof(ApiPage)}");
        }

        private async void OnLocalizationClicked(object obj)
        {
            await Shell.Current.GoToAsync($"/{nameof(LocalizationPage)}");
        }

        private async void OnThemeClicked(object obj)
        {
            await Shell.Current.GoToAsync($"/{nameof(ThemePage)}");
        }

        private void OnWriteReviewClicked(object obj)
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                Launcher.OpenAsync("market://details?id=" + AppInfo.PackageName);
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
            {
                Launcher.OpenAsync("https://apps.apple.com/app/" + AppInfo.PackageName);
            }
            else
            {

            }
        }

        private void OnPutRatingClicked(object obj)
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                Launcher.OpenAsync("market://details?id=" + AppInfo.PackageName);
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
            {
                Launcher.OpenAsync("https://apps.apple.com/app/" + AppInfo.PackageName);
            }
            else
            {

            }
        }

        private void OnShareWithFriendsClicked(object obj)
        {
            string subject = AppInfo.Name;
            string text = AppInfo.Name;
            string uri = "market://details?id=" + AppInfo.PackageName;
            string title = "Поделиться через";

            Share.RequestAsync(new ShareTextRequest
            {
                Subject = subject,
                Text = text,
                Uri = uri,
                Title = title
            });
        }

        private void OnWriteDeveloperClicked(object obj)
        {
            #region AppInfo

            //  App Info:

            string AppName = AppInfo.Name;
            string AppPackageName = AppInfo.PackageName;
            string AppTheme = AppInfo.RequestedTheme.ToString();

            //  Version Info:

            string AppVersion = AppInfo.VersionString;
            string AppBuild = AppInfo.BuildString;

            #endregion

            #region DeviceInfo

            //  Device Info:

            string Model = DeviceInfo.Model;
            string Manufacturer = DeviceInfo.Manufacturer;
            string Name = DeviceInfo.Name;
            string VersionString = DeviceInfo.VersionString;
            string Version = DeviceInfo.Version.ToString();
            DevicePlatform Platform = DeviceInfo.Platform;
            DeviceIdiom Idiom = DeviceInfo.Idiom;
            DeviceType DeviceType = DeviceInfo.DeviceType;

            #endregion

            #region Email

            //  Launcher.OpenAsync("mailto:");

            List<string> Split(string recipients) => recipients?.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)?.ToList();

            string subject = "Hello World!";                                    // Заголовок
            string body = "This is the email body.\nWe hope you like it!";      // Текст письма

            string recipientsTo = "vitalii.dreov@gmail.com";                    // Кому
            string recipientsCc = null;                                         // Копия
            string recipientsBcc = null;                                        // Скрытая

            bool attachmentFile = false;                                        //
            string attachmentContents = null;                                   //
            string attachmentName = null;                                       //

            bool isHtml = false;                                                // это HTML

            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                BodyFormat = isHtml ? EmailBodyFormat.Html : EmailBodyFormat.PlainText,
                To = Split(recipientsTo),
                Cc = Split(recipientsCc),
                Bcc = Split(recipientsBcc),
            };

            if (attachmentFile)
            {
                if (!string.IsNullOrWhiteSpace(attachmentName) || !string.IsNullOrWhiteSpace(attachmentContents))
                {
                    var fn = string.IsNullOrWhiteSpace(attachmentName) ? "Attachment.txt" : attachmentName.Trim();

                    var file = Path.Combine(FileSystem.CacheDirectory, fn);

                    File.WriteAllText(file, attachmentContents);

                    message.Attachments.Add(new EmailAttachment(file));
                }
            }

            Email.ComposeAsync(message);

            #endregion
        }

        private void OnPrivacyPolicyClicked(object obj)
        {
            Uri uri = new Uri("https://docs.google.com/document/d/1xh_4Pz37A6YPXl82k50UTsLc4r8VjKdnsRTTNcYdo5Q/edit?usp=sharing");

            BrowserLaunchOptions options = new BrowserLaunchOptions()
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.FromUint(0xFF121212),
                PreferredControlColor = Colors.White
            };

            Browser.Default.OpenAsync(uri, options);

            //Launcher.OpenAsync("https://docs.google.com/document/d/1i_1pOIjbGMbOiwrDMpuuiLP3gtYNq1TtVOIQS7DE2Sc/edit?usp=drive_link");
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}