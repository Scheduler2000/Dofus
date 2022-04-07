using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SymbioticObjectErrorMessage : ObjectErrorMessage
{
    public new const uint Id = 8441;

    public SymbioticObjectErrorMessage(sbyte reason, sbyte errorCode)
    {
        Reason = reason;
        ErrorCode = errorCode;
    }

    public SymbioticObjectErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ErrorCode { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(ErrorCode);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ErrorCode = reader.ReadSByte();
    }
}