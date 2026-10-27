using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class sa : Migration
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
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CashierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName", "Country", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Đặc Sản Việt", "Việt Nam", "Thương hiệu cửa hàng chuyên kinh doanh đặc sản vùng miền.", true },
                    { 2, "Tây Ninh", "Việt Nam", "Nhóm sản phẩm đặc trưng như muối tôm, bánh tráng và gia vị Tây Ninh.", true },
                    { 3, "Bến Tre", "Việt Nam", "Nhóm đặc sản dừa, kẹo dừa và sản phẩm truyền thống Bến Tre.", true },
                    { 4, "Đà Lạt", "Việt Nam", "Nhóm nông sản, trái cây sấy và đặc sản Đà Lạt.", true },
                    { 5, "Tây Nguyên", "Việt Nam", "Cà phê, hạt và các đặc sản đặc trưng Tây Nguyên.", true },
                    { 6, "Hải Châu", "Việt Nam", "Bánh kẹo và các sản phẩm bánh kẹo truyền thống.", true },
                    { 7, "Ô Mai Hồng Lam", "Việt Nam", "Ô mai và các sản phẩm ăn vặt đặc trưng miền Bắc.", true },
                    { 8, "Vissan", "Việt Nam", "Các sản phẩm thịt chế biến và thực phẩm đóng gói.", true },
                    { 9, "Việt San", "Việt Nam", "Nhóm sản phẩm bánh tráng và đồ ăn vặt.", true },
                    { 10, "Tân Tân", "Việt Nam", "Các loại đậu phộng và hạt chế biến.", true },
                    { 11, "Nông Sản Việt", "Việt Nam", "Các sản phẩm nông sản khô và trái cây sấy.", true },
                    { 12, "Mekong", "Việt Nam", "Nhóm đặc sản miền Tây và sản phẩm từ nông sản địa phương.", true },
                    { 13, "Đặc Sản Miền Trung", "Việt Nam", "Các loại bánh, chả và đặc sản miền Trung.", true },
                    { 14, "Trà Việt", "Việt Nam", "Các loại trà truyền thống và trà đặc sản Việt Nam.", true },
                    { 15, "Quà Việt", "Việt Nam", "Các bộ quà tặng đặc sản vùng miền và sản phẩm đóng gói.", true }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Đặc sản miền Bắc", "Đặc sản Hà Nội, Hải Phòng, Bắc Ninh, Tây Bắc và các tỉnh miền Bắc." },
                    { 2, "Đặc sản miền Trung", "Đặc sản Huế, Đà Nẵng, Quảng Nam, Nghệ An và các tỉnh miền Trung." },
                    { 3, "Đặc sản miền Nam", "Đặc sản miền Tây Nam Bộ, Đông Nam Bộ và các tỉnh miền Nam." },
                    { 4, "Bánh tráng & Đồ ăn vặt", "Bánh tráng trộn, bánh tráng phơi sương, bánh tráng cuốn và đồ ăn vặt." },
                    { 5, "Khô bò & Khô gà", "Khô bò, khô gà lá chanh, khô heo và các loại thịt khô." },
                    { 6, "Khô hải sản", "Mực khô, cá khô, tôm khô và các loại hải sản chế biến khô." },
                    { 7, "Mắm & Đặc sản lên men", "Các loại mắm, nước mắm truyền thống và đặc sản lên men vùng miền." },
                    { 8, "Bánh kẹo truyền thống", "Bánh đậu xanh, kẹo dừa, bánh pía và các loại bánh kẹo đặc sản." },
                    { 9, "Các loại hạt & Đậu", "Hạt điều, đậu phộng, hạt sen và các loại hạt rang truyền thống." },
                    { 10, "Trái cây sấy", "Xoài sấy, mít sấy, chuối sấy và các loại trái cây sấy dẻo." },
                    { 11, "Trà & Cà phê đặc sản", "Trà Thái Nguyên, trà Shan Tuyết, cà phê Tây Nguyên và các loại trà cà phê vùng miền." },
                    { 12, "Gia vị & Nước chấm", "Muối tôm Tây Ninh, muối ớt, sa tế và các loại gia vị đặc sản." },
                    { 13, "Đặc sản đông lạnh", "Chả ram, nem chua, chả bò và các đặc sản cần bảo quản đông lạnh." },
                    { 14, "Đồ uống đặc sản", "Nước thốt nốt, nước dừa, đồ uống đóng chai và các loại đồ uống vùng miền." },
                    { 15, "Combo quà tặng đặc sản", "Các bộ quà tặng tổng hợp đặc sản vùng miền và đồ ăn vặt." }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 1, "59 Nguyễn Thị Minh Khai, Phường Võ Thị Sáu, Quận 3, TP. Hồ Chí Minh", "Nguyễn Văn A", "Vàng", "0901122334", 150 },
                    { 2, "120 Võ Văn Tần, Phường Võ Thị Sáu, Quận 3, TP. Hồ Chí Minh", "Trần Thị B", "Bạc", "0918877665", 50 },
                    { 3, "15 Lý Thường Kiệt, Phường 14, Quận 10, TP. Hồ Chí Minh", "Lê Văn C", "Chuẩn", "0983344556", 10 },
                    { 4, "12 Nguyễn Huệ, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh", "Phạm Minh Tuấn", "Vàng", "0905123456", 180 },
                    { 5, "45 Lê Lợi, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh", "Hoàng Thị Lan", "Bạc", "0912345678", 75 },
                    { 6, "8 Trần Hưng Đạo, Phường 6, Quận 5, TP. Hồ Chí Minh", "Võ Quốc Bảo", "Chuẩn", "0937654321", 20 },
                    { 7, "102 Điện Biên Phủ, Phường 17, Quận Bình Thạnh, TP. Hồ Chí Minh", "Đặng Thu Hà", "Kim cương", "0944556677", 520 },
                    { 8, "36 Nguyễn Thị Thập, Phường Tân Quy, Quận 7, TP. Hồ Chí Minh", "Bùi Anh Khoa", "Chuẩn", "0966778899", 5 },
                    { 9, "27 Phan Văn Trị, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh", "Ngô Thanh Mai", "Bạc", "0977889900", 90 },
                    { 10, "63 Cách Mạng Tháng 8, Phường 12, Quận 10, TP. Hồ Chí Minh", "Đỗ Hoài Nam", "Vàng", "0988990011", 210 },
                    { 11, "210 Quang Trung, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh", "Lý Gia Hân", "Chuẩn", "0399123456", 0 },
                    { 12, "5 Võ Văn Ngân, Phường Linh Chiểu, TP. Thủ Đức, TP. Hồ Chí Minh", "Trương Quốc Việt", "Bạc", "0868234567", 60 },
                    { 13, "88 Nguyễn Oanh, Phường 17, Quận Gò Vấp, TP. Hồ Chí Minh", "Nguyễn Minh Khôi", "Vàng", "0908765432", 230 },
                    { 14, "156 Hoàng Diệu, Phường 6, Quận 4, TP. Hồ Chí Minh", "Phan Ngọc Anh", "Bạc", "0938123456", 85 },
                    { 15, "72 Kha Vạn Cân, Phường Hiệp Bình Chánh, TP. Thủ Đức, TP. Hồ Chí Minh", "Đinh Thanh Tùng", "Chuẩn", "0976234518", 15 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "WAREHOUSE" },
                    { 3, "CASHIER" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Address", "Email", "PhoneNumber", "SupplierName" },
                values: new object[,]
                {
                    { 1, "Tây Ninh, Việt Nam", "dacsantayninh@example.com", "02763812345", "Cơ sở Đặc sản Tây Ninh" },
                    { 2, "Thành phố Hồ Chí Minh, Việt Nam", "banhtrang@example.com", "02838123456", "Cơ sở Bánh tráng Việt" },
                    { 3, "Thành phố Hồ Chí Minh, Việt Nam", "khobo@example.com", "02838234567", "Cơ sở Khô bò miền Nam" },
                    { 4, "Bình Dương, Việt Nam", "hatdinhduong@example.com", "02838345678", "Nhà cung cấp Ngũ cốc và Hạt" },
                    { 5, "Bến Tre, Việt Nam", "dacsanbentre@example.com", "02753845678", "Cơ sở Đặc sản Bến Tre" },
                    { 6, "Khánh Hòa, Việt Nam", "haisan@example.com", "02583856789", "Nhà cung cấp Hải sản khô" },
                    { 7, "Cà Mau, Việt Nam", "mamtruyenthong@example.com", "02916678901", "Cơ sở Mắm truyền thống miền Tây" },
                    { 8, "Hải Dương, Việt Nam", "banhkeo@example.com", "02203845678", "Cơ sở Bánh kẹo đặc sản miền Bắc" },
                    { 9, "Lâm Đồng, Việt Nam", "traicaysay@example.com", "02633890123", "Nhà cung cấp Trái cây sấy" },
                    { 10, "Đắk Lắk, Việt Nam", "caphe@example.com", "02633901234", "Cơ sở Cà phê Tây Nguyên" },
                    { 11, "Bình Phước, Việt Nam", "hat rang@example.com", "02743812345", "Cơ sở Đậu phộng và Hạt rang" },
                    { 12, "Đà Nẵng, Việt Nam", "mientrung@example.com", "02363812345", "Nhà cung cấp Đặc sản miền Trung" },
                    { 13, "Hà Nội, Việt Nam", "mienbac@example.com", "02433812345", "Cơ sở Đặc sản miền Bắc" },
                    { 14, "Cần Thơ, Việt Nam", "mientay@example.com", "02923876543", "Nhà cung cấp Đặc sản miền Tây" },
                    { 15, "Thành phố Hồ Chí Minh, Việt Nam", "quaviet@example.com", "02839876543", "Nhà cung cấp Combo Quà Việt" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "BrandId", "CategoryId", "CostPrice", "IsActive", "Price", "ProductName", "StockQuantity", "SupplierId", "Unit" },
                values: new object[,]
                {
                    { 1, "8938501234561", 2, 4, 30000m, true, 45000m, "Bánh tráng phơi sương Tây Ninh 500g", 50, 1, "bịch" },
                    { 2, "8938501234562", 2, 12, 15000m, true, 25000m, "Muối tôm Tây Ninh 200g", 80, 1, "hũ" },
                    { 3, "8938501234563", 1, 5, 70000m, true, 95000m, "Khô bò miếng cay 250g", 30, 3, "gói" },
                    { 4, "8938501234564", 1, 5, 45000m, true, 65000m, "Khô gà lá chanh 200g", 35, 3, "gói" },
                    { 5, "8938501234565", 3, 8, 26000m, true, 40000m, "Kẹo dừa Bến Tre 300g", 45, 5, "hộp" },
                    { 6, "8938501234566", 13, 8, 52000m, true, 75000m, "Bánh pía sầu riêng 400g", 25, 12, "hộp" },
                    { 7, "8938501234567", 1, 6, 140000m, true, 180000m, "Mực khô loại vừa 200g", 20, 6, "gói" },
                    { 8, "8938501234568", 1, 6, 62000m, true, 85000m, "Cá chỉ vàng khô 300g", 28, 6, "gói" },
                    { 9, "8938501234569", 10, 9, 22000m, true, 35000m, "Đậu phộng rang tỏi ớt 250g", 60, 11, "gói" },
                    { 10, "8938501234570", 11, 9, 70000m, true, 95000m, "Hạt điều rang muối 250g", 32, 4, "hộp" },
                    { 11, "8938501234571", 4, 10, 38000m, true, 55000m, "Mít sấy giòn 200g", 40, 9, "gói" },
                    { 12, "8938501234572", 11, 10, 32000m, true, 48000m, "Xoài sấy dẻo 250g", 42, 9, "gói" },
                    { 13, "8938501234573", 5, 11, 80000m, true, 110000m, "Cà phê rang xay Tây Nguyên 500g", 25, 10, "gói" },
                    { 14, "8938501234574", 14, 11, 48000m, true, 70000m, "Trà Thái Nguyên 200g", 30, 13, "gói" },
                    { 15, "8938501234575", 9, 4, 18000m, true, 30000m, "Bánh tráng cuộn muối nhuyễn 250g", 55, 2, "bịch" },
                    { 16, "8938501234576", 13, 13, 95000m, true, 125000m, "Chả bò Đà Nẵng 500g", 18, 12, "gói" },
                    { 17, "8938501234577", 15, 15, 180000m, true, 250000m, "Combo quà tặng đặc sản Việt Nam", 12, 15, "hộp" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.vn", "Quản trị hệ thống", true, "$2b$11$...", "0900000001", 1, "admin" },
                    { 2, new DateTime(2026, 1, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "warehouse01@gmail.vn", "Nguyễn Thị Mai", true, "$2b$11$...", "0900000002", 2, "warehouse01" },
                    { 3, new DateTime(2026, 1, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "warehouse02@gmail.vn", "Trần Văn Điều", true, "$2b$11$...", "0900000003", 2, "warehouse02" },
                    { 4, new DateTime(2026, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier01@gmail.vn", "Lê Thị Thu Ngân", true, "$2b$11$...", "0900000004", 3, "cashier01" },
                    { 5, new DateTime(2026, 2, 1, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier02@gmail.vn", "Phạm Văn Ngân", true, "$2b$11$...", "0900000005", 3, "cashier02" },
                    { 6, new DateTime(2026, 2, 1, 8, 20, 0, 0, DateTimeKind.Unspecified), "cashier03@gmail.vn", "Hoàng Thị Ngân", true, "$2b$11$...", "0900000006", 3, "cashier03" },
                    { 7, new DateTime(2026, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier04@gmail.vn", "Võ Minh Ngân", true, "$2b$11$...", "0900000007", 3, "cashier04" },
                    { 8, new DateTime(2026, 2, 10, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier05@gmail.vn", "Đặng ThịNgân", true, "$2b$11$...", "0900000008", 3, "cashier05" },
                    { 9, new DateTime(2026, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier06@gmail.vn", "Bùi Văn Ngân", true, "$2b$11$...", "0900000009", 3, "cashier06" },
                    { 10, new DateTime(2026, 3, 1, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier07@gmail.vn", "Ngô Thị Thu Ngân", true, "$2b$11$...", "0900000010", 3, "cashier07" },
                    { 11, new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier08@gmail.vn", "Đỗ Văn Ngân", true, "$2b$11$...", "0900000011", 3, "cashier08" },
                    { 12, new DateTime(2026, 4, 1, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier09@gmail.vn", "Lý Thị Thu Ngân", false, "$2b$11$...", "0900000012", 3, "cashier09" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CashierId", "CreatedAt", "CustomerId", "Discount", "OrderCode", "PaymentMethod", "Status", "Subtotal", "Total" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2026, 9, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 0m, "HD0001", "CASH", "PAID", 82000m, 82000m },
                    { 2, 4, new DateTime(2026, 9, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 10000m, "HD0002", "MOMO", "PAID", 221000m, 211000m },
                    { 3, 5, new DateTime(2026, 9, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 6, 0m, "HD0003", "CASH", "PAID", 173000m, 173000m },
                    { 4, 5, new DateTime(2026, 9, 4, 14, 20, 0, 0, DateTimeKind.Unspecified), 7, 20000m, "HD0004", "CARD", "PAID", 400000m, 380000m },
                    { 5, 6, new DateTime(2026, 9, 5, 16, 45, 0, 0, DateTimeKind.Unspecified), 4, 23000m, "HD0005", "BANK_TRANSFER", "PAID", 467000m, 444000m },
                    { 6, 6, new DateTime(2026, 9, 6, 8, 40, 0, 0, DateTimeKind.Unspecified), 8, 0m, "HD0006", "CASH", "PAID", 158000m, 158000m },
                    { 7, 7, new DateTime(2026, 9, 7, 9, 5, 0, 0, DateTimeKind.Unspecified), 3, 0m, "HD0007", "CASH", "PAID", 126000m, 126000m },
                    { 8, 7, new DateTime(2026, 9, 8, 17, 10, 0, 0, DateTimeKind.Unspecified), 10, 12000m, "HD0008", "MOMO", "PAID", 237000m, 225000m },
                    { 9, 8, new DateTime(2026, 9, 9, 18, 30, 0, 0, DateTimeKind.Unspecified), 5, 0m, "HD0009", "CARD", "PAID", 151000m, 151000m },
                    { 10, 8, new DateTime(2026, 9, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 11, 0m, "HD0010", "CASH", "CANCELLED", 129000m, 129000m },
                    { 11, 9, new DateTime(2026, 9, 11, 15, 25, 0, 0, DateTimeKind.Unspecified), 9, 12000m, "HD0011", "BANK_TRANSFER", "PAID", 262000m, 250000m },
                    { 12, 9, new DateTime(2026, 9, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 12, 0m, "HD0012", "MOMO", "PAID", 258000m, 258000m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "LineTotal", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 50000m, 1, 1, 2, 25000m },
                    { 2, 32000m, 1, 2, 1, 32000m },
                    { 3, 65000m, 2, 3, 1, 65000m },
                    { 4, 156000m, 2, 5, 2, 78000m },
                    { 5, 89000m, 3, 7, 1, 89000m },
                    { 6, 84000m, 3, 8, 2, 42000m },
                    { 7, 145000m, 4, 9, 1, 145000m },
                    { 8, 120000m, 4, 10, 1, 120000m },
                    { 9, 135000m, 4, 17, 1, 135000m },
                    { 10, 338000m, 5, 12, 2, 169000m },
                    { 11, 129000m, 5, 11, 1, 129000m },
                    { 12, 104000m, 6, 13, 2, 52000m },
                    { 13, 54000m, 6, 16, 3, 18000m },
                    { 14, 48000m, 7, 14, 1, 48000m },
                    { 15, 78000m, 7, 15, 2, 39000m },
                    { 16, 95000m, 8, 4, 1, 95000m },
                    { 17, 110000m, 8, 6, 2, 55000m },
                    { 18, 32000m, 8, 2, 1, 32000m },
                    { 19, 126000m, 9, 8, 3, 42000m },
                    { 20, 25000m, 9, 1, 1, 25000m },
                    { 21, 129000m, 10, 11, 1, 129000m },
                    { 22, 130000m, 11, 3, 2, 65000m },
                    { 23, 96000m, 11, 14, 2, 48000m },
                    { 24, 36000m, 11, 16, 2, 18000m },
                    { 25, 89000m, 12, 7, 1, 89000m },
                    { 26, 169000m, 12, 12, 1, 169000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandName",
                table: "Brands",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CashierId",
                table: "Orders",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders",
                column: "OrderCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
