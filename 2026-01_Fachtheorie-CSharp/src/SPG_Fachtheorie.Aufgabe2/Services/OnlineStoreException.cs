using System;

namespace SPG_Fachtheorie.Aufgabe2.Services;

[Serializable]
public class OnlineStoreException : Exception
{
    public OnlineStoreException()
    {
    }

    public OnlineStoreException(string? message) : base(message)
    {
    }

    public OnlineStoreException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}