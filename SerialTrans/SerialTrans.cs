using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace SerialTrans
{
    class SerialTrans
    {
        static public string[] getSerialPortList()
        {
            return SerialPort.GetPortNames();
        }
    }
}
