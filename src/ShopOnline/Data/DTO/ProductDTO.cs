namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductDTO
    {
        public int ID { get; set; }

        [Display(Name = "Mã sản phẩm")]
        [StringLength(12)]
        public string Code { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name="Danh mục")]
        [Required]
        public int? CategoryID { get; set; }

        [Display(Name="Nhà cung cấp")]
        [Required]
        public int? SupplierID { get; set; }

        [Display(Name="Ảnh mô tả")]
        [StringLength(256)]
        public string UrlImage { get; set; }

        [Display(Name="Giá nhập")]
        public double? ImportPrice { get; set; }

        [Display(Name="Giá bán")]
        public double? ExportPrice { get; set; }

        [Display(Name="Mô tả sản phẩm")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Display(Name="Giảm giá")]
        [Range(0,100,ErrorMessage ="Giảm giá trong khoảng 0-100%")]
        public double? Discount { get; set; }

        [Display(Name="Tổng mua")]
        public int? TotalPurchase { get; set; }

        [Display(Name ="Tổng bán")]
        public int? TotalInventory { get; set; }

        [Display(Name ="Trạng thái")]
        public bool? Status { get; set; }

        [Display(Name = "Hiển thị trên trang chủ")]
        public bool? ShowOnHome { get; set; }

        public virtual ICollection<ImageDetail> ImageDetails { get; set; }
        public virtual Category Category { get; set; }
        public virtual Suppelier Suppelier { get; set; }
    }
}
