using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildApplicationReceivedMessage : Message
{
    public const uint Id = 3891;

    public GuildApplicationReceivedMessage(string playerName, ulong playerId)
    {
        PlayerName = playerName;
        PlayerId = playerId;
    }

    public GuildApplicationReceivedMessage()
    {
    }

    public override uint MessageId => Id;

    public string PlayerName { get; set; }

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(PlayerName);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerName = reader.ReadUTF();
        PlayerId = reader.ReadVarULong();
    }
}