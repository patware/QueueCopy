using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;

namespace QueueCopy
{
    public partial class UpdateForm : Form
    {
        delegate void StringParameterDelegate(string value);

        //private Queue<string> _messageQueue = new Queue<string>();
        private UpdateCheckInfo _info = null;

        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            this.Show();

            uxCheckerBackgroundWorker.RunWorkerAsync();
            //checkForUpdate();
        }

        private void updateStatus(string message)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(updateStatus), new object[] { message });
                return;
            }

            NewMethod(message);

        }

        private void NewMethod(string message)
        {
            // Must be on the UI thread if we've got this far
            uxMessagesListBox.Items.Add(message);
            uxMessagesListBox.SelectedIndex = uxMessagesListBox.Items.Count - 1;
            uxMessagesListBox.Invalidate();
        }


        private void uxCheckerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = checkForUpdate();
        }

        private bool checkForUpdate()
        {

            bool returnValue = false;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    updateStatus("Checking with Server");
                    _info = ad.CheckForDetailedUpdate();

                    updateStatus(string.Format("Installed version: {0}", ad.CurrentVersion));

                    if (_info.UpdateAvailable)
                    {
                        returnValue = true;

                        updateStatus(string.Format("Latest version: {0}", _info.AvailableVersion));

                        if (_info.IsUpdateRequired)
                            updateStatus("Update is required");
                        else
                            updateStatus("Your current version is obsolete and should be updated");

                        updateStatus(string.Format("Size of the update: {0} kb", _info.UpdateSizeBytes / 1024));
                    }
                    else
                    {
                        updateStatus(string.Format("Latest version: {0}", ad.CurrentVersion));
                        updateStatus("Your current version is the latest");
                    }

                }
                catch (DeploymentDownloadException dde)
                {
                    updateStatus("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    returnValue = false;
                }
                catch (InvalidDeploymentException ide)
                {
                    updateStatus("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    returnValue = false;
                }
                catch (InvalidOperationException ioe)
                {
                    updateStatus("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    returnValue = false;
                }

            }
            else
                updateStatus("This app is not a ClickOnce application");

            return returnValue;

        }



        private void uxUpdateLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uxMessagesListBox.Items.Clear();
            uxUpdateBackgroundWorker.RunWorkerAsync();
        }

        private void uxUpdateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = updateApplication();
        }

        private bool updateApplication()
        {
            bool returnValue = false;

            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

            try
            {
                ad.Update();

                returnValue = true;

            }
            catch (DeploymentDownloadException dde)
            {
                updateStatus("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                return false;
            }

            return returnValue;
        }

        private void uxCheckerBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uxUpdateLinkLabel.Enabled = (bool)e.Result;
        }

        private void uxUpdateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                MessageBox.Show("The application has been upgraded, and will now restart.");
                Application.Restart();
            }
        }



    }
}