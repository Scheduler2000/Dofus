using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatSmileyRequestMessage : Message
{
    public const uint Id = 9062;

    public ChatSmileyRequestMessage(ushort smileyId)
    {
        SmileyId = smileyId;
    }

    public ChatSmileyRequestMessage()
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