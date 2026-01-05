using ChristmasListBL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;

public class WishlistItemViewModel : ViewModel
{
    public int Id { get; set; }

    private string _title = string.Empty;
    private string? _description;
    private string? _imageUrl;
    private string _websiteUrl = string.Empty;

    public string Title
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }
    public string? Description
    {
        get => _description;
        set { _description = value; OnPropertyChanged(); }
    }

    public string? ImageUrl
    {
        get => _imageUrl;
        set { _imageUrl = value; OnPropertyChanged(); }
    }

    public string WebsiteUrl
    {
        get => _websiteUrl;
        set { _websiteUrl = value; OnPropertyChanged(); }
    }

    public bool saveableState
    {
        get => !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(WebsiteUrl);
    }

    public WishlistItemViewModel()
    {
        Id = 0;
    }

    public static WishlistItemViewModel FromModel(WishItem model)
    {
        return new WishlistItemViewModel
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            WebsiteUrl = model.WebsiteUrl
        };
    }
}
