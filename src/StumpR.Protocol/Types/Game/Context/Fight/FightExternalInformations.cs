using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightExternalInformations
{
    public const short Id = 7149;

    public FightExternalInformations(ushort fightId, sbyte fightType, int fightStart, bool fightSpectatorLocked)
    {
        FightId = fightId;
        FightType = fightType;
        FightStart = fightStart;
        FightSpectatorLocked = fightSpectatorLocked;
    }

    public FightExternalInformations()
    {
    }

    public virtual short TypeId => Id;

    public ushort FightId { get; set; }

    public sbyte FightType { get; set; }

    public int FightStart { get; set; }

    public bool FightSpectatorLocked { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteSByte(FightType);
        writer.WriteInt(FightStart);
        writer.WriteBoolean(FightSpectatorLocked);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        FightType = reader.ReadSByte();
        FightStart = reader.ReadInt();
        FightSpectatorLocked = reader.ReadBoolean();
    }
}