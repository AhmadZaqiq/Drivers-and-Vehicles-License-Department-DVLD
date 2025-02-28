namespace Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms
{
    partial class frmManageUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.MaskedTextBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cmUserSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.callToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.btnClose = new SiticoneNetFrameworkUI.SiticoneButton();
            this.btnAddNewPerson = new SiticoneNetFrameworkUI.SiticoneButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmUserSettings.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(451, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(247, 258);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(273, 20);
            this.txtFilter.TabIndex = 19;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(97, 633);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblRecordsCount.TabIndex = 17;
            this.lblRecordsCount.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 633);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "# Records:";
            // 
            // cbFilter
            // 
            this.cbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(81, 258);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(160, 21);
            this.cbFilter.TabIndex = 15;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmUserSettings;
            this.dgvUsers.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvUsers.Location = new System.Drawing.Point(14, 12);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1137, 318);
            this.dgvUsers.TabIndex = 14;
            this.dgvUsers.MouseEnter += new System.EventHandler(this.dgvUsers_MouseEnter);
            this.dgvUsers.MouseLeave += new System.EventHandler(this.dgvUsers_MouseLeave);
            // 
            // cmUserSettings
            // 
            this.cmUserSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmUserSettings.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmUserSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem1,
            this.toolStripSeparator2,
            this.addNewPersonToolStripMenuItem1,
            this.editUserToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.changePasswordStripMenuItem1,
            this.toolStripSeparator1,
            this.sendEmailToolStripMenuItem1,
            this.callToolStripMenuItem});
            this.cmUserSettings.Name = "cmPersonSettings";
            this.cmUserSettings.Size = new System.Drawing.Size(200, 282);
            // 
            // showDetailsToolStripMenuItem1
            // 
            this.showDetailsToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_text_description_24_filled;
            this.showDetailsToolStripMenuItem1.Name = "showDetailsToolStripMenuItem1";
            this.showDetailsToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.showDetailsToolStripMenuItem1.Text = "Show Details";
            this.showDetailsToolStripMenuItem1.Click += new System.EventHandler(this.showDetailsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // addNewPersonToolStripMenuItem1
            // 
            this.addNewPersonToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewPersonToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_people_add_24_filled1;
            this.addNewPersonToolStripMenuItem1.Name = "addNewPersonToolStripMenuItem1";
            this.addNewPersonToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.addNewPersonToolStripMenuItem1.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem1.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem1_Click);
            // 
            // editUserToolStripMenuItem1
            // 
            this.editUserToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUserToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_edit_24_filled;
            this.editUserToolStripMenuItem1.Name = "editUserToolStripMenuItem1";
            this.editUserToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.editUserToolStripMenuItem1.Text = "Edit";
            this.editUserToolStripMenuItem1.Click += new System.EventHandler(this.editUsernameToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_person_delete_24_filled;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // changePasswordStripMenuItem1
            // 
            this.changePasswordStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_password_24_filled__1_;
            this.changePasswordStripMenuItem1.Name = "changePasswordStripMenuItem1";
            this.changePasswordStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.changePasswordStripMenuItem1.Text = "Change Password";
            this.changePasswordStripMenuItem1.Click += new System.EventHandler(this.changePasswordStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // sendEmailToolStripMenuItem1
            // 
            this.sendEmailToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendEmailToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_mail_24_filled;
            this.sendEmailToolStripMenuItem1.Name = "sendEmailToolStripMenuItem1";
            this.sendEmailToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.sendEmailToolStripMenuItem1.Text = "Send Email";
            this.sendEmailToolStripMenuItem1.Click += new System.EventHandler(this.sendEmailToolStripMenuItem1_Click);
            // 
            // callToolStripMenuItem
            // 
            this.callToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callToolStripMenuItem.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_call_24_filled;
            this.callToolStripMenuItem.Name = "callToolStripMenuItem";
            this.callToolStripMenuItem.Size = new System.Drawing.Size(199, 38);
            this.callToolStripMenuItem.Text = "Call";
            this.callToolStripMenuItem.Click += new System.EventHandler(this.callToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filter by:";
            // 
            // cbIsActive
            // 
            this.cbIsActive.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Location = new System.Drawing.Point(247, 258);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(160, 21);
            this.cbIsActive.TabIndex = 22;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
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
            this.siticonePanel1.Controls.Add(this.dgvUsers);
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
            this.siticonePanel1.Location = new System.Drawing.Point(12, 286);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.siticonePanel1.RippleAlpha = 50;
            this.siticonePanel1.RippleAlphaDecrement = 3;
            this.siticonePanel1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel1.RippleMaxSize = 600F;
            this.siticonePanel1.RippleSpeed = 15F;
            this.siticonePanel1.ShowBorder = true;
            this.siticonePanel1.Size = new System.Drawing.Size(1167, 344);
            this.siticonePanel1.TabIndex = 23;
            this.siticonePanel1.TabStop = true;
            this.siticonePanel1.UseBorderGradient = false;
            this.siticonePanel1.UseMultiGradient = false;
            this.siticonePanel1.UsePatternTexture = false;
            this.siticonePanel1.UseRadialGradient = false;
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
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.TooltipText = null;
            this.btnClose.UseAdvancedRendering = true;
            this.btnClose.UseParticles = false;
            this.btnClose.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnAddNewPerson.AccessibleName = "";
            this.btnAddNewPerson.AutoSizeBasedOnText = false;
            this.btnAddNewPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_people_add_24_filled;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.BadgeBackColor = System.Drawing.Color.White;
            this.btnAddNewPerson.BadgeFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddNewPerson.BadgeValue = 0;
            this.btnAddNewPerson.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnAddNewPerson.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.BorderWidth = 2;
            this.btnAddNewPerson.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.ButtonImage = null;
            this.btnAddNewPerson.CanBeep = true;
            this.btnAddNewPerson.CanGlow = false;
            this.btnAddNewPerson.CanShake = true;
            this.btnAddNewPerson.ContextMenuStripEx = null;
            this.btnAddNewPerson.CornerRadiusBottomLeft = 20;
            this.btnAddNewPerson.CornerRadiusBottomRight = 20;
            this.btnAddNewPerson.CornerRadiusTopLeft = 20;
            this.btnAddNewPerson.CornerRadiusTopRight = 20;
            this.btnAddNewPerson.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewPerson.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnAddNewPerson.EnableLongPress = false;
            this.btnAddNewPerson.EnablePressAnimation = true;
            this.btnAddNewPerson.EnableRippleEffect = true;
            this.btnAddNewPerson.EnableShadow = false;
            this.btnAddNewPerson.EnableTextWrapping = false;
            this.btnAddNewPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewPerson.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNewPerson.GlowIntensity = 100;
            this.btnAddNewPerson.GlowRadius = 20F;
            this.btnAddNewPerson.GradientBackground = false;
            this.btnAddNewPerson.GradientColor = System.Drawing.Color.White;
            this.btnAddNewPerson.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAddNewPerson.HintText = null;
            this.btnAddNewPerson.HoverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNewPerson.HoverTextColor = System.Drawing.Color.White;
            this.btnAddNewPerson.HoverTransitionDuration = 250;
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPerson.ImagePadding = 5;
            this.btnAddNewPerson.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAddNewPerson.IsRadial = false;
            this.btnAddNewPerson.IsReadOnly = false;
            this.btnAddNewPerson.IsToggleButton = false;
            this.btnAddNewPerson.IsToggled = false;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1114, 220);
            this.btnAddNewPerson.LongPressDurationMS = 1000;
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNewPerson.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAddNewPerson.ParticleCount = 15;
            this.btnAddNewPerson.PressAnimationScale = 0.97F;
            this.btnAddNewPerson.PressedBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAddNewPerson.PressTransitionDuration = 150;
            this.btnAddNewPerson.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnAddNewPerson.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNewPerson.RippleOpacity = 0.3F;
            this.btnAddNewPerson.RippleRadiusMultiplier = 0.6F;
            this.btnAddNewPerson.ShadowBlur = 5;
            this.btnAddNewPerson.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddNewPerson.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnAddNewPerson.ShakeDuration = 500;
            this.btnAddNewPerson.ShakeIntensity = 5;
            this.btnAddNewPerson.Size = new System.Drawing.Size(65, 60);
            this.btnAddNewPerson.TabIndex = 53;
            this.btnAddNewPerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNewPerson.TextColor = System.Drawing.Color.White;
            this.btnAddNewPerson.TooltipText = null;
            this.btnAddNewPerson.UseAdvancedRendering = true;
            this.btnAddNewPerson.UseParticles = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1191, 715);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.lblRecordsCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cmUserSettings.ResumeLayout(false);
            this.siticonePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtFilter;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbIsActive;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel1;
        private SiticoneNetFrameworkUI.SiticoneButton btnClose;
        private SiticoneNetFrameworkUI.SiticoneButton btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmUserSettings;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem callToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem changePasswordStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}