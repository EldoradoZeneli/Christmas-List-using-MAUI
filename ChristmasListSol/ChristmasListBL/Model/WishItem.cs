using ChristmasListBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListBL.Model;

public class WishItem
{
    private string _title;
    private string? _imageUrl;
    private string _websiteUrl;
    private string? _description;

    public int Id { get; set; }

    public string Title
    {
        get => _title;
        set
        {
            if(string.IsNullOrEmpty(value))
                throw new ChristmasException("Title cannot be null or empty.");
            _title = value;
        }
    }
    public string? ImageUrl
    {
        get => _imageUrl ?? string.Empty;
        set => _imageUrl = value;
    }

    public string WebsiteUrl
    {
        get => _websiteUrl;
        set
        {
            if(string.IsNullOrEmpty(value))
                throw new ChristmasException("Website URL cannot be null or empty.");
            _websiteUrl = value;
        }
    }

    public string? Description
    {
        get => _description ?? string.Empty;
        set => _description = value;
    }

    public WishItem()
    {
        Id = 0;
        _title = string.Empty;
        _websiteUrl = string.Empty;
        _imageUrl = null;
        _description = null;
    }
    public WishItem(string title, string websiteUrl)
    {
        Title = title;
        WebsiteUrl = websiteUrl;
    }

    public WishItem(string title, string websiteUrl, string? imageUrl, string? description) 
         : this(title, websiteUrl)
    {
        ImageUrl = imageUrl;
        Description = description;
    }

    public WishItem(int id, string title, string websiteUrl, string? imageUrl = null, string? description = null)
        : this(title, websiteUrl)
    {
        Id = id;
        ImageUrl = imageUrl;
        Description = description;
    }
}
