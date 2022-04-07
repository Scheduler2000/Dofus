using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildListMessage : Message
{
    public const uint Id = 5503;

    public GuildListMessage(IEnumerable<GuildInformations> guilds)
    {
        Guilds = guilds;
    }

    public GuildListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GuildInformations> Guilds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Guilds.Count());
        foreach (GuildInformations objectToSend in Guilds) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort guildsCount = reader.ReadUShort();
        var guilds_ = new GuildInformations[guildsCount];

        for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
        {
            var objectToAdd = new GuildInformations();
            objectToAdd.Deserialize(reader);
            guilds_[guildsIndex] = objectToAdd;
        }
        Guilds = guilds_;
    }
}