using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRefreshMonsterBoostsMessage : Message
{
    public const uint Id = 2110;

    public GameRefreshMonsterBoostsMessage(IEnumerable<MonsterBoosts> monsterBoosts, IEnumerable<MonsterBoosts> familyBoosts)
    {
        MonsterBoosts = monsterBoosts;
        FamilyBoosts = familyBoosts;
    }

    public GameRefreshMonsterBoostsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<MonsterBoosts> MonsterBoosts { get; set; }

    public IEnumerable<MonsterBoosts> FamilyBoosts { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) MonsterBoosts.Count());
        foreach (MonsterBoosts objectToSend in MonsterBoosts) objectToSend.Serialize(writer);
        writer.WriteShort((short) FamilyBoosts.Count());
        foreach (MonsterBoosts objectToSend in FamilyBoosts) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort monsterBoostsCount = reader.ReadUShort();
        var monsterBoosts_ = new MonsterBoosts[monsterBoostsCount];

        for (var monsterBoostsIndex = 0; monsterBoostsIndex < monsterBoostsCount; monsterBoostsIndex++)
        {
            var objectToAdd = new MonsterBoosts();
            objectToAdd.Deserialize(reader);
            monsterBoosts_[monsterBoostsIndex] = objectToAdd;
        }
        MonsterBoosts = monsterBoosts_;
        ushort familyBoostsCount = reader.ReadUShort();
        var familyBoosts_ = new MonsterBoosts[familyBoostsCount];

        for (var familyBoostsIndex = 0; familyBoostsIndex < familyBoostsCount; familyBoostsIndex++)
        {
            var objectToAdd = new MonsterBoosts();
            objectToAdd.Deserialize(reader);
            familyBoosts_[familyBoostsIndex] = objectToAdd;
        }
        FamilyBoosts = familyBoosts_;
    }
}