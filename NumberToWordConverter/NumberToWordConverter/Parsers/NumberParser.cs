using NumberToWordConverter.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWordConverter.Parsers
{
    public class NumberParser : IParser<string, long>
    {
        public NumberParser()
        {
        }

        public IList<long> ParseInput(string input)
        {
            IList<long> result = new List<long>();

            StringBuilder newNumber = new StringBuilder();
            bool numberForming = false;
            bool spaceBeforeNumber = true; // if number is at beginning of text

            foreach (var currentCharacter in input)
            { 
                if (currentCharacter == ' ')
                {
                    spaceBeforeNumber = true;

                    if (numberForming) // we are at the end of the number
                    {
                        result.Add(long.Parse(newNumber.ToString()));
                        numberForming = false;
                        newNumber.Clear();
                    }
                }
                else if (Int32.TryParse(currentCharacter.ToString(), out int number))
                {
                    if (!numberForming && !spaceBeforeNumber) // we are about to start a new number but there is a character before it
                        throw new InvalidNumberException("number invalid");

                    numberForming = true;

                    newNumber.Append(currentCharacter);
                }
                else
                {
                    if (numberForming) // we are already forming a number and have encountered something invalid
                        throw new InvalidNumberException("number invalid");

                    spaceBeforeNumber = false;
                }
            }

            if (numberForming) // handle last number if exists
                result.Add(long.Parse(newNumber.ToString()));

            return result;
        }
    }
}
