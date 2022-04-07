using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightChangeLookMessage : AbstractGameActionMessage
{
    public new const uint Id = 4039;

    public GameActionFightChangeLookMessage(ushort actionId, double sourceId, double targetId, EntityLook entityLook)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        EntityLook = entityLook;
    }

    public GameActionFightChangeLookMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public EntityLook EntityLook { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        EntityLook.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        EntityLook = new EntityLook();
        EntityLook.Deserialize(reader);
    }
}