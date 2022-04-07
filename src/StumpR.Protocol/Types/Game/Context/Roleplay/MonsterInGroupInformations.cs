using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MonsterInGroupInformations : MonsterInGroupLightInformations
{
    public new const short Id = 2614;

    public MonsterInGroupInformations(int genericId, sbyte grade, short level, EntityLook look)
    {
        GenericId = genericId;
        Grade = grade;
        Level = level;
        Look = look;
    }

    public MonsterInGroupInformations()
    {
    }

    public override short TypeId => Id;

    public EntityLook Look { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}