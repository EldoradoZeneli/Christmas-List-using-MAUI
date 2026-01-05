using ChristmasListBL.Interfaces;
using ChristmasListBL.Model;
using ChristmasListUI_MAUI.Interfaces;
using ChristmasListUI_MAUI.Services;
using ChristmasListUI_MAUI.View_Models;
using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace ChristmasListUI_MAUI.View_Models;

public class WishlistViewModel : ViewModel
{
    private INavigationService _navigationService;
    private IChristmasManager _manager;

    public ICommand NewItemCommand { get; }
    public ICommand RefreshCommand { get; }

    private ObservableCollection<WishlistItemViewModel> _wishlistItems;

    public ObservableCollection<WishlistItemViewModel> WishlistItems
    {
        get => _wishlistItems;
        set { _wishlistItems = value; OnPropertyChanged(); }
    }

    private WishlistItemViewModel? _selectedWishItem;

    public WishlistItemViewModel? SelectedWishItem
    {
        get => _selectedWishItem;
        set 
        { 
            _selectedWishItem = value; 
            OnPropertyChanged();
            _navigationService.GoToWishItemDetailPage(value);

            //Clearing selection afterwards
            _selectedWishItem = null;
            OnPropertyChanged();
        }
    }


    public WishlistViewModel(INavigationService navigationService, IChristmasManager manager)
    {
        _navigationService = navigationService;
        _manager = manager;

        NewItemCommand = new Command(() => _navigationService.GoToWishItemDetailPage(null));
        WishlistItems = GetItems();
    }

    public ObservableCollection<WishlistItemViewModel> GetItems()
    {
        return new ObservableCollection<WishlistItemViewModel>(Mapper.MapWishItemsToViewModel(_manager.GetWishItems()));
    }
}
