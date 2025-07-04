﻿namespace Drivers_and_Vehicles_License_Department__DVLD_.People.Forms
{
    partial class frmAddAndUpdatePeople
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
            this.Panel = new SiticoneNetFrameworkUI.SiticonePanel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.txtAddress = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.txtEmail = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.txtPhone = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.txtNationalNO = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.txtLastName = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.txtThirdName = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.txtSecondName = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.btnRemoveImage = new SiticoneNetFrameworkUI.SiticoneButton();
            this.btnSetNewPicture = new SiticoneNetFrameworkUI.SiticoneButton();
            this.rbFemale = new SiticoneNetFrameworkUI.SiticoneRadioButton();
            this.rbMale = new SiticoneNetFrameworkUI.SiticoneRadioButton();
            this.txtFirstName = new SiticoneNetFrameworkUI.SiticoneTextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.btnSave = new SiticoneNetFrameworkUI.SiticoneButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseForm = new SiticoneNetFrameworkUI.SiticoneButton();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.AcrylicTintColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Panel.BackColor = System.Drawing.Color.Transparent;
            this.Panel.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.Panel.BorderDashPattern = null;
            this.Panel.BorderGradientEndColor = System.Drawing.Color.Purple;
            this.Panel.BorderGradientStartColor = System.Drawing.Color.Blue;
            this.Panel.BorderThickness = 2F;
            this.Panel.Controls.Add(this.pbPersonImage);
            this.Panel.Controls.Add(this.txtAddress);
            this.Panel.Controls.Add(this.txtEmail);
            this.Panel.Controls.Add(this.txtPhone);
            this.Panel.Controls.Add(this.txtNationalNO);
            this.Panel.Controls.Add(this.txtLastName);
            this.Panel.Controls.Add(this.txtThirdName);
            this.Panel.Controls.Add(this.txtSecondName);
            this.Panel.Controls.Add(this.btnRemoveImage);
            this.Panel.Controls.Add(this.btnSetNewPicture);
            this.Panel.Controls.Add(this.rbFemale);
            this.Panel.Controls.Add(this.rbMale);
            this.Panel.Controls.Add(this.txtFirstName);
            this.Panel.Controls.Add(this.dtpDateOfBirth);
            this.Panel.Controls.Add(this.label8);
            this.Panel.Controls.Add(this.label7);
            this.Panel.Controls.Add(this.label12);
            this.Panel.Controls.Add(this.cbCountry);
            this.Panel.CornerRadiusBottomLeft = 10F;
            this.Panel.CornerRadiusBottomRight = 10F;
            this.Panel.CornerRadiusTopLeft = 10F;
            this.Panel.CornerRadiusTopRight = 10F;
            this.Panel.EnableAcrylicEffect = false;
            this.Panel.EnableMicaEffect = false;
            this.Panel.EnableRippleEffect = false;
            this.Panel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.Panel.GradientColors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.Gray};
            this.Panel.GradientPositions = new float[] {
        0F,
        0.5F,
        1F};
            this.Panel.Location = new System.Drawing.Point(12, 71);
            this.Panel.Name = "Panel";
            this.Panel.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.Panel.RippleAlpha = 50;
            this.Panel.RippleAlphaDecrement = 3;
            this.Panel.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Panel.RippleMaxSize = 600F;
            this.Panel.RippleSpeed = 15F;
            this.Panel.ShowBorder = true;
            this.Panel.Size = new System.Drawing.Size(1152, 640);
            this.Panel.TabIndex = 1;
            this.Panel.TabStop = true;
            this.Panel.UseBorderGradient = false;
            this.Panel.UseMultiGradient = false;
            this.Panel.UsePatternTexture = false;
            this.Panel.UseRadialGradient = false;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.face_1000dp_000000_FILL0_wght400_GRAD0_opsz48;
            this.pbPersonImage.Location = new System.Drawing.Point(47, 112);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(300, 300);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 127;
            this.pbPersonImage.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleDescription = "A customizable text input field.";
            this.txtAddress.AccessibleName = "Text Box";
            this.txtAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtAddress.BlinkCount = 3;
            this.txtAddress.BlinkShadow = false;
            this.txtAddress.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtAddress.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtAddress.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtAddress.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtAddress.CanShake = true;
            this.txtAddress.ContinuousBlink = false;
            this.txtAddress.CornerRadiusBottomLeft = 30;
            this.txtAddress.CornerRadiusBottomRight = 30;
            this.txtAddress.CornerRadiusTopLeft = 30;
            this.txtAddress.CornerRadiusTopRight = 30;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.CursorBlinkRate = 500;
            this.txtAddress.CursorColor = System.Drawing.Color.Black;
            this.txtAddress.CursorHeight = 26;
            this.txtAddress.CursorOffset = 0;
            this.txtAddress.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtAddress.CursorWidth = 1;
            this.txtAddress.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAddress.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtAddress.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtAddress.EnableDropShadow = false;
            this.txtAddress.FillColor1 = System.Drawing.Color.Black;
            this.txtAddress.FillColor2 = System.Drawing.Color.Black;
            this.txtAddress.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtAddress.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtAddress.IsEnabled = true;
            this.txtAddress.Location = new System.Drawing.Point(459, 491);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtAddress.PlaceholderText = "Address";
            this.txtAddress.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtAddress.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtAddress.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtAddress.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtAddress.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAddress.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtAddress.ShadowAnimationDuration = 1;
            this.txtAddress.ShadowBlur = 10;
            this.txtAddress.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress.Size = new System.Drawing.Size(625, 127);
            this.txtAddress.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtAddress.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtAddress.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtAddress.SolidFillColor = System.Drawing.Color.White;
            this.txtAddress.TabIndex = 12;
            this.txtAddress.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtAddress.ValidationErrorMessage = "Invalid input.";
            this.txtAddress.ValidationFunction = null;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtEmail
            // 
            this.txtEmail.AccessibleDescription = "A customizable text input field.";
            this.txtEmail.AccessibleName = "Text Box";
            this.txtEmail.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtEmail.BlinkCount = 3;
            this.txtEmail.BlinkShadow = false;
            this.txtEmail.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtEmail.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtEmail.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtEmail.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtEmail.CanShake = true;
            this.txtEmail.ContinuousBlink = false;
            this.txtEmail.CornerRadiusBottomLeft = 30;
            this.txtEmail.CornerRadiusBottomRight = 30;
            this.txtEmail.CornerRadiusTopLeft = 30;
            this.txtEmail.CornerRadiusTopRight = 30;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.CursorBlinkRate = 500;
            this.txtEmail.CursorColor = System.Drawing.Color.Black;
            this.txtEmail.CursorHeight = 26;
            this.txtEmail.CursorOffset = 0;
            this.txtEmail.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtEmail.CursorWidth = 1;
            this.txtEmail.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtEmail.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtEmail.EnableDropShadow = false;
            this.txtEmail.FillColor1 = System.Drawing.Color.Black;
            this.txtEmail.FillColor2 = System.Drawing.Color.Black;
            this.txtEmail.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtEmail.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtEmail.IsEnabled = true;
            this.txtEmail.Location = new System.Drawing.Point(787, 423);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtEmail.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtEmail.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtEmail.ShadowAnimationDuration = 1;
            this.txtEmail.ShadowBlur = 10;
            this.txtEmail.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmail.Size = new System.Drawing.Size(297, 38);
            this.txtEmail.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtEmail.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtEmail.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtEmail.SolidFillColor = System.Drawing.Color.White;
            this.txtEmail.TabIndex = 11;
            this.txtEmail.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtEmail.ValidationErrorMessage = "Invalid input.";
            this.txtEmail.ValidationFunction = null;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtPhone
            // 
            this.txtPhone.AccessibleDescription = "A customizable text input field.";
            this.txtPhone.AccessibleName = "Text Box";
            this.txtPhone.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtPhone.BlinkCount = 3;
            this.txtPhone.BlinkShadow = false;
            this.txtPhone.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtPhone.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtPhone.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtPhone.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtPhone.CanShake = true;
            this.txtPhone.ContinuousBlink = false;
            this.txtPhone.CornerRadiusBottomLeft = 30;
            this.txtPhone.CornerRadiusBottomRight = 30;
            this.txtPhone.CornerRadiusTopLeft = 30;
            this.txtPhone.CornerRadiusTopRight = 30;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.CursorBlinkRate = 500;
            this.txtPhone.CursorColor = System.Drawing.Color.Black;
            this.txtPhone.CursorHeight = 26;
            this.txtPhone.CursorOffset = 0;
            this.txtPhone.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtPhone.CursorWidth = 1;
            this.txtPhone.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPhone.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtPhone.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtPhone.EnableDropShadow = false;
            this.txtPhone.FillColor1 = System.Drawing.Color.Black;
            this.txtPhone.FillColor2 = System.Drawing.Color.Black;
            this.txtPhone.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtPhone.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtPhone.IsEnabled = true;
            this.txtPhone.Location = new System.Drawing.Point(787, 345);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtPhone.PlaceholderText = "Phone";
            this.txtPhone.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtPhone.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtPhone.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtPhone.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtPhone.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPhone.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtPhone.ShadowAnimationDuration = 1;
            this.txtPhone.ShadowBlur = 10;
            this.txtPhone.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhone.Size = new System.Drawing.Size(297, 38);
            this.txtPhone.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtPhone.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtPhone.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtPhone.SolidFillColor = System.Drawing.Color.White;
            this.txtPhone.TabIndex = 9;
            this.txtPhone.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtPhone.ValidationErrorMessage = "Invalid input.";
            this.txtPhone.ValidationFunction = null;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtNationalNO
            // 
            this.txtNationalNO.AccessibleDescription = "A customizable text input field.";
            this.txtNationalNO.AccessibleName = "Text Box";
            this.txtNationalNO.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtNationalNO.BackColor = System.Drawing.Color.Transparent;
            this.txtNationalNO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtNationalNO.BlinkCount = 3;
            this.txtNationalNO.BlinkShadow = false;
            this.txtNationalNO.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtNationalNO.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtNationalNO.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtNationalNO.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtNationalNO.CanShake = true;
            this.txtNationalNO.ContinuousBlink = false;
            this.txtNationalNO.CornerRadiusBottomLeft = 30;
            this.txtNationalNO.CornerRadiusBottomRight = 30;
            this.txtNationalNO.CornerRadiusTopLeft = 30;
            this.txtNationalNO.CornerRadiusTopRight = 30;
            this.txtNationalNO.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationalNO.CursorBlinkRate = 500;
            this.txtNationalNO.CursorColor = System.Drawing.Color.Black;
            this.txtNationalNO.CursorHeight = 26;
            this.txtNationalNO.CursorOffset = 0;
            this.txtNationalNO.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtNationalNO.CursorWidth = 1;
            this.txtNationalNO.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNationalNO.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtNationalNO.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtNationalNO.EnableDropShadow = false;
            this.txtNationalNO.FillColor1 = System.Drawing.Color.Black;
            this.txtNationalNO.FillColor2 = System.Drawing.Color.Black;
            this.txtNationalNO.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtNationalNO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNationalNO.ForeColor = System.Drawing.Color.Black;
            this.txtNationalNO.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtNationalNO.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtNationalNO.IsEnabled = true;
            this.txtNationalNO.Location = new System.Drawing.Point(787, 268);
            this.txtNationalNO.Name = "txtNationalNO";
            this.txtNationalNO.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtNationalNO.PlaceholderText = "National NO.";
            this.txtNationalNO.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtNationalNO.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtNationalNO.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtNationalNO.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtNationalNO.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNationalNO.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtNationalNO.ShadowAnimationDuration = 1;
            this.txtNationalNO.ShadowBlur = 10;
            this.txtNationalNO.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtNationalNO.Size = new System.Drawing.Size(297, 38);
            this.txtNationalNO.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtNationalNO.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtNationalNO.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtNationalNO.SolidFillColor = System.Drawing.Color.White;
            this.txtNationalNO.TabIndex = 7;
            this.txtNationalNO.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtNationalNO.ValidationErrorMessage = "Invalid input.";
            this.txtNationalNO.ValidationFunction = null;
            this.txtNationalNO.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNO_Validating);
            // 
            // txtLastName
            // 
            this.txtLastName.AccessibleDescription = "A customizable text input field.";
            this.txtLastName.AccessibleName = "Text Box";
            this.txtLastName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtLastName.BlinkCount = 3;
            this.txtLastName.BlinkShadow = false;
            this.txtLastName.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtLastName.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtLastName.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtLastName.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtLastName.CanShake = true;
            this.txtLastName.ContinuousBlink = false;
            this.txtLastName.CornerRadiusBottomLeft = 30;
            this.txtLastName.CornerRadiusBottomRight = 30;
            this.txtLastName.CornerRadiusTopLeft = 30;
            this.txtLastName.CornerRadiusTopRight = 30;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.CursorBlinkRate = 500;
            this.txtLastName.CursorColor = System.Drawing.Color.Black;
            this.txtLastName.CursorHeight = 26;
            this.txtLastName.CursorOffset = 0;
            this.txtLastName.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtLastName.CursorWidth = 1;
            this.txtLastName.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLastName.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtLastName.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtLastName.EnableDropShadow = false;
            this.txtLastName.FillColor1 = System.Drawing.Color.Black;
            this.txtLastName.FillColor2 = System.Drawing.Color.Black;
            this.txtLastName.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtLastName.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtLastName.IsEnabled = true;
            this.txtLastName.Location = new System.Drawing.Point(787, 187);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtLastName.PlaceholderText = "Last Name";
            this.txtLastName.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtLastName.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtLastName.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtLastName.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtLastName.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtLastName.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtLastName.ShadowAnimationDuration = 1;
            this.txtLastName.ShadowBlur = 10;
            this.txtLastName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtLastName.Size = new System.Drawing.Size(297, 38);
            this.txtLastName.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtLastName.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtLastName.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtLastName.SolidFillColor = System.Drawing.Color.White;
            this.txtLastName.TabIndex = 4;
            this.txtLastName.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtLastName.ValidationErrorMessage = "Invalid input.";
            this.txtLastName.ValidationFunction = null;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtThirdName
            // 
            this.txtThirdName.AccessibleDescription = "A customizable text input field.";
            this.txtThirdName.AccessibleName = "Text Box";
            this.txtThirdName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtThirdName.BackColor = System.Drawing.Color.Transparent;
            this.txtThirdName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtThirdName.BlinkCount = 3;
            this.txtThirdName.BlinkShadow = false;
            this.txtThirdName.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtThirdName.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtThirdName.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtThirdName.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtThirdName.CanShake = true;
            this.txtThirdName.ContinuousBlink = false;
            this.txtThirdName.CornerRadiusBottomLeft = 30;
            this.txtThirdName.CornerRadiusBottomRight = 30;
            this.txtThirdName.CornerRadiusTopLeft = 30;
            this.txtThirdName.CornerRadiusTopRight = 30;
            this.txtThirdName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThirdName.CursorBlinkRate = 500;
            this.txtThirdName.CursorColor = System.Drawing.Color.Black;
            this.txtThirdName.CursorHeight = 26;
            this.txtThirdName.CursorOffset = 0;
            this.txtThirdName.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtThirdName.CursorWidth = 1;
            this.txtThirdName.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtThirdName.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtThirdName.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtThirdName.EnableDropShadow = false;
            this.txtThirdName.FillColor1 = System.Drawing.Color.Black;
            this.txtThirdName.FillColor2 = System.Drawing.Color.Black;
            this.txtThirdName.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtThirdName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThirdName.ForeColor = System.Drawing.Color.Black;
            this.txtThirdName.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtThirdName.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtThirdName.IsEnabled = true;
            this.txtThirdName.Location = new System.Drawing.Point(459, 187);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtThirdName.PlaceholderText = "Third Name";
            this.txtThirdName.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtThirdName.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtThirdName.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtThirdName.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtThirdName.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtThirdName.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtThirdName.ShadowAnimationDuration = 1;
            this.txtThirdName.ShadowBlur = 10;
            this.txtThirdName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtThirdName.Size = new System.Drawing.Size(297, 38);
            this.txtThirdName.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtThirdName.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtThirdName.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtThirdName.SolidFillColor = System.Drawing.Color.White;
            this.txtThirdName.TabIndex = 3;
            this.txtThirdName.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtThirdName.ValidationErrorMessage = "Invalid input.";
            this.txtThirdName.ValidationFunction = null;
            // 
            // txtSecondName
            // 
            this.txtSecondName.AccessibleDescription = "A customizable text input field.";
            this.txtSecondName.AccessibleName = "Text Box";
            this.txtSecondName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtSecondName.BackColor = System.Drawing.Color.Transparent;
            this.txtSecondName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtSecondName.BlinkCount = 3;
            this.txtSecondName.BlinkShadow = false;
            this.txtSecondName.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtSecondName.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtSecondName.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtSecondName.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtSecondName.CanShake = true;
            this.txtSecondName.ContinuousBlink = false;
            this.txtSecondName.CornerRadiusBottomLeft = 30;
            this.txtSecondName.CornerRadiusBottomRight = 30;
            this.txtSecondName.CornerRadiusTopLeft = 30;
            this.txtSecondName.CornerRadiusTopRight = 30;
            this.txtSecondName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSecondName.CursorBlinkRate = 500;
            this.txtSecondName.CursorColor = System.Drawing.Color.Black;
            this.txtSecondName.CursorHeight = 26;
            this.txtSecondName.CursorOffset = 0;
            this.txtSecondName.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtSecondName.CursorWidth = 1;
            this.txtSecondName.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSecondName.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtSecondName.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtSecondName.EnableDropShadow = false;
            this.txtSecondName.FillColor1 = System.Drawing.Color.Black;
            this.txtSecondName.FillColor2 = System.Drawing.Color.Black;
            this.txtSecondName.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtSecondName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondName.ForeColor = System.Drawing.Color.Black;
            this.txtSecondName.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtSecondName.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtSecondName.IsEnabled = true;
            this.txtSecondName.Location = new System.Drawing.Point(787, 113);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtSecondName.PlaceholderText = "Second Name";
            this.txtSecondName.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtSecondName.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtSecondName.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtSecondName.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtSecondName.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSecondName.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtSecondName.ShadowAnimationDuration = 1;
            this.txtSecondName.ShadowBlur = 10;
            this.txtSecondName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSecondName.Size = new System.Drawing.Size(297, 38);
            this.txtSecondName.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtSecondName.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtSecondName.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtSecondName.SolidFillColor = System.Drawing.Color.White;
            this.txtSecondName.TabIndex = 2;
            this.txtSecondName.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtSecondName.ValidationErrorMessage = "Invalid input.";
            this.txtSecondName.ValidationFunction = null;
            this.txtSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnRemoveImage.AccessibleName = "Remove";
            this.btnRemoveImage.AutoSizeBasedOnText = false;
            this.btnRemoveImage.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveImage.BadgeBackColor = System.Drawing.Color.Red;
            this.btnRemoveImage.BadgeFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveImage.BadgeValue = 0;
            this.btnRemoveImage.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnRemoveImage.BorderColor = System.Drawing.Color.Transparent;
            this.btnRemoveImage.BorderWidth = 2;
            this.btnRemoveImage.ButtonBackColor = System.Drawing.Color.Silver;
            this.btnRemoveImage.ButtonImage = null;
            this.btnRemoveImage.CanBeep = true;
            this.btnRemoveImage.CanGlow = false;
            this.btnRemoveImage.CanShake = true;
            this.btnRemoveImage.ContextMenuStripEx = null;
            this.btnRemoveImage.CornerRadiusBottomLeft = 20;
            this.btnRemoveImage.CornerRadiusBottomRight = 20;
            this.btnRemoveImage.CornerRadiusTopLeft = 20;
            this.btnRemoveImage.CornerRadiusTopRight = 20;
            this.btnRemoveImage.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnRemoveImage.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnRemoveImage.EnableLongPress = false;
            this.btnRemoveImage.EnablePressAnimation = true;
            this.btnRemoveImage.EnableRippleEffect = true;
            this.btnRemoveImage.EnableShadow = false;
            this.btnRemoveImage.EnableTextWrapping = false;
            this.btnRemoveImage.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveImage.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveImage.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveImage.GlowIntensity = 100;
            this.btnRemoveImage.GlowRadius = 20F;
            this.btnRemoveImage.GradientBackground = false;
            this.btnRemoveImage.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnRemoveImage.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRemoveImage.HintText = null;
            this.btnRemoveImage.HoverBackColor = System.Drawing.Color.DimGray;
            this.btnRemoveImage.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnRemoveImage.HoverTextColor = System.Drawing.Color.Black;
            this.btnRemoveImage.HoverTransitionDuration = 250;
            this.btnRemoveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveImage.ImagePadding = 5;
            this.btnRemoveImage.ImageSize = new System.Drawing.Size(16, 16);
            this.btnRemoveImage.IsRadial = false;
            this.btnRemoveImage.IsReadOnly = false;
            this.btnRemoveImage.IsToggleButton = false;
            this.btnRemoveImage.IsToggled = false;
            this.btnRemoveImage.Location = new System.Drawing.Point(135, 467);
            this.btnRemoveImage.LongPressDurationMS = 1000;
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnRemoveImage.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRemoveImage.ParticleCount = 15;
            this.btnRemoveImage.PressAnimationScale = 0.97F;
            this.btnRemoveImage.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRemoveImage.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnRemoveImage.PressTransitionDuration = 150;
            this.btnRemoveImage.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnRemoveImage.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveImage.RippleOpacity = 0.3F;
            this.btnRemoveImage.RippleRadiusMultiplier = 0.6F;
            this.btnRemoveImage.ShadowBlur = 5;
            this.btnRemoveImage.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveImage.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnRemoveImage.ShakeDuration = 500;
            this.btnRemoveImage.ShakeIntensity = 5;
            this.btnRemoveImage.Size = new System.Drawing.Size(124, 39);
            this.btnRemoveImage.TabIndex = 14;
            this.btnRemoveImage.Text = "Remove";
            this.btnRemoveImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRemoveImage.TextColor = System.Drawing.Color.Black;
            this.btnRemoveImage.TooltipText = null;
            this.btnRemoveImage.UseAdvancedRendering = true;
            this.btnRemoveImage.UseParticles = false;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnSetNewPicture
            // 
            this.btnSetNewPicture.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnSetNewPicture.AccessibleName = "Set New Picture";
            this.btnSetNewPicture.AutoSizeBasedOnText = false;
            this.btnSetNewPicture.BackColor = System.Drawing.Color.Transparent;
            this.btnSetNewPicture.BadgeBackColor = System.Drawing.Color.Red;
            this.btnSetNewPicture.BadgeFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetNewPicture.BadgeValue = 0;
            this.btnSetNewPicture.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnSetNewPicture.BorderColor = System.Drawing.Color.Transparent;
            this.btnSetNewPicture.BorderWidth = 2;
            this.btnSetNewPicture.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSetNewPicture.ButtonImage = null;
            this.btnSetNewPicture.CanBeep = true;
            this.btnSetNewPicture.CanGlow = false;
            this.btnSetNewPicture.CanShake = true;
            this.btnSetNewPicture.ContextMenuStripEx = null;
            this.btnSetNewPicture.CornerRadiusBottomLeft = 20;
            this.btnSetNewPicture.CornerRadiusBottomRight = 20;
            this.btnSetNewPicture.CornerRadiusTopLeft = 20;
            this.btnSetNewPicture.CornerRadiusTopRight = 20;
            this.btnSetNewPicture.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnSetNewPicture.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnSetNewPicture.EnableLongPress = false;
            this.btnSetNewPicture.EnablePressAnimation = true;
            this.btnSetNewPicture.EnableRippleEffect = true;
            this.btnSetNewPicture.EnableShadow = false;
            this.btnSetNewPicture.EnableTextWrapping = false;
            this.btnSetNewPicture.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetNewPicture.ForeColor = System.Drawing.Color.Transparent;
            this.btnSetNewPicture.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSetNewPicture.GlowIntensity = 100;
            this.btnSetNewPicture.GlowRadius = 20F;
            this.btnSetNewPicture.GradientBackground = false;
            this.btnSetNewPicture.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnSetNewPicture.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSetNewPicture.HintText = null;
            this.btnSetNewPicture.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.btnSetNewPicture.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnSetNewPicture.HoverTextColor = System.Drawing.Color.Black;
            this.btnSetNewPicture.HoverTransitionDuration = 250;
            this.btnSetNewPicture.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSetNewPicture.ImagePadding = 5;
            this.btnSetNewPicture.ImageSize = new System.Drawing.Size(16, 16);
            this.btnSetNewPicture.IsRadial = false;
            this.btnSetNewPicture.IsReadOnly = false;
            this.btnSetNewPicture.IsToggleButton = false;
            this.btnSetNewPicture.IsToggled = false;
            this.btnSetNewPicture.Location = new System.Drawing.Point(88, 423);
            this.btnSetNewPicture.LongPressDurationMS = 1000;
            this.btnSetNewPicture.Name = "btnSetNewPicture";
            this.btnSetNewPicture.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnSetNewPicture.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSetNewPicture.ParticleCount = 15;
            this.btnSetNewPicture.PressAnimationScale = 0.97F;
            this.btnSetNewPicture.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(162)))), ((int)(((byte)(0)))));
            this.btnSetNewPicture.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnSetNewPicture.PressTransitionDuration = 150;
            this.btnSetNewPicture.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnSetNewPicture.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSetNewPicture.RippleOpacity = 0.3F;
            this.btnSetNewPicture.RippleRadiusMultiplier = 0.6F;
            this.btnSetNewPicture.ShadowBlur = 5;
            this.btnSetNewPicture.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSetNewPicture.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnSetNewPicture.ShakeDuration = 500;
            this.btnSetNewPicture.ShakeIntensity = 5;
            this.btnSetNewPicture.Size = new System.Drawing.Size(219, 39);
            this.btnSetNewPicture.TabIndex = 13;
            this.btnSetNewPicture.Text = "Set New Picture";
            this.btnSetNewPicture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSetNewPicture.TextColor = System.Drawing.Color.Black;
            this.btnSetNewPicture.TooltipText = null;
            this.btnSetNewPicture.UseAdvancedRendering = true;
            this.btnSetNewPicture.UseParticles = false;
            this.btnSetNewPicture.Click += new System.EventHandler(this.btnSetNewPicture_Click);
            // 
            // rbFemale
            // 
            this.rbFemale.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.rbFemale.BackColor = System.Drawing.Color.Transparent;
            this.rbFemale.CanBeep = true;
            this.rbFemale.CanShake = true;
            this.rbFemale.Checked = false;
            this.rbFemale.CheckedColor = System.Drawing.Color.Gold;
            this.rbFemale.ContainerBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbFemale.ContainerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbFemale.ContainerBorderWidth = 1;
            this.rbFemale.ContainerBottomLeftRadius = 8;
            this.rbFemale.ContainerBottomRightRadius = 8;
            this.rbFemale.ContainerCheckedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbFemale.ContainerCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbFemale.ContainerCheckedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbFemale.ContainerCheckedPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbFemale.ContainerHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbFemale.ContainerPadding = 8;
            this.rbFemale.ContainerPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbFemale.ContainerTopLeftRadius = 8;
            this.rbFemale.ContainerTopRightRadius = 8;
            this.rbFemale.EnableRipple = false;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFemale.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.rbFemale.IsContained = false;
            this.rbFemale.IsReadOnly = false;
            this.rbFemale.Location = new System.Drawing.Point(553, 289);
            this.rbFemale.MinimumSize = new System.Drawing.Size(178, 24);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.rbFemale.RippleDuration = 0.5F;
            this.rbFemale.RippleStyle = SiticoneNetFrameworkUI.SiticoneRadioButton.RippleAnimationStyle.Standard;
            this.rbFemale.ShakeDuration = 0.5F;
            this.rbFemale.Size = new System.Drawing.Size(178, 30);
            this.rbFemale.TabIndex = 6;
            this.rbFemale.Text = "Female";
            this.rbFemale.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rbFemale.ToolTipText = "";
            this.rbFemale.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.rbMale.BackColor = System.Drawing.Color.Transparent;
            this.rbMale.CanBeep = true;
            this.rbMale.CanShake = true;
            this.rbMale.Checked = false;
            this.rbMale.CheckedColor = System.Drawing.Color.Gold;
            this.rbMale.ContainerBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbMale.ContainerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbMale.ContainerBorderWidth = 1;
            this.rbMale.ContainerBottomLeftRadius = 8;
            this.rbMale.ContainerBottomRightRadius = 8;
            this.rbMale.ContainerCheckedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbMale.ContainerCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbMale.ContainerCheckedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbMale.ContainerCheckedPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(56)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbMale.ContainerHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbMale.ContainerPadding = 8;
            this.rbMale.ContainerPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbMale.ContainerTopLeftRadius = 8;
            this.rbMale.ContainerTopRightRadius = 8;
            this.rbMale.EnableRipple = false;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbMale.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.rbMale.IsContained = false;
            this.rbMale.IsReadOnly = false;
            this.rbMale.Location = new System.Drawing.Point(553, 256);
            this.rbMale.MinimumSize = new System.Drawing.Size(178, 24);
            this.rbMale.Name = "rbMale";
            this.rbMale.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.rbMale.RippleDuration = 0.5F;
            this.rbMale.RippleStyle = SiticoneNetFrameworkUI.SiticoneRadioButton.RippleAnimationStyle.Standard;
            this.rbMale.ShakeDuration = 0.5F;
            this.rbMale.Size = new System.Drawing.Size(178, 27);
            this.rbMale.TabIndex = 5;
            this.rbMale.Text = "Male";
            this.rbMale.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rbMale.ToolTipText = "";
            this.rbMale.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.rbMale.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.AccessibleDescription = "A customizable text input field.";
            this.txtFirstName.AccessibleName = "Text Box";
            this.txtFirstName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtFirstName.BlinkCount = 3;
            this.txtFirstName.BlinkShadow = false;
            this.txtFirstName.BorderColor1 = System.Drawing.Color.LightSlateGray;
            this.txtFirstName.BorderColor2 = System.Drawing.Color.LightSlateGray;
            this.txtFirstName.BorderFocusColor1 = System.Drawing.Color.Gold;
            this.txtFirstName.BorderFocusColor2 = System.Drawing.Color.Gold;
            this.txtFirstName.CanShake = true;
            this.txtFirstName.ContinuousBlink = false;
            this.txtFirstName.CornerRadiusBottomLeft = 30;
            this.txtFirstName.CornerRadiusBottomRight = 30;
            this.txtFirstName.CornerRadiusTopLeft = 30;
            this.txtFirstName.CornerRadiusTopRight = 30;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.CursorBlinkRate = 500;
            this.txtFirstName.CursorColor = System.Drawing.Color.Black;
            this.txtFirstName.CursorHeight = 26;
            this.txtFirstName.CursorOffset = 0;
            this.txtFirstName.CursorStyle = SiticoneNetFrameworkUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            this.txtFirstName.CursorWidth = 1;
            this.txtFirstName.DisabledBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFirstName.DisabledBorderColor = System.Drawing.Color.LightGray;
            this.txtFirstName.DisabledTextColor = System.Drawing.Color.Gray;
            this.txtFirstName.EnableDropShadow = false;
            this.txtFirstName.FillColor1 = System.Drawing.Color.Black;
            this.txtFirstName.FillColor2 = System.Drawing.Color.Black;
            this.txtFirstName.FillGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.HoverBorderColor1 = System.Drawing.Color.Yellow;
            this.txtFirstName.HoverBorderColor2 = System.Drawing.Color.Yellow;
            this.txtFirstName.IsEnabled = true;
            this.txtFirstName.Location = new System.Drawing.Point(459, 113);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtFirstName.PlaceholderText = "First Name";
            this.txtFirstName.ReadOnlyBorderColor1 = System.Drawing.Color.LightGray;
            this.txtFirstName.ReadOnlyBorderColor2 = System.Drawing.Color.LightGray;
            this.txtFirstName.ReadOnlyFillColor1 = System.Drawing.Color.WhiteSmoke;
            this.txtFirstName.ReadOnlyFillColor2 = System.Drawing.Color.WhiteSmoke;
            this.txtFirstName.ReadOnlyPlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFirstName.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.txtFirstName.ShadowAnimationDuration = 1;
            this.txtFirstName.ShadowBlur = 10;
            this.txtFirstName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtFirstName.Size = new System.Drawing.Size(297, 38);
            this.txtFirstName.SolidBorderColor = System.Drawing.Color.LightSlateGray;
            this.txtFirstName.SolidBorderFocusColor = System.Drawing.Color.Gold;
            this.txtFirstName.SolidBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.txtFirstName.SolidFillColor = System.Drawing.Color.White;
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.TextPadding = new System.Windows.Forms.Padding(13, 1, 13, 1);
            this.txtFirstName.ValidationErrorMessage = "Invalid input.";
            this.txtFirstName.ValidationFunction = null;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.Location = new System.Drawing.Point(538, 351);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(2025, 1, 30, 4, 56, 42, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(202, 27);
            this.dtpDateOfBirth.TabIndex = 8;
            this.dtpDateOfBirth.Value = new System.DateTime(2025, 1, 30, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(455, 259);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 21);
            this.label8.TabIndex = 97;
            this.label8.Text = "Gender:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(415, 354);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 95;
            this.label7.Text = "Date Of Bitrh:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(451, 430);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 21);
            this.label12.TabIndex = 114;
            this.label12.Text = "Country:";
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCountry.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(538, 430);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(202, 29);
            this.cbCountry.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnSave.AccessibleName = "Save";
            this.btnSave.AutoSizeBasedOnText = false;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BadgeBackColor = System.Drawing.Color.Red;
            this.btnSave.BadgeFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.BadgeValue = 0;
            this.btnSave.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderWidth = 2;
            this.btnSave.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSave.ButtonImage = null;
            this.btnSave.CanBeep = true;
            this.btnSave.CanGlow = false;
            this.btnSave.CanShake = true;
            this.btnSave.ContextMenuStripEx = null;
            this.btnSave.CornerRadiusBottomLeft = 20;
            this.btnSave.CornerRadiusBottomRight = 20;
            this.btnSave.CornerRadiusTopLeft = 20;
            this.btnSave.CornerRadiusTopRight = 20;
            this.btnSave.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnSave.EnableLongPress = false;
            this.btnSave.EnablePressAnimation = true;
            this.btnSave.EnableRippleEffect = true;
            this.btnSave.EnableShadow = false;
            this.btnSave.EnableTextWrapping = false;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.GlowIntensity = 100;
            this.btnSave.GlowRadius = 20F;
            this.btnSave.GradientBackground = false;
            this.btnSave.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSave.HintText = null;
            this.btnSave.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.btnSave.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnSave.HoverTextColor = System.Drawing.Color.Black;
            this.btnSave.HoverTransitionDuration = 250;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImagePadding = 5;
            this.btnSave.ImageSize = new System.Drawing.Size(16, 16);
            this.btnSave.IsRadial = false;
            this.btnSave.IsReadOnly = false;
            this.btnSave.IsToggleButton = false;
            this.btnSave.IsToggled = false;
            this.btnSave.Location = new System.Drawing.Point(1039, 717);
            this.btnSave.LongPressDurationMS = 1000;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnSave.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSave.ParticleCount = 15;
            this.btnSave.PressAnimationScale = 0.97F;
            this.btnSave.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(162)))), ((int)(((byte)(0)))));
            this.btnSave.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnSave.PressTransitionDuration = 150;
            this.btnSave.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnSave.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.RippleOpacity = 0.3F;
            this.btnSave.RippleRadiusMultiplier = 0.6F;
            this.btnSave.ShadowBlur = 5;
            this.btnSave.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnSave.ShakeDuration = 500;
            this.btnSave.ShakeIntensity = 5;
            this.btnSave.Size = new System.Drawing.Size(124, 39);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextColor = System.Drawing.Color.Black;
            this.btnSave.TooltipText = null;
            this.btnSave.UseAdvancedRendering = true;
            this.btnSave.UseParticles = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(437, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(302, 50);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "Add New Person";
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
            this.btnCloseForm.Location = new System.Drawing.Point(908, 717);
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
            this.btnCloseForm.TabIndex = 49;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseForm.TextColor = System.Drawing.Color.Black;
            this.btnCloseForm.TooltipText = null;
            this.btnCloseForm.UseAdvancedRendering = true;
            this.btnCloseForm.UseParticles = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(96, 47);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(40, 21);
            this.lblPersonID.TabIndex = 51;
            this.lblPersonID.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 50;
            this.label1.Text = "PersonID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddAndUpdatePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 762);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddAndUpdatePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddAndUpdatePeople2";
            this.Load += new System.EventHandler(this.frmAddAndUpdatePeople_Load);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SiticoneNetFrameworkUI.SiticonePanel Panel;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtAddress;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtEmail;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtPhone;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtNationalNO;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtLastName;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtThirdName;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtSecondName;
        private SiticoneNetFrameworkUI.SiticoneButton btnRemoveImage;
        private SiticoneNetFrameworkUI.SiticoneButton btnSave;
        private SiticoneNetFrameworkUI.SiticoneButton btnSetNewPicture;
        private SiticoneNetFrameworkUI.SiticoneRadioButton rbFemale;
        private SiticoneNetFrameworkUI.SiticoneRadioButton rbMale;
        private SiticoneNetFrameworkUI.SiticoneTextBox txtFirstName;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label lblTitle;
        private SiticoneNetFrameworkUI.SiticoneButton btnCloseForm;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}