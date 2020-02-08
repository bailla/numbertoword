using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Parsers
{
    public interface IParser<Input, Output>
    {
        IList<Output> ParseInput(Input input);
    }
}
