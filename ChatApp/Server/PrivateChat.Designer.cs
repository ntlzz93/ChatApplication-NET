namespace Client
{
    partial class PrivateChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivateChat));
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(320, 276);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(59, 52);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 276);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(301, 52);
            this.txtInput.TabIndex = 5;
            this.txtInput.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.Color.White;
            this.txtReceive.Location = new System.Drawing.Point(12, 12);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(367, 246);
            this.txtReceive.TabIndex = 4;
            this.txtReceive.Text = "";
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 339);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtReceive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrivateChat";
            this.Text = "PrivateChat - user";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.RichTextBox txtReceive;
    }
}