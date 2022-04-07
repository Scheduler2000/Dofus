using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismsListRegisterMessage : Message
{
    public const uint Id = 4105;

    public PrismsListRegisterMessage(sbyte listen)
    {
        Listen = listen;
    }

    public PrismsListRegisterMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Listen { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Listen);
    }

    public override void Deserialize(IDataReader reader)
    {
        Listen = reader.ReadSByte();
    }
}