using ChristmasListBL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListBL.Interfaces;

public interface IChristmaslistRepository
{
    void AddGiftItem(GiftItem giftItem);
    void AddPerson(Person person);
    void AddWishlistItem(WishItem wishItem);
    List<GiftItem> GetGiftItems();
    List<Person> GetPersons();
    List<WishItem> GetWishItems();
    void UpdateGiftItem(GiftItem giftItem);
    void UpdateWishItem(WishItem wishItem);
}
