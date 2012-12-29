namespace ExIDFManagment
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDropboxFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseDropboxFolder = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblException = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dropbox Folder";
            // 
            // txtDropboxFolder
            // 
            this.txtDropboxFolder.Location = new System.Drawing.Point(88, 3);
            this.txtDropboxFolder.Name = "txtDropboxFolder";
            this.txtDropboxFolder.Size = new System.Drawing.Size(224, 20);
            this.txtDropboxFolder.TabIndex = 1;
            // 
            // btnBrowseDropboxFolder
            // 
            this.btnBrowseDropboxFolder.Location = new System.Drawing.Point(321, 1);
            this.btnBrowseDropboxFolder.Name = "btnBrowseDropboxFolder";
            this.btnBrowseDropboxFolder.Size = new System.Drawing.Size(29, 23);
            this.btnBrowseDropboxFolder.TabIndex = 2;
            this.btnBrowseDropboxFolder.Text = "...";
            this.btnBrowseDropboxFolder.UseVisualStyleBackColor = true;
            this.btnBrowseDropboxFolder.Click += new System.EventHandler(this.btnBrowseDropboxFolder_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveSettings.Location = new System.Drawing.Point(75, 0);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 47);
            this.btnSaveSettings.TabIndex = 3;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSettingsCancel.Location = new System.Drawing.Point(0, 0);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 47);
            this.btnSettingsCancel.TabIndex = 3;
            this.btnSettingsCancel.Text = "Cancel";
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(378, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 174);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveSettings);
            this.panel1.Controls.Add(this.btnSettingsCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 47);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblException);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 70);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnBrowseDropboxFolder);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtDropboxFolder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 57);
            this.panel3.TabIndex = 9;
            // 
            // lblException
            // 
            this.lblException.AutoSize = true;
            this.lblException.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblException.Location = new System.Drawing.Point(4, 5);
            this.lblException.Margin = new System.Windows.Forms.Padding(3);
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size(130, 34);
            this.lblException.TabIndex = 4;
            this.lblException.Text = "Settings";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(441, 174);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmSettings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDropboxFolder;
        private System.Windows.Forms.Button btnBrowseDropboxFolder;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnSettingsCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblException;
    }
}