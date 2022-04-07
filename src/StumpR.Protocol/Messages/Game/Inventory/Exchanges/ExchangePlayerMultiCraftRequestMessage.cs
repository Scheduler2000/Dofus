using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
{
    public new const uint Id = 6947;

    public ExchangePlayerMultiCraftRequestMessage(sbyte exchangeType, ulong target, uint skillId)
    {
        ExchangeType = exchangeType;
        Target = target;
        SkillId = skillId;
    }

    public ExchangePlayerMultiCraftRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Target { get; set; }

    public uint SkillId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Target);
        writer.WriteVarUInt(SkillId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Target = reader.ReadVarULong();
        SkillId = reader.ReadVarUInt();
    }
}