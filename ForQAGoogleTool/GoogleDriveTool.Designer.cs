namespace ForQAGoogleTool
{
    partial class GoogleDriveTool
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCreateType;
        private System.Windows.Forms.Label lblCreateType;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBrowseLocation;
        private System.Windows.Forms.NumericUpDown numFileCount;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.ComboBox cmbShareDriveOption;
        private System.Windows.Forms.TextBox txtSearchDrive;
        private System.Windows.Forms.Button btnLoadDrives;
        private System.Windows.Forms.TreeView treeDriveView;

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
            groupBox1 = new GroupBox();
            txtContent = new TextBox();
            label4 = new Label();
            cbFileType = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            lblCreateType = new Label();
            cmbCreateType = new ComboBox();
            numFileCount = new NumericUpDown();
            btnCreate = new Button();
            lblNote = new Label();
            groupBox2 = new GroupBox();
            btnSaveLocation = new Button();
            label5 = new Label();
            cmbShareDriveOption = new ComboBox();
            txtSearchDrive = new TextBox();
            btnLoadDrives = new Button();
            treeDriveView = new TreeView();
            lblCredentialPath = new Label();
            groupBox3 = new GroupBox();
            btnInitialize = new Button();
            lblUserEmail = new Label();
            txtUserEmail = new TextBox();
            btnBrowse = new Button();
            txtCredentialPath = new TextBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFileCount).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtContent);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbFileType);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblCreateType);
            groupBox1.Controls.Add(cmbCreateType);
            groupBox1.Controls.Add(numFileCount);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(lblNote);
            groupBox1.Location = new Point(25, 223);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(492, 674);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create Section";
            // 
            // txtContent
            // 
            txtContent.Location = new Point(22, 317);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(440, 243);
            txtContent.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 268);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 12;
            label4.Text = "File Content ";
            // 
            // cbFileType
            // 
            cbFileType.FormattingEnabled = true;
            cbFileType.Location = new Point(22, 214);
            cbFileType.Name = "cbFileType";
            cbFileType.Size = new Size(181, 33);
            cbFileType.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 172);
            label3.Name = "label3";
            label3.Size = new Size(80, 25);
            label3.TabIndex = 10;
            label3.Text = "File Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 172);
            label2.Name = "label2";
            label2.Size = new Size(215, 25);
            label2.TabIndex = 9;
            label2.Text = "Number of Files to Create";
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 138);
            txtName.Name = "txtName";
            txtName.Size = new Size(441, 31);
            txtName.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 96);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 7;
            label1.Text = "File Name";
            // 
            // lblCreateType
            // 
            lblCreateType.AutoSize = true;
            lblCreateType.Location = new Point(20, 49);
            lblCreateType.Name = "lblCreateType";
            lblCreateType.Size = new Size(181, 25);
            lblCreateType.TabIndex = 0;
            lblCreateType.Text = "Select Type to Create:";
            // 
            // cmbCreateType
            // 
            cmbCreateType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCreateType.Items.AddRange(new object[] { "File", "Folder", "Shared Drive" });
            cmbCreateType.Location = new Point(208, 46);
            cmbCreateType.Name = "cmbCreateType";
            cmbCreateType.Size = new Size(254, 33);
            cmbCreateType.TabIndex = 1;
            cmbCreateType.SelectedIndexChanged += cmbCreateType_SelectedIndexChanged;
            // 
            // numFileCount
            // 
            numFileCount.Location = new Point(227, 215);
            numFileCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFileCount.Name = "numFileCount";
            numFileCount.Size = new Size(234, 31);
            numFileCount.TabIndex = 2;
            numFileCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numFileCount.Visible = false;
            // 
            // btnCreate
            // 
            btnCreate.Enabled = false;
            btnCreate.Location = new Point(21, 617);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(128, 51);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.Click += btnCreate_Click;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNote.ForeColor = Color.Red;
            lblNote.Location = new Point(20, 563);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(248, 38);
            lblNote.TabIndex = 6;
            lblNote.Text = "Location Required!";
            lblNote.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnSaveLocation);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cmbShareDriveOption);
            groupBox2.Controls.Add(txtSearchDrive);
            groupBox2.Controls.Add(btnLoadDrives);
            groupBox2.Controls.Add(treeDriveView);
            groupBox2.Location = new Point(542, 223);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(561, 674);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Location Create Settings";
            // 
            // btnSaveLocation
            // 
            btnSaveLocation.Location = new Point(22, 620);
            btnSaveLocation.Name = "btnSaveLocation";
            btnSaveLocation.Size = new Size(112, 34);
            btnSaveLocation.TabIndex = 5;
            btnSaveLocation.Text = "Save";
            btnSaveLocation.UseVisualStyleBackColor = true;
            btnSaveLocation.Click += btnSaveLocation_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 35);
            label5.Name = "label5";
            label5.Size = new Size(208, 25);
            label5.TabIndex = 4;
            label5.Text = "Select Location To Create";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbShareDriveOption
            // 
            cmbShareDriveOption.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShareDriveOption.Location = new Point(20, 74);
            cmbShareDriveOption.Name = "cmbShareDriveOption";
            cmbShareDriveOption.Size = new Size(507, 33);
            cmbShareDriveOption.TabIndex = 0;
            cmbShareDriveOption.SelectedIndexChanged += cmbShareDriveOption_SelectedIndexChanged;
            // 
            // txtSearchDrive
            // 
            txtSearchDrive.Location = new Point(20, 127);
            txtSearchDrive.Name = "txtSearchDrive";
            txtSearchDrive.PlaceholderText = "Enter keyword...";
            txtSearchDrive.Size = new Size(507, 31);
            txtSearchDrive.TabIndex = 1;
            txtSearchDrive.Visible = false;
            // 
            // btnLoadDrives
            // 
            btnLoadDrives.Location = new Point(20, 172);
            btnLoadDrives.Name = "btnLoadDrives";
            btnLoadDrives.Size = new Size(100, 47);
            btnLoadDrives.TabIndex = 2;
            btnLoadDrives.Text = "Load Drives";
            btnLoadDrives.Click += btnLoadDrives_Click;
            // 
            // treeDriveView
            // 
            treeDriveView.Location = new Point(20, 237);
            treeDriveView.Name = "treeDriveView";
            treeDriveView.Size = new Size(513, 370);
            treeDriveView.TabIndex = 3;
            treeDriveView.AfterSelect += treeDriveView_AfterSelect;
            // 
            // lblCredentialPath
            // 
            lblCredentialPath.AutoSize = true;
            lblCredentialPath.Location = new Point(6, 48);
            lblCredentialPath.Name = "lblCredentialPath";
            lblCredentialPath.Size = new Size(165, 25);
            lblCredentialPath.TabIndex = 2;
            lblCredentialPath.Text = "Credential File Path:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnInitialize);
            groupBox3.Controls.Add(lblUserEmail);
            groupBox3.Controls.Add(txtUserEmail);
            groupBox3.Controls.Add(btnBrowse);
            groupBox3.Controls.Add(txtCredentialPath);
            groupBox3.Controls.Add(lblCredentialPath);
            groupBox3.Location = new Point(25, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1078, 205);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Google Credentials";
            // 
            // btnInitialize
            // 
            btnInitialize.Location = new Point(6, 138);
            btnInitialize.Name = "btnInitialize";
            btnInitialize.Size = new Size(307, 45);
            btnInitialize.TabIndex = 7;
            btnInitialize.Text = "Initialize Google Drive Service";
            btnInitialize.UseVisualStyleBackColor = true;
            btnInitialize.Click += btnInitialize_Click;
            // 
            // lblUserEmail
            // 
            lblUserEmail.AutoSize = true;
            lblUserEmail.Location = new Point(553, 48);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(98, 25);
            lblUserEmail.TabIndex = 6;
            lblUserEmail.Text = "User Email:";
            // 
            // txtUserEmail
            // 
            txtUserEmail.Location = new Point(554, 83);
            txtUserEmail.Name = "txtUserEmail";
            txtUserEmail.Size = new Size(400, 31);
            txtUserEmail.TabIndex = 5;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(6, 81);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(100, 34);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtCredentialPath
            // 
            txtCredentialPath.Location = new Point(116, 83);
            txtCredentialPath.Name = "txtCredentialPath";
            txtCredentialPath.Size = new Size(400, 31);
            txtCredentialPath.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(360, 626);
            label6.Name = "label6";
            label6.Size = new Size(173, 30);
            label6.TabIndex = 8;
            label6.Text = "Written by Noah";
            // 
            // GoogleDriveTool
            // 
            ClientSize = new Size(1108, 919);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "GoogleDriveTool";
            Text = "Google Drive Tool";
            FormClosed += GoogleDriveTool_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFileCount).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbFileType;
        private TextBox txtContent;
        private Label label5;
        private Button btnSaveLocation;
        private Label lblCredentialPath;
        private GroupBox groupBox3;
        private TextBox txtCredentialPath;
        private Button btnBrowse;
        private TextBox txtUserEmail;
        private Label lblUserEmail;
        private Button btnInitialize;
        private Label label6;
    }
}
