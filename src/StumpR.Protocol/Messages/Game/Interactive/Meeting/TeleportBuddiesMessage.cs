using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportBuddiesMessage : Message
{
    public const uint Id = 9150;

    public TeleportBuddiesMessage(ushort dungeonId)
    {
        DungeonId = dungeonId;
    }

    public TeleportBuddiesMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
    }
}