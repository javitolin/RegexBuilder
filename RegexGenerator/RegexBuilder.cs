using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexGenerator
{
    public class RegexBuilder
    {
        private readonly bool _matchFullText;
        private StringBuilder _regexPattern = new StringBuilder();


        /// <summary>
        /// Helper List with all numbers
        /// </summary>
        public static List<char> AllNumbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// Helper List with all English characters in lower case
        /// </summary>
        public static List<char> AllLettersLowerCase = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        /// <summary>
        /// Helper List with all English characters in upper case
        /// </summary>
        public static List<char> AllLettersUpperCase = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// Helper List with all English characters in lower case and upper case
        /// </summary>
        public static List<char> AllLettersAllCases = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// Helper List with all English characters in lower case and upper case and all numbers
        /// </summary>
        public static List<char> AllLettersAndNumbers = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// Creates a RegexBuilder object
        /// </summary>
        /// <param name="matchFullText">If true, the built regex will search for the regex from beginning to end. (Adds ^ and $ to regex)</param>
        public RegexBuilder(bool matchFullText = true)
        {
            _matchFullText = matchFullText;

            if (_matchFullText)
            {
                _regexPattern.Append("^");
            }
        }

        /// <summary>
        /// Adds a pattern clause to the regex.
        /// Use <see cref="RegexGenerator"/> for helper functions
        /// </summary>
        /// <param name="rule">The pattern to add</param>
        /// <returns>Returns itself</returns>
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

        /// <summary>
        /// Converts the value of this instance into a Regex
        /// </summary>
        /// <param name="options">Optional. Custom <see cref="RegexOptions"/>. Defaults to <see cref="RegexOptions.None"/></param>
        /// <param name="matchTimeout">Optional. Match timeout when searching. Defaults to <see cref="Regex.InfiniteMatchTimeout"/></param>
        /// <returns>A C# Regex object</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
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


        /// <summary>
        /// Tries to convert the value of this instance into a Regex
        /// </summary>
        /// <param name="regex">Out parameter. If success this parameter will contain the Regex object. Null of failure</param>
        /// <param name="options">Optional. Custom <see cref="RegexOptions"/>. Defaults to <see cref="RegexOptions.None"/></param>
        /// <param name="matchTimeout">Optional. Match timeout when searching. Defaults to <see cref="Regex.InfiniteMatchTimeout"/></param>
        /// <returns>True if success, False otherwise</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public bool TryToRegex(out Regex? regex, RegexOptions options = RegexOptions.None, TimeSpan? matchTimeout = null)
        {
            try
            {
                regex = ToRegex(options, matchTimeout);
                return true;
            }
            catch (Exception)
            {
                regex = null;
                return false;
            }
        }

        /// <summary>
        /// Converts the inner generated clause to a String
        /// </summary>
        /// <returns>A string containing the value of the generated pattern</returns>
        public override string ToString()
        {
            return _regexPattern.ToString();
        }
    }
}