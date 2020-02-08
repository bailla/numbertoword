using NumberToWordConverter.RulesEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.RulesProcessor
{
    public interface IRulesProcessor<Input, Output>
    {
        IList<Output> Process(IList<Input> items, IRulesEngine<Input, Output> rulesEngine);
    }
}
