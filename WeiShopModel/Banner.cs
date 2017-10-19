namespace WeiShopModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Image { get; set; }

        [Required]
        [StringLength(100)]
        public string Link { get; set; }

        [Column(TypeName = "text")]
        public string Memo { get; set; }

        public int PostUserId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
