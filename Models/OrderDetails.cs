using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gift_Auth.Models
{
    public partial class OrderDetails
    {
        public int OrderDetId { get; set; }
        public int OrderId { get; set; }
        public int GiftId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
