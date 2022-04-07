using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightResumeSlaveInfo
{
    public const short Id = 8117;

    public GameFightResumeSlaveInfo(double slaveId,
        IEnumerable<GameFightSpellCooldown> spellCooldowns,
        sbyte summonCount,
        sbyte bombCount)
    {
        SlaveId = slaveId;
        SpellCooldowns = spellCooldowns;
        SummonCount = summonCount;
        BombCount = bombCount;
    }

    public GameFightResumeSlaveInfo()
    {
    }

    public virtual short TypeId => Id;

    public double SlaveId { get; set; }

    public IEnumerable<GameFightSpellCooldown> SpellCooldowns { get; set; }

    public sbyte SummonCount { get; set; }

    public sbyte BombCount { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(SlaveId);
        writer.WriteShort((short) SpellCooldowns.Count());
        foreach (GameFightSpellCooldown objectToSend in SpellCooldowns) objectToSend.Serialize(writer);
        writer.WriteSByte(SummonCount);
        writer.WriteSByte(BombCount);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        SlaveId = reader.ReadDouble();
        ushort spellCooldownsCount = reader.ReadUShort();
        var spellCooldowns_ = new GameFightSpellCooldown[spellCooldownsCount];

        for (var spellCooldownsIndex = 0; spellCooldownsIndex < spellCooldownsCount; spellCooldownsIndex++)
        {
            var objectToAdd = new GameFightSpellCooldown();
            objectToAdd.Deserialize(reader);
            spellCooldowns_[spellCooldownsIndex] = objectToAdd;
        }
        SpellCooldowns = spellCooldowns_;
        SummonCount = reader.ReadSByte();
        BombCount = reader.ReadSByte();
    }
}