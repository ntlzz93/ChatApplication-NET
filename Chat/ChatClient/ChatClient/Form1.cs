using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace ChatClient
{
    public partial class Form1 : Form
    {
        byte[] data = new byte[1024];
        string input;
        int port;
        TcpClient server;
        int recv;
        string stringData;
        public Form1()
        {
            InitializeComponent();
            Form_Load();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Form_Load()
        {
            rtbContent.AppendText("Please Enter the port number of Server:\n");
            //rtbContent.Text = "Please Enter the port number of Server:\n";
        }
        /// <summary>
        /// Function connect to server with port number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            input = txtPort.Text;
            port = Int32.Parse(input);
            try
            {
                server = new TcpClient("127.0.0.1", port);
            }
            catch (SocketException)
            {
                rtbContent.AppendText("Unable to connect to server");
                return;
            }
            rtbContent.AppendText("Connected to Server...\n");
            //rtbContent.Text = "Connected to Server...\n";
        }
        /// <summary>
        /// This function is used to display data in Rick Text Box
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtbContent.InvokeRequired)
            {
               // SetTextCallback d = new SetTextCallback(SetText);
                //this.Invoke(d, new object[] { text });
            }
            else
            {
                this.rtbContent.SelectionColor = Color.Blue;
                this.rtbContent.SelectedText = "\nFriend: " + text;
            }
        }
        /// <summary>
        /// Function send data to server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                    NetworkStream ns = server.GetStream();
                    StateObject state = new StateObject();
                    state.workSocket = server.Client;
                    server.Client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                          new AsyncCallback((new Form1()).OnReceive), state);

                    input = rtbSend.Text;

                    ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                    //ns.Flush();

                    rtbContent.AppendText("Me "+rtbSend.Text + "\n");
                    rtbSend.Text = "";

                    //receiveData(ns);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Send Button", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Event called when server send data for client.
        /// </summary>
       
        private void receiveData(NetworkStream ns)
        {
            //NetworkStream ns = server.GetStream();
            //StateObject state = new StateObject();
            //server.Client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            //      new AsyncCallback((new Form1()).OnReceive), state);
            data = new byte[1024];
            recv = ns.Read(data, 0, data.Length);
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            rtbContent.AppendText("Friend "+stringData+"\n");

        }
        /// <summary>
        /// Event called when Form close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(Object sender, FormClosedEventArgs e)
        {
            rtbContent.Text = "Disconnecting from server...";
            server.Close();
            MessageBox.Show( "FormClosed Event");
        }
        /// <summary>
        /// Asynchronous Callback function which receives data from client
        /// </summary>
        /// <param name="ar"></param>
        public void OnReceive(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead;

            if (handler.Connected)
            {

                // Read data from the client socket. 
                try
                {
                    bytesRead = handler.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        // There  might be more data, so store the data received so far.
                        state.sb.Remove(0, state.sb.Length);
                        state.sb.Append(Encoding.ASCII.GetString(
                                         state.buffer, 0, bytesRead));

                        // Display Text in Rich Text Box
                        content = state.sb.ToString();
                        rtbContent.AppendText(content.ToString());

                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(OnReceive), state);

                    }
                }

                catch (SocketException socketException)
                {
                    //WSAECONNRESET, the other side closed impolitely
                    if (socketException.ErrorCode == 10054 || ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
                    {
                        handler.Close();
                    }
                }

            // Eat up exception....
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + "\n" + exception.StackTrace);

                }
            }
        }
    }
    /// <summary>
    /// Server receive state
    /// </summary>
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
}
