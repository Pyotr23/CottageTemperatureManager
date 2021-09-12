using System;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Configuration;
using CottageTemperature.Libraries.Core.Services;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.IO
{
    /// <inheritdoc cref="IPortService"/>
    public class SerialPortService : IPortService
    {
        private readonly ILogger<SerialPortService> _logger;
        private readonly SerialPortWrapper _port;

        /// <inheritdoc cref="IPortService.PortName"/>
        public string PortName => _port.Name;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="configuration"> Configuration. </param>
        public SerialPortService(ILogger<SerialPortService> logger, 
            ConfigurationParser configuration)
        {
            _logger = logger;
            
            var name = configuration.TemperatureControlComPortName;
            _port = new SerialPortWrapper(name);
        }

        /// <inheritdoc cref="IPortService.Write"/>
        public void Write(string text)
        {
            if (!_port.IsValid())
            {
                _logger.LogError("No COM-port with name \"{PortName}\"", PortName);
                return;
            }

            try
            {
                _port.Write(text);
            }
            catch (UnauthorizedAccessException exception)
            {
                _logger.LogError(exception, "Port \"{PortName}\" already used", PortName);
            }
        }

        /// <inheritdoc cref="IPortService.SubscribeToReceiveLine"/>
        public void SubscribeToReceiveLine(Func<string, Task> handler)
        {
            _port.ReadingLineNotify += handler;
            _port.Open();
        }
        
        /// <inheritdoc cref="IPortService.UnsubscribeToReceiveLine"/>
        public void UnsubscribeToReceiveLine(Func<string, Task> handler)
        {
            _port.ReadingLineNotify -= handler;
            _port.Close();
        }
    }
}