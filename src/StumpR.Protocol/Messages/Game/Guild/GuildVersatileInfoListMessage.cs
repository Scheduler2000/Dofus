using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildVersatileInfoListMessage : Message
{
    public const uint Id = 211;

    public GuildVersatileInfoListMessage(IEnumerable<GuildVersatileInformations> guilds)
    {
        Guilds = guilds;
    }

    public GuildVersatileInfoListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GuildVersatileInformations> Guilds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Guilds.Count());

        foreach (GuildVersatileInformations objectToSend in Guilds)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort guildsCount = reader.ReadUShort();
        var guilds_ = new GuildVersatileInformations[guildsCount];

        for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GuildVersatileInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            guilds_[guildsIndex] = objectToAdd;
        }
        Guilds = guilds_;
    }
}