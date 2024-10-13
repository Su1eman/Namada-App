using Namada_Maui.ViewModels.Validators;

namespace Namada_Maui.Views.Validators;

public partial class InfoValidatorsPage : ContentPage
{
	public InfoValidatorsPage()
	{
		InitializeComponent();

        BindingContext = new InfoValidatorsViewModel();
    }
}