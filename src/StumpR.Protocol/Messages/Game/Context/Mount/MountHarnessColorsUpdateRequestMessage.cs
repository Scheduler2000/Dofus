using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountHarnessColorsUpdateRequestMessage : Message
{
    public const uint Id = 7947;

    public MountHarnessColorsUpdateRequestMessage(bool useHarnessColors)
    {
        UseHarnessColors = useHarnessColors;
    }

    public MountHarnessColorsUpdateRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool UseHarnessColors { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(UseHarnessColors);
    }

    public override void Deserialize(IDataReader reader)
    {
        UseHarnessColors = reader.ReadBoolean();
    }
}