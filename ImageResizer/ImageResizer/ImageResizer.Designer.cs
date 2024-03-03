namespace ImageResizer
{
    partial class ResizerForm
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
            this.ClearButton = new System.Windows.Forms.Button();
            this.AddImage = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DefaultPicture = new System.Windows.Forms.PictureBox();
            this.NewPicture = new System.Windows.Forms.PictureBox();
            this.ImageAdjustment = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ParallelBox = new System.Windows.Forms.CheckBox();
            this.ConsequentialBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageAdjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Tomato;
            this.ClearButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(599, 557);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(117, 43);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddImage
            // 
            this.AddImage.BackColor = System.Drawing.Color.Tomato;
            this.AddImage.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddImage.Location = new System.Drawing.Point(590, 24);
            this.AddImage.Name = "AddImage";
            this.AddImage.Size = new System.Drawing.Size(155, 57);
            this.AddImage.TabIndex = 2;
            this.AddImage.Text = "Upload Image";
            this.AddImage.UseVisualStyleBackColor = false;
            this.AddImage.Click += new System.EventHandler(this.AddImage_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownloadButton.Location = new System.Drawing.Point(1020, 557);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(179, 43);
            this.DownloadButton.TabIndex = 4;
            this.DownloadButton.Text = "Download Resized Image";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DefaultPicture
            // 
            this.DefaultPicture.Location = new System.Drawing.Point(101, 229);
            this.DefaultPicture.Name = "DefaultPicture";
            this.DefaultPicture.Size = new System.Drawing.Size(540, 310);
            this.DefaultPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DefaultPicture.TabIndex = 6;
            this.DefaultPicture.TabStop = false;
            // 
            // NewPicture
            // 
            this.NewPicture.Location = new System.Drawing.Point(674, 229);
            this.NewPicture.Name = "NewPicture";
            this.NewPicture.Size = new System.Drawing.Size(525, 310);
            this.NewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NewPicture.TabIndex = 7;
            this.NewPicture.TabStop = false;
            // 
            // ImageAdjustment
            // 
            this.ImageAdjustment.Location = new System.Drawing.Point(629, 107);
            this.ImageAdjustment.Name = "ImageAdjustment";
            this.ImageAdjustment.Size = new System.Drawing.Size(158, 22);
            this.ImageAdjustment.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(526, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Resize in %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(475, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Choose algorithm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(292, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Uploaded image:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(913, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Resized image:";
            // 
            // ParallelBox
            // 
            this.ParallelBox.AutoSize = true;
            this.ParallelBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParallelBox.Location = new System.Drawing.Point(639, 149);
            this.ParallelBox.Name = "ParallelBox";
            this.ParallelBox.Size = new System.Drawing.Size(88, 23);
            this.ParallelBox.TabIndex = 13;
            this.ParallelBox.Text = "Parallel";
            this.ParallelBox.UseVisualStyleBackColor = true;
            this.ParallelBox.CheckedChanged += new System.EventHandler(this.ParallelBox_CheckedChanged);
            // 
            // ConsequentialBox
            // 
            this.ConsequentialBox.AutoSize = true;
            this.ConsequentialBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsequentialBox.Location = new System.Drawing.Point(639, 178);
            this.ConsequentialBox.Name = "ConsequentialBox";
            this.ConsequentialBox.Size = new System.Drawing.Size(143, 23);
            this.ConsequentialBox.TabIndex = 14;
            this.ConsequentialBox.Text = "Consequential";
            this.ConsequentialBox.UseVisualStyleBackColor = true;
            this.ConsequentialBox.CheckedChanged += new System.EventHandler(this.ConsequentialBox_CheckedChanged);
            // 
            // ResizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1291, 635);
            this.Controls.Add(this.ConsequentialBox);
            this.Controls.Add(this.ParallelBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImageAdjustment);
            this.Controls.Add(this.NewPicture);
            this.Controls.Add(this.DefaultPicture);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.AddImage);
            this.Controls.Add(this.ClearButton);
            this.Name = "ResizerForm";
            this.Text = "Image Resizer";
            ((System.ComponentModel.ISupportInitialize)(this.DefaultPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageAdjustment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button AddImage;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.PictureBox DefaultPicture;
        private System.Windows.Forms.PictureBox NewPicture;
        private System.Windows.Forms.NumericUpDown ImageAdjustment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ParallelBox;
        private System.Windows.Forms.CheckBox ConsequentialBox;
    }
}

