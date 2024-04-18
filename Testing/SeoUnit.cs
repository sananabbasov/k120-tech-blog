using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Helpers;
using Xunit;

namespace Testing;

public class SeoUnit
{
    [Fact]
    public void Seo_Camel_Case()
    {
        var url = "SaLam NeCeSiNiz";
        var res = "salam-necesiniz";
        string test = SeoHelper.CreateSeoUrl(url);
        Assert.Equal(res, test);
    }


     [Fact]
    public void Seo_Non_Alphenumeric()
    {
        var url = "SaLam 2 NeCeSiNiz $& test-";
        var res = "salam-2-necesiniz-test";
        string test = SeoHelper.CreateSeoUrl(url);
        Assert.Equal(res, test);
    }

    [Fact]
    public void Seo_Start_Non_Alphenumeric()
    {
        var url = "#S#aLam 2 NeCeSiNiz $& test-";
        var res = "salam-2-necesiniz-test";
        string test = SeoHelper.CreateSeoUrl(url);
        Assert.Equal(res, test);
    }


    [Fact]
    public void Seo_Non_English_Letter()
    {
        var url = "Salam necəsiniz?";
        var res = "salam-necesiniz";
        string test = SeoHelper.CreateSeoUrl(url);
        Assert.Equal(res, test);
    }
}
