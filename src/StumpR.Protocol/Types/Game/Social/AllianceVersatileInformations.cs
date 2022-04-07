using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AllianceVersatileInformations
{
    public const short Id = 1207;

    public AllianceVersatileInformations(uint allianceId, ushort nbGuilds, ushort nbMembers, ushort nbSubarea)
    {
        AllianceId = allianceId;
        NbGuilds = nbGuilds;
        NbMembers = nbMembers;
        NbSubarea = nbSubarea;
    }

    public AllianceVersatileInformations()
    {
    }

    public virtual short TypeId => Id;

    public uint AllianceId { get; set; }

    public ushort NbGuilds { get; set; }

    public ushort NbMembers { get; set; }

    public ushort NbSubarea { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(AllianceId);
        writer.WriteVarUShort(NbGuilds);
        writer.WriteVarUShort(NbMembers);
        writer.WriteVarUShort(NbSubarea);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        AllianceId = reader.ReadVarUInt();
        NbGuilds = reader.ReadVarUShort();
        NbMembers = reader.ReadVarUShort();
        NbSubarea = reader.ReadVarUShort();
    }
}