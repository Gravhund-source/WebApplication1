using System;
using System.Collections.Generic;

namespace WebApplication1.Areas.Database.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string User1 { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
