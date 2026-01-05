using ChristmasListBL.Interfaces;
using ChristmasListBL.Model;
using ChristmasListUtils;
using System;
using System.Diagnostics;
using System.Linq;

namespace ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;

[QueryProperty(nameof(ItemVm), "Item")]
public class WishDetailViewModel : ViewModel
{
    private IChristmasManager _manager;
    private WishlistItemViewModel? _itemVm;

    private string _titleField = string.Empty;
    private string _imageUrlField = string.Empty;
    private string _websiteField = string.Empty;
    private string _descriptionField = string.Empty;

    public string TitleField
    {
        get => _titleField;
        set
        {
            _titleField = value;
            OnPropertyChanged();
            SaveCommand.ChangeCanExecute();
        }
    }
    public string ImageUrlField
    {
        get => _imageUrlField;
        set
        {
            _imageUrlField = value;
            OnPropertyChanged();
        }
    }
    public string WebsiteField
    {
        get => _websiteField;
        set
        {
            _websiteField = value;
            OnPropertyChanged();
            SaveCommand.ChangeCanExecute();
        }
    }
    public string DescriptionField
    {
        get => _descriptionField;
        set { _descriptionField = value; OnPropertyChanged(); }
    }


    public WishlistItemViewModel? ItemVm
    {
        get => _itemVm;
        set
        {
            _itemVm = value;
            OnPropertyChanged();

            if (_itemVm != null)
            {
                TitleField = _itemVm.Title ?? string.Empty;
                DescriptionField = _itemVm.Description ?? string.Empty;
                ImageUrlField = _itemVm.ImageUrl ?? string.Empty;
                WebsiteField = _itemVm.WebsiteUrl ?? string.Empty;

                // If the incoming VM doesn't carry an Id (shell/object round-trip may drop it),
                // try to resolve the authoritative Id from the manager so updates go to the existing row.
                if (_itemVm.Id == 0)
                {
                    var match = _manager.GetWishItems().FirstOrDefault(w =>
                        string.Equals(w.Title, _itemVm.Title, StringComparison.Ordinal) &&
                        string.Equals(w.WebsiteUrl, _itemVm.WebsiteUrl, StringComparison.Ordinal));
                    if (match != null)
                    {
                        _itemVm.Id = match.Id;
                    }
                }
            }
            SaveCommand.ChangeCanExecute();
        }
    }
    
    public Command SaveCommand { get; }

    public WishDetailViewModel(IChristmasManager manager)
    {
        _manager = manager ?? throw new ArgumentNullException(nameof(manager));

        SaveCommand = new Command(async () => await SaveWishListItem(), CanSave);
    }

    private bool CanSave()
    {
        // allow saving for both new and existing items based on entered fields
        return !string.IsNullOrWhiteSpace(TitleField) && !string.IsNullOrWhiteSpace(WebsiteField);
    }

    private async Task SaveWishListItem()
    {
        Debug.WriteLine("SaveWishListItem invoked");
        try
        {
            if (_itemVm == null || _itemVm.Id == 0)
            {
                // Creating new item
                var newItem = new WishItem
                {
                    Title = TitleField,
                    Description = DescriptionField,
                    ImageUrl = ImageUrlField,
                    WebsiteUrl = WebsiteField
                };

                // add to persistence
                _manager.AddWishlistItem(newItem);

                // if a VM existed (rare when creating) update its Id from the model (manager/repo should set it)
                if (_itemVm != null)
                {
                    _itemVm.Id = newItem.Id;
                }
            }
            else
            {
                // Updating existing item - build model preserving Id and send to manager
                var updated = new WishItem(_itemVm.Id, TitleField, WebsiteField, ImageUrlField, DescriptionField);
                _manager.UpdateWishItem(updated);

                // keep UI VM in sync
                _itemVm.Title = TitleField;
                _itemVm.Description = DescriptionField;
                _itemVm.ImageUrl = ImageUrlField;
                _itemVm.WebsiteUrl = WebsiteField;
            }

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Save failed: " + ex);
            throw;
        }
    }
}
