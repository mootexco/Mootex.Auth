namespace Mootex.Auth.Models.Apps;

public sealed class AppModel : IModelWithNumericId
{
    public ulong Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
