using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightCastOnTargetRequestMessage : Message
{
    public const uint Id = 8001;

    public GameActionFightCastOnTargetRequestMessage(ushort spellId, double targetId)
    {
        SpellId = spellId;
        TargetId = targetId;
    }

    public GameActionFightCastOnTargetRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SpellId { get; set; }

    public double TargetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SpellId);
        writer.WriteDouble(TargetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellId = reader.ReadVarUShort();
        TargetId = reader.ReadDouble();
    }
}