namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    partial class frmLicensesHistory
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
            this.siticoneTabControl1 = new SiticoneNetFrameworkUI.SiticoneTabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.tabInternational = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.siticonePanel2 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCloseForm = new SiticoneNetFrameworkUI.SiticoneButton();
            this.ctrlPersonCard1 = new Drivers_and_Vehicles_License_Department__DVLD_.ctrlPersonCard();
            this.siticoneTabControl1.SuspendLayout();
            this.tabLocal.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.tabInternational.SuspendLayout();
            this.siticonePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // siticoneTabControl1
            // 
            this.siticoneTabControl1.BorderColor = System.Drawing.Color.Transparent;
            this.siticoneTabControl1.BorderWidth = 1;
            this.siticoneTabControl1.CloseButtonColor = System.Drawing.Color.Gray;
            this.siticoneTabControl1.CloseButtonHoverColor = System.Drawing.Color.Red;
            this.siticoneTabControl1.CloseButtonSymbolPadding = 0.25F;
            this.siticoneTabControl1.CloseButtonThickness = 1.8F;
            this.siticoneTabControl1.ContextMenuFont = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneTabControl1.Controls.Add(this.tabLocal);
            this.siticoneTabControl1.Controls.Add(this.tabInternational);
            this.siticoneTabControl1.DragIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.siticoneTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneTabControl1.GhostBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(65)))));
            this.siticoneTabControl1.GhostForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siticoneTabControl1.ItemSize = new System.Drawing.Size(160, 40);
            this.siticoneTabControl1.Location = new System.Drawing.Point(14, 668);
            this.siticoneTabControl1.Name = "siticoneTabControl1";
            this.siticoneTabControl1.PinIconHoverColor = System.Drawing.Color.DarkGray;
            this.siticoneTabControl1.PinnedIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.siticoneTabControl1.RippleColor = System.Drawing.Color.LightGray;
            this.siticoneTabControl1.SelectedIndex = 0;
            this.siticoneTabControl1.SelectedTabBackColor = System.Drawing.Color.Transparent;
            this.siticoneTabControl1.SelectedTabFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.siticoneTabControl1.SelectedTabIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(65)))));
            this.siticoneTabControl1.SelectedTabIndicatorHeight = 3;
            this.siticoneTabControl1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(65)))));
            this.siticoneTabControl1.SeparatorLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siticoneTabControl1.SeparatorLineOpacity = 0.4F;
            this.siticoneTabControl1.Size = new System.Drawing.Size(1158, 332);
            this.siticoneTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.siticoneTabControl1.TabIndex = 1;
            this.siticoneTabControl1.UnpinnedIconColor = System.Drawing.Color.Gray;
            this.siticoneTabControl1.UnselectedTabColor = System.Drawing.Color.Transparent;
            this.siticoneTabControl1.UnselectedTextColor = System.Drawing.Color.Gray;
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.label3);
            this.tabLocal.Controls.Add(this.lblRecordsCount);
            this.tabLocal.Controls.Add(this.siticonePanel1);
            this.tabLocal.Location = new System.Drawing.Point(4, 44);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(1150, 284);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "Local";
            this.tabLocal.UseVisualStyleBackColor = true;
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
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(107, 248);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblRecordsCount.TabIndex = 62;
            this.lblRecordsCount.Text = "# Records:";
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
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToResizeColumns = false;
            this.dgvLocalLicenses.AllowUserToResizeRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(12, 12);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1114, 211);
            this.dgvLocalLicenses.TabIndex = 1;
            // 
            // tabInternational
            // 
            this.tabInternational.Controls.Add(this.label1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "# Records:";
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
            // siticonePanel2
            // 
            this.siticonePanel2.AcrylicTintColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel2.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel2.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.siticonePanel2.BorderDashPattern = null;
            this.siticonePanel2.BorderGradientEndColor = System.Drawing.Color.Purple;
            this.siticonePanel2.BorderGradientStartColor = System.Drawing.Color.Blue;
            this.siticonePanel2.BorderThickness = 2F;
            this.siticonePanel2.Controls.Add(this.dataGridView1);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1114, 211);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnCloseForm.AccessibleName = "Close";
            this.btnCloseForm.AutoSizeBasedOnText = false;
            this.btnCloseForm.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseForm.BadgeBackColor = System.Drawing.Color.Red;
            this.btnCloseForm.BadgeFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.BadgeValue = 0;
            this.btnCloseForm.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnCloseForm.BorderColor = System.Drawing.Color.Transparent;
            this.btnCloseForm.BorderWidth = 2;
            this.btnCloseForm.ButtonBackColor = System.Drawing.Color.Silver;
            this.btnCloseForm.ButtonImage = null;
            this.btnCloseForm.CanBeep = true;
            this.btnCloseForm.CanGlow = false;
            this.btnCloseForm.CanShake = true;
            this.btnCloseForm.ContextMenuStripEx = null;
            this.btnCloseForm.CornerRadiusBottomLeft = 20;
            this.btnCloseForm.CornerRadiusBottomRight = 20;
            this.btnCloseForm.CornerRadiusTopLeft = 20;
            this.btnCloseForm.CornerRadiusTopRight = 20;
            this.btnCloseForm.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnCloseForm.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnCloseForm.EnableLongPress = false;
            this.btnCloseForm.EnablePressAnimation = true;
            this.btnCloseForm.EnableRippleEffect = true;
            this.btnCloseForm.EnableShadow = false;
            this.btnCloseForm.EnableTextWrapping = false;
            this.btnCloseForm.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.ForeColor = System.Drawing.Color.Transparent;
            this.btnCloseForm.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCloseForm.GlowIntensity = 100;
            this.btnCloseForm.GlowRadius = 20F;
            this.btnCloseForm.GradientBackground = false;
            this.btnCloseForm.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnCloseForm.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCloseForm.HintText = null;
            this.btnCloseForm.HoverBackColor = System.Drawing.Color.DimGray;
            this.btnCloseForm.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnCloseForm.HoverTextColor = System.Drawing.Color.Black;
            this.btnCloseForm.HoverTransitionDuration = 250;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.ImagePadding = 5;
            this.btnCloseForm.ImageSize = new System.Drawing.Size(16, 16);
            this.btnCloseForm.IsRadial = false;
            this.btnCloseForm.IsReadOnly = false;
            this.btnCloseForm.IsToggleButton = false;
            this.btnCloseForm.IsToggled = false;
            this.btnCloseForm.Location = new System.Drawing.Point(1047, 1002);
            this.btnCloseForm.LongPressDurationMS = 1000;
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnCloseForm.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCloseForm.ParticleCount = 15;
            this.btnCloseForm.PressAnimationScale = 0.97F;
            this.btnCloseForm.PressedBackColor = System.Drawing.Color.Red;
            this.btnCloseForm.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnCloseForm.PressTransitionDuration = 150;
            this.btnCloseForm.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnCloseForm.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCloseForm.RippleOpacity = 0.3F;
            this.btnCloseForm.RippleRadiusMultiplier = 0.6F;
            this.btnCloseForm.ShadowBlur = 5;
            this.btnCloseForm.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCloseForm.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnCloseForm.ShakeDuration = 500;
            this.btnCloseForm.ShakeIntensity = 5;
            this.btnCloseForm.Size = new System.Drawing.Size(125, 39);
            this.btnCloseForm.TabIndex = 62;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseForm.TextColor = System.Drawing.Color.Black;
            this.btnCloseForm.TooltipText = null;
            this.btnCloseForm.UseAdvancedRendering = true;
            this.btnCloseForm.UseParticles = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCard1.Location = new System.Drawing.Point(14, 14);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.PersonID = 0;
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1158, 646);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1185, 1050);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.siticoneTabControl1);
            this.Controls.Add(this.ctrlPersonCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ء";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            this.siticoneTabControl1.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            this.siticonePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.tabInternational.ResumeLayout(false);
            this.tabInternational.PerformLayout();
            this.siticonePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private SiticoneNetFrameworkUI.SiticoneTabControl siticoneTabControl1;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabInternational;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel1;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SiticoneNetFrameworkUI.SiticoneButton btnCloseForm;
    }
}