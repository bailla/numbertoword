using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Inputters
{
    public class ConsoleFileNameDialogue : IInputterDialogue<string>
    {
        const string DEFAULT_FILE = @"inputFile.txt";

        public ConsoleFileNameDialogue()
        {
        }

        public string Dialogue()
        {
            Console.WriteLine("Enter path of file or hit enter to use existing");
            string filePath = Console.ReadLine();

            if (String.IsNullOrEmpty(filePath))
                filePath = DEFAULT_FILE;

            return filePath;
        }
    }
}
