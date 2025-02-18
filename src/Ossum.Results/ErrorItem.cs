namespace Ossum.Results;

public class ErrorItem(string field, string code, string message)
{
    public string Field { get; set; } = field;
    public string Code { get; set; } = code;
    public string Message { get; set; } = message;
}
