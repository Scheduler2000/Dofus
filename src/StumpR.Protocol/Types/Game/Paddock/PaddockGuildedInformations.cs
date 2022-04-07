using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PaddockGuildedInformations : PaddockBuyableInformations
{
    public new const short Id = 6908;

    public PaddockGuildedInformations(ulong price, bool locked, bool deserted, GuildInformations guildInfo)
    {
        Price = price;
        Locked = locked;
        Deserted = deserted;
        GuildInfo = guildInfo;
    }

    public PaddockGuildedInformations()
    {
    }

    public override short TypeId => Id;

    public bool Deserted { get; set; }

    public GuildInformations GuildInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(Deserted);
        GuildInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Deserted = reader.ReadBoolean();
        GuildInfo = new GuildInformations();
        GuildInfo.Deserialize(reader);
    }
}