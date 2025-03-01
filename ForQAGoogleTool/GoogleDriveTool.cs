using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Windows.Forms;

namespace ForQAGoogleTool
{
    public partial class GoogleDriveTool : Form
    {
        private string selectedDriveOrFolderID;
        private DriveService _driveService;
        public GoogleDriveTool(DriveService driveService)
        {
            InitializeComponent();
            InitializeForm();
            _driveService = driveService;
            treeDriveView.AfterExpand += treeDriveView_AfterExpand;
        }

        private void InitializeForm()
        {
            // Ẩn tất cả các controls khi form load lên
            txtName.Visible = false;
            label1.Visible = false;
            cbFileType.Visible = false;
            label3.Visible = false;
            numFileCount.Visible = false;
            label2.Visible = false;
            txtContent.Visible = false;
            label4.Visible = false;
            lblNote.Visible = false;
            btnCreate.Enabled = false;
            cbFileType.Items.Clear();
            cbFileType.Items.AddRange(new object[] { "txt", "docx", "doc", "pdf", "xls", "xlsx", "csv", "png", "jpg", "jpeg", "gif", "zip", "rar", "svg", "mp4", "mp3" });
            cmbShareDriveOption.Items.AddRange(new object[] { "Load All", "Search by Name" });

            cmbShareDriveOption.SelectedIndex = 0;
        }

        private void cmbCreateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn loại cần tạo (File, Folder, Share Drive)
            InitializeForm(); // Reset trạng thái

            string selectedType = cmbCreateType.SelectedItem.ToString();

            if (selectedType == "File")
            {
                txtName.Visible = true;
                label1.Text = "File Name";
                label1.Visible = true;
                cbFileType.Visible = true;
                label3.Visible = true;
                numFileCount.Visible = true;
                label2.Visible = true;
                txtContent.Visible = true;
                label4.Visible = true;
                btnCreate.Enabled = false;
            }
            else if (selectedType == "Folder")
            {
                txtName.Visible = true;
                label1.Text = "Folder Name";
                label1.Visible = true;
                btnCreate.Enabled = false;
            }
            else if (selectedType == "Share Drive")
            {
                txtName.Visible = true;
                label1.Text = "Shared Drive Name";
                label1.Visible = true;
                btnCreate.Enabled = true;
            }
        }

        private void cbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn loại file, kiểm tra có cần hiển thị nội dung file không
            string selectedFileType = cbFileType.SelectedItem?.ToString();
            txtContent.Visible = selectedFileType == "txt" || selectedFileType == "docx" || selectedFileType == "doc";
            label4.Visible = txtContent.Visible;
        }

        private void cmbShareDriveOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn phương thức tải Share Drive
            txtSearchDrive.Visible = cmbShareDriveOption.SelectedItem.ToString() == "Search by Name";
        }

        private async void btnLoadDrives_Click(object sender, EventArgs e)
        {
            if (_driveService == null)
            {
                MessageBox.Show("Google Drive service is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            treeDriveView.Nodes.Clear();

            if (cmbShareDriveOption.SelectedItem == null)
            {
                MessageBox.Show("Please select an option first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (cmbShareDriveOption.SelectedItem.ToString() == "Load All")
                {
                    await LoadAllSharedDrives();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtSearchDrive.Text))
                    {
                        MessageBox.Show("The Search text input share drive by name cannot be left blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    await LoadSharedDrivesByName(txtSearchDrive.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load drives: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task LoadAllSharedDrives()
        {
            var request = _driveService.Drives.List();
            request.Fields = "nextPageToken, drives(id, name)";
            request.PageSize = 100;
            var response = await request.ExecuteAsync();

            if (response.Drives != null && response.Drives.Count > 0)
            {
                foreach (var drive in response.Drives)
                {
                    TreeNode driveNode = new TreeNode($"{drive.Name} ({drive.Id})");
                    driveNode.Tag = drive.Id;
                    driveNode.Nodes.Add("Loading...");
                    treeDriveView.Nodes.Add(driveNode);
                }
            }
        }

        private async void treeDriveView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "Loading...")
            {
                e.Node.Nodes.Clear();

                string parentId = e.Node.Tag?.ToString();
                if (string.IsNullOrEmpty(parentId))
                {
                    MessageBox.Show("Parent ID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool isSharedDrive = e.Node.Parent == null || e.Node.Level == 0;
                await LoadFolders(parentId, e.Node, isSharedDrive);
            }
        }

        private async Task LoadFolders(string parentId, TreeNode parentNode, bool isSharedDrive)
        {
            try
            {
                var request = _driveService.Files.List();
                request.Q = $"'{parentId}' in parents and mimeType='application/vnd.google-apps.folder' and trashed=false";
                if (isSharedDrive)
                {
                 
                    request.DriveId = parentId;
                    request.Corpora = "drive";
                }
                request.Fields = "nextPageToken, files(id, name)";
                request.SupportsAllDrives = true;
                request.IncludeItemsFromAllDrives = true;

                var response = await request.ExecuteAsync();

                if (response.Files != null && response.Files.Count > 0)
                {
                    treeDriveView.Invoke((MethodInvoker)(() =>
                    {
                        foreach (var folder in response.Files)
                        {
                            TreeNode folderNode = new TreeNode($"{folder.Name} ({folder.Id})")
                            {
                                Tag = folder.Id
                            };
                            folderNode.Nodes.Add("Loading..."); // Thêm node giả
                            parentNode.Nodes.Add(folderNode);
                        }
                    }));
                }
                else
                {
                    treeDriveView.Invoke((MethodInvoker)(() =>
                    {
                        parentNode.Nodes.Clear();
                        parentNode.Nodes.Add("No folders found.");
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load folders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSharedDrivesByName(string searchKey)
        {
            treeDriveView.Nodes.Clear();
            treeDriveView.Enabled = true;
            try
            {
                var request = _driveService.Drives.List();
                request.Q = $"name contains '{searchKey}'";
                var response = await request.ExecuteAsync();

                if (response.Drives != null && response.Drives.Count > 0)
                {
                    foreach (var drive in response.Drives)
                    {
                        TreeNode driveNode = new TreeNode($"{drive.Name} ({drive.Id})");
                        driveNode.Tag = drive.Id;
                        driveNode.Nodes.Add("Loading..."); 
                        treeDriveView.Nodes.Add(driveNode);
                    }
                }

                if (treeDriveView.Nodes.Count == 0)
                {
                    MessageBox.Show("No matching Share Drive found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                treeDriveView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to search for drives: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void treeDriveView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedDriveOrFolderID = e.Node.Text.Split('(')[1].Replace(")", "");
            btnCreate.Enabled = true;
        }
    }
}
