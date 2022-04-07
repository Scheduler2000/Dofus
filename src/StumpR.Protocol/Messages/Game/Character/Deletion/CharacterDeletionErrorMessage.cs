using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterDeletionErrorMessage : Message
{
    public const uint Id = 4473;

    public CharacterDeletionErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public CharacterDeletionErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
    }
}