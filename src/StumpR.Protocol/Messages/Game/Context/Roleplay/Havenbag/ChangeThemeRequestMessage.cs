using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChangeThemeRequestMessage : Message
{
    public const uint Id = 8958;

    public ChangeThemeRequestMessage(sbyte theme)
    {
        Theme = theme;
    }

    public ChangeThemeRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Theme { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Theme);
    }

    public override void Deserialize(IDataReader reader)
    {
        Theme = reader.ReadSByte();
    }
}