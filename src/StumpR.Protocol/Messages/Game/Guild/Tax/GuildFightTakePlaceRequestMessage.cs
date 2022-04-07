using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
{
    public new const uint Id = 1932;

    public GuildFightTakePlaceRequestMessage(double taxCollectorId, ulong replacedCharacterId)
    {
        TaxCollectorId = taxCollectorId;
        ReplacedCharacterId = replacedCharacterId;
    }

    public GuildFightTakePlaceRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ReplacedCharacterId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(ReplacedCharacterId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ReplacedCharacterId = reader.ReadVarULong();
    }
}