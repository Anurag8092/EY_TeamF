using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gift_Auth.Models
{
    public partial class Gifts
    {
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
        public string GiftImg { get; set; }
    }
}
