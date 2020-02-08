using System;
using System.Text;

namespace NumberToWordConverter.RulesEngines
{
    public class AmericanNumberFormatRulesEngine : IRulesEngine<long, string>
    {
        public string ProcessItem(long item)
        {
            return Process(item);
        }

        private string Process(long item)
        {
            return item.IsRootNumber() ? ProcessRootNumber(item) :
                item.IsTeesNumber() ? ProcessTees(item) :
                item.IsHundredsNumber() ? ProcessHundreds(item) :
                item.IsThousandsNumber() ? ProcessThousands(item) :
                item.IsMillionsNumber() ? ProcessMillions(item) :
                item.IsBillionsNumber() ? ProcessBillions(item) : 
                $"Unhandled: {item}";
        }

        private string ProcessRootNumber(long item)
        {
            // beginning numbers that have no combinations

            switch (item)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                default:
                    throw new Exception($"number {item} not handled in ProcessRootNumber");
            }
        }

        private string ProcessTees(long item)
        {
            StringBuilder teeNumber = new StringBuilder();

            switch (item.FirstDigit())
            {
                case 2:
                    teeNumber.Append("twenty");
                    break;
                case 3:
                    teeNumber.Append("thirty");
                    break;
                case 4:
                    teeNumber.Append("forty");
                    break;
                case 5:
                    teeNumber.Append("fifty");
                    break;
                case 6:
                    teeNumber.Append("sixty");
                    break;
                case 7:
                    teeNumber.Append("seventy");
                    break;
                case 8:
                    teeNumber.Append("eighty");
                    break;
                case 9:
                    teeNumber.Append("ninety");
                    break;
                default:
                    throw new Exception($"number {item} not handled in ProcessTees");
            }

            if (item.SecondDigit() == 0)
                return teeNumber.ToString();

            return teeNumber.Append("-" + Process(item.SecondDigit())).ToString();
        }

        private string ProcessHundreds(long item)
        {
            StringBuilder hundredNumber = new StringBuilder();

            hundredNumber.Append(Process(item.FirstDigit()) + " hundred");

            long remainingDigits = long.Parse(item.ToString().Substring(1, 2).ToString());

            if (remainingDigits == 0)
                return hundredNumber.ToString();

            return hundredNumber.Append(" and " + Process(remainingDigits)).ToString();
        }

        private string ProcessThousands(long item)
        {
            StringBuilder thousandNumber = new StringBuilder();

            int length = item.ToString().Length;

            long thousands = long.Parse(item.ToString().Substring(0, length - 3)); // first thousand digits #xxx, ##xxx, ###xxx
            thousandNumber.Append(Process(thousands) + " thousand");

            long hundreds = long.Parse(item.ToString().Substring(length - 3, 3)); // remaining hundred digits x###, xx###, xxx###

            if (hundreds == 0)
                return thousandNumber.ToString();

            if(hundreds >= 100)
                return thousandNumber.Append(", " + Process(hundreds)).ToString();

            return thousandNumber.Append(" and " + Process(hundreds)).ToString();
        }

        private string ProcessMillions(long item)
        {
            StringBuilder millionNumber = new StringBuilder();

            int length = item.ToString().Length;

            long millions = long.Parse(item.ToString().Substring(0, length - 6)); // first million digits
            millionNumber.Append(Process(millions) + " million");

            long thousands = long.Parse(item.ToString().Substring(length - 6, 6)); // last thousand digits

            if (thousands == 0)
                return millionNumber.ToString();

            return millionNumber.Append(", " + Process(thousands)).ToString();
        }

        private string ProcessBillions(long item)
        {
            StringBuilder billionNumber = new StringBuilder();

            int length = item.ToString().Length;

            long billions = long.Parse(item.ToString().Substring(0, length - 9)); // first billion digits
            billionNumber.Append(Process(billions) + " billion");

            long millions = long.Parse(item.ToString().Substring(length - 9, 9)); // last thousand digits

            if (millions == 0)
                return billionNumber.ToString();

            return billionNumber.Append(", " + Process(millions)).ToString();
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsRootNumber(this long value)
        {
            if (value <= 19)
                return true;

            return false;
        }

        public static bool IsTeesNumber(this long value)
        {
            if (value >= 20 && value <= 99)
                return true;

            return false;
        }

        public static bool IsHundredsNumber(this long value)
        {
            if (value >= 100 && value <= 999)
                return true;

            return false;
        }

        public static bool IsThousandsNumber(this long value)
        {
            if (value >= 1000 && value <= 999999)
                return true;

            return false;
        }

        public static bool IsMillionsNumber(this long value)
        {
            if (value >= 1000000 && value <= 999999999)
                return true;

            return false;
        }

        public static bool IsBillionsNumber(this long value)
        {
            if (value >= 1000000000 && value <= 999999999999)
                return true;

            return false;
        }

        public static long FirstDigit(this long value)
        {
            return long.Parse(value.ToString()[0].ToString());
        }

        public static long SecondDigit(this long value)
        {
            return long.Parse(value.ToString()[1].ToString());
        }
    }
}