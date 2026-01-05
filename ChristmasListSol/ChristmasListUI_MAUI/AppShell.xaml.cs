namespace ChristmasListUI_MAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(WishlistPage), typeof(WishlistPage));
        Routing.RegisterRoute(nameof(WishItemDetailPage), typeof(WishItemDetailPage));

        Routing.RegisterRoute(nameof(GiftListPage), typeof(GiftListPage));
        Routing.RegisterRoute(nameof(GiftItemDetailPage), typeof(GiftItemDetailPage));
    }
}
