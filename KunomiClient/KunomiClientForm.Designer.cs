namespace KunomiClient {
    partial class KunomiClient {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KunomiClient));
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChatBox = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lstChatters = new System.Windows.Forms.ListBox();
            this.users = new System.Windows.Forms.GroupBox();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.messaging = new System.Windows.Forms.GroupBox();
            this.playerControls = new System.Windows.Forms.GroupBox();
            this.localResync = new System.Windows.Forms.Button();
            this.globalTrack = new System.Windows.Forms.Button();
            this.audioButton = new System.Windows.Forms.Button();
            this.timeDetails = new System.Windows.Forms.Label();
            this.timeTrack = new System.Windows.Forms.TrackBar();
            this.fullscreenBtn = new System.Windows.Forms.Button();
            this.playPauseBtn = new System.Windows.Forms.Button();
            this.globalTimer = new System.Windows.Forms.Timer(this.components);
            this.bufferringLabel = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.popupLabel = new System.Windows.Forms.Label();
            this.notTimer = new System.Windows.Forms.Timer(this.components);
            this.users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.messaging.SuspendLayout();
            this.playerControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.Gray;
            this.btnSend.Location = new System.Drawing.Point(498, 109);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 21);
            this.btnSend.TabIndex = 0;
            this.btnSend.Tag = "Broadcasts a message.";
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChatBox
            // 
            this.txtChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChatBox.ForeColor = System.Drawing.Color.White;
            this.txtChatBox.Location = new System.Drawing.Point(6, 16);
            this.txtChatBox.Multiline = true;
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.ReadOnly = true;
            this.txtChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatBox.Size = new System.Drawing.Size(567, 87);
            this.txtChatBox.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(6, 108);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(486, 22);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // lstChatters
            // 
            this.lstChatters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstChatters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstChatters.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstChatters.ForeColor = System.Drawing.Color.White;
            this.lstChatters.FormattingEnabled = true;
            this.lstChatters.Location = new System.Drawing.Point(3, 19);
            this.lstChatters.Name = "lstChatters";
            this.lstChatters.Size = new System.Drawing.Size(116, 159);
            this.lstChatters.TabIndex = 4;
            // 
            // users
            // 
            this.users.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.users.BackColor = System.Drawing.Color.Transparent;
            this.users.Controls.Add(this.lstChatters);
            this.users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.users.Font = new System.Drawing.Font("Leelawadee UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.users.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.users.Location = new System.Drawing.Point(580, 0);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(122, 181);
            this.users.TabIndex = 5;
            this.users.TabStop = false;
            this.users.Text = "Users";
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(704, 441);
            this.mediaPlayer.TabIndex = 6;
            // 
            // messaging
            // 
            this.messaging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.messaging.BackColor = System.Drawing.Color.Transparent;
            this.messaging.Controls.Add(this.txtMessage);
            this.messaging.Controls.Add(this.btnSend);
            this.messaging.Controls.Add(this.txtChatBox);
            this.messaging.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messaging.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.messaging.Location = new System.Drawing.Point(0, 223);
            this.messaging.Name = "messaging";
            this.messaging.Size = new System.Drawing.Size(579, 136);
            this.messaging.TabIndex = 7;
            this.messaging.TabStop = false;
            this.messaging.Text = "Messaging";
            // 
            // playerControls
            // 
            this.playerControls.Controls.Add(this.localResync);
            this.playerControls.Controls.Add(this.globalTrack);
            this.playerControls.Controls.Add(this.audioButton);
            this.playerControls.Controls.Add(this.timeDetails);
            this.playerControls.Controls.Add(this.timeTrack);
            this.playerControls.Controls.Add(this.fullscreenBtn);
            this.playerControls.Controls.Add(this.playPauseBtn);
            this.playerControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerControls.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerControls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.playerControls.Location = new System.Drawing.Point(0, 359);
            this.playerControls.Name = "playerControls";
            this.playerControls.Size = new System.Drawing.Size(704, 82);
            this.playerControls.TabIndex = 8;
            this.playerControls.TabStop = false;
            this.playerControls.Text = "Player Controls";
            // 
            // localResync
            // 
            this.localResync.Enabled = false;
            this.localResync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.localResync.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Bold);
            this.localResync.ForeColor = System.Drawing.Color.Silver;
            this.localResync.Location = new System.Drawing.Point(130, 18);
            this.localResync.Margin = new System.Windows.Forms.Padding(0);
            this.localResync.Name = "localResync";
            this.localResync.Size = new System.Drawing.Size(35, 35);
            this.localResync.TabIndex = 6;
            this.localResync.Tag = "Sync yourself with everyone else";
            this.localResync.Text = "¿";
            this.localResync.UseVisualStyleBackColor = true;
            this.localResync.Click += new System.EventHandler(this.localResync_Click);
            // 
            // globalTrack
            // 
            this.globalTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.globalTrack.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Bold);
            this.globalTrack.ForeColor = System.Drawing.Color.Silver;
            this.globalTrack.Location = new System.Drawing.Point(90, 18);
            this.globalTrack.Margin = new System.Windows.Forms.Padding(0);
            this.globalTrack.Name = "globalTrack";
            this.globalTrack.Size = new System.Drawing.Size(35, 35);
            this.globalTrack.TabIndex = 5;
            this.globalTrack.Tag = "Re-sync everyone in the room";
            this.globalTrack.Text = "ý";
            this.globalTrack.UseVisualStyleBackColor = true;
            this.globalTrack.Click += new System.EventHandler(this.globalResync);
            // 
            // audioButton
            // 
            this.audioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.audioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioButton.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Bold);
            this.audioButton.ForeColor = System.Drawing.Color.Silver;
            this.audioButton.Location = new System.Drawing.Point(620, 18);
            this.audioButton.Margin = new System.Windows.Forms.Padding(0);
            this.audioButton.Name = "audioButton";
            this.audioButton.Size = new System.Drawing.Size(35, 35);
            this.audioButton.TabIndex = 4;
            this.audioButton.Tag = "Change Volume";
            this.audioButton.Text = "X";
            this.audioButton.UseVisualStyleBackColor = true;
            this.audioButton.MouseEnter += new System.EventHandler(this.VolumeEnter);
            // 
            // timeDetails
            // 
            this.timeDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.timeDetails.ForeColor = System.Drawing.Color.White;
            this.timeDetails.Location = new System.Drawing.Point(285, 40);
            this.timeDetails.Name = "timeDetails";
            this.timeDetails.Size = new System.Drawing.Size(150, 13);
            this.timeDetails.TabIndex = 3;
            this.timeDetails.Text = "21:56 / 23:32";
            this.timeDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timeTrack
            // 
            this.timeTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTrack.Location = new System.Drawing.Point(0, 56);
            this.timeTrack.Maximum = 1000;
            this.timeTrack.Name = "timeTrack";
            this.timeTrack.Size = new System.Drawing.Size(704, 45);
            this.timeTrack.TabIndex = 2;
            this.timeTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.timeTrack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeChangeSelected);
            this.timeTrack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimeSelectionChanged);
            // 
            // fullscreenBtn
            // 
            this.fullscreenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fullscreenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullscreenBtn.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Bold);
            this.fullscreenBtn.ForeColor = System.Drawing.Color.Silver;
            this.fullscreenBtn.Location = new System.Drawing.Point(660, 18);
            this.fullscreenBtn.Margin = new System.Windows.Forms.Padding(0);
            this.fullscreenBtn.Name = "fullscreenBtn";
            this.fullscreenBtn.Size = new System.Drawing.Size(35, 35);
            this.fullscreenBtn.TabIndex = 1;
            this.fullscreenBtn.Tag = "Full-screen";
            this.fullscreenBtn.Text = "1";
            this.fullscreenBtn.UseVisualStyleBackColor = true;
            this.fullscreenBtn.Click += new System.EventHandler(this.fullscreenBtn_Click);
            // 
            // playPauseBtn
            // 
            this.playPauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseBtn.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Bold);
            this.playPauseBtn.ForeColor = System.Drawing.Color.Silver;
            this.playPauseBtn.Location = new System.Drawing.Point(10, 18);
            this.playPauseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.playPauseBtn.Name = "playPauseBtn";
            this.playPauseBtn.Size = new System.Drawing.Size(35, 35);
            this.playPauseBtn.TabIndex = 0;
            this.playPauseBtn.Tag = "Play / Pause";
            this.playPauseBtn.Text = "4";
            this.playPauseBtn.UseVisualStyleBackColor = true;
            this.playPauseBtn.Click += new System.EventHandler(this.playPauseBtn_Click);
            // 
            // globalTimer
            // 
            this.globalTimer.Enabled = true;
            this.globalTimer.Interval = 50;
            this.globalTimer.Tick += new System.EventHandler(this.globalTimer_Tick);
            // 
            // bufferringLabel
            // 
            this.bufferringLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bufferringLabel.BackColor = System.Drawing.Color.Transparent;
            this.bufferringLabel.Enabled = false;
            this.bufferringLabel.Font = new System.Drawing.Font("Leelawadee UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bufferringLabel.ForeColor = System.Drawing.Color.White;
            this.bufferringLabel.Location = new System.Drawing.Point(220, 146);
            this.bufferringLabel.Name = "bufferringLabel";
            this.bufferringLabel.Size = new System.Drawing.Size(240, 37);
            this.bufferringLabel.TabIndex = 9;
            this.bufferringLabel.Text = "Bufferring...";
            this.bufferringLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bufferringLabel.Visible = false;
            // 
            // volumeBar
            // 
            this.volumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeBar.AutoSize = false;
            this.volumeBar.LargeChange = 50;
            this.volumeBar.Location = new System.Drawing.Point(620, 273);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeBar.Size = new System.Drawing.Size(35, 104);
            this.volumeBar.TabIndex = 10;
            this.volumeBar.TickFrequency = 10;
            this.volumeBar.Value = 100;
            this.volumeBar.Visible = false;
            this.volumeBar.ValueChanged += new System.EventHandler(this.VolumeChanged);
            this.volumeBar.MouseEnter += new System.EventHandler(this.VolumeEnter);
            this.volumeBar.MouseLeave += new System.EventHandler(this.VolumeLeave);
            // 
            // popupLabel
            // 
            this.popupLabel.AutoSize = true;
            this.popupLabel.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupLabel.ForeColor = System.Drawing.Color.White;
            this.popupLabel.Location = new System.Drawing.Point(13, 13);
            this.popupLabel.Name = "popupLabel";
            this.popupLabel.Padding = new System.Windows.Forms.Padding(3);
            this.popupLabel.Size = new System.Drawing.Size(332, 19);
            this.popupLabel.TabIndex = 11;
            this.popupLabel.Text = "Hi! How\'s everyone today? I\'m a cliche sounding person lol Ik";
            this.popupLabel.Visible = false;
            // 
            // notTimer
            // 
            this.notTimer.Enabled = true;
            this.notTimer.Tick += new System.EventHandler(this.notificationTimed);
            // 
            // SGSClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.popupLabel);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.bufferringLabel);
            this.Controls.Add(this.playerControls);
            this.Controls.Add(this.messaging);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.users);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "SGSClient";
            this.Text = "Kunomi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SGSClient_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.messaging.ResumeLayout(false);
            this.messaging.PerformLayout();
            this.playerControls.ResumeLayout(false);
            this.playerControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtChatBox;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstChatters;
        private System.Windows.Forms.GroupBox users;
        private System.Windows.Forms.GroupBox messaging;
        private System.Windows.Forms.GroupBox playerControls;
        private System.Windows.Forms.Button playPauseBtn;
        private System.Windows.Forms.Button fullscreenBtn;
        private System.Windows.Forms.TrackBar timeTrack;
        private System.Windows.Forms.Label timeDetails;
        private System.Windows.Forms.Timer globalTimer;
        private System.Windows.Forms.Label bufferringLabel;
        private System.Windows.Forms.Button audioButton;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Button globalTrack;
        private System.Windows.Forms.Button localResync;
        private System.Windows.Forms.Label popupLabel;
        private System.Windows.Forms.Timer notTimer;
    }
}

