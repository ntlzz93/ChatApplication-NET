namespace Server
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatWithClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.menu;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(8, 7);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(406, 194);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Address";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nickname";
            this.columnHeader2.Width = 158;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectedToolStripMenuItem,
            this.chatWithClientToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(181, 48);
            // 
            // disconnectedToolStripMenuItem
            // 
            this.disconnectedToolStripMenuItem.Name = "disconnectedToolStripMenuItem";
            this.disconnectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disconnectedToolStripMenuItem.Text = "Disconnected Client";
            // 
            // chatWithClientToolStripMenuItem
            // 
            this.chatWithClientToolStripMenuItem.Name = "chatWithClientToolStripMenuItem";
            this.chatWithClientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chatWithClientToolStripMenuItem.Text = "Chat With Client";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(8, 207);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(325, 20);
            this.txtInput.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(339, 204);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 126;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 235);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat - Server";
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem disconnectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatWithClientToolStripMenuItem;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ColumnHeader columnHeader3;

    }
}

