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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.btnCloseForm = new SiticoneNetFrameworkUI.SiticoneButton();
            this.btnAddNewPerson = new SiticoneNetFrameworkUI.SiticoneButton();
            this.ShowDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SendEmailToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmUserSettings.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(476, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(247, 404);
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
            this.lblRecordsCount.Location = new System.Drawing.Point(97, 779);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblRecordsCount.TabIndex = 17;
            this.lblRecordsCount.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 779);
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
            this.cbFilter.Location = new System.Drawing.Point(81, 404);
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
            this.ShowDetailsToolStripMenuItem1,
            this.toolStripSeparator2,
            this.AddNewUserToolStripMenuItem1,
            this.EditUserToolStripMenuItem1,
            this.DeleteToolStripMenuItem1,
            this.ChangePasswordStripMenuItem1,
            this.toolStripSeparator1,
            this.SendEmailToolStripMenuItem1,
            this.CallToolStripMenuItem});
            this.cmUserSettings.Name = "cmPersonSettings";
            this.cmUserSettings.Size = new System.Drawing.Size(200, 282);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 406);
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
            this.cbIsActive.Location = new System.Drawing.Point(247, 404);
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
            this.siticonePanel1.Location = new System.Drawing.Point(12, 432);
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
            this.btnCloseForm.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnCloseForm.Location = new System.Drawing.Point(1054, 812);
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
            this.btnCloseForm.TabIndex = 52;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseForm.TextColor = System.Drawing.Color.Black;
            this.btnCloseForm.TooltipText = null;
            this.btnCloseForm.UseAdvancedRendering = true;
            this.btnCloseForm.UseParticles = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
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
            this.btnAddNewPerson.Location = new System.Drawing.Point(1114, 366);
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
            // ShowDetailsToolStripMenuItem1
            // 
            this.ShowDetailsToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_text_description_24_filled;
            this.ShowDetailsToolStripMenuItem1.Name = "ShowDetailsToolStripMenuItem1";
            this.ShowDetailsToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.ShowDetailsToolStripMenuItem1.Text = "Show Details";
            this.ShowDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowDetailsToolStripMenuItem1_Click);
            // 
            // AddNewUserToolStripMenuItem1
            // 
            this.AddNewUserToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewUserToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_people_add_24_filled1;
            this.AddNewUserToolStripMenuItem1.Name = "AddNewUserToolStripMenuItem1";
            this.AddNewUserToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.AddNewUserToolStripMenuItem1.Text = "Add New User";
            this.AddNewUserToolStripMenuItem1.Click += new System.EventHandler(this.AddNewPersonToolStripMenuItem1_Click);
            // 
            // EditUserToolStripMenuItem1
            // 
            this.EditUserToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditUserToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_edit_24_filled;
            this.EditUserToolStripMenuItem1.Name = "EditUserToolStripMenuItem1";
            this.EditUserToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.EditUserToolStripMenuItem1.Text = "Edit";
            this.EditUserToolStripMenuItem1.Click += new System.EventHandler(this.EditUsernameToolStripMenuItem1_Click);
            // 
            // DeleteToolStripMenuItem1
            // 
            this.DeleteToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_person_delete_24_filled;
            this.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1";
            this.DeleteToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.DeleteToolStripMenuItem1.Text = "Delete";
            this.DeleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1_Click);
            // 
            // ChangePasswordStripMenuItem1
            // 
            this.ChangePasswordStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_password_24_filled__1_;
            this.ChangePasswordStripMenuItem1.Name = "ChangePasswordStripMenuItem1";
            this.ChangePasswordStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.ChangePasswordStripMenuItem1.Text = "Change Password";
            this.ChangePasswordStripMenuItem1.Click += new System.EventHandler(this.ChangePasswordStripMenuItem1_Click);
            // 
            // SendEmailToolStripMenuItem1
            // 
            this.SendEmailToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendEmailToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_mail_24_filled;
            this.SendEmailToolStripMenuItem1.Name = "SendEmailToolStripMenuItem1";
            this.SendEmailToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.SendEmailToolStripMenuItem1.Text = "Send Email";
            this.SendEmailToolStripMenuItem1.Click += new System.EventHandler(this.SendEmailToolStripMenuItem1_Click);
            // 
            // CallToolStripMenuItem
            // 
            this.CallToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallToolStripMenuItem.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_call_24_filled;
            this.CallToolStripMenuItem.Name = "CallToolStripMenuItem";
            this.CallToolStripMenuItem.Size = new System.Drawing.Size(199, 38);
            this.CallToolStripMenuItem.Text = "Call";
            this.CallToolStripMenuItem.Click += new System.EventHandler(this.CallToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.User_research_rafiki;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(362, -65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 426);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1191, 863);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private SiticoneNetFrameworkUI.SiticoneButton btnCloseForm;
        private SiticoneNetFrameworkUI.SiticoneButton btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmUserSettings;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddNewUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem EditUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SendEmailToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}