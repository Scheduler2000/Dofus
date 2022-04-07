using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InteractiveUseRequestMessage : Message
{
    public const uint Id = 9714;

    public InteractiveUseRequestMessage(uint elemId, uint skillInstanceUid)
    {
        ElemId = elemId;
        SkillInstanceUid = skillInstanceUid;
    }

    public InteractiveUseRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ElemId { get; set; }

    public uint SkillInstanceUid { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ElemId);
        writer.WriteVarUInt(SkillInstanceUid);
    }

    public override void Deserialize(IDataReader reader)
    {
        ElemId = reader.ReadVarUInt();
        SkillInstanceUid = reader.ReadVarUInt();
    }
}