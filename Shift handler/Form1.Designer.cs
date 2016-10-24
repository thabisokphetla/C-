namespace Question4
{
    partial class Form1
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
            this.lstLocations = new System.Windows.Forms.ListBox();
            this.btnStartShift = new System.Windows.Forms.Button();
            this.lstShiftPlan = new System.Windows.Forms.ListBox();
            this.btnAddTrip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstLocations
            // 
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.Items.AddRange(new object[] {
            "Capetown:1200:12",
            "Pretoria:100:3",
            "Middelburg:160:5",
            "Boksburg:200:4",
            "Bloemfontein:400:6",
            "Durban:800:9",
            "Kokstad:1600:10"});
            this.lstLocations.Location = new System.Drawing.Point(12, 21);
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Size = new System.Drawing.Size(150, 173);
            this.lstLocations.TabIndex = 0;
            // 
            // btnStartShift
            // 
            this.btnStartShift.Location = new System.Drawing.Point(12, 200);
            this.btnStartShift.Name = "btnStartShift";
            this.btnStartShift.Size = new System.Drawing.Size(150, 23);
            this.btnStartShift.TabIndex = 1;
            this.btnStartShift.Text = "Start Shift";
            this.btnStartShift.UseVisualStyleBackColor = true;
            this.btnStartShift.Click += new System.EventHandler(this.btnStartShift_Click);
            // 
            // lstShiftPlan
            // 
            this.lstShiftPlan.FormattingEnabled = true;
            this.lstShiftPlan.Location = new System.Drawing.Point(194, 21);
            this.lstShiftPlan.Name = "lstShiftPlan";
            this.lstShiftPlan.Size = new System.Drawing.Size(616, 173);
            this.lstShiftPlan.TabIndex = 2;
            // 
            // btnAddTrip
            // 
            this.btnAddTrip.Enabled = false;
            this.btnAddTrip.Location = new System.Drawing.Point(12, 229);
            this.btnAddTrip.Name = "btnAddTrip";
            this.btnAddTrip.Size = new System.Drawing.Size(150, 23);
            this.btnAddTrip.TabIndex = 3;
            this.btnAddTrip.Text = "Add Trip";
            this.btnAddTrip.UseVisualStyleBackColor = true;
            this.btnAddTrip.Click += new System.EventHandler(this.btnAddTrip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 386);
            this.Controls.Add(this.btnAddTrip);
            this.Controls.Add(this.lstShiftPlan);
            this.Controls.Add(this.btnStartShift);
            this.Controls.Add(this.lstLocations);
            this.Name = "Form1";
            this.Text = "Question 4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLocations;
        private System.Windows.Forms.Button btnStartShift;
        private System.Windows.Forms.ListBox lstShiftPlan;
        private System.Windows.Forms.Button btnAddTrip;
    }
}

