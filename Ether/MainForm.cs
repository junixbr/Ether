using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ether
{
    public partial class MainForm : Form
    {
        private Bitmap paletteBitmap;
        private Bitmap sourceBitmap;
        private List<Color> paletteColors = new List<Color>();

        public MainForm()
        {
            InitializeComponent();
            AllowDrop = true;
            convertButton.Enabled = false;
        }

        private void loadPaletteButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Images|*.png;*.jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    paletteBitmap = new Bitmap(dialog.FileName);
                    paletteBox.Image = paletteBitmap;
                    ExtractPaletteColors();
                    CheckConvertReady();
                }
            }
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Images|*.png;*.jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    sourceBitmap = new Bitmap(dialog.FileName);
                    imageBox.Image = sourceBitmap;
                    CheckConvertReady();
                }
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (paletteBitmap == null || sourceBitmap == null || paletteColors.Count == 0) return;

            Bitmap result = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            for (int y = 0; y < sourceBitmap.Height; y++)
            {
                for (int x = 0; x < sourceBitmap.Width; x++)
                {
                    Color original = sourceBitmap.GetPixel(x, y);
                    Color nearest = FindNearestColor(original);
                    result.SetPixel(x, y, nearest);
                }
            }

            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "converted_output.png");
            result.Save(outputPath);
            MessageBox.Show("Image saved to " + outputPath);
        }

        private void ExtractPaletteColors()
        {
            paletteColors.Clear();
            for (int y = 0; y < paletteBitmap.Height; y++)
            {
                for (int x = 0; x < paletteBitmap.Width; x++)
                {
                    Color c = paletteBitmap.GetPixel(x, y);
                    if (!paletteColors.Contains(c))
                        paletteColors.Add(c);
                }
            }
        }

        private Color FindNearestColor(Color original)
        {
            double minDist = double.MaxValue;
            Color nearest = paletteColors[0];
            foreach (Color c in paletteColors)
            {
                double dist = Math.Pow(original.R - c.R, 2) + Math.Pow(original.G - c.G, 2) + Math.Pow(original.B - c.B, 2);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = c;
                }
            }
            return nearest;
        }

        private void CheckConvertReady()
        {
            convertButton.Enabled = (paletteBitmap != null && sourceBitmap != null);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.EndsWith(".png") || file.EndsWith(".jpg"))
                {
                    if (paletteBitmap == null)
                    {
                        paletteBitmap = new Bitmap(file);
                        paletteBox.Image = paletteBitmap;
                        ExtractPaletteColors();
                    }
                    else if (sourceBitmap == null)
                    {
                        sourceBitmap = new Bitmap(file);
                        imageBox.Image = sourceBitmap;
                    }
                }
            }
            CheckConvertReady();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            using (var about = new AboutForm())
            {
                about.ShowDialog(this);
            }
        }

    }
}