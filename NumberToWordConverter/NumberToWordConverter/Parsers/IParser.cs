using System.Collections.Generic;

namespace NumberToWordConverter.Parsers
{
    public interface IParser<Input, Output>
    {
        IList<Output> ParseInput(Input input);
    }
}
