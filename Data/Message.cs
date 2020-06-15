using System;

namespace chat_app.Data
{
    public enum MessageType
    {
        System,
        User
    }

    public class Message
    {
        public long Id { get; set; }

        public long AuthorId { get; set; }

        public MessageType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Content { get; set; }

        public bool IsEdited { get; set; }

        public bool IsDeleted { get; set; }
    }
}