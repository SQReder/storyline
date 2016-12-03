namespace Storyline
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
            this.btnSave = new System.Windows.Forms.Button();
            this.textSize = new System.Windows.Forms.TextBox();
            this.btnRefit = new System.Windows.Forms.Button();
            this.btnNewImageSet = new System.Windows.Forms.Button();
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(700, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textSize
            // 
            this.textSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textSize.Location = new System.Drawing.Point(700, 355);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(155, 20);
            this.textSize.TabIndex = 2;
            this.textSize.Text = "1000";
            this.textSize.TextChanged += new System.EventHandler(this.textSize_TextChanged);
            // 
            // btnRefit
            // 
            this.btnRefit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefit.Location = new System.Drawing.Point(700, 381);
            this.btnRefit.Name = "btnRefit";
            this.btnRefit.Size = new System.Drawing.Size(155, 23);
            this.btnRefit.TabIndex = 3;
            this.btnRefit.Text = "Refit";
            this.btnRefit.UseVisualStyleBackColor = true;
            this.btnRefit.Click += new System.EventHandler(this.btnRefit_Click);
            // 
            // btnNewImageSet
            // 
            this.btnNewImageSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewImageSet.Location = new System.Drawing.Point(539, 410);
            this.btnNewImageSet.Name = "btnNewImageSet";
            this.btnNewImageSet.Size = new System.Drawing.Size(155, 23);
            this.btnNewImageSet.TabIndex = 4;
            this.btnNewImageSet.Text = "New set";
            this.btnNewImageSet.UseVisualStyleBackColor = true;
            this.btnNewImageSet.Click += new System.EventHandler(this.btnNewImageSet_Click);
            // 
            // cbDebug
            // 
            this.cbDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDebug.AutoSize = true;
            this.cbDebug.Location = new System.Drawing.Point(539, 385);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(122, 17);
            this.cbDebug.TabIndex = 5;
            this.cbDebug.Text = "Draw debug borders";
            this.cbDebug.UseVisualStyleBackColor = true;
            this.cbDebug.CheckedChanged += new System.EventHandler(this.cbDebug_CheckedChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.Filter = "jpg files|*.jpg";
            this.saveFileDialog.InitialDirectory = ".";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 445);
            this.Controls.Add(this.cbDebug);
            this.Controls.Add(this.btnNewImageSet);
            this.Controls.Add(this.btnRefit);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textSize;
        private System.Windows.Forms.Button btnRefit;
        private System.Windows.Forms.Button btnNewImageSet;
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

