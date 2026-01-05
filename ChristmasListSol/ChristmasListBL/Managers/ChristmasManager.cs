using ChristmasListBL.Interfaces;
using ChristmasListBL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListBL.Services;

public class ChristmasManager : IChristmasManager
{
    private IChristmaslistRepository _repo;

    public ChristmasManager(IChristmaslistRepository repo)
    {
        _repo = repo;
    }

    public void AddGiftItem(GiftItem giftItem)
    {
        _repo.AddGiftItem(giftItem);
    }

    public void AddPerson(Person person)
    {
        _repo.AddPerson(person);
    }

    public void AddWishlistItem(WishItem wishItem)
    {
        _repo.AddWishlistItem(wishItem);
    }

    public List<GiftItem> GetGiftItems()
    {
        return _repo.GetGiftItems();
    }

    public List<Person> GetPersons()
    {
        return _repo.GetPersons();
    }

    public List<WishItem> GetWishItems()
    {
        return _repo.GetWishItems();
    }

    public void UpdateGiftItem(GiftItem giftItem)
    {
        _repo.UpdateGiftItem(giftItem);
    }

    public void UpdateWishItem(WishItem wishItem)
    {
        _repo.UpdateWishItem(wishItem);
    }
}
