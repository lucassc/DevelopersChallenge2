using DeveloperChallenge.Domain.Enums;
using DeveloperChallenge.Domain.OfxFileReaders;
using FluentAssertions;
using System;
using Xunit;

namespace DeveloperChallenge.Tests.Domain
{
    public class OfxFileReadersTests
    {
        public OfxFileReadersTests()
        {
        }

        [Theory(DisplayName = "TryParse OfxEntryType should return true when value correct")]
        [InlineData("credit", OfxEntryType.Credit)]
        [InlineData("CREDIT", OfxEntryType.Credit)]
        [InlineData("Credit", OfxEntryType.Credit)]
        [InlineData("Debit", OfxEntryType.Credit)]
        [InlineData("DEBIT", OfxEntryType.Credit)]
        [InlineData("debit", OfxEntryType.Credit)]
        public void TryParseOfxEntryType_ShouldReturnTrueWhenValueCorrect(string strValue, OfxEntryType expectedType)
        {
            var result = OfxValuesParser.TryParse(strValue, out OfxEntryType parsedValue);

            result.Should().BeTrue();
            parsedValue.Should().Be(expectedType);
        }

        [Theory(DisplayName = "TryParse OfxEntryType should return false when value incorrect")]
        [InlineData("credit1")]
        [InlineData("CREDI")]
        [InlineData("Cre")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public void TryParseOfxEntryType_ShouldReturnFalseWhenValueIncorrect(string strValue)
        {
            var result = OfxValuesParser.TryParse(strValue, out OfxEntryType _);

            result.Should().BeFalse();
        }

        [Theory(DisplayName = "TryParse DateTime should return false when value incorrect")]
        [InlineData("2014023110000[-03:BRT]")]
        [InlineData("201402[-03:BRT]")]
        [InlineData("")]
        public void TryParseOfxDateTime_ShouldReturnFalseWhenValueIncorrect(string strValue)
        {
            var result = OfxValuesParser.TryParse(strValue, out DateTime _);

            result.Should().BeFalse();
        }

        [Theory(DisplayName = "TryParse DateTime should return true when value correct")]
        [InlineData("2014022810000[-03:BRT]", "2014-02-28 10:00")]
        [InlineData("20140201[-03:BRT]", "2014-02-01 00:00:00")]
        [InlineData("20140201100000[-03:BRT]", "2014-02-01 10:00:00")]
        public void TryParseOfxDateTime_ShouldReturnTrueWhenValueCorrect(string strValue, string expetedValue)
        {
            var result = OfxValuesParser.TryParse(strValue, out DateTime parsedValue);

            result.Should().BeTrue();
            parsedValue.Should().Be(DateTime.Parse(expetedValue));
        }
    }
}