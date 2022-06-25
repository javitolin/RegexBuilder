# RegexBuilder
> An utility tool for generating Regex patterns using code (RaC - Regex as Code)

## Installation
Future: 
```
Install-Package RegexBuilder
```

## Usage example
1. Create a `RegexBuilder` object
2. Use any of the extensions methods (like `AddAnyOf`, `AddLiteral`, `AddNumbers` and more)
3. Convert the `RegexBuilder` into a `Regex` object using `ToRegex` function

```
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(new[] { 'a' });

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("a"));
```

## Contributing
1. Fork it (<https://github.com/javitolin/RegexBuilder/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request

## Meta

[AsadoDevCulture](https://AsadoDevCulture.com) 

[@jdorfsman](https://twitter.com/jdorfsman)

Distributed under the MIT license.