using System.IO.Ports;
using System.Linq;

namespace CottageTemperature.Libraries.IO
{
    internal class Port
    {
        private readonly SerialPort _instance;
        
        internal string Name { get; }
        
        internal Port(string name)
        {
            Name = name;
            _instance = new SerialPort(name);
        }

        internal void Write(string text)
        {
            _instance.Open();
            _instance.Write(text);
            _instance.Close();
        }

        internal bool IsValid()
        {
            return SerialPort
                .GetPortNames()
                .Any(portName => portName == Name);
        }
    }
}