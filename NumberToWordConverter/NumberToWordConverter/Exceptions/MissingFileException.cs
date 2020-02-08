using System;

namespace NumberToWordConverter.Exceptions
{
    public class MissingFileException : Exception
    {
        public MissingFileException(string message)
            : base(message)
        { }
    }
}