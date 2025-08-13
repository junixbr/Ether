namespace Ether
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.loadPaletteButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.paletteBox = new System.Windows.Forms.PictureBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.paletteLabel = new System.Windows.Forms.Label();
            this.imageLabel = new System.Windows.Forms.Label();
            this.paletteBorder = new System.Windows.Forms.Panel();
            this.imageBorder = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.paletteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();

            // paletteBorder
            this.paletteBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paletteBorder.BackColor = System.Drawing.Color.LightGray;
            this.paletteBorder.Location = new System.Drawing.Point(20, 35);
            this.paletteBorder.Size = new System.Drawing.Size(256, 256);
            this.paletteBorder.Controls.Add(this.paletteBox);

            // imageBorder
            this.imageBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBorder.BackColor = System.Drawing.Color.LightGray;
            this.imageBorder.Location = new System.Drawing.Point(300, 35);
            this.imageBorder.Size = new System.Drawing.Size(256, 256);
            this.imageBorder.Controls.Add(this.imageBox);

            // paletteBox
            this.paletteBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // imageBox
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // Botões
            this.loadPaletteButton.Text = "Load Palette";
            this.loadPaletteButton.Size = new System.Drawing.Size(120, 30);
            this.loadPaletteButton.Click += new System.EventHandler(this.loadPaletteButton_Click);

            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.Size = new System.Drawing.Size(120, 30);
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);

            this.convertButton.Text = "Convert";
            this.convertButton.Size = new System.Drawing.Size(120, 30);
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);

            this.aboutButton.Text = "About";
            this.aboutButton.Size = new System.Drawing.Size(120, 30);
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);

            this.quitButton.Text = "Quit";
            this.quitButton.Size = new System.Drawing.Size(120, 30);
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);

            // Labels
            this.paletteLabel.Text = "Palette Preview";
            this.paletteLabel.Location = new System.Drawing.Point(20, 10);
            this.paletteLabel.Size = new System.Drawing.Size(256, 20);
            this.paletteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.imageLabel.Text = "Image Preview";
            this.imageLabel.Location = new System.Drawing.Point(300, 10);
            this.imageLabel.Size = new System.Drawing.Size(256, 20);
            this.imageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // MainForm
            this.AllowDrop = true;
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.ClientSize = new System.Drawing.Size(580, 390);
            this.Controls.Add(this.loadPaletteButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.paletteLabel);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.paletteBorder);
            this.Controls.Add(this.imageBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette Converter";
            this.Icon = new System.Drawing.Icon("Resources/app.ico");

            // Centralização dos botões
            int formWidth = 580;
            int buttonWidth = 90;
            int spacing = 12;
            int totalButtonWidth = 5 * buttonWidth + 4 * spacing;
            int leftStart = (formWidth - totalButtonWidth) / 2;
            int top = 310;

            this.loadPaletteButton.Width = buttonWidth;
            this.loadPaletteButton.Location = new System.Drawing.Point(leftStart + 0 * (buttonWidth + spacing), top);
            this.loadImageButton.Width = buttonWidth;
            this.loadImageButton.Location = new System.Drawing.Point(leftStart + 1 * (buttonWidth + spacing), top);
            this.convertButton.Width = buttonWidth;
            this.convertButton.Location = new System.Drawing.Point(leftStart + 2 * (buttonWidth + spacing), top);
            this.aboutButton.Width = buttonWidth;
            this.aboutButton.Location = new System.Drawing.Point(leftStart + 3 * (buttonWidth + spacing), top);
            this.quitButton.Width = buttonWidth;
            this.quitButton.Location = new System.Drawing.Point(leftStart + 4 * (buttonWidth + spacing), top);

            ((System.ComponentModel.ISupportInitialize)(this.paletteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button loadPaletteButton;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox paletteBox;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Label paletteLabel;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Panel paletteBorder;
        private System.Windows.Forms.Panel imageBorder;
    }
}
