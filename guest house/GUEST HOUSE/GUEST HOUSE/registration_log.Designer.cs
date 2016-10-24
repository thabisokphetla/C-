namespace GUEST_HOUSE
{
    partial class registration_log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registration_log));
            this.label1 = new System.Windows.Forms.Label();
            this.grpLogIn = new System.Windows.Forms.GroupBox();
            this.lblPasValidate = new System.Windows.Forms.Label();
            this.lbluserval = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblClickReg = new System.Windows.Forms.Label();
            this.chkLogIn = new System.Windows.Forms.CheckBox();
            this.chkRegister = new System.Windows.Forms.CheckBox();
            this.grpRegister = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpLogIn.SuspendLayout();
            this.grpRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username(ID)";
            // 
            // grpLogIn
            // 
            this.grpLogIn.Controls.Add(this.lblPasValidate);
            this.grpLogIn.Controls.Add(this.lbluserval);
            this.grpLogIn.Controls.Add(this.btnLogIn);
            this.grpLogIn.Controls.Add(this.txtPassword);
            this.grpLogIn.Controls.Add(this.txtUserName);
            this.grpLogIn.Controls.Add(this.label3);
            this.grpLogIn.Controls.Add(this.label2);
            this.grpLogIn.Controls.Add(this.label1);
            this.grpLogIn.Enabled = false;
            this.grpLogIn.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLogIn.Location = new System.Drawing.Point(16, 69);
            this.grpLogIn.Name = "grpLogIn";
            this.grpLogIn.Size = new System.Drawing.Size(308, 163);
            this.grpLogIn.TabIndex = 1;
            this.grpLogIn.TabStop = false;
            this.grpLogIn.Text = "Log In";
            this.grpLogIn.Enter += new System.EventHandler(this.grpLogIn_Enter);
            // 
            // lblPasValidate
            // 
            this.lblPasValidate.AutoSize = true;
            this.lblPasValidate.Location = new System.Drawing.Point(175, 89);
            this.lblPasValidate.Name = "lblPasValidate";
            this.lblPasValidate.Size = new System.Drawing.Size(0, 15);
            this.lblPasValidate.TabIndex = 7;
            // 
            // lbluserval
            // 
            this.lbluserval.AutoSize = true;
            this.lbluserval.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserval.Location = new System.Drawing.Point(198, 51);
            this.lbluserval.Name = "lbluserval";
            this.lbluserval.Size = new System.Drawing.Size(0, 14);
            this.lbluserval.TabIndex = 6;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(9, 131);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(271, 23);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "Login";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 83);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(79, 21);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(90, 45);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(102, 20);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Registered Guest Only";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(361, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "THANDI\'S GUEST HOUSE BOOKING";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(6, 89);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(203, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblClickReg
            // 
            this.lblClickReg.AutoSize = true;
            this.lblClickReg.Location = new System.Drawing.Point(46, 60);
            this.lblClickReg.Name = "lblClickReg";
            this.lblClickReg.Size = new System.Drawing.Size(128, 15);
            this.lblClickReg.TabIndex = 7;
            this.lblClickReg.Text = "Click below to Register";
            // 
            // chkLogIn
            // 
            this.chkLogIn.AutoSize = true;
            this.chkLogIn.Location = new System.Drawing.Point(141, 44);
            this.chkLogIn.Name = "chkLogIn";
            this.chkLogIn.Size = new System.Drawing.Size(63, 19);
            this.chkLogIn.TabIndex = 8;
            this.chkLogIn.Text = "Log In";
            this.chkLogIn.UseVisualStyleBackColor = true;
            this.chkLogIn.CheckedChanged += new System.EventHandler(this.chkLogIn_CheckedChanged);
            // 
            // chkRegister
            // 
            this.chkRegister.AutoSize = true;
            this.chkRegister.Location = new System.Drawing.Point(403, 44);
            this.chkRegister.Name = "chkRegister";
            this.chkRegister.Size = new System.Drawing.Size(69, 19);
            this.chkRegister.TabIndex = 9;
            this.chkRegister.Text = "Register";
            this.chkRegister.UseVisualStyleBackColor = true;
            this.chkRegister.CheckedChanged += new System.EventHandler(this.chkRegister_CheckedChanged);
            // 
            // grpRegister
            // 
            this.grpRegister.Controls.Add(this.lblClickReg);
            this.grpRegister.Controls.Add(this.btnRegister);
            this.grpRegister.Enabled = false;
            this.grpRegister.Location = new System.Drawing.Point(330, 69);
            this.grpRegister.Name = "grpRegister";
            this.grpRegister.Size = new System.Drawing.Size(227, 125);
            this.grpRegister.TabIndex = 10;
            this.grpRegister.TabStop = false;
            this.grpRegister.Text = "Register";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(403, 200);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(154, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::GUEST_HOUSE.Properties.Resources.THINDI;
            this.pictureBox1.Location = new System.Drawing.Point(5, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // registration_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(569, 237);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpRegister);
            this.Controls.Add(this.chkRegister);
            this.Controls.Add(this.chkLogIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpLogIn);
            this.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "registration_log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.registration_log_Load);
            this.grpLogIn.ResumeLayout(false);
            this.grpLogIn.PerformLayout();
            this.grpRegister.ResumeLayout(false);
            this.grpRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpLogIn;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblClickReg;
        private System.Windows.Forms.CheckBox chkLogIn;
        private System.Windows.Forms.CheckBox chkRegister;
        private System.Windows.Forms.GroupBox grpRegister;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPasValidate;
        private System.Windows.Forms.Label lbluserval;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

