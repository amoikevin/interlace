﻿namespace BitTunnelClientExample.Controls
{
    partial class LoggingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _log
            // 
            this._log.Dock = System.Windows.Forms.DockStyle.Fill;
            this._log.Location = new System.Drawing.Point(0, 0);
            this._log.Name = "_log";
            this._log.Size = new System.Drawing.Size(693, 150);
            this._log.TabIndex = 0;
            this._log.Text = "";
            // 
            // LoggingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._log);
            this.Name = "LoggingControl";
            this.Size = new System.Drawing.Size(693, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _log;
    }
}
