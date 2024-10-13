using Namada_Maui.ViewModels.Validators;

namespace Namada_Maui.Views.Validators;

public partial class ValidatorsPage : ContentPage
{
    public ValidatorsPage()
    {
        InitializeComponent();

        BindingContext = new ValidatorsViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ValidatorsViewModel viewModel)
        {
            viewModel.PageFocused();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is ValidatorsViewModel viewModel)
        {
            viewModel.PageUnfocused();
        }
    }
}