using ChristmasListBL.Interfaces;
using ChristmasListDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListUtils;

public static class ChristmaslistRepositoryFactory
{
    public static ChristmaslistRepository GetChristmaslistRepository(string connectionString)
    {
        return new ChristmaslistRepository(connectionString);
    }
}
