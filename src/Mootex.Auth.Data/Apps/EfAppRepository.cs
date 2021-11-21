using Microsoft.EntityFrameworkCore;
using Mootex.Auth.Library;
using Mootex.Auth.Models.Apps;

namespace Mootex.Auth.Data.Apps;

public sealed class EfAppRepository : IAppRepository
{
    private readonly AuthDbContext db;

    public EfAppRepository(AuthDbContext db)
    {
        this.db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IAsyncEnumerable<AppModel> GetList(PaginationBySequence pagination)
    {
        if (pagination == null)
        {
            throw new ArgumentNullException(nameof(pagination));
        }

        if (pagination.Items == 0)
        {
            return AsyncEnumerable.Empty<AppModel>();
        }

        return this.db.Apps
            .Where(x => x.Id > pagination.MinId)
            .OrderBy(x => x.Id)
            .Take(pagination.Items)
            .AsAsyncEnumerable();
    }
}
