using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectUseOnCharacterMessage : ObjectUseMessage
{
    public new const uint Id = 8768;

    public ObjectUseOnCharacterMessage(uint objectUID, ulong characterId)
    {
        ObjectUID = objectUID;
        CharacterId = characterId;
    }

    public ObjectUseOnCharacterMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong CharacterId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(CharacterId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CharacterId = reader.ReadVarULong();
    }
}