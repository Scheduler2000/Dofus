using System;

namespace Renaissance.Abstract.Frame
{

    [AttributeUsage(AttributeTargets.Method)]
    public class MessageHandlerAttribute : Attribute
    {
        public int MessageId { get; }


        public MessageHandlerAttribute(int messageId)
        { this.MessageId = messageId; }
    }
}
