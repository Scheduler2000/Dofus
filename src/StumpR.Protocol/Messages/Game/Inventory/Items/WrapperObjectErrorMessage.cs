using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WrapperObjectErrorMessage : SymbioticObjectErrorMessage
{
    public new const uint Id = 1930;

    public WrapperObjectErrorMessage(sbyte reason, sbyte errorCode)
    {
        Reason = reason;
        ErrorCode = errorCode;
    }

    public WrapperObjectErrorMessage()
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