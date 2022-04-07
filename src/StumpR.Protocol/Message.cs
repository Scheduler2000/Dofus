using StumpR.Binary;

namespace StumpR.Protocol;

public abstract class Message
{
    private const byte BitRightShiftLenPacketId = 2;
    private const byte BitMask = 3;

    public abstract uint MessageId { get; }

    protected Message()
    {
    }

    public void Unpack(IDataReader reader)
    {
        Deserialize(reader);
    }

    public void Pack(IDataWriter writer)
    {
        byte typeLen = 3;
        var header = (short) SubComputeStaticHeader(MessageId, typeLen);

        writer.WriteShort(header);

        for (int i = typeLen - 1; i >= 0; i--) writer.WriteByte(0);

        Serialize(writer);
        long len = writer.Position - 5;
        writer.Seek(2, SeekOrigin.Begin);

        for (int i = typeLen - 1; i >= 0; i--) writer.WriteByte((byte) ((len >> (8 * i)) & 255));

        writer.Seek((int) len + 5, SeekOrigin.Begin);
    }

    public abstract void Serialize(IDataWriter writer);
    public abstract void Deserialize(IDataReader reader);

    private static byte ComputeTypeLen(int param1)
    {
        return param1 switch
        {
            > 65535 => 3,
            > 255 => 2,
            > 0 => 1,
            _ => 0
        };
    }

    private static uint SubComputeStaticHeader(uint id, byte typeLen)
    {
        return (id << BitRightShiftLenPacketId) | typeLen;
    }

    public override string ToString()
    {
        return GetType().Name;
    }
}