using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterReplayRequestMessage : Message
{
    public const uint Id = 9614;

    public CharacterReplayRequestMessage(ulong characterId)
    {
        CharacterId = characterId;
    }

    public CharacterReplayRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong CharacterId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(CharacterId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CharacterId = reader.ReadVarULong();
    }
}