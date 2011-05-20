namespace neprostopleer
{
    partial class LogWindow
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
            this.logListBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // logListBox1
            // 
            this.logListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListBox1.FormattingEnabled = true;
            this.logListBox1.Location = new System.Drawing.Point(0, 0);
            this.logListBox1.Name = "logListBox1";
            this.logListBox1.Size = new System.Drawing.Size(292, 273);
            this.logListBox1.TabIndex = 0;
            // 
            // LogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.logListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LogWindow";
            this.Text = "Log";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox logListBox1;


    }
}