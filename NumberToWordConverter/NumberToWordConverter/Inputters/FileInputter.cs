using NumberToWordConverter.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Inputters
{
    public class FileInputter : IInputter<string>
    {
        readonly string _fileNamePath;

        public FileInputter(string fileNamePath) => _fileNamePath = fileNamePath;

        public string Get()
        {
            string text;

            try
            {
                using (StreamReader streamReader = new StreamReader(_fileNamePath))
                {
                    text = streamReader.ReadToEnd();
                }
            }
            catch(Exception)
            {
                throw new MissingFileException($"File {_fileNamePath} has not been found");
            }

            return text;
        }
    }
}
