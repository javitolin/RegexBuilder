using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexGenerator
{
    public static class RegexGenerator
    {
        private static string AddNumberOfTimesToRule(string pattern, string numberOfTimes)
        {
            pattern += numberOfTimes;
            return pattern;
        }

        private static string AddParenthesisToPattern(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            return "(" + pattern + ")";
        }

        private static RegexBuilder AnyOfWithNegate(this RegexBuilder generatedRegex, IEnumerable<string> characters, string numberOfTimes, bool isNegative)
        {
            List<string> chars = characters.Distinct().ToList();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");

            if (isNegative)
            {
                stringBuilder.Append("^");
            }

            foreach (var character in chars)
            {
                if (character.StartsWith("\\") && !character.Equals("\\"))
                {
                    stringBuilder.Append(character);
                }
                else
                {
                    stringBuilder.Append(Regex.Escape(character));
                }
            }

            stringBuilder.Append("]");

            var pattern = AddNumberOfTimesToRule(stringBuilder.ToString(), numberOfTimes);
            return generatedRegex.AddPattern(pattern);
        }

        public static RegexBuilder AddNotAnyOf(this RegexBuilder generatedRegex, IEnumerable<string> characters, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, characters, numberOfTimes, true);
        }

        public static RegexBuilder AddNotAnyOf(this RegexBuilder generatedRegex, IEnumerable<char> characters, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, characters.Select(c => "" + c), numberOfTimes, true);
        }

        public static RegexBuilder AddAnyOf(this RegexBuilder generatedRegex, IEnumerable<string> characters, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, characters, numberOfTimes, false);
        }

        public static RegexBuilder AddAnyOf(this RegexBuilder generatedRegex, IEnumerable<char> characters, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, characters.Select(c => "" + c), numberOfTimes, false);
        }

        public static RegexBuilder AddLiteral(this RegexBuilder generatedRegex, string match, string numberOfTimes = Times.Once)
        {
            string pattern = Regex.Escape(match);
            pattern = AddParenthesisToPattern(pattern);
            pattern = AddNumberOfTimesToRule(pattern, numberOfTimes);
            pattern = AddParenthesisToPattern(pattern);
            return generatedRegex.AddPattern(pattern);
        }

        public static RegexBuilder AddAnyWordCharacter(this RegexBuilder generatedRegex, string numberOfTimes = Times.Once, IEnumerable<string>? extraCharacters = null)
        {
            string pattern = @"\w";
            List<string> characters = new[] { pattern }.ToList();
            if (extraCharacters != null)
            {
                characters.AddRange(extraCharacters);
            }

            return AddAnyOf(generatedRegex, characters, numberOfTimes);
        }

        public static RegexBuilder AddAnyWhiteSpace(this RegexBuilder generatedRegex, string numberOfTimes = Times.Once)
        {
            string pattern = @"\s";
            pattern = AddNumberOfTimesToRule(pattern, numberOfTimes);
            pattern = AddParenthesisToPattern(pattern);
            return generatedRegex.AddPattern(pattern);
        }

        public static RegexBuilder AddAny(this RegexBuilder generatedRegex, string numberOfTimes = Times.Once)
        {
            string pattern = ".";
            pattern = AddNumberOfTimesToRule(pattern, numberOfTimes);
            pattern = AddParenthesisToPattern(pattern);
            return generatedRegex.AddPattern(pattern);
        }      
        
        public static RegexBuilder AddNumbers(this RegexBuilder generatedRegex, string numberOfTimes = Times.Once)
        {
            string pattern = "[0-9]";
            pattern = AddNumberOfTimesToRule(pattern, numberOfTimes);
            pattern = AddParenthesisToPattern(pattern);
            return generatedRegex.AddPattern(pattern);
        }

        public static RegexBuilder AddCustomRegexPattern(this RegexBuilder generatedRegex, string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentException("Pattern is null or empty");
            }

            pattern = AddParenthesisToPattern(pattern);

            return generatedRegex.AddPattern(pattern);
        }
    }
}
