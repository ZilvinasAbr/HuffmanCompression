namespace HuffmanCompression
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFileButton1 = new System.Windows.Forms.Button();
            this.selectedFileTextBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectedFileTextBox2 = new System.Windows.Forms.TextBox();
            this.selectFileButton2 = new System.Windows.Forms.Button();
            this.compressButton = new System.Windows.Forms.Button();
            this.decompressButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectFileButton1
            // 
            this.selectFileButton1.Location = new System.Drawing.Point(251, 19);
            this.selectFileButton1.Name = "selectFileButton1";
            this.selectFileButton1.Size = new System.Drawing.Size(75, 23);
            this.selectFileButton1.TabIndex = 0;
            this.selectFileButton1.Text = "Select file...";
            this.selectFileButton1.UseVisualStyleBackColor = true;
            this.selectFileButton1.Click += new System.EventHandler(this.selectFileButton1_Click);
            // 
            // selectedFileTextBox1
            // 
            this.selectedFileTextBox1.Location = new System.Drawing.Point(6, 19);
            this.selectedFileTextBox1.Name = "selectedFileTextBox1";
            this.selectedFileTextBox1.Size = new System.Drawing.Size(239, 20);
            this.selectedFileTextBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.compressButton);
            this.groupBox1.Controls.Add(this.selectedFileTextBox1);
            this.groupBox1.Controls.Add(this.selectFileButton1);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compress";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.decompressButton);
            this.groupBox2.Controls.Add(this.selectFileButton2);
            this.groupBox2.Controls.Add(this.selectedFileTextBox2);
            this.groupBox2.Location = new System.Drawing.Point(5, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 90);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decompress";
            // 
            // selectedFileTextBox2
            // 
            this.selectedFileTextBox2.Location = new System.Drawing.Point(6, 19);
            this.selectedFileTextBox2.Name = "selectedFileTextBox2";
            this.selectedFileTextBox2.Size = new System.Drawing.Size(239, 20);
            this.selectedFileTextBox2.TabIndex = 0;
            // 
            // selectFileButton2
            // 
            this.selectFileButton2.Location = new System.Drawing.Point(251, 19);
            this.selectFileButton2.Name = "selectFileButton2";
            this.selectFileButton2.Size = new System.Drawing.Size(75, 23);
            this.selectFileButton2.TabIndex = 1;
            this.selectFileButton2.Text = "Select file...";
            this.selectFileButton2.UseVisualStyleBackColor = true;
            this.selectFileButton2.Click += new System.EventHandler(this.selectFileButton2_Click);
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(6, 45);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(75, 23);
            this.compressButton.TabIndex = 2;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // decompressButton
            // 
            this.decompressButton.Location = new System.Drawing.Point(6, 45);
            this.decompressButton.Name = "decompressButton";
            this.decompressButton.Size = new System.Drawing.Size(75, 23);
            this.decompressButton.TabIndex = 2;
            this.decompressButton.Text = "Decompress";
            this.decompressButton.UseVisualStyleBackColor = true;
            this.decompressButton.Click += new System.EventHandler(this.decompressButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 178);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Huffman Compressor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFileButton1;
        private System.Windows.Forms.TextBox selectedFileTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button selectFileButton2;
        private System.Windows.Forms.TextBox selectedFileTextBox2;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Button decompressButton;
    }
}

