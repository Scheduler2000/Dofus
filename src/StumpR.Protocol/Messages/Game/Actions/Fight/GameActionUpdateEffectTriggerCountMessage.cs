using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionUpdateEffectTriggerCountMessage : Message
{
    public const uint Id = 6461;

    public GameActionUpdateEffectTriggerCountMessage(IEnumerable<GameFightEffectTriggerCount> targetIds)
    {
        TargetIds = targetIds;
    }

    public GameActionUpdateEffectTriggerCountMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameFightEffectTriggerCount> TargetIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) TargetIds.Count());
        foreach (GameFightEffectTriggerCount objectToSend in TargetIds) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort targetIdsCount = reader.ReadUShort();
        var targetIds_ = new GameFightEffectTriggerCount[targetIdsCount];

        for (var targetIdsIndex = 0; targetIdsIndex < targetIdsCount; targetIdsIndex++)
        {
            var objectToAdd = new GameFightEffectTriggerCount();
            objectToAdd.Deserialize(reader);
            targetIds_[targetIdsIndex] = objectToAdd;
        }
        TargetIds = targetIds_;
    }
}