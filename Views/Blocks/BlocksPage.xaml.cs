using Namada_Maui.ViewModels.Blocks;

namespace Namada_Maui.Views.Blocks;

public partial class BlocksPage : ContentPage
{
    public BlocksPage()
    {
        InitializeComponent();

        BindingContext = new BlocksViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is BlocksViewModel viewModel)
        {
            viewModel.PageFocused();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is BlocksViewModel viewModel)
        {
            viewModel.PageUnfocused();
        }
    }
}