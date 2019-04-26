namespace VPN_Install_Application
{
    partial class MainActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainActivity));
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.Install = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkANZ = new System.Windows.Forms.CheckBox();
            this.chkNA = new System.Windows.Forms.CheckBox();
            this.chkUK = new System.Windows.Forms.CheckBox();
            this.chkEU = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // Install
            // 
            this.Install.Image = global::VPN_Install_Application.Properties.Resources.button;
            this.Install.Location = new System.Drawing.Point(12, 195);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(137, 45);
            this.Install.TabIndex = 2;
            this.Install.Text = "Install";
            this.Install.UseVisualStyleBackColor = true;
            this.Install.Click += new System.EventHandler(this.Install_Click);
            // 
            // Exit
            // 
            this.Exit.Image = global::VPN_Install_Application.Properties.Resources.button;
            this.Exit.Location = new System.Drawing.Point(177, 195);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(137, 45);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(114, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select areas to install";
            // 
            // chkANZ
            // 
            this.chkANZ.AutoSize = true;
            this.chkANZ.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkANZ.Location = new System.Drawing.Point(69, 88);
            this.chkANZ.Name = "chkANZ";
            this.chkANZ.Size = new System.Drawing.Size(48, 17);
            this.chkANZ.TabIndex = 5;
            this.chkANZ.Text = "ANZ";
            this.chkANZ.UseVisualStyleBackColor = true;
            this.chkANZ.CheckedChanged += new System.EventHandler(this.chkANZ_CheckedChanged);
            // 
            // chkNA
            // 
            this.chkNA.AutoSize = true;
            this.chkNA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkNA.Location = new System.Drawing.Point(69, 111);
            this.chkNA.Name = "chkNA";
            this.chkNA.Size = new System.Drawing.Size(41, 17);
            this.chkNA.TabIndex = 5;
            this.chkNA.Text = "NA";
            this.chkNA.UseVisualStyleBackColor = true;
            this.chkNA.CheckedChanged += new System.EventHandler(this.chkNA_CheckedChanged);
            // 
            // chkUK
            // 
            this.chkUK.AutoSize = true;
            this.chkUK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkUK.Location = new System.Drawing.Point(69, 134);
            this.chkUK.Name = "chkUK";
            this.chkUK.Size = new System.Drawing.Size(41, 17);
            this.chkUK.TabIndex = 5;
            this.chkUK.Text = "UK";
            this.chkUK.UseVisualStyleBackColor = true;
            this.chkUK.CheckedChanged += new System.EventHandler(this.chkUK_CheckedChanged);
            // 
            // chkEU
            // 
            this.chkEU.AutoSize = true;
            this.chkEU.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkEU.Location = new System.Drawing.Point(69, 158);
            this.chkEU.Name = "chkEU";
            this.chkEU.Size = new System.Drawing.Size(41, 17);
            this.chkEU.TabIndex = 6;
            this.chkEU.Text = "EU";
            this.chkEU.UseVisualStyleBackColor = true;
            this.chkEU.CheckedChanged += new System.EventHandler(this.chkEU_CheckedChanged);
            // 
            // MainActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(326, 252);
            this.ControlBox = false;
            this.Controls.Add(this.chkEU);
            this.Controls.Add(this.chkUK);
            this.Controls.Add(this.chkNA);
            this.Controls.Add(this.chkANZ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Install);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTI VPN Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainActivity_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkANZ;
        private System.Windows.Forms.CheckBox chkNA;
        private System.Windows.Forms.CheckBox chkUK;
        private System.Windows.Forms.CheckBox chkEU;
    }
}

