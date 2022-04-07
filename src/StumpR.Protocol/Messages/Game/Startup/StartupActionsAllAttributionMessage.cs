using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StartupActionsAllAttributionMessage : Message
{
    public const uint Id = 2956;

    public StartupActionsAllAttributionMessage(ulong characterId)
    {
        CharacterId = characterId;
    }

    public StartupActionsAllAttributionMessage()
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