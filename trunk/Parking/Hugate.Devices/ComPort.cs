using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
using System.Timers;

namespace Hugate.ComportConnections
{
    public class EventsComPorts
    {
        public event LfDataReceivedEventHandler LfDataReceived;
        SerialPort sp = new SerialPort();
        Timer tmrDelay = new Timer();
        string sSerialPort = "";

        public EventsComPorts()
        {
            tmrDelay.Interval = 50;
            tmrDelay.Elapsed += new ElapsedEventHandler(tmrDelay_Elapsed);
        }

        public void DataReceived(Int64 value)
        {

            LfEventArgs e = new LfEventArgs();
            e.value = value;

            if (LfDataReceived != null)
                LfDataReceived(this, e);
        }

        public bool Connect(string sPort, int intBaudrate)
        {
            try
            {
                sp.PortName = sPort;
                sp.BaudRate = intBaudrate;
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                sp.ReceivedBytesThreshold = 1;
                sp.Open();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
            return false;
        }

        public bool Disconnect()
        {
            sp.Close();
            return true;
        }

        public bool IsOpen()
        {
            return sp.IsOpen;
        }

        public void Write(string data)
        {
            sp.Write(data);
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            sp.Write(buffer, offset, count);
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            sSerialPort += sp.ReadExisting();
            if (sSerialPort.Length > 11)
            {
                if (sSerialPort[sSerialPort.Length - 1] == (char)0x02)
                {
                    if (sSerialPort[sSerialPort.Length - 12] == (char)0x01)
                    {
                        sSerialPort = sSerialPort.Substring(sSerialPort.Length - 11, 10);
                        Int64 value = Int64.Parse(sSerialPort);
                        DataReceived(value);
                    }
                    sSerialPort = "";
                }
            }
        }

        public void OpenDoor()
        {
            //Debug.WriteLine("Rts -> true");
            //sp.RtsEnable = true;
            //tmrDelay.Start();
            if (sp.IsOpen)
            {
                byte[] bwrite = new byte[50];
                for (int i = 0; i < bwrite.Length; i++)
                    bwrite[i] = 0;
                sp.Write(bwrite, 0, bwrite.Length);
            }
        }

        public void SetTimeDelayRTS(int intTimeDelay)
        {
            tmrDelay.Interval = intTimeDelay;
        }

        void tmrDelay_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug.WriteLine("Rts -> false");
            tmrDelay.Stop();
            sp.RtsEnable = false;
        }

        public string[] LoadDataAllComPorts()
        {
            return SerialPort.GetPortNames();
        }
    }

    public delegate void LfDataReceivedEventHandler(object sender, LfEventArgs e);

    public class LfEventArgs : EventArgs
    {
        public Int64 value;
    }
}
