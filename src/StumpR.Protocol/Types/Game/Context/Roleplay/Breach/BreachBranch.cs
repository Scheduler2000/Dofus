using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class BreachBranch
{
    public const short Id = 5320;

    public BreachBranch(sbyte room,
        int element,
        IEnumerable<MonsterInGroupLightInformations> bosses,
        double map,
        short score,
        short relativeScore,
        IEnumerable<MonsterInGroupLightInformations> monsters)
    {
        Room = room;
        Element = element;
        Bosses = bosses;
        Map = map;
        Score = score;
        RelativeScore = relativeScore;
        Monsters = monsters;
    }

    public BreachBranch()
    {
    }

    public virtual short TypeId => Id;

    public sbyte Room { get; set; }

    public int Element { get; set; }

    public IEnumerable<MonsterInGroupLightInformations> Bosses { get; set; }

    public double Map { get; set; }

    public short Score { get; set; }

    public short RelativeScore { get; set; }

    public IEnumerable<MonsterInGroupLightInformations> Monsters { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Room);
        writer.WriteInt(Element);
        writer.WriteShort((short) Bosses.Count());
        foreach (MonsterInGroupLightInformations objectToSend in Bosses) objectToSend.Serialize(writer);
        writer.WriteDouble(Map);
        writer.WriteShort(Score);
        writer.WriteShort(RelativeScore);
        writer.WriteShort((short) Monsters.Count());
        foreach (MonsterInGroupLightInformations objectToSend in Monsters) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Room = reader.ReadSByte();
        Element = reader.ReadInt();
        ushort bossesCount = reader.ReadUShort();
        var bosses_ = new MonsterInGroupLightInformations[bossesCount];

        for (var bossesIndex = 0; bossesIndex < bossesCount; bossesIndex++)
        {
            var objectToAdd = new MonsterInGroupLightInformations();
            objectToAdd.Deserialize(reader);
            bosses_[bossesIndex] = objectToAdd;
        }
        Bosses = bosses_;
        Map = reader.ReadDouble();
        Score = reader.ReadShort();
        RelativeScore = reader.ReadShort();
        ushort monstersCount = reader.ReadUShort();
        var monsters_ = new MonsterInGroupLightInformations[monstersCount];

        for (var monstersIndex = 0; monstersIndex < monstersCount; monstersIndex++)
        {
            var objectToAdd = new MonsterInGroupLightInformations();
            objectToAdd.Deserialize(reader);
            monsters_[monstersIndex] = objectToAdd;
        }
        Monsters = monsters_;
    }
}