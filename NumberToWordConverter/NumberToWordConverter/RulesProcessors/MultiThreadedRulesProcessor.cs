using NumberToWordConverter.RulesEngines;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberToWordConverter.RulesProcessor
{
    public class MultiThreadedRulesProcessor<Input, Output> : IRulesProcessor<Input, Output>
    {
        public IList<Output> Process(IList<Input> items, IRulesEngine<Input, Output> rulesEngine)
        {
            IList<Output> results = new List<Output>();
            IList<Task<Output>> processTasks = new List<Task<Output>>();

            foreach (var item in items)
                processTasks.Add(Task.Run(() => rulesEngine.ProcessItem(item)));

            Task.WaitAll(processTasks.ToArray());
                
            foreach(var task in processTasks)
                results.Add(task.Result);

            return results;
        }
    }
}
