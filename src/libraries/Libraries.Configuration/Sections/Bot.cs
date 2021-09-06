namespace CottageTemperature.Libraries.Configuration.Sections
{
    /// <summary>
    ///     Bot configuration section.
    /// </summary>
    public record Bot
    {
        /// <summary>
        ///     Access token.
        /// </summary>
        public string? AccessToken { get; set; }
    }
}