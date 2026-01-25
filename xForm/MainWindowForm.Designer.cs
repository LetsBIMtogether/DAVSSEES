// MainWindowForm.cs

namespace AG_DAVSSEES.xForm
{
    partial class MainWindowForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_Drawings = new System.Windows.Forms.ListView();
            this.columnHeader_viewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_dwgType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_CheckAll = new System.Windows.Forms.Button();
            this.button_UncheckAll = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel_FilterAndAbout = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_FilterKeyword = new System.Windows.Forms.TextBox();
            this.button_About = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel_FilterAndAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView_Drawings, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel_FilterAndAbout, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 537);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(554, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // listView_Drawings
            // 
            this.listView_Drawings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Drawings.CheckBoxes = true;
            this.listView_Drawings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_viewName,
            this.columnHeader_dwgType});
            this.listView_Drawings.HideSelection = false;
            this.listView_Drawings.Location = new System.Drawing.Point(3, 133);
            this.listView_Drawings.Name = "listView_Drawings";
            this.listView_Drawings.Size = new System.Drawing.Size(554, 361);
            this.listView_Drawings.TabIndex = 2;
            this.listView_Drawings.UseCompatibleStateImageBehavior = false;
            this.listView_Drawings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_viewName
            // 
            this.columnHeader_viewName.Text = "View Name";
            this.columnHeader_viewName.Width = 375;
            // 
            // columnHeader_dwgType
            // 
            this.columnHeader_dwgType.Text = "Drawing Type";
            this.columnHeader_dwgType.Width = 175;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_CheckAll, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_UncheckAll, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Delete, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 500);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(554, 34);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // button_CheckAll
            // 
            this.button_CheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CheckAll.Location = new System.Drawing.Point(0, 3);
            this.button_CheckAll.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.button_CheckAll.Name = "button_CheckAll";
            this.button_CheckAll.Size = new System.Drawing.Size(135, 28);
            this.button_CheckAll.TabIndex = 0;
            this.button_CheckAll.Text = "Check All";
            this.button_CheckAll.UseVisualStyleBackColor = true;
            this.button_CheckAll.Click += new System.EventHandler(this.button_CheckAll_Click);
            // 
            // button_UncheckAll
            // 
            this.button_UncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_UncheckAll.Location = new System.Drawing.Point(141, 3);
            this.button_UncheckAll.Name = "button_UncheckAll";
            this.button_UncheckAll.Size = new System.Drawing.Size(132, 28);
            this.button_UncheckAll.TabIndex = 0;
            this.button_UncheckAll.Text = "Uncheck All";
            this.button_UncheckAll.UseVisualStyleBackColor = true;
            this.button_UncheckAll.Click += new System.EventHandler(this.button_UncheckAll_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Delete.Location = new System.Drawing.Point(279, 3);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(275, 28);
            this.button_Delete.TabIndex = 0;
            this.button_Delete.Text = "^ DELETE ALL EXCEPT CHECKED ITEMS ^";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // tableLayoutPanel_FilterAndAbout
            // 
            this.tableLayoutPanel_FilterAndAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_FilterAndAbout.ColumnCount = 2;
            this.tableLayoutPanel_FilterAndAbout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_FilterAndAbout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel_FilterAndAbout.Controls.Add(this.textBox_FilterKeyword, 0, 0);
            this.tableLayoutPanel_FilterAndAbout.Controls.Add(this.button_About, 1, 0);
            this.tableLayoutPanel_FilterAndAbout.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel_FilterAndAbout.Name = "tableLayoutPanel_FilterAndAbout";
            this.tableLayoutPanel_FilterAndAbout.RowCount = 1;
            this.tableLayoutPanel_FilterAndAbout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_FilterAndAbout.Size = new System.Drawing.Size(554, 34);
            this.tableLayoutPanel_FilterAndAbout.TabIndex = 4;
            // 
            // textBox_FilterKeyword
            // 
            this.textBox_FilterKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FilterKeyword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FilterKeyword.Location = new System.Drawing.Point(0, 3);
            this.textBox_FilterKeyword.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.textBox_FilterKeyword.Name = "textBox_FilterKeyword";
            this.textBox_FilterKeyword.Size = new System.Drawing.Size(379, 27);
            this.textBox_FilterKeyword.TabIndex = 1;
            // 
            // button_About
            // 
            this.button_About.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_About.Location = new System.Drawing.Point(385, 3);
            this.button_About.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(169, 28);
            this.button_About.TabIndex = 2;
            this.button_About.Text = "About This Plugin";
            this.button_About.UseVisualStyleBackColor = true;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 900);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainWindowForm";
            this.Text = "AG DAVSSEES v1.0";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel_FilterAndAbout.ResumeLayout(false);
            this.tableLayoutPanel_FilterAndAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FilterKeyword;
        private System.Windows.Forms.ListView listView_Drawings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_CheckAll;
        private System.Windows.Forms.Button button_UncheckAll;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.ColumnHeader columnHeader_dwgType;
        private System.Windows.Forms.ColumnHeader columnHeader_viewName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FilterAndAbout;
        private System.Windows.Forms.Button button_About;
    }
}