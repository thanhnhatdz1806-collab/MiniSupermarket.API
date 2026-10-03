using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MiniSupermarket.API.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [StringLength(50, ErrorMessage = "Trạng thái thanh toán không vượt quá 50 ký tự")]
        public string PaymentStatus { get; set; } = "Paid"; // Paid, Pending, Cancelled

        [StringLength(50)]
        public string PaymentMethod { get; set; } = "Cash"; // Cash, Banking, QR, Card

        // Foreign Key: Khách hàng (có thể null nếu khách lẻ không đăng ký)
        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        // Quan hệ 1 - N: Một hóa đơn có nhiều chi tiết hóa đơn
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}