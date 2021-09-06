using System.Threading.Tasks;

namespace CottageTemperature.Libraries.Core.Services
{
    /// <summary>
    ///     Service for working with serial port.
    /// </summary>
    public interface ISerialPortService
    {
        /// <summary>
        ///     Write text to serial port.
        /// </summary>
        /// <param name="text"> Text. </param>
        void Write(string text);
    }
}