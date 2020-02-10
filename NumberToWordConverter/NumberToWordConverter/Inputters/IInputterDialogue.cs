using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Inputters
{
    public interface IInputterDialogue<T>
    {
        T Dialogue();
    }
}
