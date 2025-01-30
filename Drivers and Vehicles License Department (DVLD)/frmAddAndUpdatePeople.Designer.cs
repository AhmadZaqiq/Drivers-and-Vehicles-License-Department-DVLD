namespace Drivers_and_Vehicles_License_Department__DVLD_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddAndUpdatePeople));
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAddNewPerson1 = new Drivers_and_Vehicles_License_Department__DVLD_.ctrlAddNewPerson();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(169, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add\\Update Person";
            // 
            // ctrlAddNewPerson1
            // 
            this.ctrlAddNewPerson1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAddNewPerson1.Location = new System.Drawing.Point(13, 116);
            this.ctrlAddNewPerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlAddNewPerson1.Name = "ctrlAddNewPerson1";
            this.ctrlAddNewPerson1.Size = new System.Drawing.Size(788, 395);
            this.ctrlAddNewPerson1.TabIndex = 1;
            // 
            // frmAddAndUpdatePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 524);
            this.Controls.Add(this.ctrlAddNewPerson1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddAndUpdatePeople";
            this.Text = "frmAddAndUpdatePeople";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrlAddNewPerson ctrlAddNewPerson1;
    }
}