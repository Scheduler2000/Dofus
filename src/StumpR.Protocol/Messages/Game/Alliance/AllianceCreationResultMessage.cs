using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceCreationResultMessage : Message
{
    public const uint Id = 4954;

    public AllianceCreationResultMessage(sbyte result)
    {
        Result = result;
    }

    public AllianceCreationResultMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Result { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Result);
    }

    public override void Deserialize(IDataReader reader)
    {
        Result = reader.ReadSByte();
    }
}