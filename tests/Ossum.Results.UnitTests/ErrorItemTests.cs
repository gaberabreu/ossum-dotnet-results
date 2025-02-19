namespace Ossum.Results.UnitTests;

public class ErrorItemTests
{
    [Fact]
    public void GivenParameters_WhenInstantiating_ThenHasCorrectValues()
    {
        // Given
        var faker = new Faker();
        var field = faker.Lorem.Word();
        var code = faker.Random.AlphaNumeric(5);
        var message = faker.Lorem.Sentence();

        // When
        var instance = new ErrorItem(field, code, message);

        // Then
        Assert.Equal(field, instance.Field);
        Assert.Equal(code, instance.Code);
        Assert.Equal(message, instance.Message);
    }
}
