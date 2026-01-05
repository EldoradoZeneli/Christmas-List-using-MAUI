using ChristmasListBL.Model;
using ChristmasListUI_MAUI.Interfaces;
using ChristmasListUI_MAUI.View_Models;
using ChristmasListUI_MAUI.View_Models.Gift_List_View_Models;
using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasListUI_MAUI.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoToWishlistPage()
        {
            await Shell.Current.GoToAsync(nameof(WishlistPage));
        }
        public async Task GoToWishItemDetailPage(WishlistItemViewModel? item)
        {
            if (item is not null)
            {
                var navParams = new Dictionary<string, object>
                {
                    { "Item", item }
                };

                await Shell.Current.GoToAsync(nameof(WishItemDetailPage), navParams);
                return;
            }

            await Shell.Current.GoToAsync(nameof(WishItemDetailPage));
        }

        public async Task GoToGiftListPage()
        {
            await Shell.Current.GoToAsync(nameof(GiftListPage));
        }        
        public async Task GoToGiftItemDetailPage(GiftListItemViewModel item)
        {
            var navParams = new Dictionary<string, object>
            {
                { "Item", item }
            };

            await Shell.Current.GoToAsync(nameof(GiftItemDetailPage), navParams);
        }


        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
