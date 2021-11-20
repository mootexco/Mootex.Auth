using Mootex.Auth.Library;

namespace Mootex.Auth.Models.Apps;

public interface IAppRepository
{
    IAsyncEnumerable<AppModel> GetList(PaginationBySequence pagination);
}
