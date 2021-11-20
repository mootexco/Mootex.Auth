using Mootex.Auth.Models.Apps;

namespace Mootex.Auth.Entities.Apps;

public sealed class AppListItem
{
    public ulong Id { get; }

    public string Name { get; }

    public AppListItem(AppModel model)
    {
        this.Id = model.Id;
        this.Name = model.Name;
    }
}
