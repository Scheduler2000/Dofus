using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildLevelUpMessage : Message
{
    public const uint Id = 7669;

    public GuildLevelUpMessage(byte newLevel)
    {
        NewLevel = newLevel;
    }

    public GuildLevelUpMessage()
    {
    }

    public override uint MessageId => Id;

    public byte NewLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteByte(NewLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        NewLevel = reader.ReadByte();
    }
}