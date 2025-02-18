namespace Ossum.Results.UnitTests.Fakers;

public class ErrorItemFaker : Faker<ErrorItem>
{
    public ErrorItemFaker()
    {
        RuleFor(e => e.Field, f => f.Lorem.Word());
        RuleFor(e => e.Code, f => f.Random.AlphaNumeric(5));
        RuleFor(e => e.Message, f => f.Lorem.Sentence());
    }
}
