namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblInfoTitle;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblSearch = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.lblListTitle = new System.Windows.Forms.Label();
            this.lblInfoTitle = new System.Windows.Forms.Label();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // =========================================================
            // FORM
            // =========================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(630, 350);

            this.MinimumSize =
                new System.Drawing.Size(630, 350);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Name =
                "FormCategoryManagement";

            this.Text =
                "Quản lý Danh mục Nhóm hàng";

            // =========================================================
            // LABEL TÌM KIẾM
            // =========================================================

            this.lblSearch.AutoSize = true;

            this.lblSearch.Location =
                new System.Drawing.Point(20, 15);

            this.lblSearch.Name =
                "lblSearch";

            this.lblSearch.Size =
                new System.Drawing.Size(53, 15);

            this.lblSearch.Text =
                "Tìm kiếm";

            // =========================================================
            // TEXTBOX TÌM KIẾM
            // =========================================================

            this.txtSearch.Location =
                new System.Drawing.Point(20, 35);

            this.txtSearch.Name =
                "txtSearch";

            this.txtSearch.Size =
                new System.Drawing.Size(235, 23);

            this.txtSearch.TabIndex = 0;

            this.txtSearch.ForeColor =
                System.Drawing.Color.Gray;

            // Event placeholder
            this.txtSearch.Enter +=
                new System.EventHandler(
                    this.txtSearch_Enter);

            this.txtSearch.Leave +=
                new System.EventHandler(
                    this.txtSearch_Leave);

            // =========================================================
            // BUTTON TÌM KIẾM
            // =========================================================

            this.btnSearch.Location =
                new System.Drawing.Point(263, 34);

            this.btnSearch.Name =
                "btnSearch";

            this.btnSearch.Size =
                new System.Drawing.Size(72, 25);

            this.btnSearch.TabIndex = 1;

            this.btnSearch.Text =
                "Tìm kiếm";

            this.btnSearch.UseVisualStyleBackColor =
                true;

            this.btnSearch.Click +=
                new System.EventHandler(
                    this.btnSearch_Click);

            // =========================================================
            // BUTTON TẢI LẠI
            // =========================================================

            this.btnReload.Location =
                new System.Drawing.Point(341, 34);

            this.btnReload.Name =
                "btnReload";

            this.btnReload.Size =
                new System.Drawing.Size(70, 25);

            this.btnReload.TabIndex = 2;

            this.btnReload.Text =
                "Tải lại";

            this.btnReload.UseVisualStyleBackColor =
                true;

            this.btnReload.Click +=
                new System.EventHandler(
                    this.btnReload_Click);

            // =========================================================
            // TIÊU ĐỀ DANH SÁCH
            // =========================================================

            this.lblListTitle.AutoSize = true;

            this.lblListTitle.Location =
                new System.Drawing.Point(20, 70);

            this.lblListTitle.Name =
                "lblListTitle";

            this.lblListTitle.Size =
                new System.Drawing.Size(123, 15);

            this.lblListTitle.Text =
                "Danh sách Nhóm hàng";

            // =========================================================
            // DATAGRIDVIEW
            // =========================================================

            this.dataGridView1.AllowUserToAddRows =
                false;

            this.dataGridView1.AllowUserToDeleteRows =
                false;

            this.dataGridView1.AllowUserToResizeRows =
                false;

            this.dataGridView1.AutoGenerateColumns =
                false;

            this.dataGridView1.BackgroundColor =
                System.Drawing.Color.White;

            this.dataGridView1.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dataGridView1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colID,
                    this.colName,
                    this.colDescription
                });

            this.dataGridView1.Location =
                new System.Drawing.Point(20, 90);

            this.dataGridView1.MultiSelect =
                false;

            this.dataGridView1.Name =
                "dataGridView1";

            this.dataGridView1.ReadOnly =
                true;

            this.dataGridView1.RowHeadersWidth =
                30;

            this.dataGridView1.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridView1.Size =
                new System.Drawing.Size(395, 225);

            this.dataGridView1.TabIndex = 3;

            this.dataGridView1.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dataGridView1_CellClick);

            // =========================================================
            // COLUMN ID
            // =========================================================

            this.colID.DataPropertyName =
                "ID";

            this.colID.HeaderText =
                "Mã ID";

            this.colID.Name =
                "colID";

            this.colID.ReadOnly =
                true;

            this.colID.Width =
                60;

            // =========================================================
            // COLUMN NAME
            // =========================================================

            this.colName.DataPropertyName =
                "Name";

            this.colName.HeaderText =
                "Tên Nhóm hàng";

            this.colName.Name =
                "colName";

            this.colName.ReadOnly =
                true;

            this.colName.Width =
                155;

            // =========================================================
            // COLUMN DESCRIPTION
            // =========================================================

            this.colDescription.DataPropertyName =
                "Description";

            this.colDescription.HeaderText =
                "Mô Tả";

            this.colDescription.Name =
                "colDescription";

            this.colDescription.ReadOnly =
                true;

            this.colDescription.AutoSizeMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            // =========================================================
            // TIÊU ĐỀ THÔNG TIN
            // =========================================================

            this.lblInfoTitle.AutoSize = true;

            this.lblInfoTitle.Location =
                new System.Drawing.Point(430, 70);

            this.lblInfoTitle.Name =
                "lblInfoTitle";

            this.lblInfoTitle.Size =
                new System.Drawing.Size(117, 15);

            this.lblInfoTitle.Text =
                "Thông tin Nhóm hàng";

            // =========================================================
            // LABEL MÃ ID
            // =========================================================

            this.lblID.AutoSize = true;

            this.lblID.Location =
                new System.Drawing.Point(430, 93);

            this.lblID.Name =
                "lblID";

            this.lblID.Size =
                new System.Drawing.Size(32, 15);

            this.lblID.Text =
                "Mã ID";

            // =========================================================
            // TEXTBOX ID
            // =========================================================

            this.txtID.Location =
                new System.Drawing.Point(430, 110);

            this.txtID.Name =
                "txtID";

            this.txtID.ReadOnly =
                true;

            this.txtID.Size =
                new System.Drawing.Size(180, 23);

            this.txtID.TabIndex = 4;

            // =========================================================
            // LABEL TÊN
            // =========================================================

            this.lblName.AutoSize = true;

            this.lblName.Location =
                new System.Drawing.Point(430, 140);

            this.lblName.Name =
                "lblName";

            this.lblName.Size =
                new System.Drawing.Size(82, 15);

            this.lblName.Text =
                "Tên Nhóm hàng";

            // =========================================================
            // TEXTBOX TÊN
            // =========================================================

            this.txtName.Location =
                new System.Drawing.Point(430, 157);

            this.txtName.Name =
                "txtName";

            this.txtName.Size =
                new System.Drawing.Size(180, 23);

            this.txtName.TabIndex = 5;

            // =========================================================
            // LABEL MÔ TẢ
            // =========================================================

            this.lblDescription.AutoSize = true;

            this.lblDescription.Location =
                new System.Drawing.Point(430, 187);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(42, 15);

            this.lblDescription.Text =
                "Mô Tả";

            // =========================================================
            // TEXTBOX MÔ TẢ
            // =========================================================

            this.txtDescription.Location =
                new System.Drawing.Point(430, 204);

            this.txtDescription.Multiline =
                true;

            this.txtDescription.Name =
                "txtDescription";

            this.txtDescription.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtDescription.Size =
                new System.Drawing.Size(180, 55);

            this.txtDescription.TabIndex = 6;

            // =========================================================
            // BUTTON THÊM MỚI
            // =========================================================

            this.btnAdd.Location =
                new System.Drawing.Point(430, 272);

            this.btnAdd.Name =
                "btnAdd";

            this.btnAdd.Size =
                new System.Drawing.Size(58, 27);

            this.btnAdd.TabIndex = 7;

            this.btnAdd.Text =
                "Thêm mới";

            this.btnAdd.UseVisualStyleBackColor =
                true;

            this.btnAdd.Click +=
                new System.EventHandler(
                    this.btnAdd_Click);

            // =========================================================
            // BUTTON CẬP NHẬT
            // =========================================================

            this.btnUpdate.Location =
                new System.Drawing.Point(494, 272);

            this.btnUpdate.Name =
                "btnUpdate";

            this.btnUpdate.Size =
                new System.Drawing.Size(58, 27);

            this.btnUpdate.TabIndex = 8;

            this.btnUpdate.Text =
                "Cập nhật";

            this.btnUpdate.UseVisualStyleBackColor =
                true;

            this.btnUpdate.Click +=
                new System.EventHandler(
                    this.btnUpdate_Click);

            // =========================================================
            // BUTTON XÓA
            // =========================================================

            this.btnDelete.Location =
                new System.Drawing.Point(558, 272);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(52, 27);

            this.btnDelete.TabIndex = 9;

            this.btnDelete.Text =
                "Xóa";

            this.btnDelete.UseVisualStyleBackColor =
                true;

            this.btnDelete.Click +=
                new System.EventHandler(
                    this.btnDelete_Click);

            // =========================================================
            // STATUS STRIP
            // =========================================================

            this.statusStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.lblStatus
                });

            this.statusStrip1.Location =
                new System.Drawing.Point(0, 328);

            this.statusStrip1.Name =
                "statusStrip1";

            this.statusStrip1.Size =
                new System.Drawing.Size(630, 22);

            this.statusStrip1.TabIndex = 10;

            this.statusStrip1.Text =
                "statusStrip1";

            // =========================================================
            // STATUS LABEL
            // =========================================================

            this.lblStatus.Name =
                "lblStatus";

            this.lblStatus.Size =
                new System.Drawing.Size(39, 17);

            this.lblStatus.Text =
                "Ready";

            // =========================================================
            // ADD CONTROLS
            // =========================================================

            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReload);

            this.Controls.Add(this.lblListTitle);
            this.Controls.Add(this.dataGridView1);

            this.Controls.Add(this.lblInfoTitle);

            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtID);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);

            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);

            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);

            this.Controls.Add(this.statusStrip1);

            // =========================================================
            // FORM LOAD EVENT
            // =========================================================

            this.Load +=
                new System.EventHandler(
                    this.FormCategoryManagement_Load_1);

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1)).EndInit();

            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
