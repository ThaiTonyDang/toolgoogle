using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using System;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using File = System.IO.File;

namespace ForQAGoogleTool
{
    public partial class GoogleDriveTool : Form
    {
        private string selectedDriveOrFolderID;
        private SelectedLocation _selectedLocation;
        private SharedDriveObject _sharedDriveObject;
        private readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "txt", "text/plain" },
            { "doc", "application/msword" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "pdf", "application/pdf" },
            { "xls", "application/vnd.ms-excel" },
            { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { "csv", "text/csv" },
            { "png", "image/png" },
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "gif", "image/gif" },
            { "zip", "application/zip" },
            { "rar", "application/x-rar-compressed" },
            { "svg", "image/svg+xml" },
            { "mp4", "video/mp4" },
            { "mp3", "audio/mpeg" }
        };

        public DriveService DriveService { get; private set; }
        public GoogleDriveTool()
        {
            InitializeComponent();
            InitializeForm();
            _selectedLocation = new SelectedLocation();
            _sharedDriveObject = new SharedDriveObject();
            treeDriveView.AfterExpand += treeDriveView_AfterExpand;
            txtCredentialPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "securitysaproject-f09d658d8984.json");
            txtUserEmail.Text = "CGForQA@avepointgsuite.com";
            InitializeGoogleCredentials(txtCredentialPath.Text, txtUserEmail.Text);
        }

        private void InitializeForm()
        {
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
            cbFileType.SelectedIndex = 0;

            cmbShareDriveOption.Items.Clear();
            cmbShareDriveOption.Items.AddRange(new object[] { "Load All", "Search by Name", "Use Saved Location"});
            cmbShareDriveOption.SelectedIndex = 0;
        }

        private void cmbCreateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeForm();

            string selectedType = cmbCreateType.SelectedItem.ToString();

            if (selectedType == "File")
            {
                lblNote.Visible = true;
                txtName.Visible = true;
                label1.Text = "File Name";
                label1.Visible = true;
                cbFileType.Visible = true;
                label3.Visible = true;
                numFileCount.Visible = true;
                label2.Visible = true;
                txtContent.Visible = true;
                label4.Visible = true;
                groupBox2.Visible = true;
                btnCreate.Enabled = !string.IsNullOrEmpty(_selectedLocation.ParentId);
                if (!btnCreate.Enabled)
                {
                    label4.Visible = true;
                }
            }
            else if (selectedType == "Folder")
            {
                txtName.Visible = true;
                label1.Text = "Folder Name";
                label1.Visible = true;
                groupBox2.Visible = true;
                btnCreate.Enabled = !string.IsNullOrEmpty(_selectedLocation.ParentId);
                if (!btnCreate.Enabled)
                {
                    lblNote.Visible = true;
                }
            }
            else if (selectedType == "Shared Drive")
            {
                lblNote.Visible = false;
                txtName.Visible = true;
                label1.Text = "Shared Drive Name";
                label1.Visible = true;
                //groupBox2.Enabled = false;
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
            if (DriveService == null)
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
            var request = DriveService.Drives.List();
            request.Fields = "nextPageToken, drives(id, name)";
            request.PageSize = 100;
            var response = await request.ExecuteAsync();

            if (response.Drives != null && response.Drives.Count > 0)
            {
                foreach (var drive in response.Drives)
                {
                    TreeNode driveNode = new TreeNode($"{drive.Name}");
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
                bool isSharedDrive = e.Node.Parent == null || e.Node.Level == 0;


                if (string.IsNullOrEmpty(parentId))
                {
                    MessageBox.Show("Parent ID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await LoadFolders(parentId, e.Node, isSharedDrive);
            }
        }

        private async Task LoadFolders(string parentId, TreeNode parentNode, bool isSharedDrive)
        {
            try
            {
                var request = DriveService.Files.List();
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
                            TreeNode folderNode = new TreeNode($"{folder.Name}")
                            {
                                Tag = folder.Id
                            };
                            folderNode.Nodes.Add("Loading..."); 
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
                var request = DriveService.Drives.List();
                request.Q = $"name contains '{searchKey}'";
                var response = await request.ExecuteAsync();

                if (response.Drives != null && response.Drives.Count > 0)
                {
                    foreach (var drive in response.Drives)
                    {
                        TreeNode driveNode = new TreeNode($"{drive.Name}");
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
            if (e.Node.Text == "No folders found.")
            {
                selectedDriveOrFolderID = string.Empty;
                lblNote.Visible = true;
                lblNote.Text = "Cannot create new here !";
                btnCreate.Enabled = false;
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(_selectedLocation.ParentId))
                {
                    btnCreate.Enabled = true;
                    lblNote.Visible = false;
                }
            }
        }

        private async void btnSaveLocation_Click(object sender, EventArgs e)
        {
            if (treeDriveView.SelectedNode == null)
            {
                MessageBox.Show("Please select a location first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var isSharedDrive = treeDriveView.SelectedNode.Parent == null || treeDriveView.SelectedNode.Level == 0;
            _selectedLocation.ParentId = treeDriveView.SelectedNode.Tag?.ToString();
            _selectedLocation.Name = treeDriveView.SelectedNode.Text;
            _selectedLocation.Type = isSharedDrive ? "Shared Drive" : "Folder";

            if (isSharedDrive)
            {
                _sharedDriveObject.Id = _selectedLocation.ParentId;
                _sharedDriveObject.Name = _selectedLocation.Name;
                _selectedLocation.DirPathLocation = $"{_selectedLocation.Name}/";
            }
            else
            {
                _selectedLocation.DirPathLocation = await GetDirPath(_selectedLocation.ParentId); ;
            }

            string fileName = $"create_location.txt";
            string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            File.WriteAllLines(savePath, new string[]
            {
                $"ID = {_selectedLocation.ParentId}",
                $"DirPath = {_selectedLocation.DirPathLocation}",
                $"Creation Location Name = {_selectedLocation.Name}",
                $"Type = {_selectedLocation.Type}"
            });

            MessageBox.Show("Location saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = savePath,
                UseShellExecute = true
            });
            btnCreate.Enabled = !string.IsNullOrEmpty(_selectedLocation.ParentId);
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string selectedCreateType = cmbCreateType.SelectedItem?.ToString();

            if (selectedCreateType == "Shared Drive")
            {
                await CreateSharedDrive(txtName.Text);
                return;
            }
            if (string.IsNullOrEmpty(_selectedLocation.ParentId))
            {
                string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "create_location.txt");

                if (File.Exists(savePath))
                {
                    string[] lines = File.ReadAllLines(savePath);
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("ID ="))
                            _selectedLocation.ParentId = line.Replace("ID =", "").Trim();
                        else if (line.StartsWith("DirPath ="))
                            _selectedLocation.Name = line.Replace("DirPath =", "").Trim();
                        else if (line.StartsWith("Creation Location Name ="))
                            _selectedLocation.Name = line.Replace("Creation Location Name =", "").Trim();
                        else if (line.StartsWith("Type ="))
                            _selectedLocation.Type = line.Replace("Type =", "").Trim();
                    }
                }
            }

            if (string.IsNullOrEmpty(_selectedLocation.ParentId))
            {
                MessageBox.Show("No location selected! Please select a location and save first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedCreateType == "File")
            {
                await CreateFile(_selectedLocation.ParentId);
            }
            else if (selectedCreateType == "Folder")
            {
                await CreateFolder(_selectedLocation.ParentId);
            }
        }

        private async Task CreateFile(string parentId)
        {
            var numberOfFiles = (int)numFileCount.Value;
            var fileName = txtName.Text;
            var fileType = cbFileType.SelectedItem?.ToString();
            var content = txtContent.Text;
            try
            {

                for (int i = 1; i <= numberOfFiles; i++)
                {
                    string fileNameConvert = $"{fileName}-V{i}.0.{fileType}";

                    using (MemoryStream docStream = new MemoryStream(Encoding.UTF8.GetBytes($"This is test content for file {i} : {content}")))
                    {
                        var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                        {
                            Name = fileNameConvert,
                            MimeType = GetMimeType(fileType),
                            Parents = new List<string> { parentId },
                            Description = "This is an auto-generated file",
                            DriveId = _sharedDriveObject.Id,
                            CreatedTime = DateTime.UtcNow,
                            ModifiedTime = DateTime.UtcNow,
                        };

                        var request = DriveService.Files.Create(fileMetadata, docStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                        request.Fields = "*";
                        request.SupportsAllDrives = true;

                        var result = await request.UploadAsync();
                    }
                }

                MessageBox.Show($"Created file name frefix with content: {fileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show($"Created file name frefix with content fail: {fileName}", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CreateFolder(string parentId)
        {
            try
            {
                var folderName = txtName.Text;

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder",
                    Parents = new List<string> { parentId },
                    Description = "This is an auto-generated folder",
                    DriveId = _sharedDriveObject.Id,
                    CreatedTime = DateTime.UtcNow,
                    ModifiedTime = DateTime.UtcNow,
                };

                var request = DriveService.Files.Create(fileMetadata);
                request.Fields = "*";
                request.SupportsAllDrives = true;
                var folder = await request.ExecuteAsync();

                MessageBox.Show($"Created folder: {folderName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to create folder: {e.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task CreateSharedDrive(string sharedDriveName)
        {
            var requestId = Guid.NewGuid().ToString();

            var sharedDriveMetadata = new Drive()
            {
                Name = sharedDriveName
            };

            var request = DriveService.Drives.Create(sharedDriveMetadata, requestId);
            request.Fields = "id, name";

            try
            {
                var response = await request.ExecuteAsync();
                MessageBox.Show($"Created Shared Drive with ID: {response.Id}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> GetDirPath(string docId)
        {
            try
            {
                var request = DriveService.Files.Get(docId);
                request.Fields = "*";
                request.SupportsAllDrives = true;
                var file = await request.ExecuteAsync();

                List<string> pathParts = new();
                var parentId = string.Empty;
                if (file.Parents != null)
                {
                    parentId = file.Parents[0];
                }
                var driveID = file.DriveId;
                pathParts.Insert(0, file.Name);
                while (!string.IsNullOrEmpty(parentId))
                {
                    if (string.IsNullOrEmpty(driveID))
                    {
                        var driveRequest = DriveService.Files.Get(parentId);
                        driveRequest.Fields = "*";
                        driveRequest.SupportsAllDrives = true;
                        var parent = await driveRequest.ExecuteAsync();
                        pathParts.Insert(0, parent.Name);
                        if (parent.Parents != null)
                        {
                            parentId = parent.Parents[0];
                        }
                        else
                        {
                            parentId = null;
                        }
                    }
                    else
                    {
                        if (parentId != driveID)
                        {
                            var driveRequest = DriveService.Files.Get(parentId);
                            driveRequest.Fields = "*";
                            driveRequest.SupportsAllDrives = true;
                            var parent = await driveRequest.ExecuteAsync();
                            pathParts.Insert(0, parent.Name);
                            parentId = parent.Parents[0];
                        }
                        else
                        {
                            var driveRequest = DriveService.Drives.Get(parentId);
                            driveRequest.Fields = "*";
                            var drive = await driveRequest.ExecuteAsync();
                            _sharedDriveObject.Id = drive.Id;
                            _sharedDriveObject.Name = drive.Name;
                            _sharedDriveObject.Kind = drive.Kind;
                            _sharedDriveObject.CreateDate = drive.CreatedTime;
                            pathParts.Insert(0, drive.Name);
                            parentId = null;
                        }
                    }

                    if (string.IsNullOrEmpty(parentId)) break;
                }
                return string.Join("/", pathParts);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                throw;
            }

        }

        private string GetMimeType(string fileType)
        {
            if (MimeTypes.TryGetValue(fileType, out string mimeType))
            {
                return mimeType;
            }
            return "application/octet-stream";
        }

        private void GoogleDriveTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtCredentialPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            string credentialsPath = txtCredentialPath.Text;
            string userEmail = txtUserEmail.Text;

            InitializeGoogleCredentials(credentialsPath, userEmail);
        }

        private void InitializeGoogleCredentials(string credentialsPath, string userMail)
        {
            if (!File.Exists(credentialsPath))
            {
                MessageBox.Show("Credential file not found! Please provide a valid credentials.json file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var credential = GoogleCredential.FromFile(credentialsPath)
                                .CreateScoped(Google.Apis.Drive.v3.DriveService.Scope.Drive)
                                .CreateWithUser(userMail);

                DriveService = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Drive QA Tool"
                });

                MessageBox.Show("Google Drive Service Initialized Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize Google Drive service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseLocation_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadSavedLocation(filePath);
                }
            }
        }

        private void LoadSavedLocation(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.StartsWith("ID ="))
                    {
                        _selectedLocation.ParentId = line.Replace("ID =", "").Trim();
                    }
                    else if (line.StartsWith("Creation Location Name ="))
                    {
                        _selectedLocation.Name = line.Replace("Creation Location Name =", "").Trim();
                    }
                }

                if (!string.IsNullOrEmpty(_selectedLocation.ParentId))
                {
                    MessageBox.Show($"Location ready to create new : {_selectedLocation.Name}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCreate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Location ID not found in file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File read error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
