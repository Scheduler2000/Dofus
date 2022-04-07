using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AlternativeMonstersInGroupLightInformations
{
    public const short Id = 1183;

    public AlternativeMonstersInGroupLightInformations(int playerCount, IEnumerable<MonsterInGroupLightInformations> monsters)
    {
        PlayerCount = playerCount;
        Monsters = monsters;
    }

    public AlternativeMonstersInGroupLightInformations()
    {
    }

    public virtual short TypeId => Id;

    public int PlayerCount { get; set; }

    public IEnumerable<MonsterInGroupLightInformations> Monsters { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(PlayerCount);
        writer.WriteShort((short) Monsters.Count());
        foreach (MonsterInGroupLightInformations objectToSend in Monsters) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        PlayerCount = reader.ReadInt();
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