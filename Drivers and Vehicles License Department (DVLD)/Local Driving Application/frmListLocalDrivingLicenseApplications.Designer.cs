namespace Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.cmPersonSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.callToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNew = new SiticoneNetFrameworkUI.SiticoneButton();
            this.txtFilter = new System.Windows.Forms.MaskedTextBox();
            this.btnClose = new SiticoneNetFrameworkUI.SiticoneButton();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmPersonSettings.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // cmPersonSettings
            // 
            this.cmPersonSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmPersonSettings.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmPersonSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem1,
            this.toolStripSeparator4,
            this.addNewPersonToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.toolStripSeparator3,
            this.sendEmailToolStripMenuItem1,
            this.callToolStripMenuItem});
            this.cmPersonSettings.Name = "cmPersonSettings";
            this.cmPersonSettings.Size = new System.Drawing.Size(183, 244);
            // 
            // showDetailsToolStripMenuItem1
            // 
            this.showDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_text_description_24_filled;
            this.showDetailsToolStripMenuItem1.Name = "showDetailsToolStripMenuItem1";
            this.showDetailsToolStripMenuItem1.Size = new System.Drawing.Size(196, 38);
            this.showDetailsToolStripMenuItem1.Text = "Show Details";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(193, 6);
            // 
            // addNewPersonToolStripMenuItem1
            // 
            this.addNewPersonToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_people_add_24_filled1;
            this.addNewPersonToolStripMenuItem1.Name = "addNewPersonToolStripMenuItem1";
            this.addNewPersonToolStripMenuItem1.Size = new System.Drawing.Size(196, 38);
            this.addNewPersonToolStripMenuItem1.Text = "Add New Person";
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_edit_24_filled;
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(196, 38);
            this.editToolStripMenuItem1.Text = "Edit";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_person_delete_24_filled;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(196, 38);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // sendEmailToolStripMenuItem1
            // 
            this.sendEmailToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_mail_24_filled;
            this.sendEmailToolStripMenuItem1.Name = "sendEmailToolStripMenuItem1";
            this.sendEmailToolStripMenuItem1.Size = new System.Drawing.Size(196, 38);
            this.sendEmailToolStripMenuItem1.Text = "Send Email";
            // 
            // callToolStripMenuItem
            // 
            this.callToolStripMenuItem.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_call_24_filled;
            this.callToolStripMenuItem.Name = "callToolStripMenuItem";
            this.callToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.callToolStripMenuItem.Text = "Call";
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnAddNew.AccessibleName = "";
            this.btnAddNew.AutoSizeBasedOnText = false;
            this.btnAddNew.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNew.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_people_add_24_filled;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNew.BadgeBackColor = System.Drawing.Color.White;
            this.btnAddNew.BadgeFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.BadgeValue = 0;
            this.btnAddNew.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnAddNew.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddNew.BorderWidth = 2;
            this.btnAddNew.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnAddNew.ButtonImage = null;
            this.btnAddNew.CanBeep = true;
            this.btnAddNew.CanGlow = false;
            this.btnAddNew.CanShake = true;
            this.btnAddNew.ContextMenuStripEx = null;
            this.btnAddNew.CornerRadiusBottomLeft = 20;
            this.btnAddNew.CornerRadiusBottomRight = 20;
            this.btnAddNew.CornerRadiusTopLeft = 20;
            this.btnAddNew.CornerRadiusTopRight = 20;
            this.btnAddNew.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNew.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnAddNew.EnableLongPress = false;
            this.btnAddNew.EnablePressAnimation = true;
            this.btnAddNew.EnableRippleEffect = true;
            this.btnAddNew.EnableShadow = false;
            this.btnAddNew.EnableTextWrapping = false;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNew.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNew.GlowIntensity = 100;
            this.btnAddNew.GlowRadius = 20F;
            this.btnAddNew.GradientBackground = false;
            this.btnAddNew.GradientColor = System.Drawing.Color.White;
            this.btnAddNew.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAddNew.HintText = null;
            this.btnAddNew.HoverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNew.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNew.HoverTextColor = System.Drawing.Color.White;
            this.btnAddNew.HoverTransitionDuration = 250;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.ImagePadding = 5;
            this.btnAddNew.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAddNew.IsRadial = false;
            this.btnAddNew.IsReadOnly = false;
            this.btnAddNew.IsToggleButton = false;
            this.btnAddNew.IsToggled = false;
            this.btnAddNew.Location = new System.Drawing.Point(1115, 192);
            this.btnAddNew.LongPressDurationMS = 1000;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNew.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAddNew.ParticleCount = 15;
            this.btnAddNew.PressAnimationScale = 0.97F;
            this.btnAddNew.PressedBackColor = System.Drawing.Color.Transparent;
            this.btnAddNew.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNew.PressTransitionDuration = 150;
            this.btnAddNew.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnAddNew.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNew.RippleOpacity = 0.3F;
            this.btnAddNew.RippleRadiusMultiplier = 0.6F;
            this.btnAddNew.ShadowBlur = 5;
            this.btnAddNew.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddNew.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnAddNew.ShakeDuration = 500;
            this.btnAddNew.ShakeIntensity = 5;
            this.btnAddNew.Size = new System.Drawing.Size(65, 60);
            this.btnAddNew.TabIndex = 63;
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNew.TextColor = System.Drawing.Color.White;
            this.btnAddNew.TooltipText = null;
            this.btnAddNew.UseAdvancedRendering = true;
            this.btnAddNew.UseParticles = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtFilter.Location = new System.Drawing.Point(243, 231);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(277, 25);
            this.txtFilter.TabIndex = 62;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnClose.AccessibleName = "Close";
            this.btnClose.AutoSizeBasedOnText = false;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BadgeBackColor = System.Drawing.Color.Red;
            this.btnClose.BadgeFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.BadgeValue = 0;
            this.btnClose.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnClose.BorderColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderWidth = 2;
            this.btnClose.ButtonBackColor = System.Drawing.Color.Silver;
            this.btnClose.ButtonImage = null;
            this.btnClose.CanBeep = true;
            this.btnClose.CanGlow = false;
            this.btnClose.CanShake = true;
            this.btnClose.ContextMenuStripEx = null;
            this.btnClose.CornerRadiusBottomLeft = 20;
            this.btnClose.CornerRadiusBottomRight = 20;
            this.btnClose.CornerRadiusTopLeft = 20;
            this.btnClose.CornerRadiusTopRight = 20;
            this.btnClose.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnClose.EnableLongPress = false;
            this.btnClose.EnablePressAnimation = true;
            this.btnClose.EnableRippleEffect = true;
            this.btnClose.EnableShadow = false;
            this.btnClose.EnableTextWrapping = false;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.GlowIntensity = 100;
            this.btnClose.GlowRadius = 20F;
            this.btnClose.GradientBackground = false;
            this.btnClose.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnClose.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnClose.HintText = null;
            this.btnClose.HoverBackColor = System.Drawing.Color.DimGray;
            this.btnClose.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnClose.HoverTextColor = System.Drawing.Color.Black;
            this.btnClose.HoverTransitionDuration = 250;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImagePadding = 5;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.IsRadial = false;
            this.btnClose.IsReadOnly = false;
            this.btnClose.IsToggleButton = false;
            this.btnClose.IsToggled = false;
            this.btnClose.Location = new System.Drawing.Point(1054, 666);
            this.btnClose.LongPressDurationMS = 1000;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnClose.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnClose.ParticleCount = 15;
            this.btnClose.PressAnimationScale = 0.97F;
            this.btnClose.PressedBackColor = System.Drawing.Color.Red;
            this.btnClose.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnClose.PressTransitionDuration = 150;
            this.btnClose.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.RippleOpacity = 0.3F;
            this.btnClose.RippleRadiusMultiplier = 0.6F;
            this.btnClose.ShadowBlur = 5;
            this.btnClose.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnClose.ShakeDuration = 500;
            this.btnClose.ShakeIntensity = 5;
            this.btnClose.Size = new System.Drawing.Size(125, 39);
            this.btnClose.TabIndex = 61;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.TooltipText = null;
            this.btnClose.UseAdvancedRendering = true;
            this.btnClose.UseParticles = false;
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
            this.siticonePanel1.Controls.Add(this.dgvPeople);
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
            this.siticonePanel1.Location = new System.Drawing.Point(13, 258);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.siticonePanel1.RippleAlpha = 50;
            this.siticonePanel1.RippleAlphaDecrement = 3;
            this.siticonePanel1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel1.RippleMaxSize = 600F;
            this.siticonePanel1.RippleSpeed = 15F;
            this.siticonePanel1.ShowBorder = true;
            this.siticonePanel1.Size = new System.Drawing.Size(1167, 344);
            this.siticonePanel1.TabIndex = 60;
            this.siticonePanel1.TabStop = true;
            this.siticonePanel1.UseBorderGradient = false;
            this.siticonePanel1.UseMultiGradient = false;
            this.siticonePanel1.UsePatternTexture = false;
            this.siticonePanel1.UseRadialGradient = false;
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToResizeColumns = false;
            this.dgvPeople.AllowUserToResizeRows = false;
            this.dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmPersonSettings;
            this.dgvPeople.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPeople.Location = new System.Drawing.Point(14, 12);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(1137, 318);
            this.dgvPeople.TabIndex = 1;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(89, 605);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblRecordsCount.TabIndex = 59;
            this.lblRecordsCount.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 605);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 58;
            this.label3.Text = "# Records:";
            // 
            // cbFilter
            // 
            this.cbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(77, 231);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(160, 21);
            this.cbFilter.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Filter by:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(299, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 50);
            this.label1.TabIndex = 55;
            this.label1.Text = "Local Driving License Applications";
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1191, 715);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListLocalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplications_Load);
            this.cmPersonSettings.ResumeLayout(false);
            this.siticonePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmPersonSettings;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem callToolStripMenuItem;
        private SiticoneNetFrameworkUI.SiticoneButton btnAddNew;
        private System.Windows.Forms.MaskedTextBox txtFilter;
        private SiticoneNetFrameworkUI.SiticoneButton btnClose;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}