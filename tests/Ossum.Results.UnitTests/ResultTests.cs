namespace Ossum.Results.UnitTests;

public class ResultTests
{
    private readonly Faker _faker = new();
    private readonly ErrorItemFaker _errorItemFaker = new();

    [Fact]
    public void GivenParameters_WhenInstantiating_ThenHasCorrectValues()
    {
        // Given
        var status = _faker.PickRandom<ResultStatus>();

        // When
        var result = new Result(status);

        // Then
        Assert.Equal(status, result.Status);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void GivenParameters_WhenInstantiatingOk_ThenHasCorrectValues()
    {
        // Given
        var value = _faker.Random.Int();

        // When
        var result = Result.Ok(value);

        // Then
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal(value, result.Value);
    }

    [Fact]
    public void GivenParameters_WhenInstantiatingNoContent_ThenHasCorrectValues()
    {
        // Given & When
        var result = Result.NoContent();

        // Then
        Assert.Equal(ResultStatus.NoContent, result.Status);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void GivenParameters_WhenInstantiatingBadRequest_ThenHasCorrectValues()
    {
        // Given
        var error = _errorItemFaker.Generate();

        // When
        var result = Result.BadRequest(error);

        // Then
        Assert.Equal(ResultStatus.BadRequest, result.Status);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors.First());
    }

    [Fact]
    public void GivenParameters_WhenInstantiatingNotFound_ThenHasCorrectValues()
    {
        // Given & When
        var result = Result.NotFound();

        // Then
        Assert.Equal(ResultStatus.NotFound, result.Status);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void GivenResult_WhenImplicitConversionToGeneric_ThenStatusIsPreserved()
    {
        // Given
        var status = _faker.PickRandom<ResultStatus>();
        var result = new Result(status);

        // When
        Result<string> genericResult = result;

        // Then
        Assert.Equal(status, genericResult.Status);
        Assert.Null(genericResult.Value);
        Assert.Empty(genericResult.Errors);
    }

    [Fact]
    public void GivenResultWithErrors_WhenImplicitConversionToGeneric_ThenErrorsArePreserved()
    {
        // Given
        var error = _errorItemFaker.Generate();
        var result = Result.BadRequest(error);

        // When
        Result<string> genericResult = result;

        // Then
        Assert.Equal(ResultStatus.BadRequest, genericResult.Status);
        Assert.Null(genericResult.Value);
        Assert.Single(genericResult.Errors);
        Assert.Contains(error, genericResult.Errors);
    }

    [Fact]
    public void GivenValue_WhenImplicitConversionToResult_ThenValueIsSet()
    {
        // Given
        var value = _faker.Random.Word();

        // When
        Result<string> result = value;

        // Then
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal(value, result.Value);
    }
}
