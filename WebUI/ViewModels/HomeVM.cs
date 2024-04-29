using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewModels;

public class HomeVM
{
    public List<Article> PopularArticles { get; set; }
    public List<Article> RecentArticles { get; set; }
    public List<Article> PopularArticleOne { get; set; }
    public List<Article> PopularArticleTwo { get; set; }

}
