# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)
> **Buổi thực hành:** Buổi 1 - Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)
> **Buổi thực hành:** Buổi 2 - Bổ sung Xác thực (Authentication) bằng JWT và Phân quyền (Authorization) theo Role
 
---
 
## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API chịu trách nhiệm xử lý logic nghiệp vụ, quản lý dữ liệu, xác thực người dùng bằng JWT và cung cấp các RESTful API chuẩn hóa.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms đóng vai trò là máy trạm POS tại quầy. Người dùng phải đăng nhập trước (`FormLogin`) để lấy JWT Token, sau đó ứng dụng dùng `HttpClient` kèm Token này để gọi dữ liệu từ API qua mạng và hiển thị trực quan lên `DataGridView`.
---
 
## 🛠️ 2. Công nghệ Sử dụng
* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Controllers, In-Memory Data, LINQ
* **Bảo mật:** JWT Bearer Authentication (`Microsoft.AspNetCore.Authentication.JwtBearer`), Role-based Authorization
* **Frontend:** Windows Forms (.NET 8.0), `System.Net.Http.Json`, `System.Net.Http.Headers`
* **Công cụ kiểm thử:** Swagger UI
---
 
## 📂 3. Cấu trúc Solution
```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/          # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs     # Đăng nhập & phát hành JWT Token
│   │   └── CategoriesController.cs # CRUD & Search nhóm hàng (yêu cầu đăng nhập)
│   ├── Models/                   # Chứa lớp thực thể Category.cs
│   └── Program.cs                # Cấu hình dịch vụ, JWT Middleware
│
└── MiniSupermarket.WinForms/     # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs              # Màn hình đăng nhập, lấy JWT Token
    ├── FormCategoryManagement.cs # Giao diện quản lý danh mục CRUD (gắn kèm Token)
    └── SessionManager.cs         # Lưu trữ Token/Role phiên làm việc dùng chung toàn ứng dụng
```
 
---
 
## 🔐 4. Xác thực (Authentication) & Phân quyền (Authorization)
 
Kể từ Buổi 2, toàn bộ `CategoriesController` được gắn `[Authorize]`, nghĩa là **client bắt buộc phải đăng nhập lấy JWT Token trước** thì mới gọi được các API nhóm hàng.
 
### 4.1. Tài khoản mẫu (in-memory, chưa kết nối Database)
| Username  | Password | Role     |
|-----------|----------|----------|
| `admin`   | `123456` | Admin    |
| `cashier` | `123456` | Cashier  |
 
### 4.2. Endpoint đăng nhập
* **`POST /api/auth/login`** — không yêu cầu Token.
  * Body: `{ "username": "admin", "password": "123456" }`
  * Trả về `200 OK`: `{ "success": true, "token": "<JWT>", "role": "Admin" }`
  * Sai tài khoản/mật khẩu: `401 Unauthorized`.
  * Token được ký bằng thuật toán `HmacSha256`, khóa bí mật cấu hình tại `JwtSettings:Secret` trong `appsettings.json`, hiệu lực **2 giờ**.
### 4.3. Cách gửi kèm Token khi gọi API
Với mọi endpoint có `[Authorize]`, request phải đính kèm header:
```
Authorization: Bearer <token>
```
Về phía WinForms, `SessionManager` lưu `JwtToken`/`CurrentRole` sau khi đăng nhập thành công; `FormCategoryManagement` tự động gắn header này vào `HttpClient` khi Form được load.
 
### 4.4. Phân quyền theo Role
| Endpoint                              | Method | Quyền truy cập       | Mô tả                                          |
|----------------------------------------|--------|-----------------------|-------------------------------------------------|
| `/api/auth/login`                      | POST   | Public (không cần Token) | Đăng nhập, phát hành JWT                     |
| `/api/categories`                      | GET    | Admin, Cashier (đã đăng nhập) | Lấy toàn bộ danh sách nhóm hàng           |
| `/api/categories/{id}`                 | GET    | Admin, Cashier         | Lấy chi tiết nhóm hàng theo ID                 |
| `/api/categories/search?keyword=...`   | GET    | Admin, Cashier         | Tìm kiếm nhóm hàng theo từ khóa                |
| `/api/categories`                      | POST   | Admin, Cashier         | Thêm mới nhóm hàng                             |
| `/api/categories/{id}`                 | PUT    | Admin, Cashier         | Cập nhật nhóm hàng                             |
| `/api/categories/{id}`                 | DELETE | Admin, Cashier         | Xóa nhóm hàng                                  |
| `/api/categories/admin-dashboard`      | GET    | **Chỉ Admin**          | Trang quản trị, chặn tài khoản Cashier (`403`) |
| `/api/categories/staff-pos`            | GET    | Admin, Cashier         | Màn hình POS thu ngân dùng chung               |
 
> Gọi các endpoint trên mà **không** kèm Token sẽ trả về `401 Unauthorized`; đăng nhập đúng nhưng sai Role (ví dụ Cashier gọi `admin-dashboard`) sẽ trả về `403 Forbidden`.
 
### 4.5. Luồng hoạt động phía WinForms
1. Ứng dụng khởi động vào thẳng `FormLogin`.
2. Người dùng nhập tài khoản/mật khẩu → gọi `POST /api/auth/login`.
3. Đăng nhập thành công → Token và Role được lưu vào `SessionManager` → mở `FormCategoryManagement`, đóng `FormLogin`.
4. `FormCategoryManagement` gắn Token vào header `Authorization` cho mọi request CRUD/Search tiếp theo.
5. Nếu Token hết hạn (sau 2 giờ) hoặc chưa đăng nhập, API trả `401` — client cần đăng nhập lại.
---
 
## 🚀 5. Hướng dẫn Chạy và Kiểm thử Dự án
**Bước 1: Chạy phía Backend (Web API)**
1. Mở Solution bằng Visual Studio 2022.
2. Nhấp chuột phải vào project `MiniSupermarket.API` → chọn **Set as Startup Project**.
3. Nhấn **F5** để chạy. Trình duyệt sẽ tự động mở giao diện Swagger UI.
4. Trong Swagger, gọi thử `POST /api/auth/login` với tài khoản mẫu để lấy Token, bấm nút **Authorize** và dán `Bearer <token>` để kiểm thử các API nhóm hàng đã bảo mật.
**Bước 2: Chạy phía Frontend (WinForms Client)**
1. Đảm bảo cổng (Port) trong `SessionManager`/`FormLogin` (`http://localhost:7049/api/`) khớp với cổng Web API đang chạy.
2. Nhấp chuột phải vào project `MiniSupermarket.WinForms` → chọn **Debug → Start new instance**.
3. Ở màn hình đăng nhập, nhập một trong hai tài khoản mẫu (`admin`/`123456` hoặc `cashier`/`123456`).
4. Sau khi đăng nhập, thử nghiệm các chức năng: Tải danh sách, Thêm mới, Sửa, Xóa và Tìm kiếm nhóm hàng.
5. Đăng nhập bằng `cashier` và thử gọi tính năng dành riêng cho Admin để kiểm chứng cơ chế phân quyền theo Role.
---
 
## 👨‍💻 6. Tác giả
* **Họ tên sinh viên:** Đào Thanh Nhật
* **Mã sinh viên:** 2124110092
* **Lớp học phần:** CCQ2411C
