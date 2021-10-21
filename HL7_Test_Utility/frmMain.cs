using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HL7Tester
{
    public partial class frmMain : Form
    {

        #region "Variable / Property Definition"

        private TCPIPSender _tSender = new TCPIPSender();


        #endregion

        #region "Form Events"
        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region "Control Events"

        private void rdoIP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIP.Checked == true)
            {
                txtIP.Enabled = true;
                _tSender.isIPAddress = true;
                _tSender.Destination = txtIP.Text;
            }

            if (rdoIP.Checked == false)
            {
                txtIP.Enabled = false;
                _tSender.isIPAddress = false;

            }
        }
        private void rdoHostname_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHostname.Checked == true)
            {
                txtHostname.Enabled = true;
                _tSender.isIPAddress = false;
                _tSender.Destination = txtHostname.Text;

            }

            if (rdoHostname.Checked == false)
            {
                txtHostname.Enabled = false;
                _tSender.isIPAddress = true;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHL7Message.Clear();
            txtACKMsg.Clear();
            lblStatus.Text = "";


        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _tSender.CloseConnection();

            if (_tSender.skSocket.Connected == false)
            {
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                lblStatus.Text = "Disconnected";
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {


            lblStatus.Text = "";
            _tSender.OpenConnection();

            if (_tSender.skSocket != null && _tSender.skSocket.Connected == true)
            {
                btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;
                lblStatus.Text = "Connected to destination successfully";
            }
            else
            {
                lblStatus.Text = "Connect not successful: " + _tSender.sErrorMsg;
            }

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            _tSender.Port = txtPort.Text.Trim();
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            if (rdoIP.Checked == true)
                _tSender.Destination = txtIP.Text;
        }

        private void txtHostname_TextChanged(object sender, EventArgs e)
        {
            if (rdoHostname.Checked == true)
                _tSender.Destination = txtHostname.Text;
        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {


            if (txtHL7Message.Text.Length == 0)
            {
                MessageBox.Show("HL7 Message is Blank");
                return;
            }

            txtACKMsg.Text = "";
            _tSender.SendHL7(txtHL7Message.Text.Replace("\r\n", "\r").Replace("\r\r", "\r"));

            if (_tSender.AckMsg.Trim().Length > 0)
            {
                if (_tSender.AckMsg.Contains("MSA|AE") || _tSender.AckMsg.Contains("MSA|AR"))
                    lblStatus.Text = "Sent Message and Received NAK";
                else
                    lblStatus.Text = "Sent Message and Received ACK";

                txtACKMsg.Text = _tSender.AckMsg;
            }
            else
            {
                lblStatus.Text = "Send failed, never received response from destination " + _tSender.sErrorMsg;
            }


        }







    }
}
