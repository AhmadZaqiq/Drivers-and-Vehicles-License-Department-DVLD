namespace Drivers_and_Vehicles_License_Department__DVLD_.Detained_Licenses.Forms
{
    partial class frmListDetainedLicenses
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
            this.txtFilter = new System.Windows.Forms.MaskedTextBox();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.cmDetainLicensesSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowPersonlicenseHistoryStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LicenseDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LicenseHistryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLicenseStripToolMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnCloseForm = new SiticoneNetFrameworkUI.SiticoneButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReleaseLicense = new SiticoneNetFrameworkUI.SiticoneButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDetainLicense = new SiticoneNetFrameworkUI.SiticoneButton();
            this.siticonePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.cmDetainLicensesSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(392, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 50);
            this.label1.TabIndex = 65;
            this.label1.Text = "List Detained Licenses";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtFilter.Location = new System.Drawing.Point(235, 385);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(277, 25);
            this.txtFilter.TabIndex = 72;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
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
            this.siticonePanel1.Controls.Add(this.dgvDetainedLicenses);
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
            this.siticonePanel1.Location = new System.Drawing.Point(5, 412);
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
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToResizeColumns = false;
            this.dgvDetainedLicenses.AllowUserToResizeRows = false;
            this.dgvDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetainedLicenses.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.ContextMenuStrip = this.cmDetainLicensesSettings;
            this.dgvDetainedLicenses.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(13, 13);
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1137, 318);
            this.dgvDetainedLicenses.TabIndex = 1;
            // 
            // cmDetainLicensesSettings
            // 
            this.cmDetainLicensesSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmDetainLicensesSettings.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmDetainLicensesSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonlicenseHistoryStripMenuItem1,
            this.LicenseDetailsToolStripMenuItem1,
            this.LicenseHistryToolStripMenuItem1,
            this.toolStripSeparator5,
            this.ShowLicenseStripToolMenuItem1});
            this.cmDetainLicensesSettings.Name = "cmPersonSettings";
            this.cmDetainLicensesSettings.Size = new System.Drawing.Size(250, 162);
            // 
            // ShowPersonlicenseHistoryStripMenuItem1
            // 
            this.ShowPersonlicenseHistoryStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_person_24_filled;
            this.ShowPersonlicenseHistoryStripMenuItem1.Name = "ShowPersonlicenseHistoryStripMenuItem1";
            this.ShowPersonlicenseHistoryStripMenuItem1.Size = new System.Drawing.Size(249, 38);
            this.ShowPersonlicenseHistoryStripMenuItem1.Text = "Show Person Details";
            this.ShowPersonlicenseHistoryStripMenuItem1.Click += new System.EventHandler(this.ShowPersonlicenseHistoryStripMenuItem1_Click);
            // 
            // LicenseDetailsToolStripMenuItem1
            // 
            this.LicenseDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_contact_card_24_filled1;
            this.LicenseDetailsToolStripMenuItem1.Name = "LicenseDetailsToolStripMenuItem1";
            this.LicenseDetailsToolStripMenuItem1.Size = new System.Drawing.Size(249, 38);
            this.LicenseDetailsToolStripMenuItem1.Text = "Show License Details";
            this.LicenseDetailsToolStripMenuItem1.Click += new System.EventHandler(this.LicenseDetailsToolStripMenuItem1_Click);
            // 
            // LicenseHistryToolStripMenuItem1
            // 
            this.LicenseHistryToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_apps_list_detail_24_filled;
            this.LicenseHistryToolStripMenuItem1.Name = "LicenseHistryToolStripMenuItem1";
            this.LicenseHistryToolStripMenuItem1.Size = new System.Drawing.Size(249, 38);
            this.LicenseHistryToolStripMenuItem1.Text = "Show Person License History";
            this.LicenseHistryToolStripMenuItem1.Click += new System.EventHandler(this.LicenseHistryToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // ShowLicenseStripToolMenuItem1
            // 
            this.ShowLicenseStripToolMenuItem1.Enabled = false;
            this.ShowLicenseStripToolMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_contact_card_24_filled__1_;
            this.ShowLicenseStripToolMenuItem1.Name = "ShowLicenseStripToolMenuItem1";
            this.ShowLicenseStripToolMenuItem1.Size = new System.Drawing.Size(249, 38);
            this.ShowLicenseStripToolMenuItem1.Text = "Show License";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(81, 759);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblRecordsCount.TabIndex = 69;
            this.lblRecordsCount.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 759);
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
            this.cbFilter.Location = new System.Drawing.Point(69, 385);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(160, 21);
            this.cbFilter.TabIndex = 67;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
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
            this.btnCloseForm.Location = new System.Drawing.Point(1038, 867);
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
            this.btnCloseForm.Size = new System.Drawing.Size(125, 38);
            this.btnCloseForm.TabIndex = 71;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseForm.TextColor = System.Drawing.Color.Black;
            this.btnCloseForm.TooltipText = null;
            this.btnCloseForm.UseAdvancedRendering = true;
            this.btnCloseForm.UseParticles = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Filter by:";
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnReleaseLicense.AccessibleName = "";
            this.btnReleaseLicense.AutoSizeBasedOnText = false;
            this.btnReleaseLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_lock_open_24_filled1;
            this.btnReleaseLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReleaseLicense.BadgeBackColor = System.Drawing.Color.White;
            this.btnReleaseLicense.BadgeFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnReleaseLicense.BadgeValue = 0;
            this.btnReleaseLicense.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnReleaseLicense.BorderColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.BorderWidth = 2;
            this.btnReleaseLicense.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.ButtonImage = null;
            this.btnReleaseLicense.CanBeep = true;
            this.btnReleaseLicense.CanGlow = false;
            this.btnReleaseLicense.CanShake = true;
            this.btnReleaseLicense.ContextMenuStripEx = null;
            this.btnReleaseLicense.CornerRadiusBottomLeft = 20;
            this.btnReleaseLicense.CornerRadiusBottomRight = 20;
            this.btnReleaseLicense.CornerRadiusTopLeft = 20;
            this.btnReleaseLicense.CornerRadiusTopRight = 20;
            this.btnReleaseLicense.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnReleaseLicense.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnReleaseLicense.EnableLongPress = false;
            this.btnReleaseLicense.EnablePressAnimation = true;
            this.btnReleaseLicense.EnableRippleEffect = true;
            this.btnReleaseLicense.EnableShadow = false;
            this.btnReleaseLicense.EnableTextWrapping = false;
            this.btnReleaseLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReleaseLicense.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReleaseLicense.GlowIntensity = 100;
            this.btnReleaseLicense.GlowRadius = 20F;
            this.btnReleaseLicense.GradientBackground = false;
            this.btnReleaseLicense.GradientColor = System.Drawing.Color.White;
            this.btnReleaseLicense.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReleaseLicense.HintText = null;
            this.btnReleaseLicense.HoverBackColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnReleaseLicense.HoverTextColor = System.Drawing.Color.White;
            this.btnReleaseLicense.HoverTransitionDuration = 250;
            this.btnReleaseLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReleaseLicense.ImagePadding = 5;
            this.btnReleaseLicense.ImageSize = new System.Drawing.Size(16, 16);
            this.btnReleaseLicense.IsRadial = false;
            this.btnReleaseLicense.IsReadOnly = false;
            this.btnReleaseLicense.IsToggleButton = false;
            this.btnReleaseLicense.IsToggled = false;
            this.btnReleaseLicense.Location = new System.Drawing.Point(1036, 346);
            this.btnReleaseLicense.LongPressDurationMS = 1000;
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnReleaseLicense.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnReleaseLicense.ParticleCount = 15;
            this.btnReleaseLicense.PressAnimationScale = 0.97F;
            this.btnReleaseLicense.PressedBackColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnReleaseLicense.PressTransitionDuration = 150;
            this.btnReleaseLicense.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnReleaseLicense.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReleaseLicense.RippleOpacity = 0.3F;
            this.btnReleaseLicense.RippleRadiusMultiplier = 0.6F;
            this.btnReleaseLicense.ShadowBlur = 5;
            this.btnReleaseLicense.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReleaseLicense.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnReleaseLicense.ShakeDuration = 500;
            this.btnReleaseLicense.ShakeIntensity = 5;
            this.btnReleaseLicense.Size = new System.Drawing.Size(65, 60);
            this.btnReleaseLicense.TabIndex = 75;
            this.btnReleaseLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReleaseLicense.TextColor = System.Drawing.Color.White;
            this.btnReleaseLicense.TooltipText = null;
            this.btnReleaseLicense.UseAdvancedRendering = true;
            this.btnReleaseLicense.UseParticles = false;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.traffic_fine_rafiki;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(343, -34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 426);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnDetainLicense.AccessibleName = "";
            this.btnDetainLicense.AutoSizeBasedOnText = false;
            this.btnDetainLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_lock_closed_24_filled;
            this.btnDetainLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetainLicense.BadgeBackColor = System.Drawing.Color.White;
            this.btnDetainLicense.BadgeFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnDetainLicense.BadgeValue = 0;
            this.btnDetainLicense.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.BorderColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.BorderWidth = 2;
            this.btnDetainLicense.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.ButtonImage = null;
            this.btnDetainLicense.CanBeep = true;
            this.btnDetainLicense.CanGlow = false;
            this.btnDetainLicense.CanShake = true;
            this.btnDetainLicense.ContextMenuStripEx = null;
            this.btnDetainLicense.CornerRadiusBottomLeft = 20;
            this.btnDetainLicense.CornerRadiusBottomRight = 20;
            this.btnDetainLicense.CornerRadiusTopLeft = 20;
            this.btnDetainLicense.CornerRadiusTopRight = 20;
            this.btnDetainLicense.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnDetainLicense.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnDetainLicense.EnableLongPress = false;
            this.btnDetainLicense.EnablePressAnimation = true;
            this.btnDetainLicense.EnableRippleEffect = true;
            this.btnDetainLicense.EnableShadow = false;
            this.btnDetainLicense.EnableTextWrapping = false;
            this.btnDetainLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetainLicense.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDetainLicense.GlowIntensity = 100;
            this.btnDetainLicense.GlowRadius = 20F;
            this.btnDetainLicense.GradientBackground = false;
            this.btnDetainLicense.GradientColor = System.Drawing.Color.White;
            this.btnDetainLicense.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnDetainLicense.HintText = null;
            this.btnDetainLicense.HoverBackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnDetainLicense.HoverTextColor = System.Drawing.Color.White;
            this.btnDetainLicense.HoverTransitionDuration = 250;
            this.btnDetainLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetainLicense.ImagePadding = 5;
            this.btnDetainLicense.ImageSize = new System.Drawing.Size(16, 16);
            this.btnDetainLicense.IsRadial = false;
            this.btnDetainLicense.IsReadOnly = false;
            this.btnDetainLicense.IsToggleButton = false;
            this.btnDetainLicense.IsToggled = false;
            this.btnDetainLicense.Location = new System.Drawing.Point(1107, 346);
            this.btnDetainLicense.LongPressDurationMS = 1000;
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnDetainLicense.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDetainLicense.ParticleCount = 15;
            this.btnDetainLicense.PressAnimationScale = 0.97F;
            this.btnDetainLicense.PressedBackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnDetainLicense.PressTransitionDuration = 150;
            this.btnDetainLicense.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnDetainLicense.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDetainLicense.RippleOpacity = 0.3F;
            this.btnDetainLicense.RippleRadiusMultiplier = 0.6F;
            this.btnDetainLicense.ShadowBlur = 5;
            this.btnDetainLicense.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDetainLicense.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnDetainLicense.ShakeDuration = 500;
            this.btnDetainLicense.ShakeIntensity = 5;
            this.btnDetainLicense.Size = new System.Drawing.Size(65, 60);
            this.btnDetainLicense.TabIndex = 73;
            this.btnDetainLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDetainLicense.TextColor = System.Drawing.Color.White;
            this.btnDetainLicense.TooltipText = null;
            this.btnDetainLicense.UseAdvancedRendering = true;
            this.btnDetainLicense.UseParticles = false;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 917);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ListDetainedLicenses";
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            this.siticonePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.cmDetainLicensesSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private SiticoneNetFrameworkUI.SiticoneButton btnDetainLicense;
        private System.Windows.Forms.MaskedTextBox txtFilter;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel1;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.ContextMenuStrip cmDetainLicensesSettings;
        private System.Windows.Forms.ToolStripMenuItem LicenseDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem LicenseHistryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseStripToolMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonlicenseHistoryStripMenuItem1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilter;
        private SiticoneNetFrameworkUI.SiticoneButton btnCloseForm;
        private System.Windows.Forms.Label label2;
        private SiticoneNetFrameworkUI.SiticoneButton btnReleaseLicense;
    }
}