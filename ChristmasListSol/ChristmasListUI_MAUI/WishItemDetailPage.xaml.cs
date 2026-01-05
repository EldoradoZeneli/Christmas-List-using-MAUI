using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;

namespace ChristmasListUI_MAUI;

public partial class WishItemDetailPage : ContentPage
{
	public WishItemDetailPage(WishDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}