using NumberToWordConverter.Outputters;
using NumberToWordConverter.Parsers;
using NumberToWordConverter.RulesEngines;
using NumberToWordConverter.RulesProcessor;
using System.Collections.Generic;

namespace NumberToWordConverter
{
    static class Program
    {
        static void Main()
        {
            IParser<string, long> parser = new NumberParser();
            IList<long> numbersToConvert = parser.ParseInput("testing 123 testing 42342355 testing 4931342433");
            IRulesProcessor<long, string> rulesProcessor = new MultiThreadedRulesProcessor<long, string>(new AmericanNumberFormatRulesEngine());
            IList<string> wordsConverted = rulesProcessor.Process(numbersToConvert);
            IOutputter<string> outputter = new StdOutStringOutputter();
            outputter.Output(wordsConverted);
        }
    }
}
