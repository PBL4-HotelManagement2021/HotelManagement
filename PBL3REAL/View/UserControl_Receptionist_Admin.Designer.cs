﻿
namespace PBL3REAL.View
{
    partial class UserControl_Receptionist_Admin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnshow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbRoom2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRoom1 = new System.Windows.Forms.ComboBox();
            this.searchRoom = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnroty_show = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnroty_add = new System.Windows.Forms.Button();
            this.btnroty_edit = new System.Windows.Forms.Button();
            this.btnroty_del = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbRoomtype = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(843, 876);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(835, 835);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chung";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnshow);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(835, 835);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lí danh sách phòng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(168, 176);
            this.btnshow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(86, 56);
            this.btnshow.TabIndex = 4;
            this.btnshow.Text = "button7";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(829, 563);
            this.dataGridView1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnadd);
            this.flowLayoutPanel1.Controls.Add(this.btnedit);
            this.flowLayoutPanel1.Controls.Add(this.btndelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(433, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(395, 147);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnadd
            // 
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnadd.Location = new System.Drawing.Point(3, 3);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(123, 147);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Thêm phòng mới";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnedit
            // 
            this.btnedit.FlatAppearance.BorderSize = 0;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnedit.Location = new System.Drawing.Point(132, 3);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(123, 147);
            this.btnedit.TabIndex = 4;
            this.btnedit.Text = "Chỉnh sửa thông tin phòng";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btndelete.Location = new System.Drawing.Point(261, 3);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(123, 147);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Xóa phòng đã chọn";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.52174F));
            this.tableLayoutPanel2.Controls.Add(this.cbRoom2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbRoom1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.searchRoom, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(373, 147);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cbRoom2
            // 
            this.cbRoom2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.cbRoom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbRoom2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoom2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRoom2.FormattingEnabled = true;
            this.cbRoom2.Location = new System.Drawing.Point(165, 51);
            this.cbRoom2.Name = "cbRoom2";
            this.cbRoom2.Size = new System.Drawing.Size(205, 36);
            this.cbRoom2.TabIndex = 5;
            this.cbRoom2.SelectedIndexChanged += new System.EventHandler(this.cbRoom2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tìm kiếm";
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 48);
            this.label4.TabIndex = 1;
            this.label4.Text = "Xem theo loại phòng";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sắp xếp theo";
            // 
            // cbRoom1
            // 
            this.cbRoom1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.cbRoom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbRoom1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRoom1.FormattingEnabled = true;
            this.cbRoom1.Location = new System.Drawing.Point(165, 3);
            this.cbRoom1.Name = "cbRoom1";
            this.cbRoom1.Size = new System.Drawing.Size(205, 36);
            this.cbRoom1.TabIndex = 4;
            // 
            // searchRoom
            // 
            this.searchRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.searchRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchRoom.Location = new System.Drawing.Point(165, 99);
            this.searchRoom.Name = "searchRoom";
            this.searchRoom.Size = new System.Drawing.Size(205, 27);
            this.searchRoom.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnroty_show);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Controls.Add(this.flowLayoutPanel2);
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage3.Location = new System.Drawing.Point(4, 37);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(835, 835);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Quản lí danh sách loại phòng";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnroty_show
            // 
            this.btnroty_show.Location = new System.Drawing.Point(205, 163);
            this.btnroty_show.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnroty_show.Name = "btnroty_show";
            this.btnroty_show.Size = new System.Drawing.Size(86, 48);
            this.btnroty_show.TabIndex = 7;
            this.btnroty_show.Text = "button1";
            this.btnroty_show.UseVisualStyleBackColor = true;
            this.btnroty_show.Click += new System.EventHandler(this.btnroty_show_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(0, 231);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(835, 604);
            this.dataGridView2.TabIndex = 6;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnroty_add);
            this.flowLayoutPanel2.Controls.Add(this.btnroty_edit);
            this.flowLayoutPanel2.Controls.Add(this.btnroty_del);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(435, 11);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(395, 147);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // btnroty_add
            // 
            this.btnroty_add.FlatAppearance.BorderSize = 0;
            this.btnroty_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnroty_add.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnroty_add.Location = new System.Drawing.Point(3, 3);
            this.btnroty_add.Name = "btnroty_add";
            this.btnroty_add.Size = new System.Drawing.Size(123, 147);
            this.btnroty_add.TabIndex = 3;
            this.btnroty_add.Text = "Thêm loại phòng mới";
            this.btnroty_add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnroty_add.UseVisualStyleBackColor = true;
            this.btnroty_add.Click += new System.EventHandler(this.btnroty_add_Click);
            // 
            // btnroty_edit
            // 
            this.btnroty_edit.FlatAppearance.BorderSize = 0;
            this.btnroty_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnroty_edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnroty_edit.Location = new System.Drawing.Point(132, 3);
            this.btnroty_edit.Name = "btnroty_edit";
            this.btnroty_edit.Size = new System.Drawing.Size(123, 147);
            this.btnroty_edit.TabIndex = 4;
            this.btnroty_edit.Text = "Chỉnh sửa thông tin loại phòng";
            this.btnroty_edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnroty_edit.UseVisualStyleBackColor = true;
            this.btnroty_edit.Click += new System.EventHandler(this.btnroty_edit_Click);
            // 
            // btnroty_del
            // 
            this.btnroty_del.FlatAppearance.BorderSize = 0;
            this.btnroty_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnroty_del.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnroty_del.Location = new System.Drawing.Point(261, 3);
            this.btnroty_del.Name = "btnroty_del";
            this.btnroty_del.Size = new System.Drawing.Size(123, 147);
            this.btnroty_del.TabIndex = 5;
            this.btnroty_del.Text = "Xóa loại phòng đã chọn";
            this.btnroty_del.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnroty_del.UseVisualStyleBackColor = true;
            this.btnroty_del.Click += new System.EventHandler(this.btnroty_del_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.36697F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.63303F));
            this.tableLayoutPanel3.Controls.Add(this.cbbRoomtype, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(11, 31);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(358, 111);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // cbbRoomtype
            // 
            this.cbbRoomtype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.cbbRoomtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbRoomtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRoomtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbRoomtype.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbbRoomtype.FormattingEnabled = true;
            this.cbbRoomtype.Location = new System.Drawing.Point(147, 3);
            this.cbbRoomtype.Name = "cbbRoomtype";
            this.cbbRoomtype.Size = new System.Drawing.Size(208, 39);
            this.cbbRoomtype.TabIndex = 5;
            this.cbbRoomtype.SelectedIndexChanged += new System.EventHandler(this.cbbRoomtype_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(147, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(208, 31);
            this.textBox2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 56);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tìm kiếm";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 55);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sắp xếp theo";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(104, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(93, 28);
            this.comboBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sắp xếp theo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.84746F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.15254F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UserControl_Receptionist_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl_Receptionist_Admin";
            this.Size = new System.Drawing.Size(838, 804);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbRoom2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRoom1;
        private System.Windows.Forms.TextBox searchRoom;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnroty_add;
        private System.Windows.Forms.Button btnroty_edit;
        private System.Windows.Forms.Button btnroty_del;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btnroty_show;
        private System.Windows.Forms.ComboBox cbbRoomtype;
    }
}