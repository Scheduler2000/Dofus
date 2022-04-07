using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildApplicationDeletedMessage : Message
{
    public const uint Id = 5546;

    public GuildApplicationDeletedMessage(bool deleted)
    {
        Deleted = deleted;
    }

    public GuildApplicationDeletedMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Deleted { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Deleted);
    }

    public override void Deserialize(IDataReader reader)
    {
        Deleted = reader.ReadBoolean();
    }
}