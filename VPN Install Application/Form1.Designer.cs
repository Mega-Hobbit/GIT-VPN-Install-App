namespace VPN_Install_Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Panel();
            this.lblInstall = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Panel();
            this.frmInstallScreen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.btnInstall.SuspendLayout();
            this.btnQuit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VPN_Install_Application.Properties.Resources._2019_03_12_15_22_34;
            this.pictureBox1.Location = new System.Drawing.Point(204, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.AutoSize = true;
            this.HeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadingLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HeadingLabel.Location = new System.Drawing.Point(27, 12);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(132, 20);
            this.HeadingLabel.TabIndex = 1;
            this.HeadingLabel.Text = "MTI VPN Installer";
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(181)))), ((int)(((byte)(224)))));
            this.btnInstall.Controls.Add(this.lblInstall);
            this.btnInstall.Location = new System.Drawing.Point(31, 76);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(113, 61);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.TabStop = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Clicked);
            // 
            // lblInstall
            // 
            this.lblInstall.AutoSize = true;
            this.lblInstall.Enabled = false;
            this.lblInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstall.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInstall.Location = new System.Drawing.Point(29, 20);
            this.lblInstall.Name = "lblInstall";
            this.lblInstall.Size = new System.Drawing.Size(56, 24);
            this.lblInstall.TabIndex = 0;
            this.lblInstall.Text = "Install";
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(181)))), ((int)(((byte)(224)))));
            this.btnQuit.Controls.Add(this.frmInstallScreen);
            this.btnQuit.Location = new System.Drawing.Point(182, 76);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(113, 61);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.TabStop = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Clicked);
            // 
            // frmInstallScreen
            // 
            this.frmInstallScreen.AutoSize = true;
            this.frmInstallScreen.Enabled = false;
            this.frmInstallScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmInstallScreen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.frmInstallScreen.Location = new System.Drawing.Point(34, 20);
            this.frmInstallScreen.Name = "frmInstallScreen";
            this.frmInstallScreen.Size = new System.Drawing.Size(44, 24);
            this.frmInstallScreen.TabIndex = 0;
            this.frmInstallScreen.Text = "Quit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(326, 149);
            this.ControlBox = false;
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTI VPN Installer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.btnInstall.ResumeLayout(false);
            this.btnInstall.PerformLayout();
            this.btnQuit.ResumeLayout(false);
            this.btnQuit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.Panel btnInstall;
        private System.Windows.Forms.Label lblInstall;
        private System.Windows.Forms.Panel btnQuit;
        private System.Windows.Forms.Label frmInstallScreen;
    }
}

