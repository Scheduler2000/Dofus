using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterSelectionMessage : Message
{
    public const uint Id = 3123;

    public CharacterSelectionMessage(ulong objectId)
    {
        ObjectId = objectId;
    }

    public CharacterSelectionMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ObjectId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ObjectId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarULong();
    }
}