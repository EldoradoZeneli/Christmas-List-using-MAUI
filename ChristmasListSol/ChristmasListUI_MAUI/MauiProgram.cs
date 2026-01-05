using ChristmasListBL.Interfaces;
using ChristmasListBL.Services;
using ChristmasListDL;
using ChristmasListUI_MAUI.Interfaces;
using ChristmasListUI_MAUI.Services;
using ChristmasListUI_MAUI.View_Models;
using ChristmasListUI_MAUI.View_Models.Gift_List_View_Models;
using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;
using Microsoft.Extensions.Logging;

namespace ChristmasListUI_MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        
        var connectionString = @"Data Source=ELEG5\SQLEXPRESS01;Initial Catalog=ChristmaslistDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        builder.Services.AddTransient<IChristmaslistRepository>(sp => new ChristmaslistRepository(connectionString));

        // ViewModels
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<WishlistViewModel>();
        builder.Services.AddTransient<WishDetailViewModel>();
        builder.Services.AddTransient<GiftListViewModel>();
        builder.Services.AddTransient<GiftItemDetailViewModel>();

        //Services
        builder.Services.AddTransient<INavigationService, NavigationService>();
        builder.Services.AddTransient<IChristmasManager, ChristmasManager>();

        // Pages
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<WishlistPage>();
        builder.Services.AddTransient<WishItemDetailPage>();
        builder.Services.AddTransient<GiftListPage>();
        builder.Services.AddTransient<GiftItemDetailPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
