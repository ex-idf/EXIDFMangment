namespace ExIDFManagment
{
    partial class ExceptionForm
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
            this.btnSaveToLog = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblException = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtExceptionDetails = new System.Windows.Forms.TextBox();
            this.txtInnerException = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveToLog
            // 
            this.btnSaveToLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveToLog.Enabled = false;
            this.btnSaveToLog.Location = new System.Drawing.Point(0, 0);
            this.btnSaveToLog.Name = "btnSaveToLog";
            this.btnSaveToLog.Size = new System.Drawing.Size(93, 45);
            this.btnSaveToLog.TabIndex = 0;
            this.btnSaveToLog.Text = "Save To Log";
            this.btnSaveToLog.UseVisualStyleBackColor = true;
            this.btnSaveToLog.Click += new System.EventHandler(this.btnSaveToLog_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSaveToLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 45);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClose.Location = new System.Drawing.Point(93, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblException
            // 
            this.lblException.AutoSize = true;
            this.lblException.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblException.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblException.Location = new System.Drawing.Point(10, 10);
            this.lblException.Margin = new System.Windows.Forms.Padding(3);
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size(154, 34);
            this.lblException.TabIndex = 3;
            this.lblException.Text = "Exception";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDate.Location = new System.Drawing.Point(22, 47);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 18);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblException);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(441, 85);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::ExIDFManagment.Properties.Resources.Cz_Error_small1;
            this.pictureBox1.Location = new System.Drawing.Point(363, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 65);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtExceptionDetails
            // 
            this.txtExceptionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExceptionDetails.Location = new System.Drawing.Point(0, 0);
            this.txtExceptionDetails.Multiline = true;
            this.txtExceptionDetails.Name = "txtExceptionDetails";
            this.txtExceptionDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExceptionDetails.Size = new System.Drawing.Size(441, 119);
            this.txtExceptionDetails.TabIndex = 6;
            // 
            // txtInnerException
            // 
            this.txtInnerException.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInnerException.Location = new System.Drawing.Point(0, 119);
            this.txtInnerException.Multiline = true;
            this.txtInnerException.Name = "txtInnerException";
            this.txtInnerException.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInnerException.Size = new System.Drawing.Size(441, 132);
            this.txtInnerException.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtExceptionDetails);
            this.panel3.Controls.Add(this.txtInnerException);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 251);
            this.panel3.TabIndex = 7;
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(441, 381);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ExceptionForm";
            this.Text = "Exception";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveToLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblException;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtExceptionDetails;
        private System.Windows.Forms.TextBox txtInnerException;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}