using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterCapabilitiesMessage : Message
{
    public const uint Id = 344;

    public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
    {
        GuildEmblemSymbolCategories = guildEmblemSymbolCategories;
    }

    public CharacterCapabilitiesMessage()
    {
    }

    public override uint MessageId => Id;

    public uint GuildEmblemSymbolCategories { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(GuildEmblemSymbolCategories);
    }

    public override void Deserialize(IDataReader reader)
    {
        GuildEmblemSymbolCategories = reader.ReadVarUInt();
    }
}