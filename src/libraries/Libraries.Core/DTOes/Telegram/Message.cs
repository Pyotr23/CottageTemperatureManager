namespace CottageTemperature.Libraries.Core.DTOes.Telegram
{
    /// <summary>
    ///     DTO of bot message.
    /// </summary>
    public record Message
    {
        /// <summary>
        ///     Identificator.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        ///     Chat identificator.
        /// </summary>
        public long ChatId { get; set; }
        
        /// <summary>
        ///     Chat name.
        /// </summary>
        public string? ChatName { get; set; }
        
        /// <summary>
        ///     Sender username.
        /// </summary>
        public string? SenderUsername { get; set; }
        
        /// <summary>
        ///     Message text.
        /// </summary>
        public string? Text { get; set; }
        
        /// <summary>
        ///     Flag whether the message is a command.
        /// </summary>
        public bool IsCommand { get; set; }
    }
}