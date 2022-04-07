using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildPaddockTeleportRequestMessage : Message
{
    public const uint Id = 7914;

    public GuildPaddockTeleportRequestMessage(double paddockId)
    {
        PaddockId = paddockId;
    }

    public GuildPaddockTeleportRequestMessage()
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