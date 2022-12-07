
namespace RandomSelector
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.btn_CheckNumber = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.進階操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_reset = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBox_numberDisplay = new System.Windows.Forms.PictureBox();
            this.PictureBox_unselectNumber = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_numberDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_unselectNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "號碼範圍";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(22, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "1-";
            // 
            // numUpDown
            // 
            this.numUpDown.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numUpDown.Location = new System.Drawing.Point(52, 56);
            this.numUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(76, 31);
            this.numUpDown.TabIndex = 0;
            this.numUpDown.TabStop = false;
            this.numUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyInput);
            // 
            // btn_CheckNumber
            // 
            this.btn_CheckNumber.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_CheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btn_CheckNumber.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_CheckNumber.Location = new System.Drawing.Point(20, 99);
            this.btn_CheckNumber.Name = "btn_CheckNumber";
            this.btn_CheckNumber.Size = new System.Drawing.Size(105, 33);
            this.btn_CheckNumber.TabIndex = 0;
            this.btn_CheckNumber.Text = "確認號碼";
            this.btn_CheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_CheckNumber.Click += new System.EventHandler(this.Btn_CheckNumber_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Select.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btn_Select.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Select.Location = new System.Drawing.Point(170, 364);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(161, 88);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "抽獎";
            this.btn_Select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Select.Click += new System.EventHandler(this.Btn_Select_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.進階操作ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 31);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyInput);
            // 
            // 進階操作ToolStripMenuItem
            // 
            this.進階操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_reset});
            this.進階操作ToolStripMenuItem.Name = "進階操作ToolStripMenuItem";
            this.進階操作ToolStripMenuItem.Size = new System.Drawing.Size(98, 27);
            this.進階操作ToolStripMenuItem.Text = "進階操作";
            // 
            // tool_reset
            // 
            this.tool_reset.Name = "tool_reset";
            this.tool_reset.Size = new System.Drawing.Size(146, 34);
            this.tool_reset.Text = "重置";
            this.tool_reset.Click += new System.EventHandler(this.Tool_reset_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numUpDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_CheckNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 480);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Select, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.axWindowsMediaPlayer1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_numberDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PictureBox_unselectNumber, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(148, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(838, 480);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(337, 339);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // pictureBox_numberDisplay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox_numberDisplay, 3);
            this.pictureBox_numberDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_numberDisplay.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_numberDisplay.Name = "pictureBox_numberDisplay";
            this.pictureBox_numberDisplay.Size = new System.Drawing.Size(495, 330);
            this.pictureBox_numberDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_numberDisplay.TabIndex = 2;
            this.pictureBox_numberDisplay.TabStop = false;
            // 
            // PictureBox_unselectNumber
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.PictureBox_unselectNumber, 2);
            this.PictureBox_unselectNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox_unselectNumber.Location = new System.Drawing.Point(504, 3);
            this.PictureBox_unselectNumber.Name = "PictureBox_unselectNumber";
            this.tableLayoutPanel1.SetRowSpan(this.PictureBox_unselectNumber, 2);
            this.PictureBox_unselectNumber.Size = new System.Drawing.Size(331, 474);
            this.PictureBox_unselectNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_unselectNumber.TabIndex = 3;
            this.PictureBox_unselectNumber.TabStop = false;
            this.PictureBox_unselectNumber.Resize += new System.EventHandler(this.PictureBox_unselectNumber_ReSize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.BackgroundImage = global::RandomSelector.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(986, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoadForm);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyInput);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_numberDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_unselectNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.Label btn_CheckNumber;
        private System.Windows.Forms.Label btn_Select;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 進階操作ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem tool_reset;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.PictureBox pictureBox_numberDisplay;
        private System.Windows.Forms.PictureBox PictureBox_unselectNumber;
    }
}

