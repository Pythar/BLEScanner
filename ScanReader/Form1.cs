using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Microsoft.Office.Interop;

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
        List<TextBox> macAddressTextBoxes = new List<TextBox>();
        List<string> uniqueMacAddresses = new List<string>();
        string signalFilterNumber = "F4240";

        public Form1()
        {  
            InitializeComponent();
            closeComButton.Enabled = false;
        }

        private void PortsButton_Click(object sender, EventArgs e)
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
            //dataBitCombo.Items.Add(7);
            dataBitCombo.Text = dataBitCombo.Items[0].ToString();

            stopBitCombo.Items.Add("1");
            /*
            stopBitCombo.Items.Add("1.5");
            stopBitCombo.Items.Add("2");*/
            //get the first item print in the text
            stopBitCombo.Text = stopBitCombo.Items[0].ToString();

            // We use a preset handshaking in the current version
            /*handShakingCombo.Items.Add("None");
            handShakingCombo.Items.Add("XOnXOff");
            handShakingCombo.Items.Add("RequestToSend");
            handShakingCombo.Items.Add("RequestToSendXOnXOff");


            //We use a preset parity in the current version
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

        // Open communication
        private void OpenComButton_Click(object sender, EventArgs e)
        {         
            openComButton.Text = "Open";
            ComPort.PortName = Convert.ToString(portSelectionBox.Text);
            ComPort.BaudRate = Convert.ToInt32(baudRateCombo.Text);
            ComPort.DataBits = Convert.ToInt16(dataBitCombo.Text);
            ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitCombo.Text);
            ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
            ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            ComPort.DtrEnable = true;
            dataTextBox.Clear();
            ComPort.Open();      
            openComButton.Enabled = false;
            closeComButton.Enabled = true;
            ComPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived_1);
        }

        // Close communication
        private void CloseComButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
            openComButton.Enabled = true;
            closeComButton.Enabled = false;
        }

        private void ThreadProc(Object stateInfo)
        {
            // Attempt to close serial port
            if (this.ComPort.IsOpen == true)
            {
                this.ComPort.Close();            
            }
        }

        // Looks if there is any data received via the serial communication.
        private void Port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string timeStamp = GetTimeStamp(DateTime.Now);
            string readLineBuffer = sp.ReadLine();
            string data = string.Empty;

            // Enter if all text fields are empty - No MAC-address filter given
            if (this.Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text)))
            {       
                if (IsSignalLowerThanFilter(this.GetHexSignalFromString(readLineBuffer)))
                {
                    GetMacAddressFromString(readLineBuffer);

                    // Adds the current time to the data line.
                    data = timeStamp + ": " + readLineBuffer;               
                    SetText(data);             
                }
            }

            else if (!this.Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text))) {
                foreach (TextBox macAddressTextBox in macAddressTextBoxes)
                {
                    // Enter if the data string contains a MAC-address given as a filter
                    if (readLineBuffer.Contains(macAddressTextBox.Text)
                        && !string.IsNullOrEmpty(macAddressTextBox.Text)
                        && IsSignalLowerThanFilter(this.GetHexSignalFromString(readLineBuffer)))
                    {                      
                        GetMacAddressFromString(readLineBuffer);

                        // Adds the current time to the data line.
                        data = timeStamp + ": " + readLineBuffer;                     
                        SetText(data);
                    }
                }
            }
        }

        // Set the data to the richtextbox field.
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

        // Get time computers time.
        public static String GetTimeStamp(DateTime value)
        {
            return value.ToString("HH:mm:ss.ffff");
        }

        //Clear the data textbox
        private void ClearTextBox_Click(object sender, EventArgs e)
        {
            dataTextBox.Clear();
        }

        // Fetch the MAC-address to show and print them out in the data textbox.
        private void MacAddressFilterButton_Click(object sender, EventArgs e)
        {
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

            // If ALL textboxes are empty, enter below.
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

        // Fetches the filter limit for the signal strength, prints it in the text box and changes the labels text.
        private void SignalStrengthFilterButton_Click(object sender, EventArgs e)
        {
            signalFilterNumber = signalStrengthTextBox.Text;
            dataTextBox.Text = "Filter set to: " + signalFilterNumber.ToString();
            setSignalStrengthLabel.Text = "Filter is currently set to " + signalStrengthTextBox.Text;
            signalStrengthTextBox.Clear();
        }

        // Extracts the hexadecimal number that represents the signal strength from the data string. Ret
        private string GetHexSignalFromString(String str)
        {
            int count = Regex.Matches(Regex.Escape(str), ",0,-").Count;
            int count2 = Regex.Matches(Regex.Escape(str), ",Brcst").Count;

            if (str.Contains(",0,-") && str.Contains(",Brcst") && count < 2 && count2 < 2)
            {
                int pFrom = str.IndexOf(",0,-") + ",0,-".Length;
                int pTo = str.LastIndexOf(",Brcst");
                string hexSignal = str.Substring(pFrom, pTo - pFrom);
                return hexSignal;
            }
            else
            {
                return "F4240";
            }         
        }

        // Extracts the MAC-address from the data string.
        // Then adds it to a list if it isn't in the list already.
        private void GetMacAddressFromString(String str)
        {
            int count = Regex.Matches(Regex.Escape(str), ",0,-").Count;
            int count2 = Regex.Matches(Regex.Escape(str), ",Brcst").Count;
            int count3 = Regex.Matches(Regex.Escape(str), ",Brcst").Count;

            if (str.Contains(",0,-") && str.Contains(",Brcst") && count < 2 && count2 < 2)
            {
                int pFrom = 0;
                int pTo = str.LastIndexOf(",0,-");
                string macAddress = str.Substring(pFrom, pTo - pFrom);
                if (!uniqueMacAddresses.Contains(macAddress))
                {
                    uniqueMacAddresses.Add(macAddress);
                }           
            }     
        }

        // Prints all the unique, recorded, MAC-addresses in the textfield.
        private void PrintMacAddresses_Click(object sender, EventArgs e)
        {
            StringBuilder macAddresses = new StringBuilder();
            dataTextBox.Clear();         

            // Start Excel
            Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;

            // Get path to excecutable (Same place as where the Excel Sheet is)
            string exeDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Open workbook
            Microsoft.Office.Interop.Excel._Workbook oWB = oXL.Workbooks.Open(System.IO.Path.Combine(exeDir, "MAC adress list example.xlsx"));
            Microsoft.Office.Interop.Excel._Worksheet oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

            int rowIdx;
            int notEmpty;

            foreach (string macAddress in uniqueMacAddresses)
            {
                rowIdx = 1;
                notEmpty = 1;

                macAddresses.Append(macAddress + "\n");

                // Loops through the rows in the Excel-document until you find 
                // a row that is completely empty. 
                while (notEmpty > 0)
                {
                    string aCellAddress = "B" + rowIdx.ToString();
                    Microsoft.Office.Interop.Excel.Range row = oXL.get_Range(aCellAddress, aCellAddress).EntireRow;
                    notEmpty = (int)oXL.WorksheetFunction.CountA(row);
                    rowIdx++;
                }

                // Set the first found completely empty row to a MAC-address value
                oSheet.Cells[rowIdx - 1, 2] = macAddress;
            }
            dataTextBox.Text = macAddresses.ToString();

            // Clears all the addresses so that they are removed when we are printing the next time.
            uniqueMacAddresses.Clear();
        }

        // Compares the signal strength with the set filter. If lower, return true since lower number means closer device.
        private Boolean IsSignalLowerThanFilter(string signalString)
        {
            int a = int.Parse(signalString, System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(signalFilterNumber, System.Globalization.NumberStyles.HexNumber);

            if (a < b)
            {
                return true;
            }
            else if ( a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Save current data to a file.
        private void SaveDataButton_Click(object sender, EventArgs e)
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
