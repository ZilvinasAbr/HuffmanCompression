using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCompression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectFileButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                selectedFileTextBox1.Text = openFileDialog1.FileName;
            }
        }

        private void selectFileButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                selectedFileTextBox2.Text = openFileDialog1.FileName;
            }
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(selectedFileTextBox1.Text);
                byte[] compressedData = Compressor.Compress(fileData);
                File.WriteAllBytes(selectedFileTextBox1.Text+=".huf", compressedData);
                selectedFileTextBox1.Text = "";
            }
            catch (IOException)
            {

            }
            catch (System.ArgumentException)
            {

            }
        }

        private void decompressButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(selectedFileTextBox2.Text);
                byte[] decompressedData = Decompressor.Decompress(fileData);
                string outputFilePath = selectedFileTextBox2.Text.Substring(0,selectedFileTextBox2.Text.Length-4);
                File.WriteAllBytes(outputFilePath, decompressedData);
                selectedFileTextBox2.Text = "";
            }
            catch (IOException)
            {

            }
            catch (System.ArgumentException)
            {

            }
        }
    }
}
