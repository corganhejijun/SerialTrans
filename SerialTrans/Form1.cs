using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SerialTrans
{
    public partial class Form1 : Form
    {
        readonly int[] BAUD_RATE = {9600, 14400, 19200, 38400, 56000, 57600, 115200};
        Writer writer;
        public Form1()
        {
            InitializeComponent();
            foreach (int rate in BAUD_RATE)
            {
                comboBoxBaudRate1.Items.Add(rate.ToString());
                comboBoxBaudRate2.Items.Add(rate.ToString());
            }
            comboBoxBaudRate1.SelectedIndex = comboBoxBaudRate2.SelectedIndex = 0;
            initPortList();
            deleOnGetSerialMsg = new DeleOnGetSerialMsg(onGetSerialMsg);
            writer = new Writer();
        }

        void initPortList()
        {
            string[] portNames = SerialTrans.getSerialPortList();
            comboBoxCom1.Items.Clear();
            comboBoxCom2.Items.Clear();
            if (portNames != null)
            {
                foreach (string name in portNames)
                {
                    if (comboBoxCom1.Items.Contains(name))
                        continue;
                    comboBoxCom1.Items.Add(name);
                    if (comboBoxCom2.Items.Contains(name))
                        continue;
                    comboBoxCom2.Items.Add(name);
                }
                if (portNames.Length > 0)
                    comboBoxCom1.SelectedIndex = 0;
                if (portNames.Length > 1)
                    comboBoxCom2.SelectedIndex = 1;
            }
        }

        delegate void DeleOnGetSerialMsg(SerialPort port);

        private DeleOnGetSerialMsg deleOnGetSerialMsg;

        void onGetSerialMsg(SerialPort port)
        {
            SerialPort otherPort = port == serialPort1 ? serialPort2 : serialPort1;
            string msg = port.ReadExisting();
            try
            {
                writer.writeFile(msg);
                showMsgInTextBox("已写入文件\r\n");
            }
            catch (Exception e)
            {
                showMsgInTextBox("错误：" + e.ToString() + "\r\n");
            }
            if (otherPort == null)
            {
                showMsgInTextBox("当前仅开启一个串口，无法转发。" + port.PortName + "收到：" + msg + "\r\n");
                return;
            }
            showMsgInTextBox(port.PortName + "向" + otherPort.PortName + "转发：" + msg + "\r\n");
            otherPort.Write(msg);
        }

        void showMsgInTextBox(string msg)
        {
            textBoxSent.Text = msg + textBoxSent.Text;
        }

        private SerialPort serialPort1;
        private SerialPort serialPort2;
        void openButtonClicked(ref SerialPort serialPort, Button button, ComboBox comboBox)
        {
            if (comboBox.Text.Equals(""))
            {
                return;
            }
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
            if (!comboBoxCom1.Text.Equals("") && comboBoxCom1.Text.Equals(comboBoxCom2.Text))
            {
                MessageBox.Show("不能同时打开同一个串口！");
                if (combo.Items.Count == combo.SelectedIndex + 1)
                    combo.SelectedItem = null;
                else
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
            releaseSerialPorts();
        }

        void releaseSerialPorts()
        {
            if (serialPort1 != null)
            {
                serialPort1.Close();
                serialPort1 = null;
            }
            if (serialPort2 != null)
            {
                serialPort2.Close();
                serialPort2 = null;
            }
        }

        // usb消息定义
        public const int WM_DEVICE_CHANGE = 0x219;

        /// <summary>
        /// 检测USB串口的拔插
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICE_CHANGE)        // 捕获USB设备的拔出消息WM_DEVICECHANGE
            {
                showMsgInTextBox("检测到设备变化，请重新设置串口!\r\n");
                releaseSerialPorts();
                initPortList();
                buttonOpenCom1.Text = "Open";
                buttonOpenCom2.Text = "Open";
            }
            base.WndProc(ref m);
        }
    }
}
