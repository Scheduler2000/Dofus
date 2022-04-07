using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildApplicationAnswerMessage : Message
{
    public const uint Id = 5404;

    public GuildApplicationAnswerMessage(bool accepted, uint playerId)
    {
        Accepted = accepted;
        PlayerId = playerId;
    }

    public GuildApplicationAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Accepted { get; set; }

    public uint PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Accepted);
        writer.WriteVarUInt(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        Accepted = reader.ReadBoolean();
        PlayerId = reader.ReadVarUInt();
    }
}