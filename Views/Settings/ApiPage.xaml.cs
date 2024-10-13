using Namada_Maui.ViewModels.Settings;

namespace Namada_Maui.Views.Settings;

public partial class ApiPage : ContentPage
{
	public ApiPage()
	{
		InitializeComponent();

        BindingContext = new ApiViewModel();
    }
}