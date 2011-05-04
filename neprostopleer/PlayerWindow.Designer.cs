namespace neprostopleer
{
    partial class PlayerWindow
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
            this.mainPrevButton = new System.Windows.Forms.Button();
            this.mainPlayPauseButton = new System.Windows.Forms.Button();
            this.mainStopButton = new System.Windows.Forms.Button();
            this.mainNextButton = new System.Windows.Forms.Button();
            this.mainArtistLabel = new System.Windows.Forms.Label();
            this.mainTrackLabel = new System.Windows.Forms.Label();
            this.mainProgressLabel = new System.Windows.Forms.Label();
            this.mainSearchButton = new System.Windows.Forms.Button();
            this.mainPlaylistButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPrevButton
            // 
            this.mainPrevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainPrevButton.Location = new System.Drawing.Point(4, 41);
            this.mainPrevButton.Name = "mainPrevButton";
            this.mainPrevButton.Size = new System.Drawing.Size(30, 23);
            this.mainPrevButton.TabIndex = 0;
            this.mainPrevButton.Text = "<<";
            this.mainPrevButton.UseVisualStyleBackColor = true;
            // 
            // mainPlayPauseButton
            // 
            this.mainPlayPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainPlayPauseButton.Location = new System.Drawing.Point(36, 41);
            this.mainPlayPauseButton.Name = "mainPlayPauseButton";
            this.mainPlayPauseButton.Size = new System.Drawing.Size(51, 23);
            this.mainPlayPauseButton.TabIndex = 1;
            this.mainPlayPauseButton.Text = "> ||";
            this.mainPlayPauseButton.UseVisualStyleBackColor = true;
            this.mainPlayPauseButton.Click += new System.EventHandler(this.mainPlayPauseButton_Click);
            // 
            // mainStopButton
            // 
            this.mainStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainStopButton.Location = new System.Drawing.Point(89, 41);
            this.mainStopButton.Name = "mainStopButton";
            this.mainStopButton.Size = new System.Drawing.Size(30, 23);
            this.mainStopButton.TabIndex = 2;
            this.mainStopButton.Text = "[_]";
            this.mainStopButton.UseVisualStyleBackColor = true;
            // 
            // mainNextButton
            // 
            this.mainNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainNextButton.Location = new System.Drawing.Point(121, 41);
            this.mainNextButton.Name = "mainNextButton";
            this.mainNextButton.Size = new System.Drawing.Size(30, 23);
            this.mainNextButton.TabIndex = 3;
            this.mainNextButton.Text = ">>";
            this.mainNextButton.UseVisualStyleBackColor = true;
            // 
            // mainArtistLabel
            // 
            this.mainArtistLabel.AutoEllipsis = true;
            this.mainArtistLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainArtistLabel.Location = new System.Drawing.Point(5, 5);
            this.mainArtistLabel.Name = "mainArtistLabel";
            this.mainArtistLabel.Size = new System.Drawing.Size(197, 15);
            this.mainArtistLabel.TabIndex = 4;
            // 
            // mainTrackLabel
            // 
            this.mainTrackLabel.AutoEllipsis = true;
            this.mainTrackLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainTrackLabel.Location = new System.Drawing.Point(5, 22);
            this.mainTrackLabel.Name = "mainTrackLabel";
            this.mainTrackLabel.Size = new System.Drawing.Size(197, 15);
            this.mainTrackLabel.TabIndex = 5;
            // 
            // mainProgressLabel
            // 
            this.mainProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mainProgressLabel.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainProgressLabel.Location = new System.Drawing.Point(208, 5);
            this.mainProgressLabel.Name = "mainProgressLabel";
            this.mainProgressLabel.Size = new System.Drawing.Size(76, 30);
            this.mainProgressLabel.TabIndex = 6;
            this.mainProgressLabel.Text = "0:00";
            this.mainProgressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mainSearchButton
            // 
            this.mainSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSearchButton.Location = new System.Drawing.Point(256, 41);
            this.mainSearchButton.Name = "mainSearchButton";
            this.mainSearchButton.Size = new System.Drawing.Size(30, 23);
            this.mainSearchButton.TabIndex = 7;
            this.mainSearchButton.Text = "Se";
            this.mainSearchButton.UseVisualStyleBackColor = true;
            // 
            // mainPlaylistButton
            // 
            this.mainPlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPlaylistButton.Location = new System.Drawing.Point(223, 41);
            this.mainPlaylistButton.Name = "mainPlaylistButton";
            this.mainPlaylistButton.Size = new System.Drawing.Size(30, 23);
            this.mainPlaylistButton.TabIndex = 8;
            this.mainPlaylistButton.Text = "PL";
            this.mainPlaylistButton.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 15;
            this.trackBar1.Location = new System.Drawing.Point(154, 42);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(66, 22);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.TickFrequency = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 33;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // PlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 67);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.mainPlaylistButton);
            this.Controls.Add(this.mainSearchButton);
            this.Controls.Add(this.mainProgressLabel);
            this.Controls.Add(this.mainTrackLabel);
            this.Controls.Add(this.mainArtistLabel);
            this.Controls.Add(this.mainNextButton);
            this.Controls.Add(this.mainStopButton);
            this.Controls.Add(this.mainPlayPauseButton);
            this.Controls.Add(this.mainPrevButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlayerWindow";
            this.Text = "neprostopleer";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mainPrevButton;
        private System.Windows.Forms.Button mainPlayPauseButton;
        private System.Windows.Forms.Button mainStopButton;
        private System.Windows.Forms.Button mainNextButton;
        private System.Windows.Forms.Label mainArtistLabel;
        private System.Windows.Forms.Label mainTrackLabel;
        private System.Windows.Forms.Label mainProgressLabel;
        private System.Windows.Forms.Button mainSearchButton;
        private System.Windows.Forms.Button mainPlaylistButton;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

