﻿namespace Airways.Application.Exceptions
{
    public class UnprocessableRequestException : Exception
    {
        public UnprocessableRequestException(string message) : base(message) { }
    }
}
