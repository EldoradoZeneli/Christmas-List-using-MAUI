using ChristmasListBL.Interfaces;
using ChristmasListBL.Services;
using ChristmasListUtils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        IChristmaslistRepository repo = ChristmaslistRepositoryFactory.GetChristmaslistRepository();
        ChristmasManager manager = new(repo);
        string connectionString = @"Data Source = ELEG5\SQLEXPRESS01; Initial Catalog = ChristmaslistDB; Integrated Security = True; Encrypt = True; Trust Server Certificate = True";
    }
}
