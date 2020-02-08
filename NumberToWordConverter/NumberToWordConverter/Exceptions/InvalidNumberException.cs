using System;

namespace NumberToWordConverter.Exceptions
{
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException(string message)
            : base(message)
        { }
    }
}
