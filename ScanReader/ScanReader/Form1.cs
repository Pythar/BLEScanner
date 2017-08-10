using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ScanReader
{
    public partial class Form1 : Form
    {
        SerialPort ComPort = new SerialPort();
        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(
                 object sender, SerialPinChangedEventArgs e);
        delegate void SetTextCallback(string text);
        // string InputData = String.Empty;
        //string[] macAddressesAsStrings;
        //Timer timer = new Timer();
        // int nonZeroMacAddresses = 100;
        List<TextBox> macAddressTextBoxes = new List<TextBox>();
        int signalFilterNumber = 100;

        public Form1()
        {  
            InitializeComponent();
            closeComButton.Enabled = false;
        }

        private void portsButton_Click(object sender, EventArgs e)
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index += 1;
                portSelectionBox.Items.Add(ArrayComPortsNames[index]);
            }

            while (!((ArrayComPortsNames[index] == ComPortName)
                          || (index == ArrayComPortsNames.GetUpperBound(0))));
            Array.Sort(ArrayComPortsNames);

            //want to get first out
            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                ComPortName = ArrayComPortsNames[0];
            }
            portSelectionBox.Text = ArrayComPortsNames[0];

            /*baudRateCombo.Items.Add(300);
            baudRateCombo.Items.Add(600);
            baudRateCombo.Items.Add(1200);
            baudRateCombo.Items.Add(2400);
            baudRateCombo.Items.Add(9600);
            baudRateCombo.Items.Add(14400);
            baudRateCombo.Items.Add(19200);
            baudRateCombo.Items.Add(38400);
            baudRateCombo.Items.Add(57600);*/
            baudRateCombo.Items.Add(115200);
            baudRateCombo.Items.ToString();
            //get first item print in text
            baudRateCombo.Text = baudRateCombo.Items[0].ToString();

            dataBitCombo.Items.Add(8);
            dataBitCombo.Items.Add(7);
            dataBitCombo.Text = dataBitCombo.Items[0].ToString();

            stopBitCombo.Items.Add("1");
            stopBitCombo.Items.Add("1.5");
            stopBitCombo.Items.Add("2");
            //get the first item print in the text
            stopBitCombo.Text = stopBitCombo.Items[0].ToString();

            /*handShakingCombo.Items.Add("None");
            handShakingCombo.Items.Add("XOnXOff");
            handShakingCombo.Items.Add("RequestToSend");
            handShakingCombo.Items.Add("RequestToSendXOnXOff");



            parityCombo.Items.Add("None");
            parityCombo.Items.Add("Even");
            parityCombo.Items.Add("Mark");
            parityCombo.Items.Add("Odd");
            parityCombo.Items.Add("Space");
            //get the first item print in the text
            parityCombo.Text = parityCombo.Items[0].ToString();*/

            ComPort.RtsEnable = true;
            ComPort.ReadTimeout = 5000;
        }

        private void openComButton_Click(object sender, EventArgs e)
        {
            /*if (openComButton.Text == "Closed")
            {*/
                openComButton.Text = "Open";
                ComPort.PortName = Convert.ToString(portSelectionBox.Text);
                ComPort.BaudRate = Convert.ToInt32(baudRateCombo.Text);
                ComPort.DataBits = Convert.ToInt16("8");
                ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
                ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
                ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                ComPort.DtrEnable = true;
                ComPort.Open();      
                openComButton.Enabled = false;
                closeComButton.Enabled = true;
                ComPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived_1);
                SetText(signalFilterNumber.ToString());
            //}
            /*else if (openComButton.Text == "Open")
            {
                openComButton.Text = "Closed";

                Thread thread = new Thread(ComPort.Close());
                ComPort.Close();
                timer.Interval = 5000; // here time in milliseconds
                timer.Tick += timer_Tick;
                timer.Start();
                openComButton.Enabled = false;            
            } */
        }

        private void closeComButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
        }

        private void ThreadProc(Object stateInfo)
        {
            // Attempt to close serial port
            if (this.ComPort.IsOpen == true)
            {
                this.ComPort.Close();
                openComButton.Enabled = true;
                closeComButton.Enabled = false;
            }
        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            openComButton.Enabled = true;
            //timer.Stop();
        }


        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
       {
            SerialPort sp = (SerialPort)sender;
            string timeStamp = GetTimeStamp(DateTime.Now);
            string readLineBuffer = sp.ReadLine();
            string data = string.Empty;
            //StringBuilder sb = new StringBuilder();

            if (this.Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text)))
            {
                int bla = GetHexFromStringAndConvertToInt(readLineBuffer);
                if (GetHexFromStringAndConvertToInt(readLineBuffer) > signalFilterNumber) {
                    data = signalFilterNumber.ToString() + "<= " + timeStamp + ": " + readLineBuffer;
                    SetText(data);
                    //dataTextBox.Text += data;
                }
            }
            else if (!this.Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text))) {
                foreach (TextBox macAddressTextBox in macAddressTextBoxes)
                {
                    if (readLineBuffer.Contains(macAddressTextBox.Text)
                        && !string.IsNullOrEmpty(macAddressTextBox.Text)
                        && this.GetHexFromStringAndConvertToInt(readLineBuffer) > signalFilterNumber)
                    {
                        data = timeStamp + ": " + readLineBuffer;
                        dataTextBox.Text += data;
                    }
                }
            }
        }

        //delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.dataTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.dataTextBox.Text += text;
            }
        }

        public static String GetTimeStamp(DateTime value)
        {
            return value.ToString("HH:mm:ss.ffff");
        }

        private void helloButton_Click(object sender, EventArgs e)
        {
            ComPort.Write("Hello World!");
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ComPort.ReadLine();
        }

        private void cleanTextBox_Click(object sender, EventArgs e)
        {
            dataTextBox.Clear();
        }

        private void macAddressFilterButton_Click(object sender, EventArgs e)
        {
            //nonZeroMacAddresses = 0;

            macAddressTextBoxes.Clear();
            StringBuilder sb = new StringBuilder();

            macAddressTextBoxes.Add(macAddressTextBox1);
            macAddressTextBoxes.Add(macAddressTextBox2);
            macAddressTextBoxes.Add(macAddressTextBox3);
            macAddressTextBoxes.Add(macAddressTextBox4);
            macAddressTextBoxes.Add(macAddressTextBox5);
            macAddressTextBoxes.Add(macAddressTextBox6);
            macAddressTextBoxes.Add(macAddressTextBox7);
            macAddressTextBoxes.Add(macAddressTextBox8);
            macAddressTextBoxes.Add(macAddressTextBox9);
            macAddressTextBoxes.Add(macAddressTextBox10);

            if (this.Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text)))
            {
                sb.AppendLine("No filter was added.");
            }

            else if (!this.Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text)))
            {
                foreach (TextBox macAddressTextBox in macAddressTextBoxes)
                {
                    if (!String.IsNullOrEmpty(macAddressTextBox.Text))
                    {
                        sb.AppendLine("Added address '" + macAddressTextBox.Text + "' to the filter.");
                    }
                }
            }

            dataTextBox.Text = sb.ToString();
        }

        private void signalStrengthFilterButton_Click(object sender, EventArgs e)
        {
            signalFilterNumber = int.Parse(signalStrengthTextBox.Text);
            dataTextBox.Text = signalFilterNumber.ToString();
            /* question = getHexFromStringAndConvertToInt("80EACA406979,0,-27,Brcst:0201061B00411100850104FEC304FEC305FFC304FFC203FFC204FEC304FFC3").ToString();
            dataTextBox.Text = question;*/
        }

        private int GetHexFromStringAndConvertToInt(String str)
        {
            int count = Regex.Matches(Regex.Escape(str), ",0,-").Count;
            int count2 = Regex.Matches(Regex.Escape(str), ",Brcst").Count;

            if (str.Contains(",0,-") && str.Contains(",Brcst") && count < 2 && count2 < 2)
            {
                int pFrom = str.IndexOf(",0,-") + ",0,-".Length;
                int pTo = str.LastIndexOf(",Brcst");
                String result = str.Substring(pFrom, pTo - pFrom);
                return Int32.Parse(result, NumberStyles.HexNumber);
            }
            else
            {
                return 100000;
            }         
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                dataTextBox.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
