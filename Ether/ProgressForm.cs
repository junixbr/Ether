using System;
using System.Windows.Forms;

namespace Ether
{
    public partial class ProgressForm : Form
    {
        private ProgressBar progressBar;
        private Label statusLabel;
        private Label progressLabel;
        private int totalItems;

        public ProgressForm(int totalItems)
        {
            this.totalItems = totalItems;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.progressBar = new ProgressBar();
            this.statusLabel = new Label();
            this.progressLabel = new Label();

            this.SuspendLayout();

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(20, 60);
            this.progressBar.Size = new System.Drawing.Size(340, 23);
            this.progressBar.Maximum = totalItems;
            this.progressBar.Minimum = 0;
            this.progressBar.Step = 1;
            this.progressBar.Style = ProgressBarStyle.Continuous;

            // statusLabel
            this.statusLabel.Location = new System.Drawing.Point(20, 20);
            this.statusLabel.Size = new System.Drawing.Size(340, 20);
            this.statusLabel.Text = "Initializing batch conversion...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // progressLabel
            this.progressLabel.Location = new System.Drawing.Point(20, 90);
            this.progressLabel.Size = new System.Drawing.Size(340, 20);
            this.progressLabel.Text = $"0 / {totalItems}";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);

            // ProgressForm
            this.ClientSize = new System.Drawing.Size(380, 130);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressLabel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Converting Images...";
            this.ControlBox = false;

            this.ResumeLayout(false);
        }

        public void UpdateProgress(int currentItem, string statusText)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string>(UpdateProgress), currentItem, statusText);
                return;
            }

            progressBar.Value = Math.Min(currentItem, totalItems);
            statusLabel.Text = statusText;
            progressLabel.Text = $"{currentItem} / {totalItems}";

            // Update the form
            Refresh();
        }
    }
}
