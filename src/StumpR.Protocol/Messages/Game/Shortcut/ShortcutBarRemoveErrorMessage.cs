using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShortcutBarRemoveErrorMessage : Message
{
    public const uint Id = 5661;

    public ShortcutBarRemoveErrorMessage(sbyte error)
    {
        Error = error;
    }

    public ShortcutBarRemoveErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Error { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Error);
    }

    public override void Deserialize(IDataReader reader)
    {
        Error = reader.ReadSByte();
    }
}