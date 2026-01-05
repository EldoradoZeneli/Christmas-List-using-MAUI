using ChristmasListUI_MAUI.View_Models.Gift_List_View_Models;

namespace ChristmasListUI_MAUI;

public partial class GiftListPage : ContentPage
{
	public GiftListPage(GiftListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}