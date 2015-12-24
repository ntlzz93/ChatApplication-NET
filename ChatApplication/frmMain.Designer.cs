namespace ChatApplication
{
    partial class frmMain
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
            this.lblTest = new System.Windows.Forms.Label();
            this.rtbConversion = new System.Windows.Forms.RichTextBox();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ptbReceive = new System.Windows.Forms.PictureBox();
            this.ptbSender = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbReceive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSender)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(12, 9);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 13);
            this.lblTest.TabIndex = 0;
            this.lblTest.Text = "label1";
            // 
            // rtbConversion
            // 
            this.rtbConversion.Location = new System.Drawing.Point(-1, 48);
            this.rtbConversion.Name = "rtbConversion";
            this.rtbConversion.ReadOnly = true;
            this.rtbConversion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbConversion.Size = new System.Drawing.Size(624, 248);
            this.rtbConversion.TabIndex = 1;
            this.rtbConversion.Text = "";
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(-1, 321);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(552, 74);
            this.rtbMessage.TabIndex = 2;
            this.rtbMessage.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(557, 321);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(66, 74);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // ptbReceive
            // 
            this.ptbReceive.Location = new System.Drawing.Point(630, 48);
            this.ptbReceive.Name = "ptbReceive";
            this.ptbReceive.Size = new System.Drawing.Size(94, 84);
            this.ptbReceive.TabIndex = 4;
            this.ptbReceive.TabStop = false;
            // 
            // ptbSender
            // 
            this.ptbSender.Location = new System.Drawing.Point(630, 238);
            this.ptbSender.Name = "ptbSender";
            this.ptbSender.Size = new System.Drawing.Size(94, 84);
            this.ptbSender.TabIndex = 5;
            this.ptbSender.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 395);
            this.Controls.Add(this.ptbSender);
            this.Controls.Add(this.ptbReceive);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.rtbConversion);
            this.Controls.Add(this.lblTest);
            this.Name = "frmMain";
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.ptbReceive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.RichTextBox rtbConversion;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.PictureBox ptbReceive;
        private System.Windows.Forms.PictureBox ptbSender;
    }
}