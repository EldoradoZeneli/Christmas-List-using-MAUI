using ChristmasListBL.Interfaces;
using ChristmasListBL.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ChristmasListDL;

public class ChristmaslistRepository : IChristmaslistRepository
{
    private readonly string _connectionString;
    public ChristmaslistRepository(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    // Add

    public void AddPerson(Person person)
    {
        const string query = @"
            INSERT INTO Person (firstName, lastName)
            VALUES (@FirstName, @LastName);";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@FirstName", person.Name);
        cmd.Parameters.AddWithValue("@LastName", (object?)person.LastName ?? DBNull.Value);

        connection.Open();
        cmd.ExecuteScalar();
    }

    public void AddWishlistItem(WishItem wishItem)
    {
        const string query = @"
            INSERT INTO WishlistItem (title, website, description, imageUrl)
            VALUES (@Title, @Website, @Description, @ImageUrl);";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Title", wishItem.Title);
        cmd.Parameters.AddWithValue("@Website", wishItem.WebsiteUrl);
        cmd.Parameters.AddWithValue("@Description", (object?)wishItem.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ImageUrl", (object?)wishItem.ImageUrl ?? DBNull.Value);

        connection.Open();
        cmd.ExecuteScalar();
    }

    public void AddGiftItem(GiftItem giftItem)
    {
        const string query = @"
            INSERT INTO GiftlistItem (title, price, description, imageUrl, personid)
            VALUES (@Title, @Price, @Description, @ImageUrl, @PersonId);";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Title", giftItem.Title);
        cmd.Parameters.AddWithValue("@Price", giftItem.Price);
        cmd.Parameters.AddWithValue("@Description", (object?)giftItem.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ImageUrl", (object?)giftItem.ImageUrl ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PersonId", (object?)giftItem.Person?.Id ?? DBNull.Value);

        connection.Open();
        cmd.ExecuteScalar();
    }

    // Get

    public List<WishItem> GetWishItems()
    {
        const string query = @"SELECT Id, title, website, description, imageUrl FROM WishlistItem";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        connection.Open();

        using var reader = cmd.ExecuteReader();
        var list = new List<WishItem>();
        while (reader.Read())
        {
            var item = new WishItem
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("title")),
                WebsiteUrl = reader.GetString(reader.GetOrdinal("website")),
                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                ImageUrl = reader.IsDBNull(reader.GetOrdinal("imageUrl")) ? null : reader.GetString(reader.GetOrdinal("imageUrl"))
            };
            list.Add(item);
        }
        return list;
    }

    public List<GiftItem> GetGiftItems()
    {
        const string query = @"SELECT Id, title, price, description, imageUrl, personid FROM GiftlistItem";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        connection.Open();

        using var reader = cmd.ExecuteReader();
        var list = new List<GiftItem>();
        while (reader.Read())
        {
            var giftItem = new GiftItem
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("title")),
                Price = reader.GetDecimal(reader.GetOrdinal("price")),
                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                ImageUrl = reader.IsDBNull(reader.GetOrdinal("imageUrl")) ? null : reader.GetString(reader.GetOrdinal("imageUrl"))
            };

            if (!reader.IsDBNull(reader.GetOrdinal("personid")))
            {
                giftItem.Person = new Person
                {
                    Id = reader.GetInt32(reader.GetOrdinal("personid")),
                    Name = string.Empty
                };
            }

            list.Add(giftItem);
        }

        return list;
    }

    public List<Person> GetPersons()
    {
        const string query = @"SELECT Id, firstName, lastName FROM Person";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        connection.Open();

        using var reader = cmd.ExecuteReader();
        var list = new List<Person>();
        while (reader.Read())
        {
            var person = new Person
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("firstName")),
                LastName = reader.IsDBNull(reader.GetOrdinal("lastName")) ? null : reader.GetString(reader.GetOrdinal("lastName"))
            };
            list.Add(person);
        }
        return list;
    }

    // Update

    public void UpdateWishItem(WishItem wishItem)
    {
        if (wishItem.Id == 0) throw new ArgumentException("WishItem.Id must be set for update", nameof(wishItem));

        const string query = @"UPDATE WishlistItem
                               SET title = @Title, website = @Website, description = @Description, imageUrl = @ImageUrl, WHERE Id = @Id";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Title", wishItem.Title);
        cmd.Parameters.AddWithValue("@Website", wishItem.WebsiteUrl);
        cmd.Parameters.AddWithValue("@Description", (object?)wishItem.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ImageUrl", (object?)wishItem.ImageUrl ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Id", wishItem.Id);

        connection.Open();
        cmd.ExecuteNonQuery();
    }

    public void UpdateGiftItem(GiftItem giftItem)
    {
        if (giftItem.Id == 0) throw new ArgumentException("GiftItem.Id must be set for update", nameof(giftItem));

        const string query = @"
            UPDATE GiftlistItem
            SET title = @Title,
                price = @Price,
                description = @Description,
                imageUrl = @ImageUrl,
                personid = @PersonId
            WHERE Id = @Id";

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Title", giftItem.Title);
        cmd.Parameters.AddWithValue("@Price", giftItem.Price);
        cmd.Parameters.AddWithValue("@Description", (object?)giftItem.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ImageUrl", (object?)giftItem.ImageUrl ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PersonId", (object?)giftItem.Person?.Id ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Id", giftItem.Id);

        connection.Open();
        cmd.ExecuteNonQuery();
    }

}
