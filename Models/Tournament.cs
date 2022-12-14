using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models
{
    public partial class Tournament
    {
        public string Name { get; set; }

        public DateTime Date  { get; set; }
        public string Place { get; set; }
        public string Status { get; set; }
    }
}
