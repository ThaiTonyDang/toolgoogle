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
            cmbShareDriveOption = new ComboBox();
            txtSearchDrive = new TextBox();
            btnLoadDrives = new Button();
            treeDriveView = new TreeView();
            lblSelectLocation = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFileCount).BeginInit();
            groupBox2.SuspendLayout();
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
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(492, 623);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create Section";
            // 
            // txtContent
            // 
            txtContent.Location = new Point(21, 280);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(440, 217);
            txtContent.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 237);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 12;
            label4.Text = "File Content ";
            // 
            // cbFileType
            // 
            cbFileType.FormattingEnabled = true;
            cbFileType.Location = new Point(20, 186);
            cbFileType.Name = "cbFileType";
            cbFileType.Size = new Size(181, 33);
            cbFileType.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 149);
            label3.Name = "label3";
            label3.Size = new Size(80, 25);
            label3.TabIndex = 10;
            label3.Text = "File Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 149);
            label2.Name = "label2";
            label2.Size = new Size(215, 25);
            label2.TabIndex = 9;
            label2.Text = "Number of Files to Create";
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 105);
            txtName.Name = "txtName";
            txtName.Size = new Size(441, 31);
            txtName.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 77);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 7;
            label1.Text = "File Name";
            // 
            // lblCreateType
            // 
            lblCreateType.AutoSize = true;
            lblCreateType.Location = new Point(20, 30);
            lblCreateType.Name = "lblCreateType";
            lblCreateType.Size = new Size(181, 25);
            lblCreateType.TabIndex = 0;
            lblCreateType.Text = "Select Type to Create:";
            // 
            // cmbCreateType
            // 
            cmbCreateType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCreateType.Items.AddRange(new object[] { "File", "Folder", "Share Drive" });
            cmbCreateType.Location = new Point(207, 27);
            cmbCreateType.Name = "cmbCreateType";
            cmbCreateType.Size = new Size(121, 33);
            cmbCreateType.TabIndex = 1;
            cmbCreateType.SelectedIndexChanged += cmbCreateType_SelectedIndexChanged;
            // 
            // numFileCount
            // 
            numFileCount.Location = new Point(227, 187);
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
            btnCreate.Location = new Point(20, 542);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(128, 51);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.ForeColor = Color.Red;
            lblNote.Location = new Point(20, 500);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(159, 25);
            lblNote.TabIndex = 6;
            lblNote.Text = "Location Required!";
            lblNote.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblSelectLocation);
            groupBox2.Controls.Add(cmbShareDriveOption);
            groupBox2.Controls.Add(txtSearchDrive);
            groupBox2.Controls.Add(btnLoadDrives);
            groupBox2.Controls.Add(treeDriveView);
            groupBox2.Location = new Point(541, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(717, 623);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Location Create Settings";
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
            btnLoadDrives.Size = new Size(86, 33);
            btnLoadDrives.TabIndex = 2;
            btnLoadDrives.Text = "Load Drives";
            btnLoadDrives.Click += btnLoadDrives_Click;
            // 
            // treeDriveView
            // 
            treeDriveView.Location = new Point(20, 220);
            treeDriveView.Name = "treeDriveView";
            treeDriveView.Size = new Size(667, 379);
            treeDriveView.TabIndex = 3;
            treeDriveView.AfterSelect += treeDriveView_AfterSelect;
            // 
            // lblSelectLocation
            // 
            lblSelectLocation.AutoSize = true;
            lblSelectLocation.Location = new Point(272, 299);
            lblSelectLocation.Name = "lblSelectLocation";
            lblSelectLocation.Size = new Size(173, 25);
            lblSelectLocation.TabIndex = 4;
            lblSelectLocation.Text = "Select Location First!";
            lblSelectLocation.Visible = false;
            // 
            // GoogleDriveTool
            // 
            ClientSize = new Size(1296, 697);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "GoogleDriveTool";
            Text = "Google Drive Tool";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFileCount).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbFileType;
        private TextBox txtContent;
        private Label lblSelectLocation;
    }
}
