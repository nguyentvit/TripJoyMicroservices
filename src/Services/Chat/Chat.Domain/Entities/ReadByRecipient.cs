namespace Chat.Domain.Entities
{
    public class ReadByRecipient : Entity<ReadByRecipientId>
    {
        public UserId ReadByUserId { get; private set; }
        private ReadByRecipient(ReadByRecipientId id, UserId readByUserId)
        {
            Id = id;
            ReadByUserId = readByUserId;
        }
        public static ReadByRecipient Of(UserId readByUserId)
        {
            var readByRecipient = new ReadByRecipient(ReadByRecipientId.Of(Guid.NewGuid()), readByUserId);
            return readByRecipient;
        }

    }
}
