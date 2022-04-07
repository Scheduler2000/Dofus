/* ReSharper disable ConditionIsAlwaysTrueOrFalse */

#pragma warning disable CS8618
#pragma warning disable CS8625

using System;
using System.Collections.Generic;
using System.IO;
using StumpR.GUI.Sniffer.Network.Frame.Architecture;
using StumpR.Protocol;

namespace StumpR.GUI.Sniffer.Network.Frame;

public class DofusPacketBuilder
{
    public bool TryBuild(List<byte> buffer, out DofusPacket packet, bool isClient)
    {
        packet = default;

        CollectionReader reader = new(buffer);


        if (reader.Remaining < 2) return false;

        ushort header = reader.ReadUShort();

        if (isClient && reader.Remaining < 4) return false;

        uint instanceId = isClient ? reader.ReadUInt() : 0;

        int messageId = header >> 2;

        int lenType = header & 3;

        if (messageId <= 0 || lenType is < 0 or > 3 || !MessageReceiver.EnsureMessageId(messageId) || reader.Remaining < lenType)
            return false;

        int len = lenType switch
        {
            0 => 0,
            1 => reader.ReadByte(),
            2 => reader.ReadUShort(),
            3 => ((reader.ReadSByte() & 255) << 16) + ((reader.ReadSByte() & 255) << 8) + (reader.ReadSByte() & 255),
            _ => throw new InvalidDataException("Length type must be inside [0;3]")
        };

        if (reader.Remaining < len) return false;

        byte[] payload = reader.ReadBytes(len);

        DofusPacketMetadata metadata = new(messageId, lenType, len, instanceId);

        packet = new DofusPacket(metadata, payload);

        buffer.RemoveRange(0, reader.BytesRead);

        return true;
    }

    private class CollectionReader
    {
        private readonly List<byte> _buffer;

        public int BytesRead { get; private set; }

        public long Remaining => _buffer.Count - BytesRead;


        public CollectionReader(List<byte> buffer)
        {
            _buffer = buffer;
            BytesRead = 0;
        }

        public byte ReadByte()
        {
            if (Remaining < sizeof(byte)) throw new Exception("Not enough data");
            
            byte value = _buffer[BytesRead];

            BytesRead += 1;

            return value;
        }

        public sbyte ReadSByte()
        {
            if (Remaining < sizeof(sbyte)) throw new Exception("Not enough data");
            
            return (sbyte) ReadByte();
        }

        public byte[] ReadBytes(int len)
        {
            if (Remaining < len ) throw new Exception("Not enough data");
            
            byte[] values = new byte[len];
            
            for (int i = BytesRead; i < len; i++) values[i - BytesRead] = _buffer[i];

            BytesRead += len;
            
            return values;
        }
        
        public ushort ReadUShort()
        {
            if (Remaining < sizeof(ushort)) throw new Exception("Not enough data");
            
            var value = (ushort) ((_buffer[BytesRead] << 8) | _buffer[BytesRead + 1]);

            BytesRead += sizeof(ushort);

            return value;
        }

        public uint ReadUInt()
        {
            if (Remaining < sizeof(uint)) throw new Exception("Not enough data");
            
            var value = (uint) ((_buffer[BytesRead] << 24) |
                                (_buffer[BytesRead + 1] << 16) |
                                (_buffer[BytesRead + 2] << 8) |
                                _buffer[BytesRead + 3]);

            BytesRead += sizeof(uint);

            return value;
        }


    }

}