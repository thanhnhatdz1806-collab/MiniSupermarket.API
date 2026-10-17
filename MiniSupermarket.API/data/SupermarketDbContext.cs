using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    // DbContext đại diện cho phiên làm việc với cơ sở dữ liệu SQL Server
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        // Khai báo các bảng dữ liệu ánh xạ từ Model
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================= RÀNG BUỘC & QUAN HỆ =================

            // Chống trùng
            modelBuilder.Entity<Category>().HasIndex(c => c.CategoryName).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(b => b.BrandName).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Barcode).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.PhoneNumber).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(o => o.OrderCode).IsUnique();

            // Product
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasOne(p => p.Brand).WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasOne(p => p.Supplier).WithMany()
                .HasForeignKey(p => p.SupplierId).OnDelete(DeleteBehavior.SetNull);

            // User - Role
            modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId).OnDelete(DeleteBehavior.Restrict);

            // Order
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany()
                .HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>().HasOne(o => o.Cashier).WithMany()
                .HasForeignKey(o => o.CashierId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderItem>().HasOne(i => i.Product).WithMany()
                .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Restrict);

            // ================= DỮ LIỆU MẪU (SEED) =================
            // Lưu ý: HasData cần giá trị cố định (không dùng DateTime.UtcNow, không hash lúc chạy)

            // ---------- Roles (3 vai trò) ----------
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "ADMIN" },
                new Role { RoleId = 2, RoleName = "WAREHOUSE" },
                new Role { RoleId = 3, RoleName = "CASHIER" }
            );
            // ---------- Categories (15) ----------
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Đặc sản miền Bắc",
                    Description = "Các đặc sản miền Bắc như bánh đậu xanh, cốm, ô mai, chè Thái Nguyên và các món ăn truyền thống."
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Đặc sản miền Trung",
                    Description = "Các đặc sản miền Trung như tré, nem chua, chả bò Đà Nẵng, mè xửng Huế và bánh tráng."
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Đặc sản miền Nam",
                    Description = "Các đặc sản miền Nam như bánh pía Sóc Trăng, kẹo dừa Bến Tre, khô cá và các loại bánh dân gian."
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Bánh kẹo truyền thống",
                    Description = "Các loại bánh kẹo truyền thống Việt Nam như bánh đậu xanh, bánh cốm, kẹo dừa và kẹo lạc."
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Snack & Đồ ăn vặt",
                    Description = "Các món ăn vặt phổ biến như snack khoai tây, bánh que, rong biển ăn liền và bánh phồng."
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Khô gà & Khô bò",
                    Description = "Các sản phẩm khô gà lá chanh, khô bò miếng, khô bò sợi và các loại thịt khô tẩm gia vị."
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Khô cá & Hải sản khô",
                    Description = "Các loại khô cá, mực khô, cá chỉ vàng, tôm khô và hải sản khô đặc sản vùng miền."
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "Mứt & Trái cây sấy",
                    Description = "Các loại mứt trái cây, chuối sấy, mít sấy, xoài sấy và trái cây sấy dẻo."
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Hạt & Đậu ăn vặt",
                    Description = "Các loại hạt điều, đậu phộng, hạt bí, hạt hướng dương và đậu rang tẩm gia vị."
                },
                new Category
                {
                    CategoryId = 10,
                    CategoryName = "Trà & Cà phê đặc sản",
                    Description = "Trà Thái Nguyên, trà sen, cà phê Buôn Ma Thuột và các sản phẩm trà, cà phê vùng miền."
                },
                new Category
                {
                    CategoryId = 11,
                    CategoryName = "Gia vị & Nước chấm",
                    Description = "Các loại nước mắm, mắm đặc sản, muối tôm Tây Ninh, sa tế và gia vị truyền thống."
                },
                new Category
                {
                    CategoryId = 12,
                    CategoryName = "Mì & Đồ ăn liền",
                    Description = "Các sản phẩm mì, miến, bún khô, phở khô và đồ ăn liền tiện lợi."
                },
                new Category
                {
                    CategoryId = 13,
                    CategoryName = "Đặc sản đóng hộp",
                    Description = "Các loại đặc sản được đóng hộp hoặc đóng gói như cá hộp, pate, thịt chế biến và thực phẩm tiện lợi."
                },
                new Category
                {
                    CategoryId = 14,
                    CategoryName = "Đồ uống & Nước giải khát",
                    Description = "Các loại nước giải khát, nước trái cây, nước dừa, nước sâm và đồ uống đặc sản vùng miền."
                },
                new Category
                {
                    CategoryId = 15,
                    CategoryName = "Combo quà tặng đặc sản",
                    Description = "Các combo bánh kẹo, trà, cà phê, hạt dinh dưỡng và đặc sản vùng miền dùng làm quà biếu."
                }
            );

            // ---------- Brands (15) ----------
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Đặc Sản Việt",
                    Country = "Việt Nam",
                    Description = "Thương hiệu chuyên cung cấp các loại đặc sản truyền thống từ nhiều vùng miền.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 2,
                    BrandName = "Bánh Pía Tân Huê Viên",
                    Country = "Việt Nam",
                    Description = "Thương hiệu bánh pía và các loại bánh đặc sản Sóc Trăng.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 3,
                    BrandName = "Kẹo Dừa Bến Tre",
                    Country = "Việt Nam",
                    Description = "Thương hiệu đặc sản nổi tiếng với các loại kẹo dừa truyền thống.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 4,
                    BrandName = "Ô Mai Hồng Lam",
                    Country = "Việt Nam",
                    Description = "Thương hiệu chuyên các sản phẩm ô mai và trái cây chế biến.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 5,
                    BrandName = "Bánh Đậu Xanh Rồng Vàng",
                    Country = "Việt Nam",
                    Description = "Thương hiệu bánh đậu xanh đặc sản Hải Dương.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 6,
                    BrandName = "Tây Ninh",
                    Country = "Việt Nam",
                    Description = "Thương hiệu và nguồn cung các sản phẩm muối tôm, muối chấm và gia vị đặc sản Tây Ninh.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 7,
                    BrandName = "Trung Nguyên Legend",
                    Country = "Việt Nam",
                    Description = "Thương hiệu cà phê Việt Nam với các dòng cà phê rang xay và cà phê hòa tan.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 8,
                    BrandName = "Tân Cương Xanh",
                    Country = "Việt Nam",
                    Description = "Thương hiệu trà xanh và trà đặc sản Thái Nguyên.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 9,
                    BrandName = "Bình Định",
                    Country = "Việt Nam",
                    Description = "Nguồn đặc sản địa phương gồm bánh tráng, bánh ít và các sản phẩm truyền thống.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 10,
                    BrandName = "Vissan",
                    Country = "Việt Nam",
                    Description = "Thương hiệu thực phẩm chế biến, xúc xích và các sản phẩm thịt đóng gói.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 11,
                    BrandName = "Kinh Đô",
                    Country = "Việt Nam",
                    Description = "Thương hiệu bánh kẹo với nhiều dòng bánh quy, bánh bông lan và bánh ăn nhẹ.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 12,
                    BrandName = "Bibica",
                    Country = "Việt Nam",
                    Description = "Thương hiệu bánh kẹo và thực phẩm ăn nhẹ phục vụ nhu cầu tiêu dùng hàng ngày.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 13,
                    BrandName = "Orion",
                    Country = "Hàn Quốc",
                    Description = "Thương hiệu bánh snack, bánh quy và các sản phẩm ăn vặt đóng gói.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 14,
                    BrandName = "Oishi",
                    Country = "Philippines",
                    Description = "Thương hiệu snack, bánh que và các sản phẩm ăn vặt đóng gói.",
                    IsActive = true
                },
                new Brand
                {
                    BrandId = 15,
                    BrandName = "Mekong Food",
                    Country = "Việt Nam",
                    Description = "Thương hiệu phục vụ nhóm đặc sản miền Tây, trái cây sấy và thực phẩm đóng gói.",
                    IsActive = true
                }
            );

            modelBuilder.Entity<Supplier>().HasData(
     new Supplier
     {
         SupplierId = 1,
         SupplierName = "Công ty TNHH Đặc sản Tây Bắc Việt",
         PhoneNumber = "02633812345",
         Email = "contact@dacsantaybac.vn",
         Address = "12 Điện Biên Phủ, TP. Sơn La, Sơn La"
     },
     new Supplier
     {
         SupplierId = 2,
         SupplierName = "Công ty CP Đặc sản Miền Trung",
         PhoneNumber = "02838123456",
         Email = "kinhdoanh@dacsanmientrung.vn",
         Address = "45 Nguyễn Văn Linh, TP. Đà Nẵng"
     },
     new Supplier
     {
         SupplierId = 3,
         SupplierName = "Công ty TNHH Đặc sản Miền Tây",
         PhoneNumber = "02838234567",
         Email = "lienhe@dacsanmientay.vn",
         Address = "28 Nguyễn Trãi, TP. Cần Thơ"
     },
     new Supplier
     {
         SupplierId = 4,
         SupplierName = "Công ty TNHH Bánh kẹo truyền thống Việt",
         PhoneNumber = "02838345678",
         Email = "banhang@banhkeotruyenthong.vn",
         Address = "86 Trần Hưng Đạo, TP. Hải Dương, Hải Dương"
     },
     new Supplier
     {
         SupplierId = 5,
         SupplierName = "Cơ sở sản xuất Snack Việt",
         PhoneNumber = "02438456789",
         Email = "snackviet@example.vn",
         Address = "21 Lê Duẩn, TP. Hồ Chí Minh"
     },
     new Supplier
     {
         SupplierId = 6,
         SupplierName = "Công ty TNHH Thực phẩm khô Việt",
         PhoneNumber = "02838567890",
         Email = "sales@thucphamkho.example.vn",
         Address = "77 Nguyễn Huệ, TP. Quy Nhơn, Bình Định"
     },
     new Supplier
     {
         SupplierId = 7,
         SupplierName = "Cơ sở Hải sản khô Phú Quốc",
         PhoneNumber = "02916678901",
         Email = "haisan@phuquoc.example.vn",
         Address = "18 Trần Hưng Đạo, TP. Phú Quốc, Kiên Giang"
     },
     new Supplier
     {
         SupplierId = 8,
         SupplierName = "Công ty CP Trái cây sấy Việt",
         PhoneNumber = "02838789012",
         Email = "info@traicaysay.example.vn",
         Address = "52 Cách Mạng Tháng Tám, TP. Hồ Chí Minh"
     },
     new Supplier
     {
         SupplierId = 9,
         SupplierName = "Hợp tác xã Hạt điều Bình Phước",
         PhoneNumber = "02723890123",
         Email = "htx@hatdieubp.example.vn",
         Address = "35 Quốc lộ 14, TP. Đồng Xoài, Bình Phước"
     },
     new Supplier
     {
         SupplierId = 10,
         SupplierName = "Công ty TNHH Trà đặc sản Thái Nguyên",
         PhoneNumber = "02633901234",
         Email = "tra@thainguyen.example.vn",
         Address = "16 Hoàng Văn Thụ, TP. Thái Nguyên, Thái Nguyên"
     },
     new Supplier
     {
         SupplierId = 11,
         SupplierName = "Công ty TNHH Gia vị Tây Ninh",
         PhoneNumber = "02838012345",
         Email = "giavi@tayninh.example.vn",
         Address = "60 Cách Mạng Tháng Tám, TP. Tây Ninh, Tây Ninh"
     },
     new Supplier
     {
         SupplierId = 12,
         SupplierName = "Công ty CP Thực phẩm khô An Giang",
         PhoneNumber = "02838123400",
         Email = "thucpham@angiang.example.vn",
         Address = "90 Trần Hưng Đạo, TP. Long Xuyên, An Giang"
     },
     new Supplier
     {
         SupplierId = 13,
         SupplierName = "Cơ sở Đặc sản đóng hộp Việt",
         PhoneNumber = "02923678901",
         Email = "dacsandonghop@example.vn",
         Address = "25 Nguyễn Văn Cừ, TP. Hồ Chí Minh"
     },
     new Supplier
     {
         SupplierId = 14,
         SupplierName = "Công ty TNHH Đồ uống đặc sản Việt",
         PhoneNumber = "02839876543",
         Email = "douong@dacsan.example.vn",
         Address = "40 Phan Đình Phùng, TP. Bảo Lộc, Lâm Đồng"
     },
     new Supplier
     {
         SupplierId = 15,
         SupplierName = "Công ty CP Quà tặng đặc sản Việt Nam",
         PhoneNumber = "02743781234",
         Email = "quatang@dacsan.example.vn",
         Address = "100 Nguyễn Huệ, TP. Hồ Chí Minh"
     }
 );

            // ---------- Products (17) ----------
            modelBuilder.Entity<Product>().HasData(
                // Category 1 - Đặc sản miền Bắc
                new Product
                {
                    ProductId = 1,
                    Barcode = "8938501234561",
                    ProductName = "Bánh đậu xanh Rồng Vàng 200g",
                    Unit = "hộp",
                    Price = 45000,
                    CostPrice = 32000,
                    StockQuantity = 35,
                    IsActive = true,
                    CategoryId = 1,
                    BrandId = 5,
                    SupplierId = 4
                },
                new Product
                {
                    ProductId = 2,
                    Barcode = "8938501234562",
                    ProductName = "Ô mai mơ Hồng Lam 250g",
                    Unit = "hộp",
                    Price = 65000,
                    CostPrice = 45000,
                    StockQuantity = 28,
                    IsActive = true,
                    CategoryId = 1,
                    BrandId = 4,
                    SupplierId = 4
                },

                // Category 2 - Đặc sản miền Trung
                new Product
                {
                    ProductId = 3,
                    Barcode = "8938501234563",
                    ProductName = "Mè xửng Huế truyền thống 300g",
                    Unit = "gói",
                    Price = 38000,
                    CostPrice = 26000,
                    StockQuantity = 42,
                    IsActive = true,
                    CategoryId = 2,
                    BrandId = 1,
                    SupplierId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Barcode = "8938501234564",
                    ProductName = "Bánh tráng mè Bình Định 500g",
                    Unit = "gói",
                    Price = 42000,
                    CostPrice = 29000,
                    StockQuantity = 50,
                    IsActive = true,
                    CategoryId = 2,
                    BrandId = 9,
                    SupplierId = 2
                },

                // Category 3 - Đặc sản miền Nam
                new Product
                {
                    ProductId = 5,
                    Barcode = "8938501234565",
                    ProductName = "Kẹo dừa Bến Tre 300g",
                    Unit = "gói",
                    Price = 35000,
                    CostPrice = 24000,
                    StockQuantity = 45,
                    IsActive = true,
                    CategoryId = 3,
                    BrandId = 3,
                    SupplierId = 3
                },
                new Product
                {
                    ProductId = 6,
                    Barcode = "8938501234566",
                    ProductName = "Bánh pía Tân Huê Viên 400g",
                    Unit = "hộp",
                    Price = 78000,
                    CostPrice = 56000,
                    StockQuantity = 24,
                    IsActive = true,
                    CategoryId = 3,
                    BrandId = 2,
                    SupplierId = 3
                },

                // Category 4 - Bánh kẹo truyền thống
                new Product
                {
                    ProductId = 7,
                    Barcode = "8938501234567",
                    ProductName = "Bánh quy bơ truyền thống 250g",
                    Unit = "hộp",
                    Price = 52000,
                    CostPrice = 36000,
                    StockQuantity = 32,
                    IsActive = true,
                    CategoryId = 4,
                    BrandId = 11,
                    SupplierId = 4
                },
                new Product
                {
                    ProductId = 8,
                    Barcode = "8938501234568",
                    ProductName = "Snack khoai tây vị truyền thống gói 150g",
                    Unit = "gói",
                    Price = 28000,
                    CostPrice = 18000,
                    StockQuantity = 60,
                    IsActive = true,
                    CategoryId = 5,
                    BrandId = 13,
                    SupplierId = 5
                },

                // Category 5 - Snack & Đồ ăn vặt
                new Product
                {
                    ProductId = 9,
                    Barcode = "8938501234569",
                    ProductName = "Khô gà lá chanh 200g",
                    Unit = "hộp",
                    Price = 65000,
                    CostPrice = 45000,
                    StockQuantity = 40,
                    IsActive = true,
                    CategoryId = 6,
                    BrandId = 1,
                    SupplierId = 6
                },
                new Product
                {
                    ProductId = 10,
                    Barcode = "8938501234570",
                    ProductName = "Khô bò miếng đặc biệt 100g",
                    Unit = "gói",
                    Price = 85000,
                    CostPrice = 62000,
                    StockQuantity = 25,
                    IsActive = true,
                    CategoryId = 6,
                    BrandId = 1,
                    SupplierId = 6
                },

                // Category 6 - Khô gà & Khô bò
                new Product
                {
                    ProductId = 11,
                    Barcode = "8938501234571",
                    ProductName = "Mực khô loại vừa 250g",
                    Unit = "gói",
                    Price = 185000,
                    CostPrice = 145000,
                    StockQuantity = 18,
                    IsActive = true,
                    CategoryId = 7,
                    BrandId = 1,
                    SupplierId = 7
                },

                // Category 7 - Khô cá & Hải sản khô
                new Product
                {
                    ProductId = 12,
                    Barcode = "8938501234572",
                    ProductName = "Cá chỉ vàng khô 500g",
                    Unit = "gói",
                    Price = 125000,
                    CostPrice = 92000,
                    StockQuantity = 22,
                    IsActive = true,
                    CategoryId = 7,
                    BrandId = 1,
                    SupplierId = 7
                },

                // Category 8 - Mứt & Trái cây sấy
                new Product
                {
                    ProductId = 13,
                    Barcode = "8938501234573",
                    ProductName = "Mít sấy giòn 200g",
                    Unit = "gói",
                    Price = 55000,
                    CostPrice = 38000,
                    StockQuantity = 35,
                    IsActive = true,
                    CategoryId = 8,
                    BrandId = 15,
                    SupplierId = 8
                },

                // Category 9 - Hạt & Đậu ăn vặt
                new Product
                {
                    ProductId = 14,
                    Barcode = "8938501234574",
                    ProductName = "Hạt điều rang muối Bình Phước 250g",
                    Unit = "hộp",
                    Price = 95000,
                    CostPrice = 70000,
                    StockQuantity = 30,
                    IsActive = true,
                    CategoryId = 9,
                    BrandId = 12,
                    SupplierId = 9
                },

                // Category 10 - Trà & Cà phê đặc sản
                new Product
                {
                    ProductId = 15,
                    Barcode = "8938501234575",
                    ProductName = "Trà xanh Thái Nguyên 200g",
                    Unit = "gói",
                    Price = 68000,
                    CostPrice = 48000,
                    StockQuantity = 26,
                    IsActive = true,
                    CategoryId = 10,
                    BrandId = 8,
                    SupplierId = 10
                },

                // Category 11 - Gia vị & Nước chấm
                new Product
                {
                    ProductId = 16,
                    Barcode = "8938501234576",
                    ProductName = "Muối tôm Tây Ninh 200g",
                    Unit = "hũ",
                    Price = 32000,
                    CostPrice = 21000,
                    StockQuantity = 55,
                    IsActive = true,
                    CategoryId = 11,
                    BrandId = 6,
                    SupplierId = 11
                },

                // Category 12 - Mì & Đồ ăn liền
                new Product
                {
                    ProductId = 17,
                    Barcode = "8938501234577",
                    ProductName = "Miến dong đặc sản 500g",
                    Unit = "gói",
                    Price = 48000,
                    CostPrice = 33000,
                    StockQuantity = 38,
                    IsActive = true,
                    CategoryId = 12,
                    BrandId = 14,
                    SupplierId = 12
                }
            );

            // ---------- Customers (15) ----------
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Nguyễn Văn A",
                    PhoneNumber = "0901122334",
                    Address = "59 Nguyễn Thị Minh Khai, Phường Võ Thị Sáu, Quận 3, TP. Hồ Chí Minh",
                    MembershipRank = "Vàng",
                    RewardPoints = 150
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Trần Thị B",
                    PhoneNumber = "0918877665",
                    Address = "120 Võ Văn Tần, Phường Võ Thị Sáu, Quận 3, TP. Hồ Chí Minh",
                    MembershipRank = "Bạc",
                    RewardPoints = 50
                },
                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Lê Văn C",
                    PhoneNumber = "0983344556",
                    Address = "15 Lý Thường Kiệt, Phường 14, Quận 10, TP. Hồ Chí Minh",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 10
                },
                new Customer
                {
                    CustomerId = 4,
                    CustomerName = "Phạm Minh Tuấn",
                    PhoneNumber = "0905123456",
                    Address = "12 Nguyễn Huệ, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh",
                    MembershipRank = "Vàng",
                    RewardPoints = 180
                },
                new Customer
                {
                    CustomerId = 5,
                    CustomerName = "Hoàng Thị Lan",
                    PhoneNumber = "0912345678",
                    Address = "45 Lê Lợi, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh",
                    MembershipRank = "Bạc",
                    RewardPoints = 75
                },
                new Customer
                {
                    CustomerId = 6,
                    CustomerName = "Võ Quốc Bảo",
                    PhoneNumber = "0937654321",
                    Address = "8 Trần Hưng Đạo, Phường 6, Quận 5, TP. Hồ Chí Minh",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 20
                },
                new Customer
                {
                    CustomerId = 7,
                    CustomerName = "Đặng Thu Hà",
                    PhoneNumber = "0944556677",
                    Address = "102 Điện Biên Phủ, Phường 17, Quận Bình Thạnh, TP. Hồ Chí Minh",
                    MembershipRank = "Kim cương",
                    RewardPoints = 520
                },
                new Customer
                {
                    CustomerId = 8,
                    CustomerName = "Bùi Anh Khoa",
                    PhoneNumber = "0966778899",
                    Address = "36 Nguyễn Thị Thập, Phường Tân Quy, Quận 7, TP. Hồ Chí Minh",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 5
                },
                new Customer
                {
                    CustomerId = 9,
                    CustomerName = "Ngô Thanh Mai",
                    PhoneNumber = "0977889900",
                    Address = "27 Phan Văn Trị, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh",
                    MembershipRank = "Bạc",
                    RewardPoints = 90
                },
                new Customer
                {
                    CustomerId = 10,
                    CustomerName = "Đỗ Hoài Nam",
                    PhoneNumber = "0988990011",
                    Address = "63 Cách Mạng Tháng 8, Phường 12, Quận 10, TP. Hồ Chí Minh",
                    MembershipRank = "Vàng",
                    RewardPoints = 210
                },
                new Customer
                {
                    CustomerId = 11,
                    CustomerName = "Lý Gia Hân",
                    PhoneNumber = "0399123456",
                    Address = "210 Quang Trung, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 0
                },
                new Customer
                {
                    CustomerId = 12,
                    CustomerName = "Trương Quốc Việt",
                    PhoneNumber = "0868234567",
                    Address = "5 Võ Văn Ngân, Phường Linh Chiểu, TP. Thủ Đức, TP. Hồ Chí Minh",
                    MembershipRank = "Bạc",
                    RewardPoints = 60
                },
                new Customer
                {
                    CustomerId = 13,
                    CustomerName = "Nguyễn Minh Khôi",
                    PhoneNumber = "0908765432",
                    Address = "88 Nguyễn Oanh, Phường 17, Quận Gò Vấp, TP. Hồ Chí Minh",
                    MembershipRank = "Vàng",
                    RewardPoints = 230
                },
                new Customer
                {
                    CustomerId = 14,
                    CustomerName = "Phan Ngọc Anh",
                    PhoneNumber = "0938123456",
                    Address = "156 Hoàng Diệu, Phường 6, Quận 4, TP. Hồ Chí Minh",
                    MembershipRank = "Bạc",
                    RewardPoints = 85
                },
                new Customer
                {
                    CustomerId = 15,
                    CustomerName = "Đinh Thanh Tùng",
                    PhoneNumber = "0976234518",
                    Address = "72 Kha Vạn Cân, Phường Hiệp Bình Chánh, TP. Thủ Đức, TP. Hồ Chí Minh",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 15
                }
            );
            // ---------- Users (12) ----------
            // Mật khẩu của TẤT CẢ tài khoản mẫu: Healthy@123  (BCrypt đã hash sẵn, cố định)
            const string seedHash = "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.";
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", PasswordHash = seedHash, FullName = "Quản trị hệ thống", Email = "admin@healthymart.vn", Phone = "0900000001", IsActive = true, RoleId = 1, CreatedAt = new DateTime(2026, 1, 5, 8, 0, 0) },
                new User { UserId = 2, Username = "warehouse01", PasswordHash = seedHash, FullName = "Nguyễn Thị Mai", Email = "warehouse01@healthymart.vn", Phone = "0900000002", IsActive = true, RoleId = 2, CreatedAt = new DateTime(2026, 1, 6, 8, 0, 0) },
                new User { UserId = 3, Username = "warehouse02", PasswordHash = seedHash, FullName = "Trần Văn Điều", Email = "warehouse02@healthymart.vn", Phone = "0900000003", IsActive = true, RoleId = 2, CreatedAt = new DateTime(2026, 1, 6, 8, 30, 0) },
                new User { UserId = 4, Username = "cashier01", PasswordHash = seedHash, FullName = "Lê Thị Thu Ngân", Email = "cashier01@healthymart.vn", Phone = "0900000004", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 2, 1, 8, 0, 0) },
                new User { UserId = 5, Username = "cashier02", PasswordHash = seedHash, FullName = "Phạm Văn Ngân", Email = "cashier02@healthymart.vn", Phone = "0900000005", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 2, 1, 8, 10, 0) },
                new User { UserId = 6, Username = "cashier03", PasswordHash = seedHash, FullName = "Hoàng Thị Ngân", Email = "cashier03@healthymart.vn", Phone = "0900000006", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 2, 1, 8, 20, 0) },
                new User { UserId = 7, Username = "cashier04", PasswordHash = seedHash, FullName = "Võ Minh Ngân", Email = "cashier04@healthymart.vn", Phone = "0900000007", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 2, 10, 8, 0, 0) },
                new User { UserId = 8, Username = "cashier05", PasswordHash = seedHash, FullName = "Đặng ThịNgân", Email = "cashier05@healthymart.vn", Phone = "0900000008", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 2, 10, 8, 10, 0) },
                new User { UserId = 9, Username = "cashier06", PasswordHash = seedHash, FullName = "Bùi Văn Ngân", Email = "cashier06@healthymart.vn", Phone = "0900000009", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 3, 1, 8, 0, 0) },
                new User { UserId = 10, Username = "cashier07", PasswordHash = seedHash, FullName = "Ngô Thị Thu Ngân", Email = "cashier07@healthymart.vn", Phone = "0900000010", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 3, 1, 8, 10, 0) },
                new User { UserId = 11, Username = "cashier08", PasswordHash = seedHash, FullName = "Đỗ Văn Ngân", Email = "cashier08@healthymart.vn", Phone = "0900000011", IsActive = true, RoleId = 3, CreatedAt = new DateTime(2026, 4, 1, 8, 0, 0) },
                new User { UserId = 12, Username = "cashier09", PasswordHash = seedHash, FullName = "Lý Thị Thu Ngân", Email = "cashier09@healthymart.vn", Phone = "0900000012", IsActive = false, RoleId = 3, CreatedAt = new DateTime(2026, 4, 1, 8, 10, 0) }
            );

            // ---------- Orders (12) ----------
            // Total = Subtotal - Discount
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderCode = "HD0001", CustomerId = 1, CashierId = 4, Subtotal = 82000, Discount = 0, Total = 82000, PaymentMethod = "CASH", Status = "PAID", CreatedAt = new DateTime(2026, 9, 1, 9, 15, 0) },
                new Order { OrderId = 2, OrderCode = "HD0002", CustomerId = 2, CashierId = 4, Subtotal = 221000, Discount = 10000, Total = 211000, PaymentMethod = "MOMO", Status = "PAID", CreatedAt = new DateTime(2026, 9, 2, 10, 30, 0) },
                new Order { OrderId = 3, OrderCode = "HD0003", CustomerId = 6, CashierId = 5, Subtotal = 173000, Discount = 0, Total = 173000, PaymentMethod = "CASH", Status = "PAID", CreatedAt = new DateTime(2026, 9, 3, 11, 0, 0) },
                new Order { OrderId = 4, OrderCode = "HD0004", CustomerId = 7, CashierId = 5, Subtotal = 400000, Discount = 20000, Total = 380000, PaymentMethod = "CARD", Status = "PAID", CreatedAt = new DateTime(2026, 9, 4, 14, 20, 0) },
                new Order { OrderId = 5, OrderCode = "HD0005", CustomerId = 4, CashierId = 6, Subtotal = 467000, Discount = 23000, Total = 444000, PaymentMethod = "BANK_TRANSFER", Status = "PAID", CreatedAt = new DateTime(2026, 9, 5, 16, 45, 0) },
                new Order { OrderId = 6, OrderCode = "HD0006", CustomerId = 8, CashierId = 6, Subtotal = 158000, Discount = 0, Total = 158000, PaymentMethod = "CASH", Status = "PAID", CreatedAt = new DateTime(2026, 9, 6, 8, 40, 0) },
                new Order { OrderId = 7, OrderCode = "HD0007", CustomerId = 3, CashierId = 7, Subtotal = 126000, Discount = 0, Total = 126000, PaymentMethod = "CASH", Status = "PAID", CreatedAt = new DateTime(2026, 9, 7, 9, 5, 0) },
                new Order { OrderId = 8, OrderCode = "HD0008", CustomerId = 10, CashierId = 7, Subtotal = 237000, Discount = 12000, Total = 225000, PaymentMethod = "MOMO", Status = "PAID", CreatedAt = new DateTime(2026, 9, 8, 17, 10, 0) },
                new Order { OrderId = 9, OrderCode = "HD0009", CustomerId = 5, CashierId = 8, Subtotal = 151000, Discount = 0, Total = 151000, PaymentMethod = "CARD", Status = "PAID", CreatedAt = new DateTime(2026, 9, 9, 18, 30, 0) },
                new Order { OrderId = 10, OrderCode = "HD0010", CustomerId = 11, CashierId = 8, Subtotal = 129000, Discount = 0, Total = 129000, PaymentMethod = "CASH", Status = "CANCELLED", CreatedAt = new DateTime(2026, 9, 10, 12, 0, 0) },
                new Order { OrderId = 11, OrderCode = "HD0011", CustomerId = 9, CashierId = 9, Subtotal = 262000, Discount = 12000, Total = 250000, PaymentMethod = "BANK_TRANSFER", Status = "PAID", CreatedAt = new DateTime(2026, 9, 11, 15, 25, 0) },
                new Order { OrderId = 12, OrderCode = "HD0012", CustomerId = 12, CashierId = 9, Subtotal = 258000, Discount = 0, Total = 258000, PaymentMethod = "MOMO", Status = "PAID", CreatedAt = new DateTime(2026, 9, 12, 19, 0, 0) }
            );

            // ---------- OrderItems (26) ----------
            // LineTotal = Quantity * UnitPrice ; UnitPrice = giá bán tại thời điểm tạo hoá đơn
            modelBuilder.Entity<OrderItem>().HasData(
                // HD0001
                new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 25000, LineTotal = 50000 },
                new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 32000, LineTotal = 32000 },
                // HD0002
                new OrderItem { OrderItemId = 3, OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 65000, LineTotal = 65000 },
                new OrderItem { OrderItemId = 4, OrderId = 2, ProductId = 5, Quantity = 2, UnitPrice = 78000, LineTotal = 156000 },
                // HD0003
                new OrderItem { OrderItemId = 5, OrderId = 3, ProductId = 7, Quantity = 1, UnitPrice = 89000, LineTotal = 89000 },
                new OrderItem { OrderItemId = 6, OrderId = 3, ProductId = 8, Quantity = 2, UnitPrice = 42000, LineTotal = 84000 },
                // HD0004
                new OrderItem { OrderItemId = 7, OrderId = 4, ProductId = 9, Quantity = 1, UnitPrice = 145000, LineTotal = 145000 },
                new OrderItem { OrderItemId = 8, OrderId = 4, ProductId = 10, Quantity = 1, UnitPrice = 120000, LineTotal = 120000 },
                new OrderItem { OrderItemId = 9, OrderId = 4, ProductId = 17, Quantity = 1, UnitPrice = 135000, LineTotal = 135000 },
                // HD0005
                new OrderItem { OrderItemId = 10, OrderId = 5, ProductId = 12, Quantity = 2, UnitPrice = 169000, LineTotal = 338000 },
                new OrderItem { OrderItemId = 11, OrderId = 5, ProductId = 11, Quantity = 1, UnitPrice = 129000, LineTotal = 129000 },
                // HD0006
                new OrderItem { OrderItemId = 12, OrderId = 6, ProductId = 13, Quantity = 2, UnitPrice = 52000, LineTotal = 104000 },
                new OrderItem { OrderItemId = 13, OrderId = 6, ProductId = 16, Quantity = 3, UnitPrice = 18000, LineTotal = 54000 },
                // HD0007
                new OrderItem { OrderItemId = 14, OrderId = 7, ProductId = 14, Quantity = 1, UnitPrice = 48000, LineTotal = 48000 },
                new OrderItem { OrderItemId = 15, OrderId = 7, ProductId = 15, Quantity = 2, UnitPrice = 39000, LineTotal = 78000 },
                // HD0008
                new OrderItem { OrderItemId = 16, OrderId = 8, ProductId = 4, Quantity = 1, UnitPrice = 95000, LineTotal = 95000 },
                new OrderItem { OrderItemId = 17, OrderId = 8, ProductId = 6, Quantity = 2, UnitPrice = 55000, LineTotal = 110000 },
                new OrderItem { OrderItemId = 18, OrderId = 8, ProductId = 2, Quantity = 1, UnitPrice = 32000, LineTotal = 32000 },
                // HD0009
                new OrderItem { OrderItemId = 19, OrderId = 9, ProductId = 8, Quantity = 3, UnitPrice = 42000, LineTotal = 126000 },
                new OrderItem { OrderItemId = 20, OrderId = 9, ProductId = 1, Quantity = 1, UnitPrice = 25000, LineTotal = 25000 },
                // HD0010 (đã huỷ)
                new OrderItem { OrderItemId = 21, OrderId = 10, ProductId = 11, Quantity = 1, UnitPrice = 129000, LineTotal = 129000 },
                // HD0011
                new OrderItem { OrderItemId = 22, OrderId = 11, ProductId = 3, Quantity = 2, UnitPrice = 65000, LineTotal = 130000 },
                new OrderItem { OrderItemId = 23, OrderId = 11, ProductId = 14, Quantity = 2, UnitPrice = 48000, LineTotal = 96000 },
                new OrderItem { OrderItemId = 24, OrderId = 11, ProductId = 16, Quantity = 2, UnitPrice = 18000, LineTotal = 36000 },
                // HD0012
                new OrderItem { OrderItemId = 25, OrderId = 12, ProductId = 7, Quantity = 1, UnitPrice = 89000, LineTotal = 89000 },
                new OrderItem { OrderItemId = 26, OrderId = 12, ProductId = 12, Quantity = 1, UnitPrice = 169000, LineTotal = 169000 }
            );
        }
    }
}