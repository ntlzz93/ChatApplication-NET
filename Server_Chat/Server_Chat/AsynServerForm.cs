using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;


namespace Server_Chat
{
    // The commands for iteraction between the server and the client.
    enum Command
    {
        Login,  // Log into the server
        Logout, // Logout of the server
        Message,// Send a text message to all the chat clients
        List,   // Get a list of users in the chat room from the server
        Null    // No command
    }
    public partial class AsynServerForm : Form
    {
        /// <summary>
        /// Information of Client.
        /// </summary>
        /// <attribute name="socket">Socket of the client</attribute>
        /// <attribute name="strName">Name of user logged into the chat room.</attribute>
        struct ClientInfo
        {
            public Socket socket;
            public string strName;
        }

        //The collection of all clients logged into the room
        ArrayList clientList;

        //The main socket on which the server listens to the clients
        Socket serverSocket;

        byte[] byteData = new byte[1024];

        public AsynServerForm()
        {
            clientList = new ArrayList();
            InitializeComponent();
        }
        /// <summary>
        /// Event called when Form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Port default: 11000
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 11000);

                //Bind and Listen on the given address
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(10);

                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);


                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server",
                   MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndReceive(ar);

                Data msgReceived = new Data(byteData);

                Data msgToSend = new Data();

                byte[] message;

                msgToSend.cmdCommand = msgReceived.cmdCommand;
                msgToSend.strName = msgReceived.strName;
                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:
                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.socket = clientSocket;
                        clientInfo.strName = msgReceived.strName;

                        clientList.Add(clientInfo);

                        msgToSend.strMessage = "<<<" + msgReceived.strName + " has joined the room >>>";
                        break;

                    case Command.Logout:
                        int nIndex = 0;
                        foreach (ClientInfo client in clientList)
                        {
                            if (client.socket == clientSocket)
                            {
                                clientList.RemoveAt(nIndex);
                                break;
                            }
                            ++nIndex;
                        }
                        clientSocket.Close();
                        msgToSend.strMessage = "<<<" + msgReceived.strName + " has left the room >>> ";
                        break;

                    case Command.Message:
                        // Broadcast to all users
                        msgToSend.strMessage = msgReceived.strName + ": " + msgReceived.strMessage;
                        break;
                    case Command.List:
                        // Send the names of all users in the chat room to the new user
                        msgToSend.cmdCommand = Command.List;
                        msgToSend.strName = null;
                        msgToSend.strMessage = null;

                        //Collect the names of the user in the chat room
                        foreach (ClientInfo client in clientList)
                        {
                            msgToSend.strMessage += client.strName + "*";
                        }
                        message = msgToSend.toByte();
                        clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,new AsyncCallback(OnSend),clientSocket);
                        break;
                }
                if (msgToSend.cmdCommand != Command.List)
                {
                    message = msgToSend.toByte();
                    foreach (ClientInfo clientInfo in clientList)
                    {
                        if (clientInfo.socket != clientSocket || msgToSend.cmdCommand != Command.Login)
                        {
                            // Send the message to all users
                            clientInfo.socket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), clientInfo.socket);
                        }
                    }

                    txtLog.Text += msgToSend.strMessage + "\r\n";
                }

                if (msgReceived.cmdCommand != Command.Logout)
                {
                    clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    class Data
    {
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
        }
        /// <summary>
        /// Converts the bytes into object of type Data
        /// </summary>
        /// <param name="data"></param>
        public Data(byte[] data)
        {
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);
            int nameLen = BitConverter.ToInt32(data, 4);
            int msgLen = BitConverter.ToInt32(data, 8);
            if (nameLen > 0)
            {
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            }
            else
            {
                this.strName = null;
            }
            if (msgLen > 0)
            {
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            }
            else
            {
                this.strMessage = null;
            }
        }

        public byte[] toByte()
        {
            List<byte> result = new List<byte>();

            // First four are for the Command
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));
            //Add the lenght of the name
            if (strName != null)
            {
                result.AddRange(BitConverter.GetBytes(strName.Length));
            }
            else
            {
                result.AddRange(BitConverter.GetBytes(0));
            }
            //Lenght of the message
            if (strMessage != null)
            {
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            }
            else
            {
                result.AddRange(BitConverter.GetBytes(0));
            }
            //Add the name
            if (strName != null)
            {
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));
            }
            //Add message text to our array of bytes
            if (strMessage != null)
            {
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));
            }
            return result.ToArray();
        }
        // Name of client logs into the room
        public string strName;
        // Message text
        public string strMessage;
        // Command type(login,logout,send message,..)
        public Command cmdCommand;
    }
}
