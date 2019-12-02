using Astron.Network.Framing;

namespace Renaissance.Abstract.Network.Framing
{
    public class DofusMetadata : IMessageMetadata
    {
        public int MessageId { get; set; }

        public int LengthByteCount { get; } /* None = 0, Byte = 1, Short = 2, ThreeBytes = 3 */

        public int Length { get; set; }

        public uint InstanceId { get; set; }


        public DofusMetadata(int messageId, int length)
        {
            this.MessageId = messageId;
            this.Length = length;
            this.LengthByteCount = Length > ushort.MaxValue ? 3
                                : Length > byte.MaxValue ? 2
                                : Length > 0 ? 1
                                : 0;
        }

        public DofusMetadata(int messageId, int length, uint instanceId) : this(messageId, length)
        {
            this.InstanceId = instanceId;
        }

        public override string ToString()
        {
            return $"Message Id : {MessageId} | Length type : {LengthByteCount} | Packet length : {Length} | Instance Id : {InstanceId}";
        }
    }
}
