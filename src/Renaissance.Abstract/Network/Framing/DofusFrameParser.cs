using System;
using System.Buffers;
using System.Buffers.Binary;
using Astron.Network.Buffers;
using Astron.Network.Framing;

namespace Renaissance.Abstract.Network.Framing
{
    public class DofusFrameParser : FrameParser<DofusMetadata>
    {
        private const int m_headerSize = 2;
        private const int m_instanceId = 4;

        protected override int GetMetadataLengthAbs(DofusMetadata metadata)
        {
            bool messageFromServer = metadata.InstanceId == 0;

            return messageFromServer ? m_headerSize + metadata.LengthByteCount
                                     : m_headerSize + metadata.LengthByteCount + m_instanceId;
        }

        protected override bool TryParseMetadata(ReadOnlySequence<byte> input, out DofusMetadata metadata)
        {
            int read_dofus_length(ReadOnlySpan<byte> buffer, int lengthByteCount)
            {
                var length = 0;
                for (int i = lengthByteCount - 1, j = 0; i >= 0; i--, j++)
                    length |= buffer[j] << (i * 8);

                return length;
            }

            metadata = default;
            var seqReader = new SequenceReader(input);

            if (!seqReader.TryRead(BinaryPrimitives.ReadInt16BigEndian, out short header))
                return false;
            if (!seqReader.TryRead(BinaryPrimitives.ReadUInt32BigEndian, out uint instanceId))
                return false;

            int messageId = header >> 2;
            int lenByteCount = header & 3;

            if (messageId <= 0)
                return false;
            if (!seqReader.TryRead(read => read_dofus_length(read, lenByteCount), lenByteCount, out int length))
                return false;

            metadata = new DofusMetadata(messageId, length, instanceId);
            return true;

        }

        protected override void WriteMetadataAbs(Span<byte> buffer, DofusMetadata metadata)
        {
            short header = (short)((metadata.MessageId << 2) | (byte)metadata.LengthByteCount);
            BinaryPrimitives.WriteInt16BigEndian(buffer, header);

            if (metadata.LengthByteCount == 0)
                return;

            var span = buffer.Slice(2);
            switch (metadata.LengthByteCount)
            {
                case 1:
                    span[0] = (byte)metadata.Length;
                    break;
                case 2:
                    BinaryPrimitives.WriteInt16BigEndian(span, (short)metadata.Length);
                    break;
                case 3:
                    span[0] = (byte)((metadata.Length >> 16) & byte.MaxValue);
                    BinaryPrimitives.WriteInt16BigEndian(span.Slice(1), (short)(metadata.Length & ushort.MaxValue));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(metadata.LengthByteCount));
            }
        }
    }
}
