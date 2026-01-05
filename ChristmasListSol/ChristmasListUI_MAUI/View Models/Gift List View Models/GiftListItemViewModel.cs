using ChristmasListBL.Model;

namespace ChristmasListUI_MAUI.View_Models.Gift_List_View_Models;

public class GiftListItemViewModel : ViewModel
{
    private string _title;
    private decimal _price;
    private string? _description;
    private string? _imageUrl;
    private Person? _person;

    public int Id { get; set; }
    public string Title
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }
    public decimal Price
    {
        get => _price;
        set { _price = value; OnPropertyChanged(); }
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
    public bool saveableState
    {
        get => !string.IsNullOrWhiteSpace(Title) && decimal.IsPositive(Price);
    }
    public Person? Person
    {
        get => _person;
        set { _person = value; OnPropertyChanged(); }
    }

    public GiftListItemViewModel()
    {
        Id = 0;
    }

    public static GiftListItemViewModel FromModel(GiftItem model)
    {
        return new GiftListItemViewModel
        {
            Id = model.Id,
            Title = model.Title,
            Price = model.Price,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
        };
    }
}