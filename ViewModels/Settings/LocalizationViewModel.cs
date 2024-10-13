using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.ViewModels.Settings
{
    /// <summary>
    /// 
    ///     "en-US" для английского языка в США.
    ///     "ru-RU" для русского языка в России.
    ///     "uk-UA" (украинский, Украина).
    ///     "de-DE" (немецкий, Германия)
    ///     
    /// </summary>

    public class Localization : INotifyPropertyChanged
    {
        private ushort id;
        private string name;
        private string code;
        private bool isSelect;

        public ushort Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
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

    public class LocalizationViewModel : BaseViewModel
    {
        #region Command

        public Command<Localization> ItemTapped { get; }

        #endregion

        private List<Localization> localizations = new List<Localization>()
        {
            new Localization(){ Id = 0, Name = "English", Code = "en", IsSelect = true },
            //new Localization(){ Id = 1, Name = "Русский", Code = "ru", IsSelect = false },
        };

        public List<Localization> Localizations
        {
            get { return localizations; }
            set { localizations = value; }
        }

        public LocalizationViewModel()
        {
            //localizations[AppConfig.Language].IsSelect = true;

            ItemTapped = new Command<Localization>(OnItemSelected);
        }

        #region Command

        private void OnItemSelected(Localization localization)
        {
            if (localization == null)
                return;

            var cultureInfo = new CultureInfo(localization.Code);

            Thread.CurrentThread.CurrentCulture = cultureInfo;

            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Application.Current.MainPage = new AppShell();
        }

        #endregion
    }
}