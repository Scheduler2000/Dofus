using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InteractiveUseWithParamRequestMessage : InteractiveUseRequestMessage
{
    public new const uint Id = 6220;

    public InteractiveUseWithParamRequestMessage(uint elemId, uint skillInstanceUid, int objectId)
    {
        ElemId = elemId;
        SkillInstanceUid = skillInstanceUid;
        ObjectId = objectId;
    }

    public InteractiveUseWithParamRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public int ObjectId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(ObjectId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectId = reader.ReadInt();
    }
}