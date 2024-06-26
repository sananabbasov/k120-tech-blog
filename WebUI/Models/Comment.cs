using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models;

public class Comment
{
    public int Id { get; set; }
    public string Reply { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int ArticleId { get; set; }
    public Article Article { get; set; }
    public DateTime CreatedDate { get; set; }
}
