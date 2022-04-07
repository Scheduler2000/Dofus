using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightResultFighterListEntry : FightResultListEntry
{
    public new const short Id = 4819;

    public FightResultFighterListEntry(ushort outcome, sbyte wave, FightLoot rewards, double objectId, bool alive)
    {
        Outcome = outcome;
        Wave = wave;
        Rewards = rewards;
        ObjectId = objectId;
        Alive = alive;
    }

    public FightResultFighterListEntry()
    {
    }

    public override short TypeId => Id;

    public double ObjectId { get; set; }

    public bool Alive { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(ObjectId);
        writer.WriteBoolean(Alive);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectId = reader.ReadDouble();
        Alive = reader.ReadBoolean();
    }
}