using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Namada_Maui.ViewModels.Overviews;

namespace Namada_Maui.Views.Overviews;

public partial class OverviewPage : ContentPage
{
    public OverviewPage()
    {
        InitializeComponent();

        scrollView.Scrolled += ScrollView_Scrolled;

        BindingContext = new OverviewViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is OverviewViewModel viewModel)
        {
            viewModel.PageFocused();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is OverviewViewModel viewModel)
        {
            viewModel.PageUnfocused();
        }
    }

    private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        var scrollView = (ScrollView)sender;

        if (scrollView.ScrollY + scrollView.Height >= scrollView.ContentSize.Height)
        {
            OverviewViewModel viewModel = (OverviewViewModel)BindingContext;

            viewModel.LoadMore();
        }
    }
}