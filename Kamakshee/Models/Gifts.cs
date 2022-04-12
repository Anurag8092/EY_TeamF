using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gifties.Models
{
    public partial class Gifts
    {
        public int PkGiftId { get; set; }
        public string GiftName { get; set; }
        public decimal? GiftPrice { get; set; }
        public int? GiftQuantity { get; set; }
        public byte[] Image { get; set; }
        public int? FkGiftCategoryId { get; set; }

        public virtual GiftCategory FkGiftCategory { get; set; }
    }
}
