using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gift_Auth.Models
{
    public partial class LoginUser
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuth { get; set; }
    }
}
