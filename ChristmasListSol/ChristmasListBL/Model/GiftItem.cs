using ChristmasListBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListBL.Model;

public class GiftItem
{
    private string _title;
    private decimal _price;
    private string? _description;
    private string? _imageUrl;

    public int Id { get; set; } = 0;
    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ChristmasException("Title cannot be null or empty.");
            _title = value;
        }
    }
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ChristmasException("Price cannot be negative.");
            _price = value;
        }
    }
    public string? Description
    {
        get => _description ?? string.Empty;
        set => _description = value;
    }
    public string? ImageUrl
    {
        get => _imageUrl ?? string.Empty;
        set => _imageUrl = value;
    }
    public Person? Person { get; set; }
    
    public GiftItem()
    {
        Id = 0;
        _title = string.Empty;
        _price = 0;
        _imageUrl = null;
        _description = null;
    }
    public GiftItem(string title, decimal price)
    {
        Title = title;
        Price = price;
    }

    public GiftItem(string title, decimal price, string? imageUrl, string? description)
         : this(title, price)
    {
        ImageUrl = imageUrl;
        Description = description;
    }

    public GiftItem(int id, string title, decimal price, string? imageUrl = null, string? description = null)
        : this(title, price)
    {
        Id = id;
        ImageUrl = imageUrl;
        Description = description;
    }
}
