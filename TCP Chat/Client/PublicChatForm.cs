using System;
using System.Windows.Forms;

namespace Client
{
    public partial class PublicChatForm : Form
    {
        public PublicChatForm()
        {
            pChat = new PrivateChatForm(this);
            InitializeComponent();
        }
        
        public readonly LoginForm formLogin = new LoginForm();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            formLogin.Client.Received += _client_Received;
            formLogin.Client.Disconnected += Client_Disconnected;
            Text = "TCP Chat - " + formLogin.txtIP.Text + " - (Connected as: " + formLogin.txtNickname.Text + ")";
            formLogin.ShowDialog();
        }

        private static void Client_Disconnected(ClientSettings cs)
        {
            
        }

        private readonly PrivateChatForm pChat;

        public void _client_Received(ClientSettings cs, string received)
        {
            DateTime time = DateTime.Now;
            var timeString = time.ToString("H:mm:ss");

            var cmd = received.Split('|');
            switch (cmd[0])
            {
                    // when connect
                case "Users":
                    this.Invoke(() =>
                    {
                        userList.Items.Clear();
                        for (int i = 1; i < cmd.Length; i++)
                        {
                            if (cmd[i] != "Connected" | cmd[i] != "RefreshChat")
                            {
                                userList.Items.Add(cmd[i]);
                            }
                        }
                    });
                    break;
                    // when receive respond message from server
                case "Message":
                    this.Invoke(() =>
                    {
                        txtReceive.Text += cmd[1] + "\r\n" + timeString + "\r\n";
                    });
                    break;
                    // when repeate content chat with server.
                case "RefreshChat":
                    this.Invoke(() =>
                    {
                        txtReceive.Text = cmd[1];
                    });
                    break;
                // open private chat by toolstrip
                case "Chat":
                    this.Invoke(() =>
                    {
                        pChat.Text = pChat.Text.Replace("user", formLogin.txtNickname.Text);
                        pChat.Show();
                    });
                    break;
                    // excute private chat
                case "pMessage":
                    this.Invoke(() =>
                    {
                        pChat.txtReceive.Text += "Server says: " + cmd[1] + "\r\n";
                    });
                    break;
                case "Disconnect":
                    Application.Exit();
                    break;
            }
        }
        /// <summary>
        /// client send public message for server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                formLogin.Client.Send("Message|" + formLogin.txtNickname.Text + "|" + txtInput.Text);
                txtReceive.Text += formLogin.txtNickname.Text + " says: " + txtInput.Text + "\r\n";
                txtInput.Text = string.Empty;
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.SelectionStart = txtReceive.TextLength;
        }

        private void privateChat_Click(object sender, EventArgs e)
        {
            formLogin.Client.Send("pChat|" + formLogin.txtNickname.Text);
        }
    }
}