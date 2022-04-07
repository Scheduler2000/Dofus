using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MoodSmileyRequestMessage : Message
{
    public const uint Id = 610;

    public MoodSmileyRequestMessage(ushort smileyId)
    {
        SmileyId = smileyId;
    }

    public MoodSmileyRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SmileyId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SmileyId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SmileyId = reader.ReadVarUShort();
    }
}