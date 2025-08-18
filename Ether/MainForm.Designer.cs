namespace Ether
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            loadPaletteButton = new Button();
            loadImageButton = new Button();
            loadBatchButton = new Button();
            convertButton = new Button();
            aboutButton = new Button();
            quitButton = new Button();
            paletteBox = new PictureBox();
            imageBox = new PictureBox();
            paletteLabel = new Label();
            imageLabel = new Label();
            batchLabel = new Label();
            paletteBorder = new Panel();
            imageBorder = new Panel();
            batchPanel = new Panel();
            batchScrollPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)paletteBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            paletteBorder.SuspendLayout();
            imageBorder.SuspendLayout();
            batchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loadPaletteButton
            // 
            loadPaletteButton.Location = new Point(102, 297);
            loadPaletteButton.Name = "loadPaletteButton";
            loadPaletteButton.Size = new Size(90, 28);
            loadPaletteButton.TabIndex = 0;
            loadPaletteButton.Text = "Load Palette";
            loadPaletteButton.Click += loadPaletteButton_Click;
            // 
            // loadImageButton
            // 
            loadImageButton.Location = new Point(409, 297);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(90, 28);
            loadImageButton.TabIndex = 1;
            loadImageButton.Text = "Load Image";
            loadImageButton.Click += loadImageButton_Click;
            // 
            // loadBatchButton
            // 
            loadBatchButton.Location = new Point(20, 359);
            loadBatchButton.Name = "loadBatchButton";
            loadBatchButton.Size = new Size(80, 28);
            loadBatchButton.TabIndex = 2;
            loadBatchButton.Text = "Load Batch";
            loadBatchButton.Click += loadBatchButton_Click;
            // 
            // convertButton
            // 
            convertButton.BackColor = SystemColors.ButtonHighlight;
            convertButton.Enabled = false;
            convertButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            convertButton.Image = Properties.Resources.play;
            convertButton.ImageAlign = ContentAlignment.MiddleLeft;
            convertButton.Location = new Point(494, 359);
            convertButton.Name = "convertButton";
            convertButton.Size = new Size(80, 30);
            convertButton.TabIndex = 3;
            convertButton.Text = "Convert";
            convertButton.TextAlign = ContentAlignment.MiddleRight;
            convertButton.UseVisualStyleBackColor = false;
            convertButton.Click += convertButton_Click;
            // 
            // aboutButton
            // 
            aboutButton.Location = new Point(494, 436);
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(80, 28);
            aboutButton.TabIndex = 4;
            aboutButton.Text = "About";
            aboutButton.Click += aboutButton_Click;
            // 
            // quitButton
            // 
            quitButton.Location = new Point(494, 476);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(80, 28);
            quitButton.TabIndex = 5;
            quitButton.Text = "Quit";
            quitButton.Click += quitButton_Click;
            // 
            // paletteBox
            // 
            paletteBox.Dock = DockStyle.Fill;
            paletteBox.Location = new Point(0, 0);
            paletteBox.Name = "paletteBox";
            paletteBox.Size = new Size(254, 254);
            paletteBox.SizeMode = PictureBoxSizeMode.Zoom;
            paletteBox.TabIndex = 0;
            paletteBox.TabStop = false;
            // 
            // imageBox
            // 
            imageBox.Dock = DockStyle.Fill;
            imageBox.Location = new Point(0, 0);
            imageBox.Name = "imageBox";
            imageBox.Size = new Size(254, 254);
            imageBox.SizeMode = PictureBoxSizeMode.Zoom;
            imageBox.TabIndex = 0;
            imageBox.TabStop = false;
            // 
            // paletteLabel
            // 
            paletteLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paletteLabel.Location = new Point(20, 10);
            paletteLabel.Name = "paletteLabel";
            paletteLabel.Size = new Size(256, 20);
            paletteLabel.TabIndex = 6;
            paletteLabel.Text = "Palette Preview";
            paletteLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imageLabel
            // 
            imageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            imageLabel.Location = new Point(320, 9);
            imageLabel.Name = "imageLabel";
            imageLabel.Size = new Size(256, 20);
            imageLabel.TabIndex = 7;
            imageLabel.Text = "Image Preview";
            imageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // batchLabel
            // 
            batchLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            batchLabel.ForeColor = Color.Black;
            batchLabel.Location = new Point(115, 359);
            batchLabel.Name = "batchLabel";
            batchLabel.Size = new Size(200, 20);
            batchLabel.TabIndex = 8;
            batchLabel.Text = "Batch Queue (8 images)";
            batchLabel.TextAlign = ContentAlignment.MiddleLeft;
            batchLabel.Visible = false;
            // 
            // paletteBorder
            // 
            paletteBorder.BackColor = Color.LightGray;
            paletteBorder.BorderStyle = BorderStyle.FixedSingle;
            paletteBorder.Controls.Add(paletteBox);
            paletteBorder.Location = new Point(20, 35);
            paletteBorder.Name = "paletteBorder";
            paletteBorder.Size = new Size(256, 256);
            paletteBorder.TabIndex = 9;
            // 
            // imageBorder
            // 
            imageBorder.BackColor = Color.LightGray;
            imageBorder.BorderStyle = BorderStyle.FixedSingle;
            imageBorder.Controls.Add(imageBox);
            imageBorder.Location = new Point(319, 35);
            imageBorder.Name = "imageBorder";
            imageBorder.Size = new Size(256, 256);
            imageBorder.TabIndex = 10;
            // 
            // batchPanel
            // 
            batchPanel.AutoScroll = true;
            batchPanel.BackColor = Color.White;
            batchPanel.BorderStyle = BorderStyle.FixedSingle;
            batchPanel.Controls.Add(batchScrollPanel);
            batchPanel.Location = new Point(115, 384);
            batchPanel.Name = "batchPanel";
            batchPanel.Size = new Size(350, 120);
            batchPanel.TabIndex = 11;
            batchPanel.Visible = false;
            // 
            // batchScrollPanel
            // 
            batchScrollPanel.AutoSize = true;
            batchScrollPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            batchScrollPanel.Location = new Point(0, 0);
            batchScrollPanel.Name = "batchScrollPanel";
            batchScrollPanel.Size = new Size(0, 0);
            batchScrollPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            AllowDrop = true;
            ClientSize = new Size(598, 520);
            Controls.Add(loadPaletteButton);
            Controls.Add(loadImageButton);
            Controls.Add(loadBatchButton);
            Controls.Add(convertButton);
            Controls.Add(aboutButton);
            Controls.Add(quitButton);
            Controls.Add(paletteLabel);
            Controls.Add(imageLabel);
            Controls.Add(batchLabel);
            Controls.Add(paletteBorder);
            Controls.Add(imageBorder);
            Controls.Add(batchPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ether - Pixel Art Color Converter";
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            ((System.ComponentModel.ISupportInitialize)paletteBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            paletteBorder.ResumeLayout(false);
            imageBorder.ResumeLayout(false);
            batchPanel.ResumeLayout(false);
            batchPanel.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button loadPaletteButton;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button loadBatchButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox paletteBox;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Label paletteLabel;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Label batchLabel;
        private System.Windows.Forms.Panel paletteBorder;
        private System.Windows.Forms.Panel imageBorder;
        private System.Windows.Forms.Panel batchPanel;
        private System.Windows.Forms.Panel batchScrollPanel;
    }
}
