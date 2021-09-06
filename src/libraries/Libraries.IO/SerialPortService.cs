using System;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Configuration;
using CottageTemperature.Libraries.Core.Services;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.IO
{
    /// <inheritdoc cref="ISerialPortService"/>
    public class SerialPortService : ISerialPortService
    {
        private readonly ILogger<SerialPortService> _logger;
        private readonly Port _masterPort;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="configuration"> Configuration. </param>
        public SerialPortService(ILogger<SerialPortService> logger, ConfigurationParser configuration)
        {
            _logger = logger;
            var name = configuration.TemperatureControlComPortName;
            _masterPort = new Port(name);
        }

        /// <inheritdoc cref="ISerialPortService.Write"/>
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
    }
}