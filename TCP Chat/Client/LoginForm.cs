using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        public ClientSettings Client { get; set; }

        public LoginForm()
        {
            Client = new ClientSettings();
            InitializeComponent();
        }
        string path = @"D:\Study\user.txt";
        private void btnConnect_Click(object sender, EventArgs e)
        {
                string readText = File.ReadAllText(path);
                if (readText.Contains(txtNickname.Text))
                {
                    MessageBox.Show("nickname existed","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    Client.Connected += Client_Connected;
                    Client.Connect(txtIP.Text, 2016);
                    Client.Send("Connect|" + txtNickname.Text + "|connected");
                }        
        }

        private void Client_Connected(object sender, EventArgs e)
        {
            this.Invoke(Close);
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        
    }
}