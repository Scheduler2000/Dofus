using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DungeonPartyFinderListenRequestMessage : Message
{
    public const uint Id = 1266;

    public DungeonPartyFinderListenRequestMessage(ushort dungeonId)
    {
        DungeonId = dungeonId;
    }

    public DungeonPartyFinderListenRequestMessage()
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