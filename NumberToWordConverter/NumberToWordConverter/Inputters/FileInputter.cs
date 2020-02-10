using NumberToWordConverter.Exceptions;
using System;
using System.IO;

namespace NumberToWordConverter.Inputters
{
    public class FileInputter : IInputter<string>
    {
        readonly IInputterDialogue<string> _inputterDialogue;

        public FileInputter(IInputterDialogue<string> inputterDialogue) => _inputterDialogue = inputterDialogue;

        public string Get()
        {
            string filePath = _inputterDialogue.Dialogue();

            string text;

            try
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    text = streamReader.ReadToEnd();
                }
            }
            catch(Exception)
            {
                throw new MissingFileException($"File {filePath} has not been found");
            }

            return text;
        }
    }
}
