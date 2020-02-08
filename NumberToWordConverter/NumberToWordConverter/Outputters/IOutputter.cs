using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Outputters
{
    public interface IOutputter<T>
    {
        bool Output(IList<T> results);
    }
}
