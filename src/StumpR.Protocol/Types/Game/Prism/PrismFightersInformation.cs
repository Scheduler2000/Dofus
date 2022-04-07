using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PrismFightersInformation
{
    public const short Id = 8909;

    public PrismFightersInformation(ushort subAreaId,
        ProtectedEntityWaitingForHelpInfo waitingForHelpInfo,
        IEnumerable<CharacterMinimalPlusLookInformations> allyCharactersInformations,
        IEnumerable<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
    {
        SubAreaId = subAreaId;
        WaitingForHelpInfo = waitingForHelpInfo;
        AllyCharactersInformations = allyCharactersInformations;
        EnemyCharactersInformations = enemyCharactersInformations;
    }

    public PrismFightersInformation()
    {
    }

    public virtual short TypeId => Id;

    public ushort SubAreaId { get; set; }

    public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }

    public IEnumerable<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }

    public IEnumerable<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        WaitingForHelpInfo.Serialize(writer);
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
        SubAreaId = reader.ReadVarUShort();
        WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
        WaitingForHelpInfo.Deserialize(reader);
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