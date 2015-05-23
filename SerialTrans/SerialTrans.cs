using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
