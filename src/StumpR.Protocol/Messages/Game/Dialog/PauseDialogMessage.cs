using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PauseDialogMessage : Message
{
    public const uint Id = 8906;

    public PauseDialogMessage(sbyte dialogType)
    {
        DialogType = dialogType;
    }

    public PauseDialogMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte DialogType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(DialogType);
    }

    public override void Deserialize(IDataReader reader)
    {
        DialogType = reader.ReadSByte();
    }
}