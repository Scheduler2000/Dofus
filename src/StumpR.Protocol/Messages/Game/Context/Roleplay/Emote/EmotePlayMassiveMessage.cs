using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
{
    public new const uint Id = 7780;

    public EmotePlayMassiveMessage(ushort emoteId, double emoteStartTime, IEnumerable<double> actorIds)
    {
        EmoteId = emoteId;
        EmoteStartTime = emoteStartTime;
        ActorIds = actorIds;
    }

    public EmotePlayMassiveMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<double> ActorIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) ActorIds.Count());
        foreach (double objectToSend in ActorIds) writer.WriteDouble(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort actorIdsCount = reader.ReadUShort();
        var actorIds_ = new double[actorIdsCount];
        for (var actorIdsIndex = 0; actorIdsIndex < actorIdsCount; actorIdsIndex++) actorIds_[actorIdsIndex] = reader.ReadDouble();
        ActorIds = actorIds_;
    }
}