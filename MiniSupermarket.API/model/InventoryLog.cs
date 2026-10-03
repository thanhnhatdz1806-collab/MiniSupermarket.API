using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    [Table("InventoryLogs")]
    public class InventoryLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [Required(ErrorMessage = "Loại giao dịch không được để trống")]
        [StringLength(20)]
        public string TransactionType { get; set; } = string.Empty; // "IMPORT" (Nhập), "EXPORT" (Bán/Xuất), "ADJUSTMENT" (Kểm kê/Hao hụt)

        public int QuantityChange { get; set; } // Số lượng thay đổi (+10 nhập kho, -2 bán ra)

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // Quản lý chất lượng đặc sản (Hạn sử dụng & Mã lô)
        [StringLength(50)]
        public string? BatchNumber { get; set; } // Mã lô hàng

        public DateTime? ExpirationDate { get; set; } // Hạn sử dụng của lô đặc sản này

        [StringLength(255)]
        public string? Note { get; set; } // Ghi chú (Ví dụ: Nhập hàng từ nhà cung cấp Tây Bắc, Hàng hỏng/Hết hạn...)
    }
}