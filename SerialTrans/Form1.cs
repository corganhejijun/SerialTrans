using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace SerialTrans
{
    public partial class Form1 : Form
    {
        readonly int[] BAUD_RATE = {9600, 14400, 19200, 38400, 56000, 57600, 115200};
        public Form1()
        {
            InitializeComponent();
            string[] portNames = SerialTrans.getSerialPortList();
            foreach (int rate in BAUD_RATE)
            {
                comboBoxBaudRate1.Items.Add(rate.ToString());
                comboBoxBaudRate2.Items.Add(rate.ToString());
            }
            comboBoxBaudRate1.SelectedIndex = comboBoxBaudRate2.SelectedIndex = 0;
            if (portNames != null)
            {
                foreach (string name in portNames)
                {
                    comboBoxCom1.Items.Add(name);
                    comboBoxCom2.Items.Add(name);
                }
                comboBoxCom1.SelectedIndex = 0;
                comboBoxCom2.SelectedIndex = 1;
            }
            deleOnGetSerialMsg = new DeleOnGetSerialMsg(onGetSerialMsg);
        }

        delegate void DeleOnGetSerialMsg(SerialPort port);

        private DeleOnGetSerialMsg deleOnGetSerialMsg;

        void onGetSerialMsg(SerialPort port)
        {
            SerialPort otherPort = port == serialPort1 ? serialPort2 : serialPort1;
            if (otherPort == null)
            {
                textBoxSent.Text += "当前仅开启一个串口，无法转发。" + port.PortName + "收到：" + port.ReadExisting() + "\r\n";
                return;
            }
            string msg = port.ReadExisting();
            textBoxSent.Text += port.PortName + "向" + otherPort.PortName + "转发：" + msg + "\r\n";
            otherPort.Write(msg);
            textBoxSent.SelectionStart = textBoxSent.TextLength;
            textBoxSent.ScrollToCaret();
            textBoxSent.Refresh();
        }

        private SerialPort serialPort1;
        private SerialPort serialPort2;
        void openButtonClicked(ref SerialPort serialPort, Button button, ComboBox comboBox)
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort();
                serialPort.BaudRate = BAUD_RATE[comboBoxBaudRate1.SelectedIndex];
                serialPort.PortName = comboBox.Text;
                serialPort.Open();
                button.Text = "Close";
            }
            else
            {
                serialPort.Close();
                serialPort = null;
                button.Text = "Open";
            }
        }

        private void buttonOpenCom1_Click(object sender, EventArgs e)
        {
            openButtonClicked(ref serialPort1, buttonOpenCom1, comboBoxCom1);
            if (serialPort1 != null)
                serialPort1.DataReceived += SerialPort1OnDataReceived;
        }

        private void SerialPort1OnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            this.Invoke(deleOnGetSerialMsg, new object[] {sender});
        }


        private void buttonOpenCom2_Click(object sender, EventArgs e)
        {
            openButtonClicked(ref serialPort2, buttonOpenCom2, comboBoxCom2);
            if (serialPort2 != null)
                serialPort2.DataReceived += SerialPort2OnDataReceived;
        }

        private void SerialPort2OnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            this.Invoke(deleOnGetSerialMsg, new object[] {sender});
        }

        void selectPortChange(ComboBox combo)
        {
            if (comboBoxCom1.Text.Equals(comboBoxCom2.Text))
            {
                MessageBox.Show("不能同时打开同一个串口！");
                combo.SelectedIndex += 1;
            }
        }

        private void comboBoxCom1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectPortChange(comboBoxCom1);
        }

        private void comboBoxCom2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectPortChange(comboBoxCom2);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1 != null)
                serialPort1.Close();
            if (serialPort2 != null)
                serialPort2.Close();
        }
    }
}
