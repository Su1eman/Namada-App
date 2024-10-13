using Namada_Maui.ViewModels.Settings;

namespace Namada_Maui.Views.Settings;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();

        BindingContext = new SettingViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is SettingViewModel viewModel)
        {
            viewModel.PageFocused();
        }
    }
}