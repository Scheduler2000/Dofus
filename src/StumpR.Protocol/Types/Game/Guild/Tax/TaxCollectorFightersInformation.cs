using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorFightersInformation
{
    public const short Id = 9650;

    public TaxCollectorFightersInformation(double collectorId,
        IEnumerable<CharacterMinimalPlusLookInformations> allyCharactersInformations,
        IEnumerable<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
    {
        CollectorId = collectorId;
        AllyCharactersInformations = allyCharactersInformations;
        EnemyCharactersInformations = enemyCharactersInformations;
    }

    public TaxCollectorFightersInformation()
    {
    }

    public virtual short TypeId => Id;

    public double CollectorId { get; set; }

    public IEnumerable<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }

    public IEnumerable<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(CollectorId);
        writer.WriteShort((short) AllyCharactersInformations.Count());

        foreach (CharacterMinimalPlusLookInformations objectToSend in AllyCharactersInformations)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) EnemyCharactersInformations.Count());

        foreach (CharacterMinimalPlusLookInformations objectToSend in EnemyCharactersInformations)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public virtual void Deserialize(IDataReader reader)
    {
        CollectorId = reader.ReadDouble();
        ushort allyCharactersInformationsCount = reader.ReadUShort();
        var allyCharactersInformations_ = new CharacterMinimalPlusLookInformations[allyCharactersInformationsCount];

        for (var allyCharactersInformationsIndex = 0;
             allyCharactersInformationsIndex < allyCharactersInformationsCount;
             allyCharactersInformationsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            allyCharactersInformations_[allyCharactersInformationsIndex] = objectToAdd;
        }
        AllyCharactersInformations = allyCharactersInformations_;
        ushort enemyCharactersInformationsCount = reader.ReadUShort();
        var enemyCharactersInformations_ = new CharacterMinimalPlusLookInformations[enemyCharactersInformationsCount];

        for (var enemyCharactersInformationsIndex = 0;
             enemyCharactersInformationsIndex < enemyCharactersInformationsCount;
             enemyCharactersInformationsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            enemyCharactersInformations_[enemyCharactersInformationsIndex] = objectToAdd;
        }
        EnemyCharactersInformations = enemyCharactersInformations_;
    }
}