namespace Chat.Domain.ValueObjects
{
    public record ChatRoomAvatar
    {
        public string Url { get; }
        private ChatRoomAvatar(string url) => Url = url;
        public static ChatRoomAvatar Of(string url)
        {
            return new ChatRoomAvatar(url);
        }
    }
}
