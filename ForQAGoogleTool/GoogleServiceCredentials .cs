using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace ForQAGoogleTool
{
    public partial class GoogleServiceCredentials : Form
    {
        public DriveService DriveService { get; private set; }

        public GoogleServiceCredentials()
        {
            InitializeComponent();
            txtCredentialPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "securitysaproject-f09d658d8984.json");
            txtUserEmail.Text = "CGForQA@avepointgsuite.com";
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

            if (!File.Exists(credentialsPath))
            {
                MessageBox.Show("Credential file not found! Please provide a valid credentials.json file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var credential = GoogleCredential.FromFile(credentialsPath)
                                .CreateScoped(DriveService.Scope.Drive)
                                .CreateWithUser(userEmail);

                DriveService = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Drive QA Tool"
                });

                MessageBox.Show("Google Drive Service Initialized Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GoogleDriveTool driveTool = new GoogleDriveTool(DriveService);
                this.Hide();
                driveTool.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize Google Drive service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
