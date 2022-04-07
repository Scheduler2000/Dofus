using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightTackledMessage : AbstractGameActionMessage
{
    public new const uint Id = 4448;

    public GameActionFightTackledMessage(ushort actionId, double sourceId, IEnumerable<double> tacklersIds)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TacklersIds = tacklersIds;
    }

    public GameActionFightTackledMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<double> TacklersIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) TacklersIds.Count());
        foreach (double objectToSend in TacklersIds) writer.WriteDouble(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort tacklersIdsCount = reader.ReadUShort();
        var tacklersIds_ = new double[tacklersIdsCount];

        for (var tacklersIdsIndex = 0; tacklersIdsIndex < tacklersIdsCount; tacklersIdsIndex++)
            tacklersIds_[tacklersIdsIndex] = reader.ReadDouble();
        TacklersIds = tacklersIds_;
    }
}