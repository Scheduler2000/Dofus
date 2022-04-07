using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShortcutBarSwapErrorMessage : Message
{
    public const uint Id = 3330;

    public ShortcutBarSwapErrorMessage(sbyte error)
    {
        Error = error;
    }

    public ShortcutBarSwapErrorMessage()
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