namespace Ossum.Results.UnitTests;

public class ErrorItemTests
{
    private readonly Faker _faker = new();

    [Fact]
    public void GivenValidProperties_WhenCreatingInstance_ThenValuesAreSetProperly()
    {
        // Given
        var field = _faker.Lorem.Word();
        var code = _faker.Random.AlphaNumeric(5);
        var message = _faker.Lorem.Sentence();

        // When
        var instance = new ErrorItem(field, code, message);

        // Then
        Assert.Equal(field, instance.Field);
        Assert.Equal(code, instance.Code);
        Assert.Equal(message, instance.Message);
    }
}
