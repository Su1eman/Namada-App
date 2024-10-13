using Namada_Maui.ViewModels.Tracks;

namespace Namada_Maui.Views.Tracks;

public partial class TrackPage : ContentPage
{
	public TrackPage()
	{
		InitializeComponent();

        BindingContext = new TrackViewModel();
    }
}