using ChristmasListUI_MAUI.Interfaces;
using ChristmasListUI_MAUI.Services;
using ChristmasListUI_MAUI.View_Models;
using System.Collections.ObjectModel;

namespace ChristmasListUI_MAUI;

public partial class WishlistPage : ContentPage
{
    public WishlistPage(WishlistViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}