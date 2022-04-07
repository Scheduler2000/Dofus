using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartOkMulticraftCrafterMessage : Message
{
    public const uint Id = 282;

    public ExchangeStartOkMulticraftCrafterMessage(uint skillId)
    {
        SkillId = skillId;
    }

    public ExchangeStartOkMulticraftCrafterMessage()
    {
    }

    public override uint MessageId => Id;

    public uint SkillId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(SkillId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SkillId = reader.ReadVarUInt();
    }
}