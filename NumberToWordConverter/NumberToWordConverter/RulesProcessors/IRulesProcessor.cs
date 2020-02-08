using NumberToWordConverter.RulesEngines;
using System.Collections.Generic;

namespace NumberToWordConverter.RulesProcessor
{
    public interface IRulesProcessor<Input, Output>
    {
        IList<Output> Process(IList<Input> items);
    }
}
