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
                    { 1, "Đặc Sản Việt", "Việt Nam", "Thương hiệu chuyên cung cấp các loại đặc sản truyền thống từ nhiều vùng miền.", true },
                    { 2, "Bánh Pía Tân Huê Viên", "Việt Nam", "Thương hiệu bánh pía và các loại bánh đặc sản Sóc Trăng.", true },
                    { 3, "Kẹo Dừa Bến Tre", "Việt Nam", "Thương hiệu đặc sản nổi tiếng với các loại kẹo dừa truyền thống.", true },
                    { 4, "Ô Mai Hồng Lam", "Việt Nam", "Thương hiệu chuyên các sản phẩm ô mai và trái cây chế biến.", true },
                    { 5, "Bánh Đậu Xanh Rồng Vàng", "Việt Nam", "Thương hiệu bánh đậu xanh đặc sản Hải Dương.", true },
                    { 6, "Tây Ninh", "Việt Nam", "Thương hiệu và nguồn cung các sản phẩm muối tôm, muối chấm và gia vị đặc sản Tây Ninh.", true },
                    { 7, "Trung Nguyên Legend", "Việt Nam", "Thương hiệu cà phê Việt Nam với các dòng cà phê rang xay và cà phê hòa tan.", true },
                    { 8, "Tân Cương Xanh", "Việt Nam", "Thương hiệu trà xanh và trà đặc sản Thái Nguyên.", true },
                    { 9, "Bình Định", "Việt Nam", "Nguồn đặc sản địa phương gồm bánh tráng, bánh ít và các sản phẩm truyền thống.", true },
                    { 10, "Vissan", "Việt Nam", "Thương hiệu thực phẩm chế biến, xúc xích và các sản phẩm thịt đóng gói.", true },
                    { 11, "Kinh Đô", "Việt Nam", "Thương hiệu bánh kẹo với nhiều dòng bánh quy, bánh bông lan và bánh ăn nhẹ.", true },
                    { 12, "Bibica", "Việt Nam", "Thương hiệu bánh kẹo và thực phẩm ăn nhẹ phục vụ nhu cầu tiêu dùng hàng ngày.", true },
                    { 13, "Orion", "Hàn Quốc", "Thương hiệu bánh snack, bánh quy và các sản phẩm ăn vặt đóng gói.", true },
                    { 14, "Oishi", "Philippines", "Thương hiệu snack, bánh que và các sản phẩm ăn vặt đóng gói.", true },
                    { 15, "Mekong Food", "Việt Nam", "Thương hiệu phục vụ nhóm đặc sản miền Tây, trái cây sấy và thực phẩm đóng gói.", true }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Đặc sản miền Bắc", "Các đặc sản miền Bắc như bánh đậu xanh, cốm, ô mai, chè Thái Nguyên và các món ăn truyền thống." },
                    { 2, "Đặc sản miền Trung", "Các đặc sản miền Trung như tré, nem chua, chả bò Đà Nẵng, mè xửng Huế và bánh tráng." },
                    { 3, "Đặc sản miền Nam", "Các đặc sản miền Nam như bánh pía Sóc Trăng, kẹo dừa Bến Tre, khô cá và các loại bánh dân gian." },
                    { 4, "Bánh kẹo truyền thống", "Các loại bánh kẹo truyền thống Việt Nam như bánh đậu xanh, bánh cốm, kẹo dừa và kẹo lạc." },
                    { 5, "Snack & Đồ ăn vặt", "Các món ăn vặt phổ biến như snack khoai tây, bánh que, rong biển ăn liền và bánh phồng." },
                    { 6, "Khô gà & Khô bò", "Các sản phẩm khô gà lá chanh, khô bò miếng, khô bò sợi và các loại thịt khô tẩm gia vị." },
                    { 7, "Khô cá & Hải sản khô", "Các loại khô cá, mực khô, cá chỉ vàng, tôm khô và hải sản khô đặc sản vùng miền." },
                    { 8, "Mứt & Trái cây sấy", "Các loại mứt trái cây, chuối sấy, mít sấy, xoài sấy và trái cây sấy dẻo." },
                    { 9, "Hạt & Đậu ăn vặt", "Các loại hạt điều, đậu phộng, hạt bí, hạt hướng dương và đậu rang tẩm gia vị." },
                    { 10, "Trà & Cà phê đặc sản", "Trà Thái Nguyên, trà sen, cà phê Buôn Ma Thuột và các sản phẩm trà, cà phê vùng miền." },
                    { 11, "Gia vị & Nước chấm", "Các loại nước mắm, mắm đặc sản, muối tôm Tây Ninh, sa tế và gia vị truyền thống." },
                    { 12, "Mì & Đồ ăn liền", "Các sản phẩm mì, miến, bún khô, phở khô và đồ ăn liền tiện lợi." },
                    { 13, "Đặc sản đóng hộp", "Các loại đặc sản được đóng hộp hoặc đóng gói như cá hộp, pate, thịt chế biến và thực phẩm tiện lợi." },
                    { 14, "Đồ uống & Nước giải khát", "Các loại nước giải khát, nước trái cây, nước dừa, nước sâm và đồ uống đặc sản vùng miền." },
                    { 15, "Combo quà tặng đặc sản", "Các combo bánh kẹo, trà, cà phê, hạt dinh dưỡng và đặc sản vùng miền dùng làm quà biếu." }
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
                    { 1, "12 Điện Biên Phủ, TP. Sơn La, Sơn La", "contact@dacsantaybac.vn", "02633812345", "Công ty TNHH Đặc sản Tây Bắc Việt" },
                    { 2, "45 Nguyễn Văn Linh, TP. Đà Nẵng", "kinhdoanh@dacsanmientrung.vn", "02838123456", "Công ty CP Đặc sản Miền Trung" },
                    { 3, "28 Nguyễn Trãi, TP. Cần Thơ", "lienhe@dacsanmientay.vn", "02838234567", "Công ty TNHH Đặc sản Miền Tây" },
                    { 4, "86 Trần Hưng Đạo, TP. Hải Dương, Hải Dương", "banhang@banhkeotruyenthong.vn", "02838345678", "Công ty TNHH Bánh kẹo truyền thống Việt" },
                    { 5, "21 Lê Duẩn, TP. Hồ Chí Minh", "snackviet@example.vn", "02438456789", "Cơ sở sản xuất Snack Việt" },
                    { 6, "77 Nguyễn Huệ, TP. Quy Nhơn, Bình Định", "sales@thucphamkho.example.vn", "02838567890", "Công ty TNHH Thực phẩm khô Việt" },
                    { 7, "18 Trần Hưng Đạo, TP. Phú Quốc, Kiên Giang", "haisan@phuquoc.example.vn", "02916678901", "Cơ sở Hải sản khô Phú Quốc" },
                    { 8, "52 Cách Mạng Tháng Tám, TP. Hồ Chí Minh", "info@traicaysay.example.vn", "02838789012", "Công ty CP Trái cây sấy Việt" },
                    { 9, "35 Quốc lộ 14, TP. Đồng Xoài, Bình Phước", "htx@hatdieubp.example.vn", "02723890123", "Hợp tác xã Hạt điều Bình Phước" },
                    { 10, "16 Hoàng Văn Thụ, TP. Thái Nguyên, Thái Nguyên", "tra@thainguyen.example.vn", "02633901234", "Công ty TNHH Trà đặc sản Thái Nguyên" },
                    { 11, "60 Cách Mạng Tháng Tám, TP. Tây Ninh, Tây Ninh", "giavi@tayninh.example.vn", "02838012345", "Công ty TNHH Gia vị Tây Ninh" },
                    { 12, "90 Trần Hưng Đạo, TP. Long Xuyên, An Giang", "thucpham@angiang.example.vn", "02838123400", "Công ty CP Thực phẩm khô An Giang" },
                    { 13, "25 Nguyễn Văn Cừ, TP. Hồ Chí Minh", "dacsandonghop@example.vn", "02923678901", "Cơ sở Đặc sản đóng hộp Việt" },
                    { 14, "40 Phan Đình Phùng, TP. Bảo Lộc, Lâm Đồng", "douong@dacsan.example.vn", "02839876543", "Công ty TNHH Đồ uống đặc sản Việt" },
                    { 15, "100 Nguyễn Huệ, TP. Hồ Chí Minh", "quatang@dacsan.example.vn", "02743781234", "Công ty CP Quà tặng đặc sản Việt Nam" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "BrandId", "CategoryId", "CostPrice", "IsActive", "Price", "ProductName", "StockQuantity", "SupplierId", "Unit" },
                values: new object[,]
                {
                    { 1, "8938501234561", 5, 1, 32000m, true, 45000m, "Bánh đậu xanh Rồng Vàng 200g", 35, 4, "hộp" },
                    { 2, "8938501234562", 4, 1, 45000m, true, 65000m, "Ô mai mơ Hồng Lam 250g", 28, 4, "hộp" },
                    { 3, "8938501234563", 1, 2, 26000m, true, 38000m, "Mè xửng Huế truyền thống 300g", 42, 2, "gói" },
                    { 4, "8938501234564", 9, 2, 29000m, true, 42000m, "Bánh tráng mè Bình Định 500g", 50, 2, "gói" },
                    { 5, "8938501234565", 3, 3, 24000m, true, 35000m, "Kẹo dừa Bến Tre 300g", 45, 3, "gói" },
                    { 6, "8938501234566", 2, 3, 56000m, true, 78000m, "Bánh pía Tân Huê Viên 400g", 24, 3, "hộp" },
                    { 7, "8938501234567", 11, 4, 36000m, true, 52000m, "Bánh quy bơ truyền thống 250g", 32, 4, "hộp" },
                    { 8, "8938501234568", 13, 5, 18000m, true, 28000m, "Snack khoai tây vị truyền thống gói 150g", 60, 5, "gói" },
                    { 9, "8938501234569", 1, 6, 45000m, true, 65000m, "Khô gà lá chanh 200g", 40, 6, "hộp" },
                    { 10, "8938501234570", 1, 6, 62000m, true, 85000m, "Khô bò miếng đặc biệt 100g", 25, 6, "gói" },
                    { 11, "8938501234571", 1, 7, 145000m, true, 185000m, "Mực khô loại vừa 250g", 18, 7, "gói" },
                    { 12, "8938501234572", 1, 7, 92000m, true, 125000m, "Cá chỉ vàng khô 500g", 22, 7, "gói" },
                    { 13, "8938501234573", 15, 8, 38000m, true, 55000m, "Mít sấy giòn 200g", 35, 8, "gói" },
                    { 14, "8938501234574", 12, 9, 70000m, true, 95000m, "Hạt điều rang muối Bình Phước 250g", 30, 9, "hộp" },
                    { 15, "8938501234575", 8, 10, 48000m, true, 68000m, "Trà xanh Thái Nguyên 200g", 26, 10, "gói" },
                    { 16, "8938501234576", 6, 11, 21000m, true, 32000m, "Muối tôm Tây Ninh 200g", 55, 11, "hũ" },
                    { 17, "8938501234577", 14, 12, 33000m, true, 48000m, "Miến dong đặc sản 500g", 38, 12, "gói" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "admin@healthymart.vn", "Quản trị hệ thống", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000001", 1, "admin" },
                    { 2, new DateTime(2026, 1, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "warehouse01@healthymart.vn", "Nguyễn Thị Mai", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000002", 2, "warehouse01" },
                    { 3, new DateTime(2026, 1, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "warehouse02@healthymart.vn", "Trần Văn Điều", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000003", 2, "warehouse02" },
                    { 4, new DateTime(2026, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier01@healthymart.vn", "Lê Thị Thu Ngân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000004", 3, "cashier01" },
                    { 5, new DateTime(2026, 2, 1, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier02@healthymart.vn", "Phạm Văn Ngân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000005", 3, "cashier02" },
                    { 6, new DateTime(2026, 2, 1, 8, 20, 0, 0, DateTimeKind.Unspecified), "cashier03@healthymart.vn", "Hoàng Thị Ngân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000006", 3, "cashier03" },
                    { 7, new DateTime(2026, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier04@healthymart.vn", "Võ Minh Ngân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000007", 3, "cashier04" },
                    { 8, new DateTime(2026, 2, 10, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier05@healthymart.vn", "Đặng ThịNgân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000008", 3, "cashier05" },
                    { 9, new DateTime(2026, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier06@healthymart.vn", "Bùi Văn Ngân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000009", 3, "cashier06" },
                    { 10, new DateTime(2026, 3, 1, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier07@healthymart.vn", "Ngô Thị Thu Ngân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000010", 3, "cashier07" },
                    { 11, new DateTime(2026, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "cashier08@healthymart.vn", "Đỗ Văn Ngân", true, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000011", 3, "cashier08" },
                    { 12, new DateTime(2026, 4, 1, 8, 10, 0, 0, DateTimeKind.Unspecified), "cashier09@healthymart.vn", "Lý Thị Thu Ngân", false, "$2b$11$Kce6ZlNDqAZeWGjWjezVDuvhT5YGuqyxFMjEc6g8Zx1VbYe0Rq7B.", "0900000012", 3, "cashier09" }
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
