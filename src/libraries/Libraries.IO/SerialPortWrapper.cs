using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageTemperature.Libraries.IO
{
    public class SerialPortWrapper 
    {
        private readonly SerialPort _port;

        // internal delegate Task ReadLineHandler(string line);

        private event Func<string, Task>? _readingLineNotify;
        
        internal event Func<string, Task>? ReadingLineNotify
        {
            add
            {
                _port.DataReceived += DataReceivedHandler;
                _readingLineNotify += value;
            }
            remove
            {
                _port.DataReceived -= DataReceivedHandler;
                _readingLineNotify -= value;
            }
        }

        internal string Name { get; }
        
        internal SerialPortWrapper(string name)
        {
            Name = name;
            _port = new SerialPort(name)
            {
                Encoding = Encoding.UTF8
            };
        }

        internal void Write(string text)
        {
            _port.Open();
            _port.Write(text);
            _port.Close();
        }

        internal bool IsValid()
        {
            return SerialPort
                .GetPortNames()
                .Any(portName => portName == Name);
        }

        internal void Open()
        {
            if (_port.IsOpen)
                return;
            _port.Open();
        }
        
        internal void Close()
        {
            if (_port.IsOpen)
                _port.Close();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs args)
        {
            var line = _port.ReadLine();
            _readingLineNotify?.Invoke(line);
        }
    }
}