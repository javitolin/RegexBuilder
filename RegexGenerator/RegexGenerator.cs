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

        private static RegexBuilder AnyOfWithNegate(this RegexBuilder generatedRegex, IEnumerable<string> characters, string numberOfTimes, bool isNegate)
        {
            List<string> chars = characters.Distinct().ToList();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");

            if (isNegate)
            {
                stringBuilder.Append("^");
            }

            foreach (var character in chars)
            {
                if (character.StartsWith("\\") && !character.Equals("\\")) // User escaped character
                {
                    stringBuilder.Append(character);
                }
                else if (character.Length > 1 && !character.StartsWith("\\")) // User sent a whole word
                {
                    stringBuilder.Append("(");
                    stringBuilder.Append(character);
                    stringBuilder.Append(")");
                }
                else // Any other letter
                {
                    stringBuilder.Append(Regex.Escape(character));
                }
            }

            stringBuilder.Append("]");

            var pattern = AddNumberOfTimesToRule(stringBuilder.ToString(), numberOfTimes);
            return generatedRegex.AddPattern(pattern);
        }

        /// <summary>
        /// Adds a "Not Any Of" clause to the regex.
        /// Translates to ([^...<paramref name="verbs"/>])
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="verbs">The list of verbs (characters or words) to search for</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddNotAnyOf(this RegexBuilder generatedRegex, IEnumerable<string> verbs, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, verbs, numberOfTimes, true);
        }

        /// <summary>
        /// Adds a "Not Any Of" clause to the regex.
        /// Translates to ([^...<paramref name="characters"/>])
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="characters">The list of characters to search for</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddNotAnyOf(this RegexBuilder generatedRegex, IEnumerable<char> characters, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, characters.Select(c => "" + c), numberOfTimes, true);
        }

        /// <summary>
        /// Adds a "Any Of" clause to the regex.
        /// Translates to ([...<paramref name="verbs"/>])
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="verbs">The list of verbs (characters or words) to search for</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddAnyOf(this RegexBuilder generatedRegex, IEnumerable<string> verbs, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, verbs, numberOfTimes, false);
        }

        /// <summary>
        /// Adds a "Any Of" clause to the regex.
        /// Translates to ([...<paramref name="characters"/>])
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="characters">The list of characters to search for</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddAnyOf(this RegexBuilder generatedRegex, IEnumerable<char> characters, string numberOfTimes = Times.Once)
        {
            return AnyOfWithNegate(generatedRegex, characters.Select(c => "" + c), numberOfTimes, false);
        }

        /// <summary>
        /// Adds a literal verb clause to the regex.
        /// Translates to (<paramref name="verb"/>)
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="verb">The verb to search for</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddVerb(this RegexBuilder generatedRegex, string verb, string numberOfTimes = Times.Once)
        {
            string pattern = Regex.Escape(verb);
            pattern = AddParenthesisToPattern(pattern);
            pattern = AddNumberOfTimesToRule(pattern, numberOfTimes);
            pattern = AddParenthesisToPattern(pattern);
            return generatedRegex.AddPattern(pattern);
        }

        /// <summary>
        /// Adds a clause to search for any word character (A to Z, a to z, numbers and _ (underscore))
        /// Translates to ([\w]) which is equivalent to ([A-Za-z0-9_])
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <param name="extraCharacters">Optional. Extra characters to add to the clause. Similar to <see cref="AddAnyOf(RegexBuilder, IEnumerable{string}, string)"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
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

        /// <summary>
        /// Adds a clause to search for any white space (Tabs, spaces, line breaks and such)
        /// Translates to ([\s])
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <param name="extraCharacters">Optional. Extra characters to add to the clause. Similar to <see cref="AddAnyOf(RegexBuilder, IEnumerable{string}, string)"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddAnyWhiteSpace(this RegexBuilder generatedRegex, string numberOfTimes = Times.Once, IEnumerable<string>? extraCharacters = null)
        {
            string pattern = @"\s";
            List<string> characters = new[] { pattern }.ToList();
            if (extraCharacters != null)
            {
                characters.AddRange(extraCharacters);
            }

            return AddAnyOf(generatedRegex, characters, numberOfTimes);
        }

        /// <summary>
        /// Adds a clause to search for anything
        /// Translates to (.)
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddAny(this RegexBuilder generatedRegex, string numberOfTimes = Times.Once)
        {
            string pattern = ".";
            pattern = AddNumberOfTimesToRule(pattern, numberOfTimes);
            pattern = AddParenthesisToPattern(pattern);
            return generatedRegex.AddPattern(pattern);
        }

        /// <summary>
        /// Adds a clause to search for any number
        /// Translates to ([0-9])
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="numberOfTimes">Optional. Use <see cref="RegexGenerator.Times"/></param>
        /// <param name="extraCharacters">Optional. Extra characters to add to the clause. Similar to <see cref="AddAnyOf(RegexBuilder, IEnumerable{string}, string)"/></param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        public static RegexBuilder AddAnyNumber(this RegexBuilder generatedRegex, string numberOfTimes = Times.Once, IEnumerable<string>? extraCharacters = null)
        {
            string pattern = "[0-9]";
            List<string> characters = new[] { pattern }.ToList();
            if (extraCharacters != null)
            {
                characters.AddRange(extraCharacters);
            }

            return AddAnyOf(generatedRegex, characters, numberOfTimes);
        }

        /// <summary>
        /// Adds a clause with your custom regex
        /// </summary>
        /// <param name="generatedRegex">The RegexBuilder object to work on</param>
        /// <param name="pattern">Custom regex pattern</param>
        /// <returns>A <see cref="RegexBuilder"/> object with the new constrains</returns>
        /// <exception cref="ArgumentException">Throws if pattern is null or empty</exception>
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
