using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace KunomiClient
{
    //The commands for interaction between the server and the client
    enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        List,       //Get a list of users in the chat room from the server
        MediaURL,   //The URL of the media to play
        Play,       //The user plays or pauses the media
        Buffering,  //The user is buffering
        Time,       //Set the time of media playback
        LocalResync,//The user wants to resync
        Null        //No command
    }

    public partial class KunomiClient : Form
    {
        public Socket clientSocket; //The main client socket
        public string strName;      //Name by which the user logs into the room
        public EndPoint epServer;   //The EndPoint of the server
        public CustomLabel notification = new CustomLabel(); // The notification which appears on the top left corner.
        System.Media.SoundPlayer sPlayer = new System.Media.SoundPlayer(); // Plays user interface sounds.

        byte []byteData = new byte[1024];

        /// <summary>
        /// Initializes the main client form, setting properties for controls not possible with the visual editor.
        /// </summary>
        public KunomiClient()
        {
            InitializeComponent();
            mediaPlayer.SendToBack();
            mediaPlayer.uiMode = "none";
            mediaPlayer.network.bufferingTime = 10000;
            mediaPlayer.stretchToFit = true;
            mediaPlayer.enableContextMenu = false;
        }

        /// <summary>
        /// Displays information that is required to be constantly updated per frame for the user.
        /// </summary>
        private void frameUpdate() {
            try {
                timeDetails.Text = mediaPlayer.currentMedia.durationString + " / " + mediaPlayer.Ctlcontrols.currentPositionString;
            } catch {
                timeDetails.Text = "No media playing";
            }
            
            Thread.Sleep(100);
            frameUpdate();
        }

        //Broadcast the message typed by the user to everyone
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {		
                //Fill the info for the message to be send
                Data msgToSend = new Data();
                
                msgToSend.strName = strName;
                msgToSend.strMessage = txtMessage.Text;
                msgToSend.cmdCommand = Command.Message;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSendTo (byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to send message to the server.", "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
        
        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// When the user recieves a command from the server.
        /// </summary>
        /// <param name="ar"></param>
        private void OnReceive(IAsyncResult ar)
        {            
            try
            {                
                clientSocket.EndReceive(ar);

                //Convert the bytes received into an object of type Data
                Data msgReceived = new Data(byteData);

                //Accordingly process the message received
                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:
                        lstChatters.Items.Add(msgReceived.strName);
                        break;

                    case Command.Logout:
                        lstChatters.Items.Remove(msgReceived.strName);
                        break;

                    case Command.Message:
                        break;

                    case Command.List:
                        lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
                        lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
                        string msg = "\r\n<<<" + strName + " has joined the room>>>";
                        txtChatBox.Text += msg;
                        txtChatBox.SelectionStart = txtChatBox.Text.Length;
                        txtChatBox.ScrollToCaret();
                        pushNotification(msg, Color.Green);
                        break;

                    case Command.MediaURL:
                        mediaPlayer.URL = msgReceived.strMessage;
                        isPaused = false;
                        playPause(true);
                        break;

                    case Command.Time:
                        mediaPlayer.Ctlcontrols.currentPosition = double.Parse(msgReceived.strMessage);
                        string msgT = "\r\n<<<" + strName + " has re-synced the room.>>>";
                        txtChatBox.Text += msgT;
                        txtChatBox.SelectionStart = txtChatBox.Text.Length;
                        txtChatBox.ScrollToCaret();
                        pushNotification(msgT, Color.Orange);
                        break;

                    case Command.LocalResync:
                        string[] resync = msgReceived.strMessage.Split('*');
                        if (resync[0] == "2") {
                            try {
                                //Fill the info for the message to be send
                                Data msgToSend = new Data();

                                msgToSend.strName = msgReceived.strName;
                                msgToSend.strMessage = "3*" + mediaPlayer.Ctlcontrols.currentPosition + "*" + isPaused.ToString();

                                msgToSend.cmdCommand = Command.LocalResync;

                                byte[] byteData = msgToSend.ToByte();

                                //Send it to the server
                                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                                txtMessage.Text = null;
                            }
                            catch (Exception) {
                                MessageBox.Show("Unable to send message to the server.", "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } else if (resync[0] == "3") {
                            mediaPlayer.Ctlcontrols.currentPosition = Convert.ToDouble(resync[1]);
                            if (resync[2] == "True") {
                                isPaused = false;
                                playPause(true);
                            }
                            else {
                                isPaused = true;
                                playPause(true);
                            }
                        }
                        break;

                    case Command.Buffering:
                        if (msgReceived.strMessage == "TRUE") {
                            isPaused = false;
                            playPause(true);
                        } else {
                            isPaused = true;
                            playPause(true);
                        }
                            break;

                    case Command.Play:
                        string msgP;
                        if (msgReceived.strMessage == "PLAY") {
                            isPaused = true;
                            playPause(true);
                            msgP = "\r\n<<<" + strName + " has resumed the video>>>";
                            txtChatBox.Text += msgP;
                            txtChatBox.SelectionStart = txtChatBox.Text.Length;
                            txtChatBox.ScrollToCaret();
                        } else {
                            isPaused = false;
                            playPause(true);
                            msgP = "\r\n<<<" + strName + " has paused the video>>>";
                            txtChatBox.Text += msgP;
                            txtChatBox.SelectionStart = txtChatBox.Text.Length;
                            txtChatBox.ScrollToCaret();
                        }
                        pushNotification(msgP, Color.Blue);
                        break;
                }
                if (msgReceived.cmdCommand == Command.MediaURL) {
                    string msgM = "\r\n" + "The video source has changed to: " + '"' + msgReceived.strMessage + '"';
                    txtChatBox.Text += msgM;
                    txtChatBox.SelectionStart = txtChatBox.Text.Length;
                    txtChatBox.ScrollToCaret();
                    pushNotification(msgM, Color.Pink);
                }
                else if (msgReceived.cmdCommand == Command.Play || msgReceived.cmdCommand == Command.Time) {

                }
                else if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List) {
                    string msgN = "\r\n" + msgReceived.strMessage;
                    txtChatBox.Text += msgN;
                    txtChatBox.SelectionStart = txtChatBox.Text.Length;
                    txtChatBox.ScrollToCaret();
                    pushNotification(msgN, Color.White);
                }

                byteData = new byte[1024];                

                //Start listening to receive more data from the user
                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epServer,
                                           new AsyncCallback(OnReceive), null);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kunomi Client: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Display a pop-up notification with the desired text and color.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="tColor"></param>
        private void pushNotification(string notification, Color tColor) {
            popupLabel.ForeColor = tColor;
            popupLabel.Text = notification;
            popupLabel.Visible = true;
            notIntervals = 50;
        }
        int notIntervals = 0;

        /// <summary>
        /// Set the visibility of the pop-up to zero, once the notification intervals has reached zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notificationTimed(object sender, EventArgs e) {
            if (notIntervals == 0) {
                popupLabel.Visible = false;
            } else {
                notIntervals--;
            }
        }

        /// <summary>
        /// First-time commands and setups for the client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
	    CheckForIllegalCrossThreadCalls = false;

            this.Text = "Kunomi: " + strName;
            
            //The user has logged into the system so we now request the server to send
            //the names of all users who are in the chat room
            Data msgToSend = new Data ();
            msgToSend.cmdCommand = Command.List;
            msgToSend.strName = strName;
            msgToSend.strMessage = null;

            byteData = msgToSend.ToByte();

            clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, 
                new AsyncCallback(OnSend), null);

            byteData = new byte[1024];
            try {
                //Start listening to the data asynchronously
                clientSocket.BeginReceiveFrom(byteData,
                                           0, byteData.Length,
                                           SocketFlags.None,
                                           ref epServer,
                                           new AsyncCallback(OnReceive),
                                           null);
                sPlayer.Stream = Properties.Resources.Welcome;
                sPlayer.Play();
            } catch {
                sPlayer.Stream = Properties.Resources.Critical;
                sPlayer.Play();
                MessageBox.Show("Could not reach the host.");
                Environment.FailFast("Could not reach the host.");
            }

        }

        /// <summary>
        /// When the user begins typing a message, enable the send message button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }

        /// <summary>
        /// Prompts the user if they want to exit, and then logs out of the server before terminating the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kunomi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to leave the room?", "Kunomi: " + strName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                //Send a message to logout of the server
                Data msgToSend = new Data ();
                msgToSend.cmdCommand = Command.Logout;
                msgToSend.strName = strName;
                msgToSend.strMessage = null;

                byte[] b = msgToSend.ToByte ();
                clientSocket.SendTo(b, 0, b.Length, SocketFlags.None, epServer);
                clientSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// If the user presses the 'Enter' key while the message box is the selected control, attempt to send the message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, null);
            }
        }

        /// <summary>
        /// Toggles playback of media.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playPauseBtn_Click(object sender, EventArgs e) {
            playPause(false);
        }

        bool isPaused = true;

        /// <summary>
        /// Pauses or plays the media for the client.
        /// </summary>
        /// <param name="auto"></param>
        private void playPause(bool auto) {
            if (isPaused) {
                playPauseBtn.Text = ";";
                isPaused = false;
                mediaPlayer.Ctlcontrols.play();
                if (!auto) {
                    play();
                }
            } else {
                playPauseBtn.Text = "4";
                isPaused = true;
                mediaPlayer.Ctlcontrols.pause();
                if (!auto) {
                    play();
                }
            }
        }

        /// <summary>
        /// Sends the current play-back time of this user to the server.
        /// </summary>
        /// <param name="time"></param>
        private void time(double time) {
            try {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.strName = strName;
                msgToSend.strMessage = time.ToString();
                msgToSend.cmdCommand = Command.Time;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                txtMessage.Text = null;
            }
            catch (Exception) {
                MessageBox.Show("Unable to send message to the server.", "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sends either a play or pause command to the server, so all other clients are in the same play-back state.
        /// </summary>
        private void play() {
            try {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.strName = strName;
                if (isPaused) {
                    msgToSend.strMessage = "PAUSE";
                } else {
                    msgToSend.strMessage = "PLAY";
                }
                msgToSend.cmdCommand = Command.Play;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                txtMessage.Text = null;
            }
            catch (Exception) {
                MessageBox.Show("Unable to send message to the server.", "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// If this client has halted playback due to buffering, notify all other clients to pause, and
        /// resume once buffering has completed.
        /// </summary>
        /// <param name="start"></param>
        private void buffering(bool start) {
            try {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.strName = strName;
                if (start) {
                    msgToSend.strMessage = "TRUE";
                }
                else {
                    msgToSend.strMessage = "FALSE";
                }
                msgToSend.cmdCommand = Command.Buffering;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                txtMessage.Text = null;
            }
            catch (Exception) {
                MessageBox.Show("Unable to send message to the server.", "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool isFullscreen = false;

        /// <summary>
        /// Toggls full-screen mode of the program between windowed/maximized, and borderless fullscreen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullscreenBtn_Click(object sender, EventArgs e) {
            if (isFullscreen) {
                isFullscreen = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            } else {
                isFullscreen = true;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                MouseInForm();
            }
        }

        private bool mEntered;

        /// <summary>
        /// Sets various properties on regular intervals.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void globalTimer_Tick(object sender, EventArgs e) {
            try {
                timeDetails.Text = mediaPlayer.Ctlcontrols.currentPositionString + " / " + mediaPlayer.currentMedia.durationString;
                playPauseBtn.Enabled = true;

                if (!timeSelected) {
                    double timeRelative = mediaPlayer.Ctlcontrols.currentPosition / mediaPlayer.currentMedia.duration;
                    timeTrack.Value = Convert.ToInt32(timeRelative * 1000);
                }
            }
            catch {
                timeDetails.Text = "No media playing";
                playPauseBtn.Enabled = false;
            }

            Point pos = this.PointToClient(Cursor.Position);

            // Make it so that when fullscreen, the UI will still hide on edge.
            Rectangle cropped = this.ClientRectangle;
            cropped.Width -= 2;
            bool entered = cropped.Contains(pos);

            // Check if the cursor is on the screen.
            if (entered != mEntered) {
                mEntered = entered;
                if (!entered) {
                    MouseOutOfForm();
                } else {
                    MouseInForm();
                }
            }
        }

        /// <summary>
        /// Hides UI elements and resizes media player to full screen when mouse is out of the window.
        /// </summary>
        private void MouseOutOfForm() {
            messaging.Visible = false;
            users.Visible = false;
            playerControls.Visible = false;
            volumeBar.Visible = false;
            mediaPlayer.Height = this.Height;
            mediaPlayer.Width = this.Width;
            mediaPlayer.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Shows UI elements and crops media player when mouse is in the window.
        /// </summary>
        private void MouseInForm() {
            messaging.Visible = true;
            users.Visible = true;
            playerControls.Visible = true;
            mediaPlayer.Dock = DockStyle.None;
            int fullscreenOffset;
            if (isFullscreen) {
                fullscreenOffset = 0;
            } else {
                fullscreenOffset = 40;
            }
            mediaPlayer.Height = (this.Height - fullscreenOffset) - (messaging.Height + playerControls.Height);
            mediaPlayer.Width = (this.Width - (fullscreenOffset / 2)) - users.Width;
        }

        /// <summary>
        /// Show the volume bar when the volume icon is hovered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeEnter(object sender, EventArgs e) {
            volumeBar.Visible = true;
        }


        /// <summary>
        /// Hide the volume bar when the user leaves the volume icon or the bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeLeave(object sender, EventArgs e) {
            volumeBar.Visible = false;
        }

        /// <summary>
        /// Sets the volume of the media player in relation to the volume bar setting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeChanged(object sender, EventArgs e) {
            mediaPlayer.settings.volume = volumeBar.Value;
        }

        /// <summary>
        /// Sets all other clients play-back time to match this client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void globalResync(object sender, EventArgs e) {
            time(mediaPlayer.Ctlcontrols.currentPosition);
        }

        bool timeSelected = false;

        /// <summary>
        /// Shows the selected time while dragging the timeline.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeChangeSelected(object sender, MouseEventArgs e) {
            timeSelected = true;
        }

        /// <summary>
        /// Change the media playback position in relation to the time selected by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeSelectionChanged(object sender, MouseEventArgs e) {
            try {
                timeSelected = false;
                double percentage = Convert.ToDouble(timeTrack.Value) / 1000;
                time(mediaPlayer.currentMedia.duration * percentage);
            } catch {

            }
        }

        /// <summary>
        /// TODO: Not implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localResync_Click(object sender, EventArgs e) {
            Resync();
        }

        /// <summary>
        /// TODO: Not yet finished, resyncs this user to others by a method not yet thought of.
        /// </summary>
        private void Resync() {
            try {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.strName = strName;
                msgToSend.strMessage = "1*0*0";
                msgToSend.cmdCommand = Command.LocalResync;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                txtMessage.Text = null;
            }
            catch (Exception) {
                MessageBox.Show("Unable to send message to the server.", "Kunomi: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    //The data structure by which the server and the client interact with 
    //each other
    class Data
    {
        //Default constructor
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
        }

        //Converts the bytes into an object of type Data
        public Data(byte[] data)
        {
            //The first four bytes are for the Command
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            //The next four store the length of the name
            int nameLen = BitConverter.ToInt32(data, 4);

            //The next four store the length of the message
            int msgLen = BitConverter.ToInt32(data, 8);

            //This check makes sure that strName has been passed in the array of bytes
            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;

            //This checks for a null message field
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }

        //Converts the Data structure into an array of bytes
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //First four are for the Command
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //Add the length of the name
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Length of the message
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Add the name
            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            //And, lastly we add the message text to our array of bytes
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string strName;      //Name by which the client logs into the room
        public string strMessage;   //Message text
        public Command cmdCommand;  //Command type (login, logout, send message, etcetera)
    }
}