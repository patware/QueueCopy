namespace QueueCopy
{
    partial class UpdateForm
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
            this.uxMessagesListBox = new System.Windows.Forms.ListBox();
            this.uxUpdateLinkLabel = new System.Windows.Forms.LinkLabel();
            this.uxCheckerBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.uxUpdateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // uxMessagesListBox
            // 
            this.uxMessagesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMessagesListBox.FormattingEnabled = true;
            this.uxMessagesListBox.Location = new System.Drawing.Point(5, 6);
            this.uxMessagesListBox.Name = "uxMessagesListBox";
            this.uxMessagesListBox.Size = new System.Drawing.Size(238, 160);
            this.uxMessagesListBox.TabIndex = 0;
            // 
            // uxUpdateLinkLabel
            // 
            this.uxUpdateLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxUpdateLinkLabel.AutoSize = true;
            this.uxUpdateLinkLabel.Enabled = false;
            this.uxUpdateLinkLabel.Location = new System.Drawing.Point(121, 172);
            this.uxUpdateLinkLabel.Name = "uxUpdateLinkLabel";
            this.uxUpdateLinkLabel.Size = new System.Drawing.Size(42, 13);
            this.uxUpdateLinkLabel.TabIndex = 1;
            this.uxUpdateLinkLabel.TabStop = true;
            this.uxUpdateLinkLabel.Text = "Update";
            this.uxUpdateLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uxUpdateLinkLabel_LinkClicked);
            // 
            // uxCheckerBackgroundWorker
            // 
            this.uxCheckerBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uxCheckerBackgroundWorker_DoWork);
            this.uxCheckerBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uxCheckerBackgroundWorker_RunWorkerCompleted);
            // 
            // uxUpdateBackgroundWorker
            // 
            this.uxUpdateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uxUpdateBackgroundWorker_DoWork);
            this.uxUpdateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uxUpdateBackgroundWorker_RunWorkerCompleted);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 190);
            this.Controls.Add(this.uxUpdateLinkLabel);
            this.Controls.Add(this.uxMessagesListBox);
            this.Name = "UpdateForm";
            this.Text = "Update";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uxMessagesListBox;
        private System.Windows.Forms.LinkLabel uxUpdateLinkLabel;
        private System.ComponentModel.BackgroundWorker uxCheckerBackgroundWorker;
        private System.ComponentModel.BackgroundWorker uxUpdateBackgroundWorker;
    }

}