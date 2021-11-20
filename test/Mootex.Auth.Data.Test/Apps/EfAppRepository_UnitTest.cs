using System;
using Mootex.Auth.Data.Apps;
using Mootex.Auth.Models.Apps;
using Xunit;

namespace Mootex.Auth.Data.Test.Apps;

public sealed class EfAppRepository_UnitTest
{
    private readonly IAppRepository sut;

    public EfAppRepository_UnitTest()
    {
        this.sut = new EfAppRepository(new AppDbContextCreator(string.Empty));
    }

    [Fact]
    public void GetList_HandlesNullArguments()
    {
        Assert.Throws<ArgumentNullException>(() => this.sut.GetList(null!));
    }
}
