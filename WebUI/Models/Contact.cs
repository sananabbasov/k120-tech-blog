using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models;

public class Contact
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
}
