using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OriginRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    MembershipRank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OriginRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    MinStockQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "InventoryLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    QuantityChange = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName", "Description", "OriginRegion" },
                values: new object[,]
                {
                    { 1, "Hồng Lam", "Thương hiệu tinh hoa quà Việt, chuyên ô mai và mứt truyền thống", "Hà Nội" },
                    { 2, "Tân Huê Viên", "Thương hiệu bánh pía và lạp xưởng nổi tiếng Miền Tây", "Sóc Trăng" },
                    { 3, "Yến Hoàng", "Chuyên kẹo dừa và các sản phẩm chế biến từ dừa nguyên chất", "Bến Tre" },
                    { 4, "L'angfarm", "Đặc sản Đà Lạt, trái cây sấy khô và trà thảo mộc", "Đà Lạt" },
                    { 5, "Đặc Sản Tây Bắc", "Thịt sấy, gia vị chẩm chéo và nông sản vùng cao", "Hà Giang - Sơn La" },
                    { 6, "Bảo Minh", "Chuyên bánh cốm, bánh đậu xanh và bánh kẹo truyền thống Miền Bắc", "Hà Nội" },
                    { 7, "Hà Xua", "Đặc sản tré rơm, nem chả và thủy hải sản khô Quy Nhơn", "Bình Định" },
                    { 8, "Phú Hương", "Nước mắm truyền thống và mực khô sấy sa tế Phú Quốc", "Phú Quốc" },
                    { 9, "Xưởng Ăn Vặt Sài Gòn", "Cơm cháy chà bông, bánh tráng trộn và các món ăn vặt hiện đại", "TP. Hồ Chí Minh" },
                    { 10, "Trà Tân Cương", "Trà đinh, trà mộc thượng hạng chuẩn vùng Thái Nguyên", "Thái Nguyên" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Đặc sản Miền Bắc", "Bánh cốm, thịt trâu gắp bếp, ô mai truyền thống" },
                    { 2, "Đặc sản Miền Trung", "Mực rim sa tế, tré Bình Định, bánh ép Huế" },
                    { 3, "Đặc sản Miền Tây & Nam Bộ", "Bánh pía Sóc Trăng, kẹo dừa Bến Tre, lạp xưởng" },
                    { 4, "Trái cây sấy khô & Dẻo", "Mít sấy, xoài sấy dẻo, chuối sấy giòn Đà Lạt" },
                    { 5, "Đồ ăn vặt mặn", "Cơm cháy chà bông, khô gà lá chanh, bánh tráng" },
                    { 6, "Trà & Thảo mộc vùng miền", "Trà Thái Nguyên, trà sâm dây Ngọc Linh, trà mướp đắng" },
                    { 7, "Bánh kẹo truyền thống", "Bánh cốm, bánh đậu xanh, kẹo cu đơ, kẹo chuối" },
                    { 8, "Thủy hải sản khô & Rim", "Cá chỉ vàng rim, mực xé hấp nước dừa, tôm khô" },
                    { 9, "Gia vị & Nước chấm đặc sản", "Nước mắm Phú Quốc, muối tôm Tây Ninh, chẩm chéo" },
                    { 10, "Nước giải khát & Nước trái cây", "Nước dừa tươi đóng lon, nước mủ trôm, nước chanh dây" },
                    { 11, "Nông sản & Hạt dinh dưỡng", "Hạt điều Bình Phước, hạt macca Tây Nguyên, sen sấy" },
                    { 12, "Rượu & Đồ uống lên men", "Rượu mận Tả Van, rượu mơ Yên Tử, rượu thốt nốt" },
                    { 13, "Đặc sản Tây Nguyên", "Cà phê Cầu Đất, tiêu Chư Sê, măng khô Kon Tum" },
                    { 14, "Mứt & Trái cây ngâm", "Mứt dâu tây Đà Lạt, dầm sấu, mứt quất hồng giòn" },
                    { 15, "Combo & Hộp quà đặc sản", "Bộ quà tặng đặc sản 3 miền, hộp quà Tết vùng miền" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 1, "123 Lê Lợi, Q.1, TP.HCM", "Nguyễn Văn A", "Vàng", "0901122334", 210 },
                    { 2, "456 Nguyễn Trãi, Q.5, TP.HCM", "Trần Thị B", "Bạc", "0918877665", 85 },
                    { 3, "78 Điện Biên Phủ, Q.3, TP.HCM", "Lê Văn C", "Chuẩn", "0983344556", 25 },
                    { 4, "12 Cách Mạng Tháng 8, Q.10, TP.HCM", "Phạm Thị D", "Kim Cương", "0934567890", 540 },
                    { 5, "89 Hoàng Văn Thụ, Q.Phú Nhuận, TP.HCM", "Hoàng Minh E", "Bạc", "0971122444", 110 },
                    { 6, "204 Nguyễn Thị Minh Khai, Q.3, TP.HCM", "Đỗ Thu F", "Chuẩn", "0909988776", 15 },
                    { 7, "55 Phan Đăng Lưu, Q.Bình Thạnh, TP.HCM", "Vũ Quốc G", "Vàng", "0945112233", 320 },
                    { 8, "15 Nguyễn Hữu Cảnh, Q.Bình Thạnh, TP.HCM", "Đặng Mai H", "Chuẩn", "0966778899", 0 },
                    { 9, "88 Lý Thường Kiệt, Q.10, TP.HCM", "Bùi Anh Khoa", "Bạc", "0931223344", 95 },
                    { 10, "302 Võ Văn Tần, Q.3, TP.HCM", "Ngô Bích Ngọc", "Vàng", "0978990011", 280 },
                    { 11, "12 Trần Hưng Đạo, Q.1, TP.HCM", "Trịnh Quốc Bảo", "Chuẩn", "0903445566", 40 },
                    { 12, "74 Ba Tháng Hai, Q.10, TP.HCM", "Lý Mỹ Duyên", "Kim Cương", "0915667788", 610 },
                    { 13, "450 Xô Viết Nghệ Tĩnh, Q.Bình Thạnh, TP.HCM", "Đoàn Tấn Phát", "Bạc", "0982114455", 130 },
                    { 14, "19 An Dương Vương, Q.5, TP.HCM", "Dương Khánh Linh", "Chuẩn", "0947889900", 10 },
                    { 15, "500 Cộng Hòa, Q.Tân Bình, TP.HCM", "Phan Hoài Nam", "Vàng", "0963221100", 190 }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "PromotionId", "Code", "Description", "DiscountAmount", "DiscountPercent", "EndDate", "IsActive", "StartDate" },
                values: new object[,]
                {
                    { 1, "DACSAN10K", "Giảm 10.000 VNĐ cho đơn hàng đặc sản từ 200.000 VNĐ", 10000m, 0.0, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "ANVAT10", "Giảm 10% cho tất cả đơn hàng đồ ăn vặt sấy khô", 0m, 10.0, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "TET2026", "Chương trình quà tặng đặc sản mừng lễ", 20000m, 0.0, new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Address", "ContactName", "OriginRegion", "PhoneNumber", "SupplierName" },
                values: new object[,]
                {
                    { 1, "Thành phố Sơn La, Tỉnh Sơn La", "Nguyễn Văn Hùng", "Sơn La - Hà Giang", "0988111222", "Công ty TNHH Đặc Sản Tây Bắc" },
                    { 2, "KCN Quang Minh, Mê Linh, Hà Nội", "Trần Thu Hà", "Hà Nội", "0912333444", "Cơ sở Sản xuất Ô mai Hồng Lam" },
                    { 3, "Quy Đức, Châu Thành, Sóc Trăng", "Thái Tuấn", "Sóc Trăng", "02993888999", "Công ty TNHH Bánh Pía Tân Huê Viên" },
                    { 4, "Mỏ Cày Bắc, Bến Tre", "Lê Thị Lan", "Bến Tre", "0903555666", "Xưởng Kẹo Dừa Bến Tre Yến Hoàng" },
                    { 5, "Phường 10, TP. Đà Lạt, Lâm Đồng", "Phạm Quốc Bảo", "Đà Lạt", "02633888777", "Nông Sản Sấy L'angfarm Đà Lạt" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FullName", "IsActive", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Quản Lý Cửa Hàng", true, "admin123_hash", "Admin", "admin" },
                    { 2, "Thu Ngân - Nguyễn Mai", true, "cashier123_hash", "Cashier", "cashier01" },
                    { 3, "Thủ Kho - Trần Tuấn", true, "warehouse123_hash", "Warehouse", "warehouse01" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "PaymentMethod", "PaymentStatus", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), "Banking", "Paid", 265000m },
                    { 2, 2, new DateTime(2026, 3, 22, 14, 15, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 130000m },
                    { 3, 4, new DateTime(2026, 3, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "QR Code", "Paid", 350000m },
                    { 4, 3, new DateTime(2026, 3, 27, 16, 45, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 97000m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "BrandId", "CategoryId", "CostPrice", "ImageUrl", "IsActive", "MinStockQuantity", "Price", "ProductName", "StockQuantity", "Unit" },
                values: new object[,]
                {
                    { 1, "8938502000001", 5, 1, 135000m, null, true, 5, 180000m, "Thịt trâu gắp bếp Tây Bắc 200g", 18, "Gói" },
                    { 2, "8938502000002", 1, 1, 45000m, null, true, 10, 65000m, "Ô mai sấu xào Hồng Lam 300g", 45, "Hộp" },
                    { 3, "8938502000003", 7, 2, 82000m, null, true, 5, 110000m, "Tré rơm Bình Định (Hộp 10 xâu)", 20, "Hộp" },
                    { 4, "8938502000004", 7, 8, 70000m, null, true, 10, 95000m, "Mực rim sa tế Quy Nhơn 250g", 35, "Hũ" },
                    { 5, "8938502000005", 2, 3, 60000m, null, true, 10, 85000m, "Bánh pía trứng chảy Sóc Trăng 400g", 52, "Túi" },
                    { 6, "8938502000006", 3, 3, 28000m, null, true, 15, 45000m, "Kẹo dừa béo Bến Tre 300g", 75, "Gói" },
                    { 7, "8938502000007", 4, 4, 36000m, null, true, 10, 55000m, "Xoài sấy dẻo L'angfarm 200g", 50, "Túi" },
                    { 8, "8938502000008", 4, 4, 27000m, null, true, 12, 42000m, "Mít sấy giòn L'angfarm 150g", 60, "Túi" },
                    { 9, "8938502000009", 9, 5, 48000m, null, true, 10, 75000m, "Cơm cháy chà bông Sài Gòn 500g", 40, "Túi" },
                    { 10, "8938502000010", 9, 5, 42000m, null, true, 8, 68000m, "Khô gà xé lá chanh đậm vị 300g", 38, "Hũ" },
                    { 11, "8938502000011", 10, 6, 85000m, null, true, 5, 120000m, "Trà Thái Nguyên thượng hạng 200g", 32, "Gói" },
                    { 12, "8938502000012", 6, 7, 8000m, null, true, 15, 12000m, "Bánh cốm Hàng Than Hà Nội 100g", 80, "Cái" },
                    { 13, "8938502000013", 8, 9, 85000m, null, true, 6, 115000m, "Nước mắm Phú Quốc Phú Hương 500ml", 30, "Chai" },
                    { 14, "8938502000014", 3, 10, 11000m, null, true, 24, 18000m, "Nước dừa tươi đóng lon Bến Tre 330ml", 120, "Lon" },
                    { 15, "8938502000015", null, 11, 120000m, null, true, 5, 165000m, "Hạt điều rang muối Bình Phước 500g", 25, "Hũ" }
                });

            migrationBuilder.InsertData(
                table: "InventoryLogs",
                columns: new[] { "LogId", "BatchNumber", "ExpirationDate", "Note", "ProductId", "QuantityChange", "SupplierId", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, "LOT-TB-20260301", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhập kho lô thịt trâu gắp bếp Tây Bắc", 1, 20, null, new DateTime(2026, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 2, "LOT-THV-20260305", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhập kho bánh pía Tân Huê Viên", 5, 60, null, new DateTime(2026, 3, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "IMPORT" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 180000m },
                    { 2, 1, 5, 1, 85000m },
                    { 3, 2, 2, 2, 65000m },
                    { 4, 3, 3, 1, 110000m },
                    { 5, 4, 6, 1, 45000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_ProductId",
                table: "InventoryLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_SupplierId",
                table: "InventoryLogs",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryLogs");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
