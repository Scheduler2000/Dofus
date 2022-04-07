using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DungeonKeyRingUpdateMessage : Message
{
    public const uint Id = 2874;

    public DungeonKeyRingUpdateMessage(ushort dungeonId, bool available)
    {
        DungeonId = dungeonId;
        Available = available;
    }

    public DungeonKeyRingUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public bool Available { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
        writer.WriteBoolean(Available);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
        Available = reader.ReadBoolean();
    }
}