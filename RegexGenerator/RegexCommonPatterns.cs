namespace RegexGenerator
{
    public static class RegexCommonPatterns
    {
        public static string UsernamePattern(string numberOfTimes = Times.Once)
        {
            return @$"([a-zA-Z0-9_\.]{numberOfTimes})";
        }

        public static string EmailPattern()
        {
            RegexBuilder builder = new RegexBuilder();

            builder.AddAnyWordCharacter(Times.AtLeastOnce, new[] { "." })
                .AddLiteral("@", Times.Once)
                .AddAnyWordCharacter(Times.AtLeastOnce)
                .AddLiteral(".")
                .AddAnyWordCharacter(Times.AtLeast(2));

            return builder.ToString();
        }
    }
}
