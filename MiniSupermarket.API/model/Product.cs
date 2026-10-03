using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MiniSupermarket.API.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Mã vạch sản phẩm không được để trống")]
        [StringLength(50)]
        public string Barcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(30)]
        public string Unit { get; set; } = "Gói"; // Đơn vị tính: Gói, Hộp, Hũ, KG, Xâu...

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Giá bán

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; } // Giá vốn (Nhập vào) để tính lợi nhuận

        public int StockQuantity { get; set; } // Số lượng tồn kho hiện tại

        public int MinStockQuantity { get; set; } = 5; // Ngưỡng tồn kho tối thiểu để cảnh báo nhập hàng

        [StringLength(500)]
        public string? ImageUrl { get; set; } // Link ảnh sản phẩm

        public bool IsActive { get; set; } = true; // Trạng thái: true (Đang bán), false (Ngừng kinh doanh)

        // Foreign Key: Khóa ngoại liên kết tới bảng Categories
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        // Foreign Key: Khóa ngoại liên kết tới bảng Brands (Cho phép null nếu không rõ thương hiệu)
        public int? BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        // Quan hệ 1 - N tới OrderDetail và InventoryLog
        [JsonIgnore]
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

        [JsonIgnore]
        public virtual ICollection<InventoryLog>? InventoryLogs { get; set; }
    }
}