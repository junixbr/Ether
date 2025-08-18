namespace Ether
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.LinkLabel licenseLink;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.LinkLabel emailLink;
        private System.Windows.Forms.Button okButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.aboutLabel = new System.Windows.Forms.Label();
            this.licenseLink = new System.Windows.Forms.LinkLabel();
            this.authorLabel = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.emailLink = new System.Windows.Forms.LinkLabel();

            // aboutLabel
            this.aboutLabel.Text =
                "Ether is an open-source pixel art color converter that lets you\ntransform images according to a chosen color palette.\n\n" +
                "BSD 2-Clause License\n" +
                "Copyright (c) 2025 Alfredo Saldanha\n\n" +
                "All rights reserved.\n\n" +
                "Redistribution and use in source and binary forms, with or without\n" +
                "modification, are permitted provided that the following conditions\nare met...\n";
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(10, 10);
            this.aboutLabel.MaximumSize = new System.Drawing.Size(380, 0);

            // licenseLink
            this.licenseLink.Text = "Read full BSD 2-Clause License";
            this.licenseLink.LinkClicked += (s, e) =>
            {
                System.Diagnostics.Process.Start("https://opensource.org/licenses/BSD-2-Clause");
            };
            this.licenseLink.AutoSize = true;
            this.licenseLink.Location = new System.Drawing.Point(10, 180);

            // author
            this.authorLabel.Text = "Author: Alfredo Saldanha";
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(10, 210);

            // githubLink
            this.githubLink.Text = "Github: https://github.com/junixbr";
            this.githubLink.LinkClicked += (s, e) =>
            {
                System.Diagnostics.Process.Start("https://github.com/junixbr");
            };
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(10, 230);

            // emailLink
            this.emailLink.Text = "Email: junixbr@gmail.com (click to copy)";
            this.emailLink.LinkClicked += (s, e) =>
            {
                System.Windows.Forms.Clipboard.SetText("junixbr@gmail.com");
                System.Windows.Forms.MessageBox.Show("Email copied to clipboard.", "Copied", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            };
            this.emailLink.AutoSize = true;
            this.emailLink.Location = new System.Drawing.Point(10, 250);

            // AboutForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 320);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.licenseLink);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.emailLink);

            this.okButton = new System.Windows.Forms.Button();
            this.okButton.Text = "OK";
            this.okButton.Size = new System.Drawing.Size(80, 30);
            this.okButton.Location = new System.Drawing.Point((this.ClientSize.Width - 80) / 2, 280);
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.Click += (s, e) => this.Close();
            this.Controls.Add(this.okButton);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Icon = new System.Drawing.Icon("../../../Resources/app.ico");
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
