using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInformationsGeneralMessage : Message
{
    public const uint Id = 8015;

    public GuildInformationsGeneralMessage(bool abandonnedPaddock,
        byte level,
        ulong expLevelFloor,
        ulong experience,
        ulong expNextLevelFloor,
        int creationDate,
        ushort nbTotalMembers,
        ushort nbConnectedMembers)
    {
        AbandonnedPaddock = abandonnedPaddock;
        Level = level;
        ExpLevelFloor = expLevelFloor;
        Experience = experience;
        ExpNextLevelFloor = expNextLevelFloor;
        CreationDate = creationDate;
        NbTotalMembers = nbTotalMembers;
        NbConnectedMembers = nbConnectedMembers;
    }

    public GuildInformationsGeneralMessage()
    {
    }

    public override uint MessageId => Id;

    public bool AbandonnedPaddock { get; set; }

    public byte Level { get; set; }

    public ulong ExpLevelFloor { get; set; }

    public ulong Experience { get; set; }

    public ulong ExpNextLevelFloor { get; set; }

    public int CreationDate { get; set; }

    public ushort NbTotalMembers { get; set; }

    public ushort NbConnectedMembers { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(AbandonnedPaddock);
        writer.WriteByte(Level);
        writer.WriteVarULong(ExpLevelFloor);
        writer.WriteVarULong(Experience);
        writer.WriteVarULong(ExpNextLevelFloor);
        writer.WriteInt(CreationDate);
        writer.WriteVarUShort(NbTotalMembers);
        writer.WriteVarUShort(NbConnectedMembers);
    }

    public override void Deserialize(IDataReader reader)
    {
        AbandonnedPaddock = reader.ReadBoolean();
        Level = reader.ReadByte();
        ExpLevelFloor = reader.ReadVarULong();
        Experience = reader.ReadVarULong();
        ExpNextLevelFloor = reader.ReadVarULong();
        CreationDate = reader.ReadInt();
        NbTotalMembers = reader.ReadVarUShort();
        NbConnectedMembers = reader.ReadVarUShort();
    }
}