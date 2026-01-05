using ChristmasListUI_MAUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ChristmasListUI_MAUI.View_Models;

public class MainPageViewModel : ViewModel
{
    private INavigationService _navigationService;

    public ICommand WishlistCommand { get; }
    public ICommand GiftListCommand { get; }

    public MainPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        WishlistCommand = new Command(() => _navigationService.GoToWishlistPage());

        GiftListCommand = new Command(() => _navigationService.GoToGiftListPage());
    }
}
