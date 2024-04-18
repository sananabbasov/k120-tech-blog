using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebUI.Helpers;

public class SeoHelper
{
    public static string CreateSeoUrl(string url)
    {
        var res = url.ToLower().Replace("ə","e").Replace("ü","u").Replace("ç","c").Replace("ş","s").Replace("ğ","g").Replace("ö","o").Replace("ı","i");
        Regex rgx = new Regex("[^a-zA-Z0-9 ]");
        string result = rgx.Replace(res, "");
        var  test = result.Split(" ").Where(x=>!string.IsNullOrWhiteSpace(x)).ToList();
        return string.Join("-",test);
    }
}
