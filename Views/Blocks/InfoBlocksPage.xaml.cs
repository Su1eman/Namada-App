using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Namada_Maui.ViewModels.Blocks;

namespace Namada_Maui.Views.Blocks;

public partial class InfoBlocksPage : ContentPage
{
	public InfoBlocksPage()
	{
		InitializeComponent();

        scrollView.Scrolled += ScrollView_Scrolled;

        BindingContext = new InfoBlocksViewModel();
    }

    private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        var scrollView = (ScrollView)sender;

        if (scrollView.ScrollY + scrollView.Height >= scrollView.ContentSize.Height)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            InfoBlocksViewModel viewModel = (InfoBlocksViewModel)BindingContext;

            if (viewModel.signatures.Count < viewModel.signaturesTemp.Count)
            {
                string text = "Loading";

                ToastDuration duration = ToastDuration.Short;

                double fontSize = 14;

                var toast = Toast.Make(text, duration, fontSize);

                await toast.Show(cancellationTokenSource.Token);

                viewModel.LoadMore();
            }

            //if (BindingContext is InfoBlocksViewModel viewModel)
            //{
            //    viewModel.LoadMore();
            //}

            ////// Вызываем ваш метод для загрузки дополнительных данных
            //((InfoBlocksViewModel)BindingContext).LoadMore();
        }
    }
}