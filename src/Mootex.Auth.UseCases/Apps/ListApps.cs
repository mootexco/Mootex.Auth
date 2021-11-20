using Mootex.Auth.Entities.Apps;
using Mootex.Auth.Library;
using Mootex.Auth.Models.Apps;

namespace Mootex.Auth.UseCases.Apps;

public sealed class ListApps : UseCase<PaginationBySequence, IAsyncEnumerable<AppListItem>>
{
    private readonly IAppRepository apps;

    public ListApps(IAppRepository apps)
    {
        this.apps = apps ?? throw new ArgumentNullException(nameof(apps));
    }

    public override async IAsyncEnumerable<AppListItem> Execute(PaginationBySequence input)
    {
        await foreach (var x in this.apps.GetList(input))
        {
            yield return new AppListItem(x);
        }
    }
}
