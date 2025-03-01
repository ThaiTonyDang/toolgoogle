namespace ForQAGoogleTool
{
    partial class GoogleServiceCredentials
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCredentialPath;
        private System.Windows.Forms.TextBox txtCredentialPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblUserEmail;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.Button btnInitialize;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCredentialPath = new System.Windows.Forms.Label();
            this.txtCredentialPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblUserEmail = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCredentialPath
            // 
            this.lblCredentialPath.AutoSize = true;
            this.lblCredentialPath.Location = new System.Drawing.Point(20, 20);
            this.lblCredentialPath.Name = "lblCredentialPath";
            this.lblCredentialPath.Size = new System.Drawing.Size(140, 25);
            this.lblCredentialPath.TabIndex = 0;
            this.lblCredentialPath.Text = "Credential File Path:";
            // 
            // txtCredentialPath
            // 
            this.txtCredentialPath.Location = new System.Drawing.Point(20, 50);
            this.txtCredentialPath.Name = "txtCredentialPath";
            this.txtCredentialPath.Size = new System.Drawing.Size(400, 31);
            this.txtCredentialPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(430, 50);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 34);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblUserEmail
            // 
            this.lblUserEmail.AutoSize = true;
            this.lblUserEmail.Location = new System.Drawing.Point(20, 100);
            this.lblUserEmail.Name = "lblUserEmail";
            this.lblUserEmail.Size = new System.Drawing.Size(103, 25);
            this.lblUserEmail.TabIndex = 3;
            this.lblUserEmail.Text = "User Email:";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Location = new System.Drawing.Point(20, 130);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(400, 31);
            this.txtUserEmail.TabIndex = 4;
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(20, 180);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(510, 45);
            this.btnInitialize.TabIndex = 5;
            this.btnInitialize.Text = "Initialize Google Drive Service";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // GoogleServiceCredentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 250);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.txtUserEmail);
            this.Controls.Add(this.lblUserEmail);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtCredentialPath);
            this.Controls.Add(this.lblCredentialPath);
            this.Name = "GoogleServiceCredentials";
            this.Text = "Google Drive Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
