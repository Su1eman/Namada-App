using Namada_Maui.ViewModels.Settings;

namespace Namada_Maui.Views.Settings;

public partial class ThemePage : ContentPage
{
	public ThemePage()
	{
		InitializeComponent();

        BindingContext = new ThemeViewModel();
    }
}