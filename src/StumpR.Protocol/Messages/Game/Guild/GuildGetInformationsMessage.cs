using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildGetInformationsMessage : Message
{
    public const uint Id = 5805;

    public GuildGetInformationsMessage(sbyte infoType)
    {
        InfoType = infoType;
    }

    public GuildGetInformationsMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte InfoType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(InfoType);
    }

    public override void Deserialize(IDataReader reader)
    {
        InfoType = reader.ReadSByte();
    }
}