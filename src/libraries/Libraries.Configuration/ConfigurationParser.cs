using CottageTemperature.Libraries.Configuration.Sections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.Configuration
{
    /// <summary>
    ///     Class for getting settings from the configuration.
    /// </summary>
    public class ConfigurationParser
    {
        private readonly ILogger<ConfigurationParser> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        ///     Access token of telegram bot.
        /// </summary>
        public string AccessToken
        {
            get
            {
                var token = _configuration
                    .GetSection(nameof(Bot))
                    .Get<Bot>()?
                    .AccessToken;

                if (token is not null)
                    return token;
                
                _logger.LogError("Error when extracting a token");
                return string.Empty;
            }
        }
            
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="configuration"> Configuration. </param>
        public ConfigurationParser(ILogger<ConfigurationParser> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
    }
}