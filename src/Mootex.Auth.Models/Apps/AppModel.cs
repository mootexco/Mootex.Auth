namespace Mootex.Auth.Models.Apps;

public sealed class AppModel
{
    public uint Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public DateTime UpdateTime { get; init; }
}
