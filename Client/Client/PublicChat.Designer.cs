namespace Client
{
    partial class PublicChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicChat));
            this.userList = new System.Windows.Forms.ListBox();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userList.ContextMenuStrip = this.menu;
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(385, 12);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(120, 316);
            this.userList.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateChat});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(139, 26);
            // 
            // privateChat
            // 
            this.privateChat.Image = global::Client.Properties.Resources.Chat_128;
            this.privateChat.Name = "privateChat";
            this.privateChat.Size = new System.Drawing.Size(138, 22);
            this.privateChat.Text = "Private Chat";
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.Color.White;
            this.txtReceive.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReceive.Location = new System.Drawing.Point(12, 12);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(367, 246);
            this.txtReceive.TabIndex = 1;
            this.txtReceive.Text = "";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 276);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(301, 52);
            this.txtInput.TabIndex = 2;
            this.txtInput.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(320, 276);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(59, 52);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // PublicChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 339);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.userList);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PublicChat";
            this.Text = "Chat - ip";
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem privateChat;
    }
}