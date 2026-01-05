using ChristmasListBL.Interfaces;
using ChristmasListUI_MAUI.Interfaces;
using ChristmasListUI_MAUI.Services;
using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ChristmasListUI_MAUI.View_Models.Gift_List_View_Models
{
    public class GiftListViewModel : ViewModel
    {
        private INavigationService _navigationService;
        private IChristmasManager _manager;

        public ICommand NewItemCommand { get; }

        private ObservableCollection<GiftListItemViewModel> _giftListItems;

        public ObservableCollection<GiftListItemViewModel> GiftListItems
        {
            get => _giftListItems;
            set { _giftListItems = value; OnPropertyChanged(); }
        }

        private GiftListItemViewModel? _selectedGiftItem;

        public GiftListItemViewModel? SelectedGiftItem
        {
            get => _selectedGiftItem;
            set
            {
                _selectedGiftItem = value;
                OnPropertyChanged();
                _navigationService.GoToGiftItemDetailPage(value);

                //Clearing selection afterwards
                _selectedGiftItem = null;
                OnPropertyChanged();
            }
        }

        public GiftListViewModel(INavigationService navigationService, IChristmasManager manager)
        {
            _navigationService = navigationService;
            _manager = manager;

            NewItemCommand = new Command(() => _navigationService.GoToWishItemDetailPage(null));
            GiftListItems = GetItems();
        }

        public ObservableCollection<GiftListItemViewModel> GetItems()
        {
            return new ObservableCollection<GiftListItemViewModel>(Mapper.MapGiftItemsToViewModel(_manager.GetGiftItems()));
        }
    }
}
