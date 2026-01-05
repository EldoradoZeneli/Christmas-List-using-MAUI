using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ChristmasListBL.Exceptions;

public class ChristmasException : Exception
{
    public ChristmasException()
    {
    }

    public ChristmasException(string? message) : base(message)
    {
    }

    public ChristmasException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
