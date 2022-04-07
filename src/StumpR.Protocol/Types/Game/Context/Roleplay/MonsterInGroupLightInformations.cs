using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MonsterInGroupLightInformations
{
    public const short Id = 4246;

    public MonsterInGroupLightInformations(int genericId, sbyte grade, short level)
    {
        GenericId = genericId;
        Grade = grade;
        Level = level;
    }

    public MonsterInGroupLightInformations()
    {
    }

    public virtual short TypeId => Id;

    public int GenericId { get; set; }

    public sbyte Grade { get; set; }

    public short Level { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(GenericId);
        writer.WriteSByte(Grade);
        writer.WriteShort(Level);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        GenericId = reader.ReadInt();
        Grade = reader.ReadSByte();
        Level = reader.ReadShort();
    }
}