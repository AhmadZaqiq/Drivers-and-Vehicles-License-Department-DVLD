namespace Drivers_and_Vehicles_License_Department__DVLD_.People.Contorls
{
    partial class ctrlPersonCardWithFilter
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.MaskedTextBox();
            this.btnAddNewPerson = new SiticoneNetFrameworkUI.SiticoneButton();
            this.btnFindPerson = new SiticoneNetFrameworkUI.SiticoneButton();
            this.gbFilters = new SiticoneNetFrameworkUI.SiticonePanel();
            this.ctrlPersonCard1 = new Drivers_and_Vehicles_License_Department__DVLD_.ctrlPersonCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 48;
            this.label2.Text = "Find by:";
            // 
            // cbFilter
            // 
            this.cbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(86, 36);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(283, 21);
            this.cbFilter.TabIndex = 49;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(375, 36);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(273, 20);
            this.txtFilter.TabIndex = 50;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            this.txtFilter.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilter_Validating);
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
            this.btnAddNewPerson.Location = new System.Drawing.Point(720, 24);
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
            this.btnAddNewPerson.Size = new System.Drawing.Size(49, 49);
            this.btnAddNewPerson.TabIndex = 52;
            this.btnAddNewPerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNewPerson.TextColor = System.Drawing.Color.White;
            this.btnAddNewPerson.TooltipText = null;
            this.btnAddNewPerson.UseAdvancedRendering = true;
            this.btnAddNewPerson.UseParticles = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard" +
    "";
            this.btnFindPerson.AccessibleName = "";
            this.btnFindPerson.AutoSizeBasedOnText = false;
            this.btnFindPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.BackgroundImage = global::Drivers_and_Vehicles_License_Department__DVLD_.Properties.Resources.ic_fluent_people_search_24_filled;
            this.btnFindPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindPerson.BadgeBackColor = System.Drawing.Color.White;
            this.btnFindPerson.BadgeFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnFindPerson.BadgeValue = 0;
            this.btnFindPerson.BadgeValueForeColor = System.Drawing.Color.White;
            this.btnFindPerson.BorderColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.BorderWidth = 2;
            this.btnFindPerson.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.ButtonImage = null;
            this.btnFindPerson.CanBeep = true;
            this.btnFindPerson.CanGlow = false;
            this.btnFindPerson.CanShake = true;
            this.btnFindPerson.ContextMenuStripEx = null;
            this.btnFindPerson.CornerRadiusBottomLeft = 20;
            this.btnFindPerson.CornerRadiusBottomRight = 20;
            this.btnFindPerson.CornerRadiusTopLeft = 20;
            this.btnFindPerson.CornerRadiusTopRight = 20;
            this.btnFindPerson.CustomCursor = System.Windows.Forms.Cursors.Default;
            this.btnFindPerson.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnFindPerson.EnableLongPress = false;
            this.btnFindPerson.EnablePressAnimation = true;
            this.btnFindPerson.EnableRippleEffect = true;
            this.btnFindPerson.EnableShadow = false;
            this.btnFindPerson.EnableTextWrapping = false;
            this.btnFindPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFindPerson.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFindPerson.GlowIntensity = 100;
            this.btnFindPerson.GlowRadius = 20F;
            this.btnFindPerson.GradientBackground = false;
            this.btnFindPerson.GradientColor = System.Drawing.Color.White;
            this.btnFindPerson.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnFindPerson.HintText = null;
            this.btnFindPerson.HoverBackColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.HoverFontStyle = System.Drawing.FontStyle.Regular;
            this.btnFindPerson.HoverTextColor = System.Drawing.Color.White;
            this.btnFindPerson.HoverTransitionDuration = 250;
            this.btnFindPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindPerson.ImagePadding = 5;
            this.btnFindPerson.ImageSize = new System.Drawing.Size(16, 16);
            this.btnFindPerson.IsRadial = false;
            this.btnFindPerson.IsReadOnly = false;
            this.btnFindPerson.IsToggleButton = false;
            this.btnFindPerson.IsToggled = false;
            this.btnFindPerson.Location = new System.Drawing.Point(665, 24);
            this.btnFindPerson.LongPressDurationMS = 1000;
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.NormalFontStyle = System.Drawing.FontStyle.Regular;
            this.btnFindPerson.ParticleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnFindPerson.ParticleCount = 15;
            this.btnFindPerson.PressAnimationScale = 0.97F;
            this.btnFindPerson.PressedBackColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.PressedFontStyle = System.Drawing.FontStyle.Regular;
            this.btnFindPerson.PressTransitionDuration = 150;
            this.btnFindPerson.ReadOnlyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnFindPerson.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFindPerson.RippleOpacity = 0.3F;
            this.btnFindPerson.RippleRadiusMultiplier = 0.6F;
            this.btnFindPerson.ShadowBlur = 5;
            this.btnFindPerson.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFindPerson.ShadowOffset = new System.Drawing.Point(2, 2);
            this.btnFindPerson.ShakeDuration = 500;
            this.btnFindPerson.ShakeIntensity = 5;
            this.btnFindPerson.Size = new System.Drawing.Size(49, 49);
            this.btnFindPerson.TabIndex = 53;
            this.btnFindPerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFindPerson.TextColor = System.Drawing.Color.White;
            this.btnFindPerson.TooltipText = null;
            this.btnFindPerson.UseAdvancedRendering = true;
            this.btnFindPerson.UseParticles = false;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // gbFilters
            // 
            this.gbFilters.AcrylicTintColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gbFilters.BackColor = System.Drawing.Color.Transparent;
            this.gbFilters.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.gbFilters.BorderDashPattern = null;
            this.gbFilters.BorderGradientEndColor = System.Drawing.Color.Purple;
            this.gbFilters.BorderGradientStartColor = System.Drawing.Color.Blue;
            this.gbFilters.BorderThickness = 2F;
            this.gbFilters.Controls.Add(this.btnFindPerson);
            this.gbFilters.Controls.Add(this.btnAddNewPerson);
            this.gbFilters.Controls.Add(this.txtFilter);
            this.gbFilters.Controls.Add(this.cbFilter);
            this.gbFilters.Controls.Add(this.label2);
            this.gbFilters.CornerRadiusBottomLeft = 10F;
            this.gbFilters.CornerRadiusBottomRight = 10F;
            this.gbFilters.CornerRadiusTopLeft = 10F;
            this.gbFilters.CornerRadiusTopRight = 10F;
            this.gbFilters.EnableAcrylicEffect = false;
            this.gbFilters.EnableMicaEffect = false;
            this.gbFilters.EnableRippleEffect = false;
            this.gbFilters.FillColor = System.Drawing.Color.WhiteSmoke;
            this.gbFilters.GradientColors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.Gray};
            this.gbFilters.GradientPositions = new float[] {
        0F,
        0.5F,
        1F};
            this.gbFilters.Location = new System.Drawing.Point(3, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.PatternStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.gbFilters.RippleAlpha = 50;
            this.gbFilters.RippleAlphaDecrement = 3;
            this.gbFilters.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gbFilters.RippleMaxSize = 600F;
            this.gbFilters.RippleSpeed = 15F;
            this.gbFilters.ShowBorder = true;
            this.gbFilters.Size = new System.Drawing.Size(1158, 100);
            this.gbFilters.TabIndex = 49;
            this.gbFilters.TabStop = true;
            this.gbFilters.UseBorderGradient = false;
            this.gbFilters.UseMultiGradient = false;
            this.gbFilters.UsePatternTexture = false;
            this.gbFilters.UseRadialGradient = false;
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 123);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1158, 646);
            this.ctrlPersonCard1.TabIndex = 48;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(1163, 769);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.MaskedTextBox txtFilter;
        private SiticoneNetFrameworkUI.SiticoneButton btnAddNewPerson;
        private SiticoneNetFrameworkUI.SiticoneButton btnFindPerson;
        private SiticoneNetFrameworkUI.SiticonePanel gbFilters;
        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
