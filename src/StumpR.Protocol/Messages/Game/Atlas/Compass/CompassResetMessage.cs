using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CompassResetMessage : Message
{
    public const uint Id = 4432;

    public CompassResetMessage(sbyte type)
    {
        Type = type;
    }

    public CompassResetMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Type { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Type);
    }

    public override void Deserialize(IDataReader reader)
    {
        Type = reader.ReadSByte();
    }
}