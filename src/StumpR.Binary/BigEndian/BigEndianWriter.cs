using System.Buffers.Binary;
using System.Text;

namespace StumpR.Binary.BigEndian;

public class BigEndianWriter : IDataWriter
{
    private readonly MemoryStream _stream;
    
    public long BytesAvailable => _stream.Length - _stream.Position;

    
    public byte[] Buffer => _stream.ToArray();

    public long Position => _stream.Position;
    
    public BigEndianWriter(int size)
    {
        _stream = new MemoryStream(size);
    }

    public BigEndianWriter(MemoryStream stream)
    {
        _stream = stream;
    }

    public BigEndianWriter() : this(new MemoryStream())
    { }
    


    public void WriteShort(short value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];

        BinaryPrimitives.WriteInt16BigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteInt(int value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];

        BinaryPrimitives.WriteInt32BigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteLong(long value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];

        BinaryPrimitives.WriteInt64BigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteUShort(ushort value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];

        BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteUInt(uint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];

        BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteULong(ulong value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];

        BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteFloat(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];

        BinaryPrimitives.WriteSingleBigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteBoolean(bool value)
    {
        _stream.WriteByte((byte) (value ? 1 : 0));
    }


    public void WriteDouble(double value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];

        BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteSingle(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];

        BinaryPrimitives.WriteSingleBigEndian(buffer, value);
        _stream.Write(buffer);
    }

    public void WriteUTF(string value)
    {
        var encoded = Encoding.UTF8.GetBytes(value);
        var length = (ushort) encoded.Length;

        WriteUShort(length);
        WriteBytes(encoded);
    }

    public void WriteUTFBytes(string value)
    {
        var encoded = Encoding.UTF8.GetBytes(value);
        WriteBytes(encoded);
    }

    public void WriteChar(char value)
    {
        WriteShort((short) value);
    }

    public void WriteByte(byte value)
    {
        _stream.WriteByte(value);
    }

    public void WriteSByte(sbyte value)
    {
        _stream.WriteByte((byte) value);
    }

    public void WriteBytes(byte[] data)
    {
        _stream.Write(data, 0, data.Length);
    }

    public void WriteVarShort(short value)
    {
        if (value is >= sbyte.MinValue and <= sbyte.MaxValue)
        {
            WriteByte((byte) value);
            return;
        }

        var c = value & ushort.MaxValue;

        while (c is not 0)
        {
            var b = c & sbyte.MaxValue;
            c = (int) ((uint) c >> 7);

            if (c > 0) b |= 128;

            WriteByte((byte) b);
        }
    }

    public void WriteVarUShort(ushort value)
    {
        WriteVarShort((short) value);
    }

    public void WriteVarInt(int value)
    {
        if (value is >= 0 and <= sbyte.MaxValue)
        {
            WriteByte((byte) value);
            return;
        }

        while (value is not 0)
        {
            var b = value & sbyte.MaxValue;
            value = (int) ((uint) value >> 7);

            if (value > 0) b |= 128;

            WriteByte((byte) b);
        }
    }

    public void WriteVarUInt(uint value)
    {
        WriteVarInt((int) value);
    }


    public void WriteVarLong(long value)
    {
        void WriteVarInt32(uint val)
        {
            while (val >= 128)
            {
                WriteByte((byte) ((val & sbyte.MaxValue) | 128));
                val >>= 7;
            }

            WriteByte((byte) val);
        }

        double newValue = value;
        var low = (uint) newValue;
        var high = (int) Math.Floor(newValue / 4294967296);

        if (high is 0)
        {
            WriteVarInt32(low);
        }
        else
        {
            for (var i = 0; i < 4; i++)
            {
                WriteByte((byte) ((low & sbyte.MaxValue) | 128));
                low >>= 7;
            }

            if ((high & (268435455 << 3)) is 0)
            {
                WriteByte((byte) (((uint) high << 4) | low));
            }
            else
            {
                WriteByte((byte) ((((uint) (high << 4) | low) & sbyte.MaxValue) | 128));
                WriteVarInt32((uint) high >> 3);
            }
        }
    }

    public void WriteVarULong(ulong value)
    {
        WriteVarLong((long) value);
    }

    public void Seek(int offset, SeekOrigin seekOrigin)
    {
        _stream.Seek(offset, seekOrigin);
    }


    public void Dispose()
    {
        _stream.Dispose();
    }
}