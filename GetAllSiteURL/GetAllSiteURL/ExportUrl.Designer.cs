namespace GetAllSiteURL
{
    partial class ExportUrl
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
            this.lblWebUrl = new System.Windows.Forms.Label();
            this.UrlStr = new System.Windows.Forms.TextBox();
            this.linkLog = new System.Windows.Forms.LinkLabel();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWebUrl
            // 
            this.lblWebUrl.AutoSize = true;
            this.lblWebUrl.Location = new System.Drawing.Point(26, 13);
            this.lblWebUrl.Name = "lblWebUrl";
            this.lblWebUrl.Size = new System.Drawing.Size(68, 13);
            this.lblWebUrl.TabIndex = 0;
            this.lblWebUrl.Text = "WebApp Url:";
            // 
            // UrlStr
            // 
            this.UrlStr.Location = new System.Drawing.Point(113, 13);
            this.UrlStr.Name = "UrlStr";
            this.UrlStr.Size = new System.Drawing.Size(341, 20);
            this.UrlStr.TabIndex = 1;
            // 
            // linkLog
            // 
            this.linkLog.AutoSize = true;
            this.linkLog.Location = new System.Drawing.Point(133, 40);
            this.linkLog.Name = "linkLog";
            this.linkLog.Size = new System.Drawing.Size(25, 13);
            this.linkLog.TabIndex = 2;
            this.linkLog.TabStop = true;
            this.linkLog.Text = "Log";
            this.linkLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLog_LinkClicked);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(379, 35);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ExportUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 87);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.linkLog);
            this.Controls.Add(this.UrlStr);
            this.Controls.Add(this.lblWebUrl);
            this.Name = "ExportUrl";
            this.Text = "ExportUrl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWebUrl;
        private System.Windows.Forms.TextBox UrlStr;
        private System.Windows.Forms.LinkLabel linkLog;
        private System.Windows.Forms.Button btnExport;
    }
}

