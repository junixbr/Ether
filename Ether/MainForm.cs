using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ether
{
    public partial class MainForm : Form
    {
        private Bitmap paletteBitmap;
        private Bitmap sourceBitmap;
        private List<Color> paletteColors = new List<Color>();
        private List<string> batchImagePaths = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            AllowDrop = true;
            UpdateUI();
        }

        private void loadPaletteButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                dialog.Title = "Select Palette Image";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPalette(dialog.FileName);
                }
            }
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                dialog.Title = "Select Image to Convert";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Clear batch mode when loading single image
                    ClearBatchMode();
                    LoadSingleImage(dialog.FileName);
                }
            }
        }

        private void loadBatchButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                dialog.Title = "Select Images for Batch Conversion";
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Clear single image mode when loading batch
                    ClearSingleImageMode();
                    AddBatchImages(dialog.FileNames);
                }
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (paletteBitmap == null || paletteColors.Count == 0)
            {
                MessageBox.Show("Please load a palette first.", "No Palette",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask user for output directory
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select output folder for converted images";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                string outputDir = dialog.SelectedPath;

                try
                {
                    // Check if we have single image or batch
                    if (batchImagePaths.Count > 0)
                    {
                        // Batch conversion
                        ProcessBatchConversion(outputDir);
                    }
                    else if (sourceBitmap != null)
                    {
                        // Single image conversion
                        ProcessSingleConversion(outputDir);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during conversion: {ex.Message}", "Conversion Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProcessSingleConversion(string outputDir)
        {
            Bitmap result = ConvertImage(sourceBitmap);
            string outputPath = Path.Combine(outputDir, "converted_image.png");

            // Ensure unique filename
            int counter = 1;
            while (File.Exists(outputPath))
            {
                outputPath = Path.Combine(outputDir, $"converted_image_{counter}.png");
                counter++;
            }

            result.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
            result.Dispose();

            MessageBox.Show($"Image converted successfully!\nSaved to: {outputPath}", "Conversion Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessBatchConversion(string outputDir)
        {
            int successCount = 0;
            int errorCount = 0;
            List<string> errors = new List<string>();

            // Create progress form
            using (var progressForm = new ProgressForm(batchImagePaths.Count))
            {
                progressForm.Show();
                Application.DoEvents();

                for (int i = 0; i < batchImagePaths.Count; i++)
                {
                    string inputPath = batchImagePaths[i];
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, $"{fileName}_converted.png");

                    try
                    {
                        progressForm.UpdateProgress(i + 1, $"Processing: {Path.GetFileName(inputPath)}");
                        Application.DoEvents();

                        using (Bitmap source = new Bitmap(inputPath))
                        {
                            Bitmap converted = ConvertImage(source);
                            converted.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                            converted.Dispose();
                        }

                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        errors.Add($"{Path.GetFileName(inputPath)}: {ex.Message}");
                    }
                }
            }

            // Show completion message
            string message = $"Batch conversion completed!\n\n" +
                           $"Successfully converted: {successCount} images\n" +
                           $"Errors: {errorCount} images\n" +
                           $"Output folder: {outputDir}";

            if (errors.Count > 0)
            {
                message += "\n\nErrors encountered:\n" + string.Join("\n", errors.Take(5));
                if (errors.Count > 5)
                    message += $"\n... and {errors.Count - 5} more errors.";
            }

            MessageBox.Show(message, "Batch Conversion Complete",
                MessageBoxButtons.OK,
                errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        private void LoadPalette(string filePath)
        {
            try
            {
                if (paletteBitmap != null)
                {
                    paletteBitmap.Dispose();
                }

                paletteBitmap = new Bitmap(filePath);
                paletteBox.Image = paletteBitmap;
                ExtractPaletteColors();
                UpdateUI();

                paletteLabel.Text = $"Palette Preview ({paletteColors.Count} colors)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading palette: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearSingleImageMode()
        {
            if (sourceBitmap != null)
            {
                sourceBitmap.Dispose();
                sourceBitmap = null;
            }
            imageBox.Image = null;
            imageLabel.Text = "Image Preview";
        }

        private void ClearBatchMode()
        {
            batchImagePaths.Clear();
            UpdateBatchUI();
        }

        private void LoadSingleImage(string filePath)
        {
            try
            {
                if (sourceBitmap != null)
                {
                    sourceBitmap.Dispose();
                }

                sourceBitmap = new Bitmap(filePath);
                imageBox.Image = sourceBitmap;
                UpdateUI();

                imageLabel.Text = $"Image Preview ({sourceBitmap.Width}x{sourceBitmap.Height})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddBatchImages(string[] filePaths)
        {
            int addedCount = 0;

            foreach (string path in filePaths)
            {
                try
                {
                    // Verify it's a valid image and not already in the list
                    if (!batchImagePaths.Contains(path))
                    {
                        using (var testImage = new Bitmap(path))
                        {
                            batchImagePaths.Add(path);
                            addedCount++;
                        }
                    }
                }
                catch
                {
                    // Skip invalid images
                }
            }

            UpdateBatchUI();
            UpdateUI();

            if (addedCount > 0)
            {
                MessageBox.Show($"Added {addedCount} images to batch queue.\nTotal: {batchImagePaths.Count} images",
                    "Batch Images Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No new valid images were added to the batch queue.",
                    "No Images Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveFromBatch(string filePath)
        {
            if (batchImagePaths.Contains(filePath))
            {
                batchImagePaths.Remove(filePath);
                UpdateBatchUI();
                UpdateUI();
            }
        }

        private void UpdateBatchUI()
        {
            // Clear existing file items
            batchScrollPanel.Controls.Clear();

            if (batchImagePaths.Count > 0)
            {
                // Show batch panel and label
                batchPanel.Visible = true;
                batchLabel.Visible = true;
                batchLabel.Text = $"Batch Queue ({batchImagePaths.Count} images)";

                // Create file items with inline remove buttons
                int yPosition = 5;
                for (int i = 0; i < batchImagePaths.Count; i++)
                {
                    string filePath = batchImagePaths[i];
                    string fileName = Path.GetFileName(filePath);

                    // Create container panel for this file item
                    Panel fileItemPanel = new Panel();
                    fileItemPanel.Location = new Point(5, yPosition);
                    fileItemPanel.Size = new Size(315, 20);
                    fileItemPanel.BackColor = Color.White;

                    // Create filename label
                    Label fileLabel = new Label();
                    fileLabel.Text = fileName;
                    fileLabel.Location = new Point(0, 2);
                    fileLabel.Size = new Size(285, 16);
                    fileLabel.Font = new Font("Segoe UI", 8.25F);
                    fileLabel.AutoEllipsis = true;

                    // Create remove button
                    Button removeBtn = new Button();
                    removeBtn.Size = new Size(20, 20);
                    removeBtn.Location = new Point(290, 1);
                    removeBtn.Image = Ether.Properties.Resources.delete;
                    removeBtn.BackColor = Color.WhiteSmoke;
                    removeBtn.FlatAppearance.BorderSize = 1;
                    removeBtn.FlatAppearance.BorderColor = Color.LightGray;
                    removeBtn.Tag = filePath;
                    removeBtn.Click += (s, e) => {
                        string path = (string)((Button)s).Tag;
                        RemoveFromBatch(path);
                    };

                    // Add controls to file item panel
                    fileItemPanel.Controls.Add(fileLabel);
                    fileItemPanel.Controls.Add(removeBtn);

                    // Add file item panel to scroll panel
                    batchScrollPanel.Controls.Add(fileItemPanel);

                    yPosition += 22; // Space between items
                }

                // Add "Clear All" button at the bottom
                Button clearAllBtn = new Button();
                clearAllBtn.Text = "Clear All";
                clearAllBtn.Size = new Size(70, 22);
                clearAllBtn.Location = new Point(5, yPosition + 5);
                clearAllBtn.Font = new Font("Microsoft Sans Serif", 8F);
                clearAllBtn.ForeColor = Color.DarkRed;
                clearAllBtn.BackColor = Color.WhiteSmoke;
                clearAllBtn.FlatStyle = FlatStyle.Flat;
                clearAllBtn.FlatAppearance.BorderSize = 1;
                clearAllBtn.FlatAppearance.BorderColor = Color.Gray;
                clearAllBtn.Click += (s, e) => {
                    if (MessageBox.Show("Clear all images from batch queue?", "Clear Batch",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        batchImagePaths.Clear();
                        UpdateBatchUI();
                        UpdateUI();
                    }
                };

                batchScrollPanel.Controls.Add(clearAllBtn);

                // Update scroll panel size
                batchScrollPanel.Size = new Size(315, yPosition + 35);

                // Show batch controls
                loadBatchButton.Visible = true;
            }
            else
            {
                // Hide batch panel and label
                batchPanel.Visible = false;
                batchLabel.Visible = false;
                loadBatchButton.Visible = true; // Keep Load Batch button visible
            }
        }

        private void UpdateUI()
        {
            // Enable Convert button if we have palette and (single image OR batch images)
            bool hasContent = (sourceBitmap != null) || (batchImagePaths.Count > 0);
            convertButton.Enabled = (paletteBitmap != null && paletteColors.Count > 0 && hasContent);
        }

        private Bitmap ConvertImage(Bitmap sourceImage)
        {
            if (paletteColors.Count == 0)
                throw new InvalidOperationException("No palette colors available");

            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color original = sourceImage.GetPixel(x, y);
                    Color nearest = FindNearestColor(original);
                    result.SetPixel(x, y, nearest);
                }
            }

            return result;
        }

        private void ExtractPaletteColors()
        {
            paletteColors.Clear();
            HashSet<Color> uniqueColors = new HashSet<Color>();

            for (int y = 0; y < paletteBitmap.Height; y++)
            {
                for (int x = 0; x < paletteBitmap.Width; x++)
                {
                    Color c = paletteBitmap.GetPixel(x, y);
                    uniqueColors.Add(c);
                }
            }

            paletteColors.AddRange(uniqueColors);
        }

        private Color FindNearestColor(Color original)
        {
            if (paletteColors.Count == 0) return original;

            double minDist = double.MaxValue;
            Color nearest = paletteColors[0];

            foreach (Color c in paletteColors)
            {
                // Euclidean distance in RGB color space
                double dist = Math.Pow(original.R - c.R, 2) +
                             Math.Pow(original.G - c.G, 2) +
                             Math.Pow(original.B - c.B, 2);

                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = c;
                }
            }

            return nearest;
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
            List<string> imageFiles = new List<string>();

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLower();
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif")
                {
                    imageFiles.Add(file);
                }
            }

            if (imageFiles.Count == 0) return;

            // If no palette loaded yet, use first image as palette
            if (paletteBitmap == null && imageFiles.Count > 0)
            {
                LoadPalette(imageFiles[0]);
                imageFiles.RemoveAt(0);
            }

            // Handle remaining images
            if (imageFiles.Count == 1)
            {
                // Single image - switch to single mode
                ClearBatchMode();
                LoadSingleImage(imageFiles[0]);
            }
            else if (imageFiles.Count > 1)
            {
                // Multiple images - switch to batch mode
                ClearSingleImageMode();
                AddBatchImages(imageFiles.ToArray());
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            using (var about = new AboutForm())
            {
                about.ShowDialog(this);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                paletteBitmap?.Dispose();
                sourceBitmap?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
