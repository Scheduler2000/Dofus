using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightResultListEntry
{
    public const short Id = 6627;

    public FightResultListEntry(ushort outcome, sbyte wave, FightLoot rewards)
    {
        Outcome = outcome;
        Wave = wave;
        Rewards = rewards;
    }

    public FightResultListEntry()
    {
    }

    public virtual short TypeId => Id;

    public ushort Outcome { get; set; }

    public sbyte Wave { get; set; }

    public FightLoot Rewards { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(Outcome);
        writer.WriteSByte(Wave);
        Rewards.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Outcome = reader.ReadVarUShort();
        Wave = reader.ReadSByte();
        Rewards = new FightLoot();
        Rewards.Deserialize(reader);
    }
}