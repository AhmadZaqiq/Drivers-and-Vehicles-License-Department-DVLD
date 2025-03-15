namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    partial class frmListPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPeople));
            this.cmPersonSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AddNewPersonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SendEmailToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.siticonePanel1 = new SiticoneNetFrameworkUI.SiticonePanel();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.btnClose = new SiticoneNetFrameworkUI.SiticoneButton();
            this.txtFilter = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNew = new SiticoneNetFrameworkUI.SiticoneButton();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.cmPersonSettings.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmPersonSettings
            // 
            this.cmPersonSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmPersonSettings.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmPersonSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetailsToolStripMenuItem1,
            this.toolStripSeparator4,
            this.AddNewPersonToolStripMenuItem1,
            this.EditToolStripMenuItem1,
            this.DeleteToolStripMenuItem1,
            this.toolStripSeparator3,
            this.SendEmailToolStripMenuItem1,
            this.CallToolStripMenuItem});
            this.cmPersonSettings.Name = "cmPersonSettings";
            this.cmPersonSettings.Size = new System.Drawing.Size(183, 244);
            // 
            // ShowDetailsToolStripMenuItem1
            // 
            this.ShowDetailsToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_text_description_24_filled;
            this.ShowDetailsToolStripMenuItem1.Name = "ShowDetailsToolStripMenuItem1";
            this.ShowDetailsToolStripMenuItem1.Size = new System.Drawing.Size(182, 38);
            this.ShowDetailsToolStripMenuItem1.Text = "Show Details";
            this.ShowDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
            // 
            // AddNewPersonToolStripMenuItem1
            // 
            this.AddNewPersonToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_people_add_24_filled1;
            this.AddNewPersonToolStripMenuItem1.Name = "AddNewPersonToolStripMenuItem1";
            this.AddNewPersonToolStripMenuItem1.Size = new System.Drawing.Size(182, 38);
            this.AddNewPersonToolStripMenuItem1.Text = "Add New Person";
            this.AddNewPersonToolStripMenuItem1.Click += new System.EventHandler(this.AddNewPersonToolStripMenuItem1_Click);
            // 
            // EditToolStripMenuItem1
            // 
            this.EditToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_edit_24_filled;
            this.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1";
            this.EditToolStripMenuItem1.Size = new System.Drawing.Size(182, 38);
            this.EditToolStripMenuItem1.Text = "Edit";
            this.EditToolStripMenuItem1.Click += new System.EventHandler(this.EditToolStripMenuItem1_Click);
            // 
            // DeleteToolStripMenuItem1
            // 
            this.DeleteToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_person_delete_24_filled;
            this.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1";
            this.DeleteToolStripMenuItem1.Size = new System.Drawing.Size(182, 38);
            this.DeleteToolStripMenuItem1.Text = "Delete";
            this.DeleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // SendEmailToolStripMenuItem1
            // 
            this.SendEmailToolStripMenuItem1.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_mail_24_filled;
            this.SendEmailToolStripMenuItem1.Name = "SendEmailToolStripMenuItem1";
            this.SendEmailToolStripMenuItem1.Size = new System.Drawing.Size(182, 38);
            this.SendEmailToolStripMenuItem1.Text = "Send Email";
            this.SendEmailToolStripMenuItem1.Click += new System.EventHandler(this.SendEmailToolStripMenuItem1_Click);
            // 
            // CallToolStripMenuItem
            // 
            this.CallToolStripMenuItem.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_call_24_filled;
            this.CallToolStripMenuItem.Name = "CallToolStripMenuItem";
            this.CallToolStripMenuItem.Size = new System.Drawing.Size(182, 38);
            this.CallToolStripMenuItem.Text = "Call";
            this.CallToolStripMenuItem.Click += new System.EventHandler(this.CallToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(476, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter by:";
            // 
            // cbFilter
            // 
            this.cbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(76, 391);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(160, 25);
            this.cbFilter.TabIndex = 5;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 765);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(88, 765);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(87, 21);
            this.lblRecordsCount.TabIndex = 8;
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
            this.siticonePanel1.Location = new System.Drawing.Point(12, 418);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.siticonePanel1.RippleAlpha = 50;
            this.siticonePanel1.RippleAlphaDecrement = 3;
            this.siticonePanel1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.siticonePanel1.RippleMaxSize = 600F;
            this.siticonePanel1.RippleSpeed = 15F;
            this.siticonePanel1.ShowBorder = true;
            this.siticonePanel1.Size = new System.Drawing.Size(1167, 344);
            this.siticonePanel1.TabIndex = 15;
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
            this.dgvPeople.MouseEnter += new System.EventHandler(this.dgvPeople_MouseEnter);
            this.dgvPeople.MouseLeave += new System.EventHandler(this.dgvPeople_MouseLeave);
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
            this.btnClose.Location = new System.Drawing.Point(1054, 812);
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
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.TooltipText = null;
            this.btnClose.UseAdvancedRendering = true;
            this.btnClose.UseParticles = false;
            this.btnClose.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(242, 391);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(277, 25);
            this.txtFilter.TabIndex = 51;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.Add_User_cuate;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(373, -80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 426);
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
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
            this.btnAddNew.Location = new System.Drawing.Point(1114, 352);
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
            this.btnAddNew.TabIndex = 54;
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNew.TextColor = System.Drawing.Color.White;
            this.btnAddNew.TooltipText = null;
            this.btnAddNew.UseAdvancedRendering = true;
            this.btnAddNew.UseParticles = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.Add_Person;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1371, 177);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(85, 80);
            this.btnAddNewPerson.TabIndex = 13;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // frmListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1191, 863);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmPeople_Load);
            this.cmPersonSettings.ResumeLayout(false);
            this.siticonePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmPersonSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddNewPersonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SendEmailToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CallToolStripMenuItem;
        private SiticoneNetFrameworkUI.SiticonePanel siticonePanel1;
        private SiticoneNetFrameworkUI.SiticoneButton btnClose;
        private System.Windows.Forms.MaskedTextBox txtFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private SiticoneNetFrameworkUI.SiticoneButton btnAddNew;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}