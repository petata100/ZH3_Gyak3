namespace FormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bAdatok = new System.Windows.Forms.Button();
            this.bExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAdatok
            // 
            this.bAdatok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bAdatok.Location = new System.Drawing.Point(12, 12);
            this.bAdatok.Name = "bAdatok";
            this.bAdatok.Size = new System.Drawing.Size(113, 47);
            this.bAdatok.TabIndex = 0;
            this.bAdatok.Text = "Adatok!";
            this.bAdatok.UseVisualStyleBackColor = true;
            this.bAdatok.Click += new System.EventHandler(this.bAdatok_Click);
            // 
            // bExcel
            // 
            this.bExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bExcel.Location = new System.Drawing.Point(131, 12);
            this.bExcel.Name = "bExcel";
            this.bExcel.Size = new System.Drawing.Size(113, 47);
            this.bExcel.TabIndex = 1;
            this.bExcel.Text = "Excel!";
            this.bExcel.UseVisualStyleBackColor = true;
            this.bExcel.Click += new System.EventHandler(this.bExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 66);
            this.Controls.Add(this.bExcel);
            this.Controls.Add(this.bAdatok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Button bAdatok;
        private Button bExcel;
    }
}