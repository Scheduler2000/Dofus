using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LockableCodeResultMessage : Message
{
    public const uint Id = 3222;

    public LockableCodeResultMessage(sbyte result)
    {
        Result = result;
    }

    public LockableCodeResultMessage()
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