using DeveloperChallenge.Domain.Enums;
using System;
using System.Globalization;

namespace DeveloperChallenge.Domain.OfxFileReaders
{
    public static class OfxValuesParser
    {
        public static bool TryParse(string value, out DateTime result)
        {
            const string format = "yyyyMMddHHmmss";

            var valueWithoutRegion = value.Contains('[')
                ? value.Substring(0, value.IndexOf('['))
                : value;

            var valueWithPadRight = valueWithoutRegion.PadRight(format.Length, '0');

            //var variation = value.Substring(value.IndexOf('[')+1,  value.LastIndexOf(':') - value.IndexOf('['));
            //var valueWithVariation = int.TryParse(variation, out var intVariation)
            //    ? $"{valueWithPadRight}{intVariation}"
            //    : valueWithPadRight;

            return DateTime.TryParseExact(valueWithPadRight, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out result);
        }

        public static bool TryParse(string value, out OfxEntryType result)
        {
            result = (value.ToUpper()) switch
            {
                "DEBIT" => OfxEntryType.Debit,
                "CREDIT" => OfxEntryType.Credit
            };

            return Enum.IsDefined(typeof(OfxEntryType), result);
        }
    }
}