using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildPaddockRemovedMessage : Message
{
    public const uint Id = 9960;

    public GuildPaddockRemovedMessage(double paddockId)
    {
        PaddockId = paddockId;
    }

    public GuildPaddockRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public double PaddockId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(PaddockId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PaddockId = reader.ReadDouble();
    }
}