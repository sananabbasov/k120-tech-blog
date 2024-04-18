using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewModels;

public class HomeVM
{
    public List<Article> FeaturedArticles { get; set; }
    public List<Article> SidebarArticles { get; set; }
    public List<Article> TopbarArticles { get; set; }
    public List<Article> Articles { get; set; }
    public List<Category> Categories { get; set; }
    public List<Category> FeaturedCategoris { get; set; }

}
