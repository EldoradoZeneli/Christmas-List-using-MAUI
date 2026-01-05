using ChristmasListBL.Interfaces;
using ChristmasListBL.Model;
using ChristmasListUI_MAUI.View_Models.Wishlist_View_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListUI_MAUI.View_Models.Gift_List_View_Models
{
    public class GiftItemDetailViewModel : ViewModel
    {
        private IChristmasManager _manager;
        private GiftListItemViewModel? _itemVm;

        private string _titleField = string.Empty;
        private string _imageUrlField = string.Empty;
        private decimal _priceField = 0;
        private string _descriptionField = string.Empty;

        public string TitleField
        {
            get => _titleField;
            set
            {
                _titleField = value;
                OnPropertyChanged();
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
        public decimal PriceField
        {
            get => _priceField;
            set
            {
                _priceField = value;
                OnPropertyChanged();
            }
        }
        public string DescriptionField
        {
            get => _descriptionField;
            set { _descriptionField = value; OnPropertyChanged(); }
        }


    }

}
