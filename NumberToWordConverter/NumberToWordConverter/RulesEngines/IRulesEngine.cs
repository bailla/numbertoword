using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.RulesEngines
{
    public interface IRulesEngine<Input, Output>
    {
        Output ProcessItem(Input item);
    }
}
