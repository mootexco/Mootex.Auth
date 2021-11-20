using Microsoft.AspNetCore.Mvc;
using Mootex.Auth.Entities.Apps;
using Mootex.Auth.Library;
using Mootex.Auth.Models.Apps;
using Mootex.Auth.UseCases.Apps;

namespace Mootex.Auth.Api.Controllers;

[ApiController]
[Route("apps")]
public sealed class AppsController : CustomController
{
    private readonly IAppRepository apps;

    public AppsController(IAppRepository apps)
    {
        this.apps = apps ?? throw new ArgumentNullException(nameof(apps));
    }

    [HttpGet]
    public IAsyncEnumerable<AppListItem> List()
    {
        return new ListApps(this.apps).Execute(new PaginationBySequence(0, 10));
    }
}
