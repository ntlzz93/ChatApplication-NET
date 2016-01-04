namespace Server_Chat
{
    partial class AsynServerForm
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
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(26, 12);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(380, 331);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(385, 13);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 330);
            this.vScrollBar1.TabIndex = 1;
            // 
            // AsynServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 355);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.txtLog);
            this.Name = "AsynServerForm";
            this.Text = "ServerTCP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

