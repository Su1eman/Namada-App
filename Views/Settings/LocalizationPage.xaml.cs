using Namada_Maui.ViewModels.Settings;

namespace Namada_Maui.Views.Settings;

public partial class LocalizationPage : ContentPage
{
    /// <summary>
    /// 
    ///     "en-US" ��� ����������� ����� � ���.
    ///     "ru-RU" ��� �������� ����� � ������.
    ///     "uk-UA" (����������, �������).
    ///     "de-DE" (��������, ��������)
    ///     
    /// </summary>
    public LocalizationPage()
    {
        InitializeComponent();

        BindingContext = new LocalizationViewModel();
    }
}