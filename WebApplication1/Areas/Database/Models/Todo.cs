using System;
using System.Collections.Generic;

namespace WebApplication1.Areas.Database.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Description { get; set; }
    }
}
