using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexGenerator
{
    public class RegexBuilder
    {
        public static List<char> AllNumbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static List<char> AllLettersLowerCase = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static List<char> AllLettersUpperCase = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static List<char> AllLettersAllCases = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static List<char> AllLettersAndNumbers = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private readonly bool _matchFullText;
        private StringBuilder _regexPattern = new StringBuilder();

        public RegexBuilder(bool matchFullText = true)
        {
            _matchFullText = matchFullText;

            if (matchFullText)
            {
                _regexPattern.Append("^");
            }
        }

        public RegexBuilder AddPattern(string rule)
        {
            _regexPattern.Append(rule);
            return this;
        }

        private string CloseRegex(string pattern)
        {
            if (pattern.EndsWith("$") || !_matchFullText)
            {
                return pattern;
            }

            pattern += "$";

            return pattern;
        }

        public Regex ToRegex(RegexOptions options = RegexOptions.None, TimeSpan? matchTimeout = null)
        {
            var regexPattern = _regexPattern.ToString();
            regexPattern = CloseRegex(regexPattern);

            if (matchTimeout == null)
            {
                matchTimeout = Regex.InfiniteMatchTimeout;
            }

            return new Regex(regexPattern, options, matchTimeout.Value);
        }

        public bool VerifyExpression()
        {
            string testPattern = _regexPattern.ToString();
            if (string.IsNullOrWhiteSpace(testPattern))
            {
                return false;
            }

            try
            {
                Regex.Match("", testPattern);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return ToRegex().ToString();
        }
    }
}