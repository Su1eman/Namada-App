using Namada_Maui.Models.Settings;
using Namada_Maui.Repository.Database;
using Namada_Maui.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.ViewModels.Settings
{
    public class Theme : INotifyPropertyChanged
    {
        private byte id;
        private string? name;
        private bool isSelect;

        public byte Id
        {
            get { return id; }
            set { id = value; }
        }

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsSelect
        {
            get => isSelect; set
            {
                if (isSelect == value) { return; }

                isSelect = value;

                OnPropertyChanged(nameof(IsSelect));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ThemeViewModel
    {
        private AppConfig appConfig;

        private List<Theme> themes = new List<Theme>()
        {
            new Theme(){ Id = 0, Name = "Default" },
            new Theme(){ Id = 1, Name = "Light" },
            new Theme(){ Id = 2, Name = "Dark" },
        };

        public List<Theme> Themes
        {
            get { return themes; }
            set { themes = value; }
        }

        #region Command

        public Command<Theme> ItemTapped { get; }

        #endregion

        public ThemeViewModel()
        {
            DBSQLite database = new DBSQLite();

            appConfig = new AppConfig();

            try
            {
                appConfig = database.QueryAppConfig(100).Result;
            }
            catch (Exception) { }

            themes[appConfig.Theme].IsSelect = true;

            ItemTapped = new Command<Theme>(OnItemSelected);
        }

        #region Command

        private void OnItemSelected(Theme theme)
        {
            if (theme == null)
                return;

            switch (theme.Id)
            {
                case 0:
                    ThemeManager.SetAppTheme(Models.Settings.Theme.Default);
                    break;
                case 1:
                    ThemeManager.SetAppTheme(Models.Settings.Theme.Light);
                    break;
                case 2:
                    ThemeManager.SetAppTheme(Models.Settings.Theme.Dark);
                    break;
            }

            themes[appConfig.Theme].IsSelect = false;

            appConfig.Theme = theme.Id;

            theme.IsSelect = true;

            DBSQLite database = new DBSQLite();

            try { database.UpdateAppConfig(appConfig); }

            catch (Exception) { }
        }

        #endregion
    }
}