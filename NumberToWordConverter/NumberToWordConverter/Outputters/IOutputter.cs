using System.Collections.Generic;

namespace NumberToWordConverter.Outputters
{
    public interface IOutputter<T>
    {
        bool Output(IList<T> results);
    }
}
