using ChristmasListBL.Model;
using ChristmasListUI_MAUI.View_Models.Gift_List_View_Models;
using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChristmasListUI_MAUI.Services;

public static class Mapper
{
    public static ObservableCollection<WishlistItemViewModel> MapWishItemsToViewModel(IEnumerable<WishItem> item)
    {
        ObservableCollection<WishlistItemViewModel> wishlistItems = [];
        foreach (var i in item)
        {
            var WishItemVm = new WishlistItemViewModel()
            {
                Title = i.Title,
                Description = i.Description,
                ImageUrl = i.ImageUrl,
                WebsiteUrl = i.WebsiteUrl
            };

            wishlistItems.Add(WishItemVm);
        }
        return wishlistItems;
    }

    public static ObservableCollection<GiftListItemViewModel> MapGiftItemsToViewModel(IEnumerable<GiftItem> item)
    {
        ObservableCollection<GiftListItemViewModel> giftListItems = [];
        foreach (var i in item)
        {
            var giftItemVm = new GiftListItemViewModel()
            {
                Title = i.Title,
                Price = i.Price,
                Description = i.Description,
                ImageUrl = i.ImageUrl,

            };

            giftListItems.Add(giftItemVm);
        }
        return giftListItems;
    }
}
