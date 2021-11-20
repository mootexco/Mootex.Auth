using System.Linq;
using System.Threading.Tasks;
using Mootex.Auth.Data.Apps;
using Mootex.Auth.Library;
using Mootex.Auth.Models.Apps;
using Xunit;

namespace Mootex.Auth.Data.Test.Apps;

public sealed class EfAppRepository_IntegrationTest
{
    private readonly IAppRepository sut;

    public EfAppRepository_IntegrationTest()
    {
        var dsn = "Data Source=../../Mootex.Auth.db";

        var db = new AppDbContextCreator(dsn);
        db.Create();
        db.CreateSampleData();

        this.sut = new EfAppRepository(db);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public async Task GetList_Takes_AdequateNumberOfItems(ushort numberOfItems)
    {
        var actual = this.sut.GetList(new PaginationBySequence(0, numberOfItems));

        Assert.Equal(numberOfItems, await actual.CountAsync());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public async Task GetList_Skips_BasedOnId(uint minId)
    {
        var actual = this.sut.GetList(new PaginationBySequence(minId, 1));
        var item = await actual.FirstAsync();

        Assert.Equal(minId + 1, item.Id);
    }
}