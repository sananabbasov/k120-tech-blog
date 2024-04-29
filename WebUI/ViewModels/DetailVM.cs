using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewModels;

public class DetailVM
{
    public Article Article { get; set; }
    public List<Article> RecentArticles { get; set; }
}
