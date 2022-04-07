using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightTurnListMessage : Message
{
    public const uint Id = 7238;

    public GameFightTurnListMessage(IEnumerable<double> ids, IEnumerable<double> deadsIds)
    {
        Ids = ids;
        DeadsIds = deadsIds;
    }

    public GameFightTurnListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<double> Ids { get; set; }

    public IEnumerable<double> DeadsIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Ids.Count());
        foreach (double objectToSend in Ids) writer.WriteDouble(objectToSend);
        writer.WriteShort((short) DeadsIds.Count());
        foreach (double objectToSend in DeadsIds) writer.WriteDouble(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort idsCount = reader.ReadUShort();
        var ids_ = new double[idsCount];
        for (var idsIndex = 0; idsIndex < idsCount; idsIndex++) ids_[idsIndex] = reader.ReadDouble();
        Ids = ids_;
        ushort deadsIdsCount = reader.ReadUShort();
        var deadsIds_ = new double[deadsIdsCount];
        for (var deadsIdsIndex = 0; deadsIdsIndex < deadsIdsCount; deadsIdsIndex++) deadsIds_[deadsIdsIndex] = reader.ReadDouble();
        DeadsIds = deadsIds_;
    }
}