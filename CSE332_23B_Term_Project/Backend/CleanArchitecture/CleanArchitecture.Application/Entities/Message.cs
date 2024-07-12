using System;

namespace CleanArchitecture.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string SenderRole { get; set; } // Role of the sender (e.g., "User" or "Caretaker")
        public string ReceiverId { get; set; }
        public string ReceiverRole { get; set; } // Role of the receiver (e.g., "User" or "Caretaker")
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
