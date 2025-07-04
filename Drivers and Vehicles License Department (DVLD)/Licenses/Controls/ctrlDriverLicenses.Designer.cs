namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Controls
{
    partial class ctrlDriverLicenses
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
            this.components = new System.ComponentModel.Container();
            this.cmShowlocalLicenseInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowLicenseDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmShowInternationalLicenseInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowInternationalLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabInternational = new System.Windows.Forms.TabPage();
            this.siticonePanel2 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInternationalRecordsCount = new System.Windows.Forms.Label();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.lblLocalRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDriverLicenses = new SiticoneNetFrameworkUI.SiticoneTabControl();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.cmShowlocalLicenseInfo.SuspendLayout();
            this.cmShowInternationalLicenseInfo.SuspendLayout();
            this.tabInternational.SuspendLayout();
            this.siticonePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.tabLocal.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            this.gbDriverLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // cmShowlocalLicenseInfo
            // 
            this.cmShowlocalLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmShowlocalLicenseInfo.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmShowlocalLicenseInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowLicenseDetailsToolStripMenuItem1});
            this.cmShowlocalLicenseInfo.Name = "cmPersonSettings";
            this.cmShowlocalLicenseInfo.Size = new System.Drawing.Size(207, 42);
            // 
            // ShowLicenseDetailsToolStripMenuItem1
            // 
            this.ShowLicenseDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_credit_card_person_24_filled;
            this.ShowLicenseDetailsToolStripMenuItem1.Name = "ShowLicenseDetailsToolStripMenuItem1";
            this.ShowLicenseDetailsToolStripMenuItem1.Size = new System.Drawing.Size(206, 38);
            this.ShowLicenseDetailsToolStripMenuItem1.Text = "Show License Details";
            this.ShowLicenseDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowLicenseDetailsToolStripMenuItem1_Click);
            // 
            // cmShowInternationalLicenseInfo
            // 
            this.cmShowInternationalLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmShowInternationalLicenseInfo.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmShowInternationalLicenseInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowInternationalLicenseInfo});
            this.cmShowInternationalLicenseInfo.Name = "cmPersonSettings";
            this.cmShowInternationalLicenseInfo.Size = new System.Drawing.Size(207, 42);
            // 
            // ShowInternationalLicenseInfo
            // 
            this.ShowInternationalLicenseInfo.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_credit_card_person_24_filled;
            this.ShowInternationalLicenseInfo.Name = "ShowInternationalLicenseInfo";
            this.ShowInternationalLicenseInfo.Size = new System.Drawing.Size(206, 38);
            this.ShowInternationalLicenseInfo.Text = "Show License Details";
            this.ShowInternationalLicenseInfo.Click += new System.EventHandler(this.ShowInternationalLicenseInfo_Click);
            // 
            // tabInternational
            // 
            this.tabInternational.Controls.Add(this.lblInternationalRecordsCount);
            this.tabInternational.Controls.Add(this.label2);
            this.tabInternational.Controls.Add(this.siticonePanel2);
            this.tabInternational.Location = new System.Drawing.Point(4, 44);
            this.tabInternational.Name = "tabInternational";
            this.tabInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternational.Size = new System.Drawing.Size(1150, 284);
            this.tabInternational.TabIndex = 1;
            this.tabInternational.Text = "International";
            this.tabInternational.UseVisualStyleBackColor = true;
            // 
            // siticonePanel2
            // 
            this.siticonePanel2.AcrylicTintColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel2.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel2.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.siticonePanel2.BorderDashPattern = null;
            this.siticonePanel2.BorderGradientEndColor = System.Drawing.Color.Purple;
            this.siticonePanel2.BorderGradientStartColor = System.Drawing.Color.Blue;
            this.siticonePanel2.BorderThickness = 2F;
            this.siticonePanel2.Controls.Add(this.dgvInternationalLicenses);
            this.siticonePanel2.CornerRadiusBottomLeft = 10F;
            this.siticonePanel2.CornerRadiusBottomRight = 10F;
            this.siticonePanel2.CornerRadiusTopLeft = 10F;
            this.siticonePanel2.CornerRadiusTopRight = 10F;
            this.siticonePanel2.EnableAcrylicEffect = false;
            this.siticonePanel2.EnableMicaEffect = false;
            this.siticonePanel2.EnableRippleEffect = false;
            this.siticonePanel2.FillColor = System.Drawing.Color.White;
            this.siticonePanel2.GradientColors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.Gray};
            this.siticonePanel2.GradientPositions = new float[] {
        0F,
        0.5F,
        1F};
            this.siticonePanel2.Location = new System.Drawing.Point(6, 11);
            this.siticonePanel2.Name = "siticonePanel2";
            this.siticonePanel2.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.siticonePanel2.RippleAlpha = 50;
            this.siticonePanel2.RippleAlphaDecrement = 3;
            this.siticonePanel2.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel2.RippleMaxSize = 600F;
            this.siticonePanel2.RippleSpeed = 15F;
            this.siticonePanel2.ShowBorder = true;
            this.siticonePanel2.Size = new System.Drawing.Size(1138, 239);
            this.siticonePanel2.TabIndex = 66;
            this.siticonePanel2.TabStop = true;
            this.siticonePanel2.UseBorderGradient = false;
            this.siticonePanel2.UseMultiGradient = false;
            this.siticonePanel2.UsePatternTexture = false;
            this.siticonePanel2.UseRadialGradient = false;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToResizeColumns = false;
            this.dgvInternationalLicenses.AllowUserToResizeRows = false;
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.cmShowInternationalLicenseInfo;
            this.dgvInternationalLicenses.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(12, 12);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1114, 211);
            this.dgvInternationalLicenses.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 65;
            this.label2.Text = "# Records:";
            // 
            // lblInternationalRecordsCount
            // 
            this.lblInternationalRecordsCount.AutoSize = true;
            this.lblInternationalRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalRecordsCount.Location = new System.Drawing.Point(107, 253);
            this.lblInternationalRecordsCount.Name = "lblInternationalRecordsCount";
            this.lblInternationalRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblInternationalRecordsCount.TabIndex = 64;
            this.lblInternationalRecordsCount.Text = "# Records:";
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.label3);
            this.tabLocal.Controls.Add(this.lblLocalRecordsCount);
            this.tabLocal.Controls.Add(this.siticonePanel1);
            this.tabLocal.Location = new System.Drawing.Point(4, 44);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(1150, 284);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "Local";
            this.tabLocal.UseVisualStyleBackColor = true;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.AcrylicTintColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel1.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel1.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.siticonePanel1.BorderDashPattern = null;
            this.siticonePanel1.BorderGradientEndColor = System.Drawing.Color.Purple;
            this.siticonePanel1.BorderGradientStartColor = System.Drawing.Color.Blue;
            this.siticonePanel1.BorderThickness = 2F;
            this.siticonePanel1.Controls.Add(this.dgvLocalLicenses);
            this.siticonePanel1.CornerRadiusBottomLeft = 10F;
            this.siticonePanel1.CornerRadiusBottomRight = 10F;
            this.siticonePanel1.CornerRadiusTopLeft = 10F;
            this.siticonePanel1.CornerRadiusTopRight = 10F;
            this.siticonePanel1.EnableAcrylicEffect = false;
            this.siticonePanel1.EnableMicaEffect = false;
            this.siticonePanel1.EnableRippleEffect = false;
            this.siticonePanel1.FillColor = System.Drawing.Color.White;
            this.siticonePanel1.GradientColors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.Gray};
            this.siticonePanel1.GradientPositions = new float[] {
        0F,
        0.5F,
        1F};
            this.siticonePanel1.Location = new System.Drawing.Point(6, 6);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.siticonePanel1.RippleAlpha = 50;
            this.siticonePanel1.RippleAlphaDecrement = 3;
            this.siticonePanel1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel1.RippleMaxSize = 600F;
            this.siticonePanel1.RippleSpeed = 15F;
            this.siticonePanel1.ShowBorder = true;
            this.siticonePanel1.Size = new System.Drawing.Size(1138, 239);
            this.siticonePanel1.TabIndex = 63;
            this.siticonePanel1.TabStop = true;
            this.siticonePanel1.UseBorderGradient = false;
            this.siticonePanel1.UseMultiGradient = false;
            this.siticonePanel1.UsePatternTexture = false;
            this.siticonePanel1.UseRadialGradient = false;
            // 
            // lblLocalRecordsCount
            // 
            this.lblLocalRecordsCount.AutoSize = true;
            this.lblLocalRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecordsCount.Location = new System.Drawing.Point(107, 248);
            this.lblLocalRecordsCount.Name = "lblLocalRecordsCount";
            this.lblLocalRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblLocalRecordsCount.TabIndex = 62;
            this.lblLocalRecordsCount.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 61;
            this.label3.Text = "# Records:";
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.BorderColor = System.Drawing.Color.Transparent;
            this.gbDriverLicenses.BorderWidth = 1;
            this.gbDriverLicenses.CloseButtonColor = System.Drawing.Color.Gray;
            this.gbDriverLicenses.CloseButtonHoverColor = System.Drawing.Color.Red;
            this.gbDriverLicenses.CloseButtonSymbolPadding = 0.25F;
            this.gbDriverLicenses.CloseButtonThickness = 1.8F;
            this.gbDriverLicenses.ContextMenuFont = new System.Drawing.Font("Segoe UI", 10F);
            this.gbDriverLicenses.Controls.Add(this.tabLocal);
            this.gbDriverLicenses.Controls.Add(this.tabInternational);
            this.gbDriverLicenses.DragIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.gbDriverLicenses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbDriverLicenses.GhostBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(65)))));
            this.gbDriverLicenses.GhostForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gbDriverLicenses.ItemSize = new System.Drawing.Size(160, 40);
            this.gbDriverLicenses.Location = new System.Drawing.Point(8, 8);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.PinIconHoverColor = System.Drawing.Color.DarkGray;
            this.gbDriverLicenses.PinnedIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.gbDriverLicenses.RippleColor = System.Drawing.Color.LightGray;
            this.gbDriverLicenses.SelectedIndex = 0;
            this.gbDriverLicenses.SelectedTabBackColor = System.Drawing.Color.Transparent;
            this.gbDriverLicenses.SelectedTabFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbDriverLicenses.SelectedTabIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(65)))));
            this.gbDriverLicenses.SelectedTabIndicatorHeight = 3;
            this.gbDriverLicenses.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(65)))));
            this.gbDriverLicenses.SeparatorLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gbDriverLicenses.SeparatorLineOpacity = 0.4F;
            this.gbDriverLicenses.Size = new System.Drawing.Size(1158, 332);
            this.gbDriverLicenses.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.gbDriverLicenses.TabIndex = 2;
            this.gbDriverLicenses.UnpinnedIconColor = System.Drawing.Color.Gray;
            this.gbDriverLicenses.UnselectedTabColor = System.Drawing.Color.Transparent;
            this.gbDriverLicenses.UnselectedTextColor = System.Drawing.Color.Gray;
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToResizeColumns = false;
            this.dgvLocalLicenses.AllowUserToResizeRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.cmShowlocalLicenseInfo;
            this.dgvLocalLicenses.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(12, 12);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1114, 211);
            this.dgvLocalLicenses.TabIndex = 1;
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriverLicenses);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1158, 332);
            this.cmShowlocalLicenseInfo.ResumeLayout(false);
            this.cmShowInternationalLicenseInfo.ResumeLayout(false);
            this.tabInternational.ResumeLayout(false);
            this.tabInternational.PerformLayout();
            this.siticonePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            this.siticonePanel1.ResumeLayout(false);
            this.gbDriverLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmShowInternationalLicenseInfo;
        private System.Windows.Forms.ToolStripMenuItem ShowInternationalLicenseInfo;
        private System.Windows.Forms.ContextMenuStrip cmShowlocalLicenseInfo;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetailsToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabInternational;
        private System.Windows.Forms.Label lblInternationalRecordsCount;
        private System.Windows.Forms.Label label2;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel2;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocalRecordsCount;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel1;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private SiticoneNetFrameworkUI.SiticoneTabControl gbDriverLicenses;
    }
}
