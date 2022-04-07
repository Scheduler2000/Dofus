using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GroupMonsterStaticInformations
{
    public const short Id = 9226;

    public GroupMonsterStaticInformations(MonsterInGroupLightInformations mainCreatureLightInfos,
        IEnumerable<MonsterInGroupInformations> underlings)
    {
        MainCreatureLightInfos = mainCreatureLightInfos;
        Underlings = underlings;
    }

    public GroupMonsterStaticInformations()
    {
    }

    public virtual short TypeId => Id;

    public MonsterInGroupLightInformations MainCreatureLightInfos { get; set; }

    public IEnumerable<MonsterInGroupInformations> Underlings { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        MainCreatureLightInfos.Serialize(writer);
        writer.WriteShort((short) Underlings.Count());
        foreach (MonsterInGroupInformations objectToSend in Underlings) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        MainCreatureLightInfos = new MonsterInGroupLightInformations();
        MainCreatureLightInfos.Deserialize(reader);
        ushort underlingsCount = reader.ReadUShort();
        var underlings_ = new MonsterInGroupInformations[underlingsCount];

        for (var underlingsIndex = 0; underlingsIndex < underlingsCount; underlingsIndex++)
        {
            var objectToAdd = new MonsterInGroupInformations();
            objectToAdd.Deserialize(reader);
            underlings_[underlingsIndex] = objectToAdd;
        }
        Underlings = underlings_;
    }
}