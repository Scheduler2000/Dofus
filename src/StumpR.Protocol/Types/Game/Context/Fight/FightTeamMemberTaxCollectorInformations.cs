using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
{
    public new const short Id = 9850;

    public FightTeamMemberTaxCollectorInformations(double objectId,
        ushort firstNameId,
        ushort lastNameId,
        byte level,
        uint guildId,
        double uid)
    {
        ObjectId = objectId;
        FirstNameId = firstNameId;
        LastNameId = lastNameId;
        Level = level;
        GuildId = guildId;
        Uid = uid;
    }

    public FightTeamMemberTaxCollectorInformations()
    {
    }

    public override short TypeId => Id;

    public ushort FirstNameId { get; set; }

    public ushort LastNameId { get; set; }

    public byte Level { get; set; }

    public uint GuildId { get; set; }

    public double Uid { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(FirstNameId);
        writer.WriteVarUShort(LastNameId);
        writer.WriteByte(Level);
        writer.WriteVarUInt(GuildId);
        writer.WriteDouble(Uid);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        FirstNameId = reader.ReadVarUShort();
        LastNameId = reader.ReadVarUShort();
        Level = reader.ReadByte();
        GuildId = reader.ReadVarUInt();
        Uid = reader.ReadDouble();
    }
}