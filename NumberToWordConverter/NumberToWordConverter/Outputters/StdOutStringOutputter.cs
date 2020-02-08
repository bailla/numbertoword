using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Outputters
{
    public class StdOutStringOutputter : IOutputter<string>
    {
        public bool Output(IList<string> results)
        {
            results.ToList<string>().ForEach(x => Console.WriteLine(x));
            return true;
        }
    }
}
