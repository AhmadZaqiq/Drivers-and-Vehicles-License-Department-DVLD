namespace Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms
{
    partial class frmListInternationalDrivingLicenses
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicense = new System.Windows.Forms.DataGridView();
            this.cmInternationalLicenseSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowPersonDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicenseDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonlicenseHistoryStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilter = new System.Windows.Forms.MaskedTextBox();
            this.btnCloseForm = new SiticoneNetFrameworkUI.SiticoneButton();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.btnAddNewInternationalLicense = new SiticoneNetFrameworkUI.SiticoneButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).BeginInit();
            this.cmInternationalLicenseSettings.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(334, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 50);
            this.label1.TabIndex = 65;
            this.label1.Text = "International Driving Licenses";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(89, 778);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblRecordsCount.TabIndex = 69;
            this.lblRecordsCount.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 778);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 68;
            this.label3.Text = "# Records:";
            // 
            // cbFilter
            // 
            this.cbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(77, 404);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(160, 21);
            this.cbFilter.TabIndex = 67;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Filter by:";
            // 
            // dgvInternationalLicense
            // 
            this.dgvInternationalLicense.AllowUserToAddRows = false;
            this.dgvInternationalLicense.AllowUserToDeleteRows = false;
            this.dgvInternationalLicense.AllowUserToResizeColumns = false;
            this.dgvInternationalLicense.AllowUserToResizeRows = false;
            this.dgvInternationalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInternationalLicense.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInternationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicense.ContextMenuStrip = this.cmInternationalLicenseSettings;
            this.dgvInternationalLicense.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvInternationalLicense.Location = new System.Drawing.Point(13, 13);
            this.dgvInternationalLicense.Name = "dgvInternationalLicense";
            this.dgvInternationalLicense.ReadOnly = true;
            this.dgvInternationalLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicense.Size = new System.Drawing.Size(1137, 318);
            this.dgvInternationalLicense.TabIndex = 1;
            // 
            // cmInternationalLicenseSettings
            // 
            this.cmInternationalLicenseSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmInternationalLicenseSettings.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmInternationalLicenseSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonDetailsToolStripMenuItem1,
            this.ShowLicenseDetailsToolStripMenuItem1,
            this.ShowPersonlicenseHistoryStripMenuItem1});
            this.cmInternationalLicenseSettings.Name = "cmPersonSettings";
            this.cmInternationalLicenseSettings.Size = new System.Drawing.Size(252, 140);
            // 
            // ShowPersonDetailsToolStripMenuItem1
            // 
            this.ShowPersonDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_person_24_filled;
            this.ShowPersonDetailsToolStripMenuItem1.Name = "ShowPersonDetailsToolStripMenuItem1";
            this.ShowPersonDetailsToolStripMenuItem1.Size = new System.Drawing.Size(251, 38);
            this.ShowPersonDetailsToolStripMenuItem1.Text = "Show Person Details";
            this.ShowPersonDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowPersonDetailsToolStripMenuItem1_Click);
            // 
            // ShowLicenseDetailsToolStripMenuItem1
            // 
            this.ShowLicenseDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_credit_card_person_24_filled;
            this.ShowLicenseDetailsToolStripMenuItem1.Name = "ShowLicenseDetailsToolStripMenuItem1";
            this.ShowLicenseDetailsToolStripMenuItem1.Size = new System.Drawing.Size(251, 38);
            this.ShowLicenseDetailsToolStripMenuItem1.Text = "Show License Details";
            this.ShowLicenseDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowLicenseDetailsToolStripMenuItem1_Click);
            // 
            // ShowPersonlicenseHistoryStripMenuItem1
            // 
            this.ShowPersonlicenseHistoryStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_apps_list_detail_24_filled;
            this.ShowPersonlicenseHistoryStripMenuItem1.Name = "ShowPersonlicenseHistoryStripMenuItem1";
            this.ShowPersonlicenseHistoryStripMenuItem1.Size = new System.Drawing.Size(251, 38);
            this.ShowPersonlicenseHistoryStripMenuItem1.Text = "Show Person licenses History";
            this.ShowPersonlicenseHistoryStripMenuItem1.Click += new System.EventHandler(this.ShowPersonLicenseHistoryStripMenuItem1_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtFilter.Location = new System.Drawing.Point(243, 404);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(277, 25);
            this.txtFilter.TabIndex = 72;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
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
            this.btnCloseForm.Location = new System.Drawing.Point(1055, 812);
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
            this.btnCloseForm.TabIndex = 71;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseForm.TextColor = System.Drawing.Color.Black;
            this.btnCloseForm.TooltipText = null;
            this.btnCloseForm.UseAdvancedRendering = true;
            this.btnCloseForm.UseParticles = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
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
            this.siticonePanel1.Controls.Add(this.dgvInternationalLicense);
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
            this.siticonePanel1.Location = new System.Drawing.Point(13, 431);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.siticonePanel1.RippleAlpha = 50;
            this.siticonePanel1.RippleAlphaDecrement = 3;
            this.siticonePanel1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel1.RippleMaxSize = 600F;
            this.siticonePanel1.RippleSpeed = 15F;
            this.siticonePanel1.ShowBorder = true;
            this.siticonePanel1.Size = new System.Drawing.Size(1167, 344);
            this.siticonePanel1.TabIndex = 70;
            this.siticonePanel1.TabStop = true;
            this.siticonePanel1.UseBorderGradient = false;
            this.siticonePanel1.UseMultiGradient = false;
            this.siticonePanel1.UsePatternTexture = false;
            this.siticonePanel1.UseRadialGradient = false;
            // 
            // btnAddNewInternationalLicense
            // 
            this.btnAddNewInternationalLicense.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnAddNewInternationalLicense.AccessibleName = "";
            this.btnAddNewInternationalLicense.AutoSizeBasedOnText = false;
            this.btnAddNewInternationalLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternationalLicense.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_slide_add_24_filled__1_;
            this.btnAddNewInternationalLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewInternationalLicense.BadgeBackColor = System.Drawing.Color.White;
            this.btnAddNewInternationalLicense.BadgeFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddNewInternationalLicense.BadgeValue = 0;
            this.btnAddNewInternationalLicense.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnAddNewInternationalLicense.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternationalLicense.BorderWidth = 2;
            this.btnAddNewInternationalLicense.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternationalLicense.ButtonImage = null;
            this.btnAddNewInternationalLicense.CanBeep = true;
            this.btnAddNewInternationalLicense.CanGlow = false;
            this.btnAddNewInternationalLicense.CanShake = true;
            this.btnAddNewInternationalLicense.ContextMenuStripEx = null;
            this.btnAddNewInternationalLicense.CornerRadiusBottomLeft = 20;
            this.btnAddNewInternationalLicense.CornerRadiusBottomRight = 20;
            this.btnAddNewInternationalLicense.CornerRadiusTopLeft = 20;
            this.btnAddNewInternationalLicense.CornerRadiusTopRight = 20;
            this.btnAddNewInternationalLicense.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewInternationalLicense.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnAddNewInternationalLicense.EnableLongPress = false;
            this.btnAddNewInternationalLicense.EnablePressAnimation = true;
            this.btnAddNewInternationalLicense.EnableRippleEffect = true;
            this.btnAddNewInternationalLicense.EnableShadow = false;
            this.btnAddNewInternationalLicense.EnableTextWrapping = false;
            this.btnAddNewInternationalLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewInternationalLicense.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNewInternationalLicense.GlowIntensity = 100;
            this.btnAddNewInternationalLicense.GlowRadius = 20F;
            this.btnAddNewInternationalLicense.GradientBackground = false;
            this.btnAddNewInternationalLicense.GradientColor = System.Drawing.Color.White;
            this.btnAddNewInternationalLicense.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAddNewInternationalLicense.HintText = null;
            this.btnAddNewInternationalLicense.HoverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternationalLicense.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNewInternationalLicense.HoverTextColor = System.Drawing.Color.White;
            this.btnAddNewInternationalLicense.HoverTransitionDuration = 250;
            this.btnAddNewInternationalLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewInternationalLicense.ImagePadding = 5;
            this.btnAddNewInternationalLicense.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAddNewInternationalLicense.IsRadial = false;
            this.btnAddNewInternationalLicense.IsReadOnly = false;
            this.btnAddNewInternationalLicense.IsToggleButton = false;
            this.btnAddNewInternationalLicense.IsToggled = false;
            this.btnAddNewInternationalLicense.Location = new System.Drawing.Point(1115, 365);
            this.btnAddNewInternationalLicense.LongPressDurationMS = 1000;
            this.btnAddNewInternationalLicense.Name = "btnAddNewInternationalLicense";
            this.btnAddNewInternationalLicense.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNewInternationalLicense.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAddNewInternationalLicense.ParticleCount = 15;
            this.btnAddNewInternationalLicense.PressAnimationScale = 0.97F;
            this.btnAddNewInternationalLicense.PressedBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternationalLicense.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNewInternationalLicense.PressTransitionDuration = 150;
            this.btnAddNewInternationalLicense.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnAddNewInternationalLicense.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNewInternationalLicense.RippleOpacity = 0.3F;
            this.btnAddNewInternationalLicense.RippleRadiusMultiplier = 0.6F;
            this.btnAddNewInternationalLicense.ShadowBlur = 5;
            this.btnAddNewInternationalLicense.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddNewInternationalLicense.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnAddNewInternationalLicense.ShakeDuration = 500;
            this.btnAddNewInternationalLicense.ShakeIntensity = 5;
            this.btnAddNewInternationalLicense.Size = new System.Drawing.Size(65, 60);
            this.btnAddNewInternationalLicense.TabIndex = 73;
            this.btnAddNewInternationalLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNewInternationalLicense.TextColor = System.Drawing.Color.White;
            this.btnAddNewInternationalLicense.TooltipText = null;
            this.btnAddNewInternationalLicense.UseAdvancedRendering = true;
            this.btnAddNewInternationalLicense.UseParticles = false;
            this.btnAddNewInternationalLicense.Click += new System.EventHandler(this.btnAddNewInternationalLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.World_amico1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(425, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 340);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // frmListInternationalDrivingLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1191, 863);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewInternationalLicense);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListInternationalDrivingLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListInternationalDrivingLicenses";
            this.Load += new System.EventHandler(this.frmListInternationalDrivingLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).EndInit();
            this.cmInternationalLicenseSettings.ResumeLayout(false);
            this.siticonePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private SiticoneNetFrameworkUI.SiticoneButton btnAddNewInternationalLicense;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalLicense;
        private System.Windows.Forms.ContextMenuStrip cmInternationalLicenseSettings;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonlicenseHistoryStripMenuItem1;
        private System.Windows.Forms.MaskedTextBox txtFilter;
        private SiticoneNetFrameworkUI.SiticoneButton btnCloseForm;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}