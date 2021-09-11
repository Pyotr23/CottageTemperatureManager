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
        private readonly SerialPortWrapper _masterPort;

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
            _masterPort = new SerialPortWrapper(name);
        }

        /// <inheritdoc cref="IPortService.Write"/>
        public void Write(string text)
        {
            if (!_masterPort.IsValid())
            {
                _logger.LogError("No COM-port with name \"{name}\"", _masterPort.Name);
                return;
            }

            try
            {
                _masterPort.Write(text);
            }
            catch (UnauthorizedAccessException exception)
            {
                _logger.LogError(exception, "Port \"{portName}\" already used", _masterPort.Name);
            }
        }

        /// <inheritdoc cref="IPortService.SubscribeToReceiveLine"/>
        public void SubscribeToReceiveLine(Func<string, Task> handler)
        {
            _masterPort.ReadingLineNotify += handler;
            _masterPort.Open();
        }
        
        /// <inheritdoc cref="IPortService.UnsubscribeToReceiveLine"/>
        public void UnsubscribeToReceiveLine(Func<string, Task> handler)
        {
            _masterPort.ReadingLineNotify -= handler;
            _masterPort.Close();
        }
    }
}