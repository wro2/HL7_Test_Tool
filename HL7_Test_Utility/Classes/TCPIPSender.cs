using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace HL7Tester
{

    //Class TCP Sender
    //Author: W. Olmstead
    //Description: Takes a String and sends it via MLLP protocol to an HL7 connector.
    class TCPIPSender
    {       
      

        #region "Private Variables"

        //MLLP Encoding Charcters
        private string _Header;
        private string _EndofMessageWrapper;
        private Socket _Socket;
        private string _ACKMsg;
        private bool _isHL7ReceivedSuccessfully;
        private string _Port;
        private string _Destination;
        private int _iCurrentNumberOfAttempts;
        private int _iMaxNumAttempts;
        private bool _isAtMaxConnectionAttempts;
        private int _iMilliSecondsBetweenConnectionRetry;
        private bool _isIPAddress;

        //Error Details
        private string _ErrorMsg;

        #endregion

        #region "Constructor (s)"

        //Default Constructor
        public TCPIPSender()
        {
            //Standard HL7 LLP Header & Footer Wrappers (assumes each segment is already ended with a end of line \r and just wraps entire message).
            _Header = Convert.ToChar(11).ToString();
            _EndofMessageWrapper = Convert.ToChar(28).ToString() + Convert.ToChar(13).ToString();
            _ACKMsg = "";
            _isHL7ReceivedSuccessfully = false;
            _ErrorMsg = "";
            _Port = "";
            _Destination = "";
            _iCurrentNumberOfAttempts = 0;
            _iMaxNumAttempts = 5;
            _isAtMaxConnectionAttempts = false;
            _iMilliSecondsBetweenConnectionRetry = 5000;
        }

        #endregion

        #region "Public Properties"


        //Define public strings with gets/sets for all private values.        
        public string Header { get { return _Header; } }
        public string EndOfMessageWrapper { get { return _EndofMessageWrapper; } }
        public string AckMsg { get { return _ACKMsg; } }


        public string Port { get { return _Port; } set { _Port = value; } }
        public string Destination { get { return _Destination; } set { _Destination = value; } }

        public Socket skSocket { get { return _Socket; } }

        public bool isHL7ReceivedSuccessfully { get { return _isHL7ReceivedSuccessfully; } }
        public bool isAtMaxConnectionAttempts { get { return _isAtMaxConnectionAttempts; } set { _isAtMaxConnectionAttempts = value; } }
        public int iCurrentNumberOfAttempts { get { return _iCurrentNumberOfAttempts; } set { _iCurrentNumberOfAttempts = value; } }
        public int iMSBetweenConnectionRetry { get { return _iMilliSecondsBetweenConnectionRetry; } set { _iMilliSecondsBetweenConnectionRetry = value; } }
        public bool isIPAddress { get { return _isIPAddress; } set { _isIPAddress = value; } }


        //General error message
        public string sErrorMsg { get { return _ErrorMsg; } }


        #endregion

        #region "Private Method (s)"

        //Private method for determining if IP / Hostname, looking up IP if hostname, and establishing a connection.
        private static Socket ConnectSocket(string sDestination, int iPort)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;
            IPAddress ipaAddress;

            if (IPAddress.TryParse(sDestination, out ipaAddress) == false)
            {
                //Not an IP, may be a hostname, try to lookup the IP via DNS.
                hostEntry = Dns.GetHostEntry(sDestination);
                ipaAddress = hostEntry.AddressList[0];

            }

            IPEndPoint ipe = new IPEndPoint(ipaAddress, iPort);
            Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            tempSocket.Connect(ipe);

            if (tempSocket.Connected)
            {
                s = tempSocket;
                // s.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.KeepAlive, 1);                         
            }

            return s;
        }

        #endregion

        #region "Public Method (s)"

        //Public Method that calls the private connection method, does error checking, and sets the TCP/IP timeout.
        public bool OpenConnection()
        {
            try
            {

                // Create a socket connection with the specified server and port.
                _Socket = ConnectSocket(_Destination, Int32.Parse(_Port));

                // If the socket could not get a connection, then return false.
                if (_Socket == null)
                {
                    _ErrorMsg = "Error: Unable to initiate TCP/IP connection. Attempt to connect failed: " + _Destination + ":" + _Port;

                    _iCurrentNumberOfAttempts += 1;
                    if (_iCurrentNumberOfAttempts >= _iMaxNumAttempts)
                        _isAtMaxConnectionAttempts = true;

                    //_Socket.Close();

                    return false;
                }
                _Socket.ReceiveTimeout = 25000;
            }
            catch (Exception ex)
            {
                _ErrorMsg = "Error: Attempting to Open TCP/IP Connection: " + ex.Message;

                _iCurrentNumberOfAttempts += 1;
                if (_iCurrentNumberOfAttempts >= _iMaxNumAttempts)
                    _isAtMaxConnectionAttempts = true;

                return false;
            }

            return true;
        }

        //Public Method used to close connection.
        public bool CloseConnection()
        {
            try
            {
                if (_Socket != null)
                {
                    _Socket.Shutdown(SocketShutdown.Both);
                    //_Socket.Close();

                }
            }
            catch (Exception ex)
            {
                _ErrorMsg = "Error: Closing Socket Failed in method CloseConnection(). Message: " + ex.ToString();
                return false;
            }

            return true;
        }

        //Public Method used to Send an HL7 Message to the destination.
        public void SendHL7(string sHL7Message)
        {

            try
            {

                //Should be connected, but check and make sure.
                if (_Socket == null)                
                    OpenConnection();                
                else
                {

                    if (_Socket.Connected == false)
                        OpenConnection();
                }

                // Add the leading and trailing characters so it is LLP complaint.
                string EncodedLLPMessage = _Header + sHL7Message + _EndofMessageWrapper;
                _ACKMsg = "";
                _ErrorMsg = "";
                _isHL7ReceivedSuccessfully = false;

                // Get the size of the message that we have to send to use for comparison of how much has been sent.
                Byte[] bytesSent = Encoding.ASCII.GetBytes(EncodedLLPMessage);
                Byte[] bytesReceived = new Byte[256];

                // Send message to the server.
                _Socket.Send(bytesSent, bytesSent.Length, 0);

                // Receive the response back
                int bytes = 0;
                bytes = _Socket.Receive(bytesReceived, bytesReceived.Length, 0);
                _ACKMsg = Encoding.ASCII.GetString(bytesReceived, 0, bytes);


                // Check to message received (ACK / NAK) to see if message was received successfully.
                if (_ACKMsg.Contains("MSA|AA"))
                { //Successful ACK
                    _isHL7ReceivedSuccessfully = true;
                    _iCurrentNumberOfAttempts = 0;
                }
                else
                {
                    if (_ACKMsg.Contains("MSA|AE") || _ACKMsg.Contains("MSA|AR"))
                    {    //Received NAK           
                        _isHL7ReceivedSuccessfully = false;
                        _ErrorMsg = "NAK Received";
                        _iCurrentNumberOfAttempts = 0;
                    }
                    else
                    {  //Didn't receive anything
                        
                        //TODO: Add Code here to handle "No Response" Scenario as appropriate.
                        _isHL7ReceivedSuccessfully = false;

                        ////Check the current retry attempts to see if we have reached the Max needed to halt.
                        //if (_iCurrentNumberOfAttempts >= _iMaxNumAttempts)
                        //_isAtMaxConnectionAttempts = true;                                  
                    }
                }
                return;
            }
            catch (Exception ex)
            {

                if (_Socket != null && _Socket.Connected == false)
                    CloseConnection();

                //TODO: Add any error checking code as appropriate.
            }
        }

        #endregion       



    }
}
