namespace CottageTemperature.Web.Configurations
{
    /// <summary>
    ///     Bot configuration section.
    /// </summary>
    public record Bot
    {
        /// <summary>
        ///     Access token.
        /// </summary>
        public string AccessToken { get; set; }
    }
}