using Namada_Maui.ViewModels.Settings;

namespace Namada_Maui.Views.Settings;

public partial class LocalizationPage : ContentPage
{
    /// <summary>
    /// 
    ///     "en-US" для английского языка в США.
    ///     "ru-RU" для русского языка в России.
    ///     "uk-UA" (украинский, Украина).
    ///     "de-DE" (немецкий, Германия)
    ///     
    /// </summary>
    public LocalizationPage()
    {
        InitializeComponent();

        BindingContext = new LocalizationViewModel();
    }
}