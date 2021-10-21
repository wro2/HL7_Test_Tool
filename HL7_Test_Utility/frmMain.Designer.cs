namespace HL7Tester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.rdoIP = new System.Windows.Forms.RadioButton();
            this.rdoHostname = new System.Windows.Forms.RadioButton();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.txtHL7Message = new System.Windows.Forms.TextBox();
            this.lblHL7Message = new System.Windows.Forms.Label();
            this.lblACK = new System.Windows.Forms.Label();
            this.txtACKMsg = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdoIP
            // 
            this.rdoIP.AutoSize = true;
            this.rdoIP.Checked = true;
            this.rdoIP.Location = new System.Drawing.Point(13, 29);
            this.rdoIP.Name = "rdoIP";
            this.rdoIP.Size = new System.Drawing.Size(82, 17);
            this.rdoIP.TabIndex = 0;
            this.rdoIP.TabStop = true;
            this.rdoIP.Text = "IP Address: ";
            this.rdoIP.UseVisualStyleBackColor = true;
            this.rdoIP.CheckedChanged += new System.EventHandler(this.rdoIP_CheckedChanged);
            // 
            // rdoHostname
            // 
            this.rdoHostname.AutoSize = true;
            this.rdoHostname.Location = new System.Drawing.Point(13, 52);
            this.rdoHostname.Name = "rdoHostname";
            this.rdoHostname.Size = new System.Drawing.Size(73, 17);
            this.rdoHostname.TabIndex = 1;
            this.rdoHostname.Text = "Hostname";
            this.rdoHostname.UseVisualStyleBackColor = true;
            this.rdoHostname.CheckedChanged += new System.EventHandler(this.rdoHostname_CheckedChanged);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(105, 29);
            this.txtIP.Name = "txtIP";
            this.txtIP.ShortcutsEnabled = false;
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 2;
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // txtHostname
            // 
            this.txtHostname.Enabled = false;
            this.txtHostname.Location = new System.Drawing.Point(105, 52);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(100, 20);
            this.txtHostname.TabIndex = 3;
            this.txtHostname.TextChanged += new System.EventHandler(this.txtHostname_TextChanged);
            // 
            // txtHL7Message
            // 
            this.txtHL7Message.Location = new System.Drawing.Point(13, 99);
            this.txtHL7Message.Multiline = true;
            this.txtHL7Message.Name = "txtHL7Message";
            this.txtHL7Message.Size = new System.Drawing.Size(686, 148);
            this.txtHL7Message.TabIndex = 4;
            // 
            // lblHL7Message
            // 
            this.lblHL7Message.AutoSize = true;
            this.lblHL7Message.Location = new System.Drawing.Point(15, 86);
            this.lblHL7Message.Name = "lblHL7Message";
            this.lblHL7Message.Size = new System.Drawing.Size(76, 13);
            this.lblHL7Message.TabIndex = 5;
            this.lblHL7Message.Text = "HL7 Message:";
            // 
            // lblACK
            // 
            this.lblACK.AutoSize = true;
            this.lblACK.Location = new System.Drawing.Point(12, 259);
            this.lblACK.Name = "lblACK";
            this.lblACK.Size = new System.Drawing.Size(87, 13);
            this.lblACK.TabIndex = 6;
            this.lblACK.Text = "ACK / NAK Msg:";
            // 
            // txtACKMsg
            // 
            this.txtACKMsg.Location = new System.Drawing.Point(15, 275);
            this.txtACKMsg.Name = "txtACKMsg";
            this.txtACKMsg.Size = new System.Drawing.Size(686, 20);
            this.txtACKMsg.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(428, 29);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 36);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(261, 30);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 9;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(226, 33);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 10;
            this.lblPort.Text = "Port:";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(576, 30);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(110, 36);
            this.btnDisconnect.TabIndex = 11;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(576, 311);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(110, 36);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "Send Msg";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(15, 311);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 36);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(15, 311);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 379);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtACKMsg);
            this.Controls.Add(this.lblACK);
            this.Controls.Add(this.lblHL7Message);
            this.Controls.Add(this.txtHL7Message);
            this.Controls.Add(this.txtHostname);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.rdoHostname);
            this.Controls.Add(this.rdoIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Basic HL7 Send Test Tool (Personal Use - W. Olmstead)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoIP;
        private System.Windows.Forms.RadioButton rdoHostname;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.TextBox txtHL7Message;
        private System.Windows.Forms.Label lblHL7Message;
        private System.Windows.Forms.Label lblACK;
        private System.Windows.Forms.TextBox txtACKMsg;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}

