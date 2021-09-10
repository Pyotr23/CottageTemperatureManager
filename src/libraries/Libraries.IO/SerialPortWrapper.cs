using System.IO.Ports;
using System.Linq;

namespace CottageTemperature.Libraries.IO
{
    internal class SerialPortWrapper 
    {
        private readonly SerialPort _port;
        
        internal string Name { get; }
        
        internal SerialPortWrapper(string name)
        {
            Name = name;
            _port = new SerialPort(name);
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

        internal delegate string ReadLineHandler(string line);

        private event ReadLineHandler? Notify;
        
        internal event ReadLineHandler? ReadingLineNotify
        {
            add
            {
                Notify += value;
                _port.DataReceived += DataReceivedHandler;
            }
            remove
            {
                Notify -= value;
                _port.DataReceived -= DataReceivedHandler;
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs args)
        {
            var line = _port.ReadLine();
            Notify?.Invoke(line);
        }
    }
}