﻿namespace Api.Core;

public class BaseException : Exception
{
    public BaseException()
    {
    }

    public BaseException(string message)
        : base(message) { }

    public BaseException(string message, Exception innerException)
        : base(message, innerException) { }
}
