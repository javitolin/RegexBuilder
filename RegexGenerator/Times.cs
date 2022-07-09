using System;

namespace SimpleRegexBuilder
{
    public static class Times
    {
        public const string Once = "{1}";
        public const string AtLeastOnce = "+";
        public const string Any = "*";

        public static string Range(int from, int to)
        {
            if (from < 0 || to < 0)
            {
                throw new ArgumentOutOfRangeException($"From [{from}] or [{to}] are lower than 0");
            }

            if (from > to)
            {
                throw new ArgumentOutOfRangeException($"From [{from}] is bigger than to [{to}]");
            }

            if (from == to)
            {
                throw new ArgumentOutOfRangeException($"From [{from}] is equal to [{to}]");
            }

            return $"{{{from},{to}}}";
        }

        public static string AtLeast(int minimum)
        {
            if (minimum < 0)
            {
                throw new ArgumentOutOfRangeException($"Received argument [{minimum}] is lower than 0");
            }

            return $"{{{minimum},}}";
        }

        public static string NoMoreThan(int maximum)
        {
            if (maximum <= 0)
            {
                throw new ArgumentOutOfRangeException($"Received argument [{maximum}] is lower than or equal to 0");
            }

            return $"{{0,{maximum}}}";
        }
        public static string Exactly(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException($"Received argument [{number}] is lower than 0");
            }

            return $"{{{number}}}";
        }
    }
}
