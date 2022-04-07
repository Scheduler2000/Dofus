using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
{
    public new const uint Id = 1560;

    public GameActionFightDispellEffectMessage(ushort actionId, double sourceId, double targetId, bool verboseCast, int boostUID)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        VerboseCast = verboseCast;
        BoostUID = boostUID;
    }

    public GameActionFightDispellEffectMessage()
    {
    }

    public override uint MessageId => Id;

    public int BoostUID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(BoostUID);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        BoostUID = reader.ReadInt();
    }
}