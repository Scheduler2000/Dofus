using System.Buffers;
using System.Buffers.Binary;
using System.Text;

namespace StumpR.Binary.BigEndian;

public class BigEndianReader : IDataReader
{
    private readonly byte[] _buffer;

    public int BytesRead { get; private set; }

    public long Remaining => _buffer.Length - BytesRead;


    public BigEndianReader(byte[] buffer)
    {
        _buffer = buffer;
        BytesRead = 0;
    }

    public BigEndianReader(MemoryStream stream) : this(stream.ToArray())
    {
    }

    public BigEndianReader(ReadOnlySequence<byte> buffer)
    {
        _buffer = buffer.ToArray();
        BytesRead = 0;
    }

    public short ReadShort()
    {
        short value = BinaryPrimitives.ReadInt16BigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(short);
        return value;
    }

    public int ReadInt()
    {
        int value = BinaryPrimitives.ReadInt32BigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(int);
        return value;
    }

    public long ReadLong()
    {
        long value = BinaryPrimitives.ReadInt64BigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(long);
        return value;
    }

    public ushort ReadUShort()
    {
        ushort value = BinaryPrimitives.ReadUInt16BigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(ushort);
        return value;
    }

    public uint ReadUInt()
    {
        uint value = BinaryPrimitives.ReadUInt32BigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(uint);
        return value;
    }

    public ulong ReadULong()
    {
        ulong value = BinaryPrimitives.ReadUInt64BigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(ulong);
        return value;
    }

    public byte ReadByte()
    {
        byte value = _buffer[BytesRead];
        BytesRead += sizeof(byte);
        return value;
    }

    public sbyte ReadSByte()
    {
        return (sbyte) ReadByte();
    }

    public byte[] ReadBytes(int length)
    {
        var buffer = _buffer.AsSpan()[BytesRead..(BytesRead + length)];
        BytesRead += length;
        return buffer.ToArray();
    }

    public bool ReadBoolean()
    {
        return ReadByte() == 1;
    }

    public double ReadDouble()
    {
        double value = BinaryPrimitives.ReadDoubleBigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(double);
        return value;
    }

    public float ReadFloat()
    {
        float value = BinaryPrimitives.ReadSingleBigEndian(_buffer.AsSpan()[BytesRead..]);
        BytesRead += sizeof(float);
        return value;
    }

    public string ReadUTF()
    {
        ushort length = ReadUShort();
        return ReadUTFBytes(length);
    }

    public string ReadUTFBytes(ushort len)
    {
        byte[] encoded = ReadBytes(len);
        return Encoding.UTF8.GetString(encoded);
    }

    public char ReadChar()
    {
        return (char) ReadShort();
    }

    public short ReadVarShort()
    {
        var result = 0;

        for (var offset = 0; offset < 16; offset += 7)
        {
            byte readByte = ReadByte();
            bool hasNext = (readByte & 128) is 128;

            if (offset > 0)
                result += (readByte & sbyte.MaxValue) << offset;
            else
                result += readByte & sbyte.MaxValue;

            if (result > short.MaxValue) result -= 65536;

            if (hasNext) continue;

            return (short) result;
        }
        
        throw new ArgumentException("Too much data.");
    }

    public ushort ReadVarUShort()
    {
        return (ushort) ReadVarShort();
    }

    public int ReadVarInt()
    {
        var result = 0;
        var hasNext = true;

        for (var offset = 0; offset < 32 && hasNext; offset += 7)
        {
            byte readByte = ReadByte();
            hasNext = (readByte & 128) == 128;

            if (offset > 0)
                result += (readByte & sbyte.MaxValue) << offset;
            else
                result += readByte & sbyte.MaxValue;
        }

        return result;
    }

    public uint ReadVarUInt()
    {
        return (uint) ReadVarInt();
    }

    public long ReadVarLong()
    {
        uint low = 0;
        int high;
        var i = 0;
        int b;

        while (true)
        {
            b = ReadByte();

            if (i is 28) break;

            if (b < 128)
            {
                low |= (uint) (b << i);
                return low;
            }

            low |= (uint) ((b & sbyte.MaxValue) << i);
            i += 7;
        }

        if (b >= 128)
        {
            b &= sbyte.MaxValue;
            low |= (uint) (b << i);
            high = b >> 4;
            i = 3;

            while (true)
            {
                b = ReadByte();

                if (i < 32)
                {
                    if (b >= 128)
                        high |= (b & sbyte.MaxValue) << i;

                    else
                        break;
                }

                i += 7;
            }

            high |= b << i;
            return high * 4294967296 + low;
        }

        low |= (uint) (b << i);
        high = b >> 4;
        return high * 4294967296 + low;
    }

    public ulong ReadVarULong()
    {
        return (ulong) ReadVarLong();
    }


    public void Seek(int offset, SeekOrigin seekOrigin)
    {
        BytesRead = seekOrigin switch
        {
            SeekOrigin.Begin => offset,
            SeekOrigin.Current => BytesRead + offset,
            SeekOrigin.End => BytesRead - Math.Abs(offset),
            _ => throw new ArgumentOutOfRangeException(nameof(seekOrigin), seekOrigin, null)
        };
    }
}