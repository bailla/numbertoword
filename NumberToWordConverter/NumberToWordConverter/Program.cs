using Microsoft.Extensions.DependencyInjection;
using NumberToWordConverter.Inputters;
using NumberToWordConverter.Outputters;
using NumberToWordConverter.Parsers;
using NumberToWordConverter.RulesEngines;
using NumberToWordConverter.RulesProcessor;
using System;
using System.Collections.Generic;

namespace NumberToWordConverter
{
    static class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IParser<string, long>, NumberParser>()
                .AddSingleton<IRulesEngine<long, string>, AmericanNumberFormatRulesEngine>()
                .AddSingleton<IRulesProcessor<long, string>, MultiThreadedRulesProcessor<long, string>>()
                .AddSingleton<IInputterDialogue<string>, ConsoleFileNameDialogue>()
                .AddSingleton<IInputter<string>, FileInputter>()
                .AddSingleton<IOutputter<string>, StdOutStringOutputter>()
                .BuildServiceProvider();

            bool run = true;
            while (run)
            {
                try
                {
                    IParser<string, long> parser = serviceProvider.GetService<IParser<string, long>>();
                    IList<long> numbersToConvert = parser.ParseInput(serviceProvider.GetService<IInputter<string>>().Get());

                    IRulesProcessor<long, string> rulesProcessor = serviceProvider.GetService<IRulesProcessor<long, string>>();
                    IList<string> wordsConverted = rulesProcessor.Process(numbersToConvert);

                    IOutputter<string> outputter = serviceProvider.GetService<IOutputter<string>>();
                    outputter.Output(wordsConverted);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Run Again y/n?");
                run = Console.ReadLine().ToLower() == "y" ? true : false;
            }
        }
    }
}
