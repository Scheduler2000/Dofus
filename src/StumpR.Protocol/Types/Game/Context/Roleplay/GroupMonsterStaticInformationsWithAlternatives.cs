using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
{
    public new const short Id = 1240;

    public GroupMonsterStaticInformationsWithAlternatives(MonsterInGroupLightInformations mainCreatureLightInfos,
        IEnumerable<MonsterInGroupInformations> underlings,
        IEnumerable<AlternativeMonstersInGroupLightInformations> alternatives)
    {
        MainCreatureLightInfos = mainCreatureLightInfos;
        Underlings = underlings;
        Alternatives = alternatives;
    }

    public GroupMonsterStaticInformationsWithAlternatives()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<AlternativeMonstersInGroupLightInformations> Alternatives { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Alternatives.Count());
        foreach (AlternativeMonstersInGroupLightInformations objectToSend in Alternatives) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort alternativesCount = reader.ReadUShort();
        var alternatives_ = new AlternativeMonstersInGroupLightInformations[alternativesCount];

        for (var alternativesIndex = 0; alternativesIndex < alternativesCount; alternativesIndex++)
        {
            var objectToAdd = new AlternativeMonstersInGroupLightInformations();
            objectToAdd.Deserialize(reader);
            alternatives_[alternativesIndex] = objectToAdd;
        }
        Alternatives = alternatives_;
    }
}