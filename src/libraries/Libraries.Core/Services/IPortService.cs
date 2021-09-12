using System;
using System.Threading.Tasks;

namespace CottageTemperature.Libraries.Core.Services
{
    /// <summary>
    ///     Service for working with port.
    /// </summary>
    public interface IPortService
    {
        /// <summary>
        ///     Write text to serial port.
        /// </summary>
        /// <param name="text"> Text. </param>
        void Write(string text);

        /// <summary>
        ///     Subscribe to receive line.
        /// </summary>
        /// <param name="handler"> Handler. </param>
        void SubscribeToReceiveLine(Func<string, Task> handler);
        
        /// <summary>
        ///     Unsubscribe to receive line.
        /// </summary>
        /// <param name="handler"> Handler. </param>
        void UnsubscribeToReceiveLine(Func<string, Task> handler);
    }
}