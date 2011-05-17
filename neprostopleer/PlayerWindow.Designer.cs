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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWindow));
            this.mainPrevButton = new System.Windows.Forms.Button();
            this.controlsImageList = new System.Windows.Forms.ImageList(this.components);
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
            this.mainPrevButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainPrevButton.ImageKey = "gtk-media-next-rtl.png";
            this.mainPrevButton.ImageList = this.controlsImageList;
            this.mainPrevButton.Location = new System.Drawing.Point(4, 41);
            this.mainPrevButton.Name = "mainPrevButton";
            this.mainPrevButton.Size = new System.Drawing.Size(32, 25);
            this.mainPrevButton.TabIndex = 0;
            this.mainPrevButton.UseVisualStyleBackColor = true;
            // 
            // controlsImageList
            // 
            this.controlsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("controlsImageList.ImageStream")));
            this.controlsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.controlsImageList.Images.SetKeyName(0, "stock_text_right_modified.png");
            this.controlsImageList.Images.SetKeyName(1, "edit-find.png");
            this.controlsImageList.Images.SetKeyName(2, "gtk-media-forward-ltr.png");
            this.controlsImageList.Images.SetKeyName(3, "gtk-media-forward-rtl.png");
            this.controlsImageList.Images.SetKeyName(4, "gtk-media-next-ltr.png");
            this.controlsImageList.Images.SetKeyName(5, "gtk-media-next-rtl.png");
            this.controlsImageList.Images.SetKeyName(6, "gtk-media-pause.png");
            this.controlsImageList.Images.SetKeyName(7, "gtk-media-play-ltr.png");
            this.controlsImageList.Images.SetKeyName(8, "gtk-media-previous-ltr.png");
            this.controlsImageList.Images.SetKeyName(9, "gtk-media-previous-rtl.png");
            this.controlsImageList.Images.SetKeyName(10, "gtk-media-record.png");
            this.controlsImageList.Images.SetKeyName(11, "gtk-media-rewind-ltr.png");
            this.controlsImageList.Images.SetKeyName(12, "gtk-media-rewind-rtl.png");
            this.controlsImageList.Images.SetKeyName(13, "gtk-media-stop.png");
            this.controlsImageList.Images.SetKeyName(14, "stock_text_right_modified_gray.png");
            this.controlsImageList.Images.SetKeyName(15, "Search_24x24.png");
            // 
            // mainPlayPauseButton
            // 
            this.mainPlayPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainPlayPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainPlayPauseButton.ImageKey = "gtk-media-play-ltr.png";
            this.mainPlayPauseButton.ImageList = this.controlsImageList;
            this.mainPlayPauseButton.Location = new System.Drawing.Point(37, 41);
            this.mainPlayPauseButton.Name = "mainPlayPauseButton";
            this.mainPlayPauseButton.Size = new System.Drawing.Size(51, 25);
            this.mainPlayPauseButton.TabIndex = 1;
            this.mainPlayPauseButton.UseVisualStyleBackColor = true;
            this.mainPlayPauseButton.Click += new System.EventHandler(this.mainPlayPauseButton_Click);
            // 
            // mainStopButton
            // 
            this.mainStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainStopButton.ImageKey = "gtk-media-stop.png";
            this.mainStopButton.ImageList = this.controlsImageList;
            this.mainStopButton.Location = new System.Drawing.Point(89, 41);
            this.mainStopButton.Name = "mainStopButton";
            this.mainStopButton.Size = new System.Drawing.Size(30, 25);
            this.mainStopButton.TabIndex = 2;
            this.mainStopButton.UseVisualStyleBackColor = true;
            // 
            // mainNextButton
            // 
            this.mainNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainNextButton.ImageKey = "gtk-media-next-ltr.png";
            this.mainNextButton.ImageList = this.controlsImageList;
            this.mainNextButton.Location = new System.Drawing.Point(120, 41);
            this.mainNextButton.Name = "mainNextButton";
            this.mainNextButton.Size = new System.Drawing.Size(32, 25);
            this.mainNextButton.TabIndex = 3;
            this.mainNextButton.UseVisualStyleBackColor = true;
            // 
            // mainArtistLabel
            // 
            this.mainArtistLabel.AutoEllipsis = true;
            this.mainArtistLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainArtistLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainArtistLabel.Location = new System.Drawing.Point(5, 5);
            this.mainArtistLabel.Name = "mainArtistLabel";
            this.mainArtistLabel.Size = new System.Drawing.Size(197, 15);
            this.mainArtistLabel.TabIndex = 4;
            // 
            // mainTrackLabel
            // 
            this.mainTrackLabel.AutoEllipsis = true;
            this.mainTrackLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainTrackLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
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
            this.mainSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainSearchButton.ImageKey = "Search_24x24.png";
            this.mainSearchButton.ImageList = this.controlsImageList;
            this.mainSearchButton.Location = new System.Drawing.Point(256, 41);
            this.mainSearchButton.Name = "mainSearchButton";
            this.mainSearchButton.Size = new System.Drawing.Size(30, 25);
            this.mainSearchButton.TabIndex = 7;
            this.mainSearchButton.UseVisualStyleBackColor = true;
            this.mainSearchButton.Click += new System.EventHandler(this.mainSearchButton_Click);
            // 
            // mainPlaylistButton
            // 
            this.mainPlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainPlaylistButton.ImageKey = "stock_text_right_modified_gray.png";
            this.mainPlaylistButton.ImageList = this.controlsImageList;
            this.mainPlaylistButton.Location = new System.Drawing.Point(223, 41);
            this.mainPlaylistButton.Name = "mainPlaylistButton";
            this.mainPlaylistButton.Size = new System.Drawing.Size(30, 25);
            this.mainPlaylistButton.TabIndex = 8;
            this.mainPlaylistButton.UseVisualStyleBackColor = true;
            this.mainPlaylistButton.Click += new System.EventHandler(this.mainPlaylistButton_Click);
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
            this.trackBar1.Size = new System.Drawing.Size(66, 24);
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
        private System.Windows.Forms.ImageList controlsImageList;
    }
}

