using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightHumanReadyStateMessage : Message
{
    public const uint Id = 4318;

    public GameFightHumanReadyStateMessage(ulong characterId, bool isReady)
    {
        CharacterId = characterId;
        IsReady = isReady;
    }

    public GameFightHumanReadyStateMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong CharacterId { get; set; }

    public bool IsReady { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(CharacterId);
        writer.WriteBoolean(IsReady);
    }

    public override void Deserialize(IDataReader reader)
    {
        CharacterId = reader.ReadVarULong();
        IsReady = reader.ReadBoolean();
    }
}