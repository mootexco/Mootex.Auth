namespace Mootex.Auth.Library;

public sealed class PaginationBySequence
{
    public uint MinId { get; init; }

    public ushort Items { get; init; }

    public PaginationBySequence(uint minId, ushort items)
    {
        this.MinId = minId;
        this.Items = items;
    }
}
