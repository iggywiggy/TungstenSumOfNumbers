using System;
using System.Globalization;

namespace SumOfNumbers.Infastructure
{
    public class Utils
    {
        public static bool ConvertStringToInt(string toBeConverted, out long converted)
        {
            if (string.IsNullOrEmpty(toBeConverted))
                throw new ArgumentNullException(nameof(toBeConverted));

            return long.TryParse(toBeConverted.Trim(), NumberStyles.Any, new CultureInfo("en-GB", false),
                out converted);
        }
    }
}