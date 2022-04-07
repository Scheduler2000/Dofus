using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AccessoryPreviewErrorMessage : Message
{
    public const uint Id = 2038;

    public AccessoryPreviewErrorMessage(sbyte error)
    {
        Error = error;
    }

    public AccessoryPreviewErrorMessage()
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