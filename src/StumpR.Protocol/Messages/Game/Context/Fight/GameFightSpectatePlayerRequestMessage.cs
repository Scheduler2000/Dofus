using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightSpectatePlayerRequestMessage : Message
{
    public const uint Id = 9098;

    public GameFightSpectatePlayerRequestMessage(ulong playerId)
    {
        PlayerId = playerId;
    }

    public GameFightSpectatePlayerRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
    }
}