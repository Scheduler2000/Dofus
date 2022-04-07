using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NpcDialogCreationMessage : Message
{
    public const uint Id = 5848;

    public NpcDialogCreationMessage(double mapId, int npcId)
    {
        MapId = mapId;
        NpcId = npcId;
    }

    public NpcDialogCreationMessage()
    {
    }

    public override uint MessageId => Id;

    public double MapId { get; set; }

    public int NpcId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MapId);
        writer.WriteInt(NpcId);
    }

    public override void Deserialize(IDataReader reader)
    {
        MapId = reader.ReadDouble();
        NpcId = reader.ReadInt();
    }
}