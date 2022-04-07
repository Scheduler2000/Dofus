using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CurrentMapMessage : Message
{
    public const uint Id = 9325;

    public CurrentMapMessage(double mapId, string mapKey)
    {
        MapId = mapId;
        MapKey = mapKey;
    }

    public CurrentMapMessage()
    {
    }

    public override uint MessageId => Id;

    public double MapId { get; set; }

    public string MapKey { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MapId);
        writer.WriteUTF(MapKey);
    }

    public override void Deserialize(IDataReader reader)
    {
        MapId = reader.ReadDouble();
        MapKey = reader.ReadUTF();
    }
}