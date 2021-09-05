namespace CottageTemperature.Libraries.Core.DTOes.Telegram
{
    public record Message
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string? ChatName { get; set; }
        public string? SenderUsername { get; set; }
        public string? Text { get; set; }
        public bool IsCommand { get; set; }
    }
}