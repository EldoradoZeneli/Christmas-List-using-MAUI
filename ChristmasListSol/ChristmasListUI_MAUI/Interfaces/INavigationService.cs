using ChristmasListBL.Model;
using ChristmasListUI_MAUI.View_Models;
using ChristmasListUI_MAUI.View_Models.Gift_List_View_Models;
using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListUI_MAUI.Interfaces
{
    public interface INavigationService
    {
        Task GoToWishlistPage();
        Task GoToWishItemDetailPage(WishlistItemViewModel? item);

        Task GoToGiftListPage();
        Task GoToGiftItemDetailPage(GiftListItemViewModel item);

        Task GoBack();
    }
}
