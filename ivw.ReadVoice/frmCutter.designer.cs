﻿namespace ivw.ReadVoice
{
    partial class frmCutter
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
            this.SuspendLayout();
            // 
            // frmCutter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCutter";
            this.Text = "frmCutter";
            this.Load += new System.EventHandler(this.FrmCutter_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmCutter_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmCutter_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmCutter_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmCutter_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmCutter_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}