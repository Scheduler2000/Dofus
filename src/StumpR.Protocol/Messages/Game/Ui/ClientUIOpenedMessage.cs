using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ClientUIOpenedMessage : Message
{
    public const uint Id = 7354;

    public ClientUIOpenedMessage(sbyte type)
    {
        Type = type;
    }

    public ClientUIOpenedMessage()
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