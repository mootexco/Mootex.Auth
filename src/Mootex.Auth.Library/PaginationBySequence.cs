namespace Mootex.Auth.Library;

public sealed class PaginationBySequence
{
    public ulong MinId { get; init; }

    public ushort Items { get; init; }

    public PaginationBySequence(ulong minId, ushort items)
    {
        this.MinId = minId;
        this.Items = items;
    }
}
