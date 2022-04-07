using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage
{
    public new const uint Id = 6409;

    public GameActionFightTriggerEffectMessage(ushort actionId, double sourceId, double targetId, bool verboseCast, int boostUID)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        VerboseCast = verboseCast;
        BoostUID = boostUID;
    }

    public GameActionFightTriggerEffectMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}