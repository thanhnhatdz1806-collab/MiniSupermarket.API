using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==========================================
            // 1. NẠP SẴN THƯƠNG HIỆU (10 BRANDS)
            // ==========================================
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, BrandName = "Hồng Lam", OriginRegion = "Hà Nội", Description = "Thương hiệu tinh hoa quà Việt, chuyên ô mai và mứt truyền thống" },
                new Brand { BrandId = 2, BrandName = "Tân Huê Viên", OriginRegion = "Sóc Trăng", Description = "Thương hiệu bánh pía và lạp xưởng nổi tiếng Miền Tây" },
                new Brand { BrandId = 3, BrandName = "Yến Hoàng", OriginRegion = "Bến Tre", Description = "Chuyên kẹo dừa và các sản phẩm chế biến từ dừa nguyên chất" },
                new Brand { BrandId = 4, BrandName = "L'angfarm", OriginRegion = "Đà Lạt", Description = "Đặc sản Đà Lạt, trái cây sấy khô và trà thảo mộc" },
                new Brand { BrandId = 5, BrandName = "Đặc Sản Tây Bắc", OriginRegion = "Hà Giang - Sơn La", Description = "Thịt sấy, gia vị chẩm chéo và nông sản vùng cao" },
                new Brand { BrandId = 6, BrandName = "Bảo Minh", OriginRegion = "Hà Nội", Description = "Chuyên bánh cốm, bánh đậu xanh và bánh kẹo truyền thống Miền Bắc" },
                new Brand { BrandId = 7, BrandName = "Hà Xua", OriginRegion = "Bình Định", Description = "Đặc sản tré rơm, nem chả và thủy hải sản khô Quy Nhơn" },
                new Brand { BrandId = 8, BrandName = "Phú Hương", OriginRegion = "Phú Quốc", Description = "Nước mắm truyền thống và mực khô sấy sa tế Phú Quốc" },
                new Brand { BrandId = 9, BrandName = "Xưởng Ăn Vặt Sài Gòn", OriginRegion = "TP. Hồ Chí Minh", Description = "Cơm cháy chà bông, bánh tráng trộn và các món ăn vặt hiện đại" },
                new Brand { BrandId = 10, BrandName = "Trà Tân Cương", OriginRegion = "Thái Nguyên", Description = "Trà đinh, trà mộc thượng hạng chuẩn vùng Thái Nguyên" }
            );

            // ==========================================
            // 2. NẠP SẴN 15 DANH MỤC (15 CATEGORIES)
            // ==========================================
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Đặc sản Miền Bắc", Description = "Bánh cốm, thịt trâu gắp bếp, ô mai truyền thống" },
                new Category { CategoryId = 2, CategoryName = "Đặc sản Miền Trung", Description = "Mực rim sa tế, tré Bình Định, bánh ép Huế" },
                new Category { CategoryId = 3, CategoryName = "Đặc sản Miền Tây & Nam Bộ", Description = "Bánh pía Sóc Trăng, kẹo dừa Bến Tre, lạp xưởng" },
                new Category { CategoryId = 4, CategoryName = "Trái cây sấy khô & Dẻo", Description = "Mít sấy, xoài sấy dẻo, chuối sấy giòn Đà Lạt" },
                new Category { CategoryId = 5, CategoryName = "Đồ ăn vặt mặn", Description = "Cơm cháy chà bông, khô gà lá chanh, bánh tráng" },
                new Category { CategoryId = 6, CategoryName = "Trà & Thảo mộc vùng miền", Description = "Trà Thái Nguyên, trà sâm dây Ngọc Linh, trà mướp đắng" },
                new Category { CategoryId = 7, CategoryName = "Bánh kẹo truyền thống", Description = "Bánh cốm, bánh đậu xanh, kẹo cu đơ, kẹo chuối" },
                new Category { CategoryId = 8, CategoryName = "Thủy hải sản khô & Rim", Description = "Cá chỉ vàng rim, mực xé hấp nước dừa, tôm khô" },
                new Category { CategoryId = 9, CategoryName = "Gia vị & Nước chấm đặc sản", Description = "Nước mắm Phú Quốc, muối tôm Tây Ninh, chẩm chéo" },
                new Category { CategoryId = 10, CategoryName = "Nước giải khát & Nước trái cây", Description = "Nước dừa tươi đóng lon, nước mủ trôm, nước chanh dây" },
                new Category { CategoryId = 11, CategoryName = "Nông sản & Hạt dinh dưỡng", Description = "Hạt điều Bình Phước, hạt macca Tây Nguyên, sen sấy" },
                new Category { CategoryId = 12, CategoryName = "Rượu & Đồ uống lên men", Description = "Rượu mận Tả Van, rượu mơ Yên Tử, rượu thốt nốt" },
                new Category { CategoryId = 13, CategoryName = "Đặc sản Tây Nguyên", Description = "Cà phê Cầu Đất, tiêu Chư Sê, măng khô Kon Tum" },
                new Category { CategoryId = 14, CategoryName = "Mứt & Trái cây ngâm", Description = "Mứt dâu tây Đà Lạt, dầm sấu, mứt quất hồng giòn" },
                new Category { CategoryId = 15, CategoryName = "Combo & Hộp quà đặc sản", Description = "Bộ quà tặng đặc sản 3 miền, hộp quà Tết vùng miền" }
            );

            // ==========================================
            // 3. NẠP SẴN 15 SẢN PHẨM (15 PRODUCTS)
            // ==========================================
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "8938502000001", ProductName = "Thịt trâu gắp bếp Tây Bắc 200g", Unit = "Gói", Price = 180000, CostPrice = 135000, StockQuantity = 18, MinStockQuantity = 5, IsActive = true, CategoryId = 1, BrandId = 5 },
                new Product { ProductId = 2, Barcode = "8938502000002", ProductName = "Ô mai sấu xào Hồng Lam 300g", Unit = "Hộp", Price = 65000, CostPrice = 45000, StockQuantity = 45, MinStockQuantity = 10, IsActive = true, CategoryId = 1, BrandId = 1 },
                new Product { ProductId = 3, Barcode = "8938502000003", ProductName = "Tré rơm Bình Định (Hộp 10 xâu)", Unit = "Hộp", Price = 110000, CostPrice = 82000, StockQuantity = 20, MinStockQuantity = 5, IsActive = true, CategoryId = 2, BrandId = 7 },
                new Product { ProductId = 4, Barcode = "8938502000004", ProductName = "Mực rim sa tế Quy Nhơn 250g", Unit = "Hũ", Price = 95000, CostPrice = 70000, StockQuantity = 35, MinStockQuantity = 10, IsActive = true, CategoryId = 8, BrandId = 7 },
                new Product { ProductId = 5, Barcode = "8938502000005", ProductName = "Bánh pía trứng chảy Sóc Trăng 400g", Unit = "Túi", Price = 85000, CostPrice = 60000, StockQuantity = 52, MinStockQuantity = 10, IsActive = true, CategoryId = 3, BrandId = 2 },
                new Product { ProductId = 6, Barcode = "8938502000006", ProductName = "Kẹo dừa béo Bến Tre 300g", Unit = "Gói", Price = 45000, CostPrice = 28000, StockQuantity = 75, MinStockQuantity = 15, IsActive = true, CategoryId = 3, BrandId = 3 },
                new Product { ProductId = 7, Barcode = "8938502000007", ProductName = "Xoài sấy dẻo L'angfarm 200g", Unit = "Túi", Price = 55000, CostPrice = 36000, StockQuantity = 50, MinStockQuantity = 10, IsActive = true, CategoryId = 4, BrandId = 4 },
                new Product { ProductId = 8, Barcode = "8938502000008", ProductName = "Mít sấy giòn L'angfarm 150g", Unit = "Túi", Price = 42000, CostPrice = 27000, StockQuantity = 60, MinStockQuantity = 12, IsActive = true, CategoryId = 4, BrandId = 4 },
                new Product { ProductId = 9, Barcode = "8938502000009", ProductName = "Cơm cháy chà bông Sài Gòn 500g", Unit = "Túi", Price = 75000, CostPrice = 48000, StockQuantity = 40, MinStockQuantity = 10, IsActive = true, CategoryId = 5, BrandId = 9 },
                new Product { ProductId = 10, Barcode = "8938502000010", ProductName = "Khô gà xé lá chanh đậm vị 300g", Unit = "Hũ", Price = 68000, CostPrice = 42000, StockQuantity = 38, MinStockQuantity = 8, IsActive = true, CategoryId = 5, BrandId = 9 },
                new Product { ProductId = 11, Barcode = "8938502000011", ProductName = "Trà Thái Nguyên thượng hạng 200g", Unit = "Gói", Price = 120000, CostPrice = 85000, StockQuantity = 32, MinStockQuantity = 5, IsActive = true, CategoryId = 6, BrandId = 10 },
                new Product { ProductId = 12, Barcode = "8938502000012", ProductName = "Bánh cốm Hàng Than Hà Nội 100g", Unit = "Cái", Price = 12000, CostPrice = 8000, StockQuantity = 80, MinStockQuantity = 15, IsActive = true, CategoryId = 7, BrandId = 6 },
                new Product { ProductId = 13, Barcode = "8938502000013", ProductName = "Nước mắm Phú Quốc Phú Hương 500ml", Unit = "Chai", Price = 115000, CostPrice = 85000, StockQuantity = 30, MinStockQuantity = 6, IsActive = true, CategoryId = 9, BrandId = 8 },
                new Product { ProductId = 14, Barcode = "8938502000014", ProductName = "Nước dừa tươi đóng lon Bến Tre 330ml", Unit = "Lon", Price = 18000, CostPrice = 11000, StockQuantity = 120, MinStockQuantity = 24, IsActive = true, CategoryId = 10, BrandId = 3 },
                new Product { ProductId = 15, Barcode = "8938502000015", ProductName = "Hạt điều rang muối Bình Phước 500g", Unit = "Hũ", Price = 165000, CostPrice = 120000, StockQuantity = 25, MinStockQuantity = 5, IsActive = true, CategoryId = 11, BrandId = null }
            );

            // ==========================================
            // 4. NẠP SẴN 15 KHÁCH HÀNG (15 CUSTOMERS)
            // ==========================================
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn A", PhoneNumber = "0901122334", Address = "123 Lê Lợi, Q.1, TP.HCM", MembershipRank = "Vàng", RewardPoints = 210 },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị B", PhoneNumber = "0918877665", Address = "456 Nguyễn Trãi, Q.5, TP.HCM", MembershipRank = "Bạc", RewardPoints = 85 },
                new Customer { CustomerId = 3, CustomerName = "Lê Văn C", PhoneNumber = "0983344556", Address = "78 Điện Biên Phủ, Q.3, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 25 },
                new Customer { CustomerId = 4, CustomerName = "Phạm Thị D", PhoneNumber = "0934567890", Address = "12 Cách Mạng Tháng 8, Q.10, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 540 },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Minh E", PhoneNumber = "0971122444", Address = "89 Hoàng Văn Thụ, Q.Phú Nhuận, TP.HCM", MembershipRank = "Bạc", RewardPoints = 110 },
                new Customer { CustomerId = 6, CustomerName = "Đỗ Thu F", PhoneNumber = "0909988776", Address = "204 Nguyễn Thị Minh Khai, Q.3, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 15 },
                new Customer { CustomerId = 7, CustomerName = "Vũ Quốc G", PhoneNumber = "0945112233", Address = "55 Phan Đăng Lưu, Q.Bình Thạnh, TP.HCM", MembershipRank = "Vàng", RewardPoints = 320 },
                new Customer { CustomerId = 8, CustomerName = "Đặng Mai H", PhoneNumber = "0966778899", Address = "15 Nguyễn Hữu Cảnh, Q.Bình Thạnh, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 0 },
                new Customer { CustomerId = 9, CustomerName = "Bùi Anh Khoa", PhoneNumber = "0931223344", Address = "88 Lý Thường Kiệt, Q.10, TP.HCM", MembershipRank = "Bạc", RewardPoints = 95 },
                new Customer { CustomerId = 10, CustomerName = "Ngô Bích Ngọc", PhoneNumber = "0978990011", Address = "302 Võ Văn Tần, Q.3, TP.HCM", MembershipRank = "Vàng", RewardPoints = 280 },
                new Customer { CustomerId = 11, CustomerName = "Trịnh Quốc Bảo", PhoneNumber = "0903445566", Address = "12 Trần Hưng Đạo, Q.1, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 40 },
                new Customer { CustomerId = 12, CustomerName = "Lý Mỹ Duyên", PhoneNumber = "0915667788", Address = "74 Ba Tháng Hai, Q.10, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 610 },
                new Customer { CustomerId = 13, CustomerName = "Đoàn Tấn Phát", PhoneNumber = "0982114455", Address = "450 Xô Viết Nghệ Tĩnh, Q.Bình Thạnh, TP.HCM", MembershipRank = "Bạc", RewardPoints = 130 },
                new Customer { CustomerId = 14, CustomerName = "Dương Khánh Linh", PhoneNumber = "0947889900", Address = "19 An Dương Vương, Q.5, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 10 },
                new Customer { CustomerId = 15, CustomerName = "Phan Hoài Nam", PhoneNumber = "0963221100", Address = "500 Cộng Hòa, Q.Tân Bình, TP.HCM", MembershipRank = "Vàng", RewardPoints = 190 }
            );

            // ==========================================
            // 5. NẠP SẴN ĐƠN HÀNG (ORDERS)
            // ==========================================
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderDate = new DateTime(2026, 3, 20, 10, 30, 0), TotalAmount = 265000, PaymentStatus = "Paid", PaymentMethod = "Banking", CustomerId = 1 },
                new Order { OrderId = 2, OrderDate = new DateTime(2026, 3, 22, 14, 15, 0), TotalAmount = 130000, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 2 },
                new Order { OrderId = 3, OrderDate = new DateTime(2026, 3, 25, 9, 0, 0), TotalAmount = 350000, PaymentStatus = "Paid", PaymentMethod = "QR Code", CustomerId = 4 },
                new Order { OrderId = 4, OrderDate = new DateTime(2026, 3, 27, 16, 45, 0), TotalAmount = 97000, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 3 }
            );

            // ==========================================
            // 6. NẠP SẴN CHI TIẾT ĐƠN HÀNG (ORDER DETAILS)
            // ==========================================
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 180000 },
                new OrderDetail { OrderDetailId = 2, OrderId = 1, ProductId = 5, Quantity = 1, UnitPrice = 85000 },
                new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 2, Quantity = 2, UnitPrice = 65000 },
                new OrderDetail { OrderDetailId = 4, OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 110000 },
                new OrderDetail { OrderDetailId = 5, OrderId = 4, ProductId = 6, Quantity = 1, UnitPrice = 45000 }
            );

            // ==========================================
            // 7. NẠP SẴN NHẬT KÝ KHO (INVENTORY LOGS)
            // ==========================================
            modelBuilder.Entity<InventoryLog>().HasData(
                new InventoryLog
                {
                    LogId = 1,
                    ProductId = 1,
                    TransactionType = "IMPORT",
                    QuantityChange = 20,
                    TransactionDate = new DateTime(2026, 3, 1, 8, 0, 0),
                    BatchNumber = "LOT-TB-20260301",
                    ExpirationDate = new DateTime(2026, 9, 1),
                    Note = "Nhập kho lô thịt trâu gắp bếp Tây Bắc"
                },
                new InventoryLog
                {
                    LogId = 2,
                    ProductId = 5,
                    TransactionType = "IMPORT",
                    QuantityChange = 60,
                    TransactionDate = new DateTime(2026, 3, 5, 9, 30, 0),
                    BatchNumber = "LOT-THV-20260305",
                    ExpirationDate = new DateTime(2026, 6, 5),
                    Note = "Nhập kho bánh pía Tân Huê Viên"
                }
            );

            // ==========================================
            // 8. NẠP SẴN NHÀ CUNG CẤP (SUPPLIERS)
            // ==========================================
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, SupplierName = "Công ty TNHH Đặc Sản Tây Bắc", ContactName = "Nguyễn Văn Hùng", PhoneNumber = "0988111222", Address = "Thành phố Sơn La, Tỉnh Sơn La", OriginRegion = "Sơn La - Hà Giang" },
                new Supplier { SupplierId = 2, SupplierName = "Cơ sở Sản xuất Ô mai Hồng Lam", ContactName = "Trần Thu Hà", PhoneNumber = "0912333444", Address = "KCN Quang Minh, Mê Linh, Hà Nội", OriginRegion = "Hà Nội" },
                new Supplier { SupplierId = 3, SupplierName = "Công ty TNHH Bánh Pía Tân Huê Viên", ContactName = "Thái Tuấn", PhoneNumber = "02993888999", Address = "Quy Đức, Châu Thành, Sóc Trăng", OriginRegion = "Sóc Trăng" },
                new Supplier { SupplierId = 4, SupplierName = "Xưởng Kẹo Dừa Bến Tre Yến Hoàng", ContactName = "Lê Thị Lan", PhoneNumber = "0903555666", Address = "Mỏ Cày Bắc, Bến Tre", OriginRegion = "Bến Tre" },
                new Supplier { SupplierId = 5, SupplierName = "Nông Sản Sấy L'angfarm Đà Lạt", ContactName = "Phạm Quốc Bảo", PhoneNumber = "02633888777", Address = "Phường 10, TP. Đà Lạt, Lâm Đồng", OriginRegion = "Đà Lạt" }
            );

            // ==========================================
            // 9. NẠP SẴN TÀI KHOẢN NGƯỜI DÙNG (USERS)
            // ==========================================
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", PasswordHash = "admin123_hash", FullName = "Quản Lý Cửa Hàng", Role = "Admin", IsActive = true },
                new User { UserId = 2, Username = "cashier01", PasswordHash = "cashier123_hash", FullName = "Thu Ngân - Nguyễn Mai", Role = "Cashier", IsActive = true },
                new User { UserId = 3, Username = "warehouse01", PasswordHash = "warehouse123_hash", FullName = "Thủ Kho - Trần Tuấn", Role = "Warehouse", IsActive = true }
            );

            // ==========================================
            // 10. NẠP SẴN KHUYẾN MÃI (PROMOTIONS)
            // ==========================================
            modelBuilder.Entity<Promotion>().HasData(
                new Promotion { PromotionId = 1, Code = "DACSAN10K", Description = "Giảm 10.000 VNĐ cho đơn hàng đặc sản từ 200.000 VNĐ", DiscountAmount = 10000, DiscountPercent = 0, StartDate = new DateTime(2026, 3, 1), EndDate = new DateTime(2026, 4, 30), IsActive = true },
                new Promotion { PromotionId = 2, Code = "ANVAT10", Description = "Giảm 10% cho tất cả đơn hàng đồ ăn vặt sấy khô", DiscountAmount = 0, DiscountPercent = 10, StartDate = new DateTime(2026, 3, 15), EndDate = new DateTime(2026, 4, 15), IsActive = true },
                new Promotion { PromotionId = 3, Code = "TET2026", Description = "Chương trình quà tặng đặc sản mừng lễ", DiscountAmount = 20000, DiscountPercent = 0, StartDate = new DateTime(2026, 1, 1), EndDate = new DateTime(2026, 2, 28), IsActive = false }
            );
        }
    }
}