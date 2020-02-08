using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Inputters
{
    public interface IInputter<T>
    {
        T Get();
    }
}
