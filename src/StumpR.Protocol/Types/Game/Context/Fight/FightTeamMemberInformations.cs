using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTeamMemberInformations
{
    public const short Id = 5640;

    public FightTeamMemberInformations(double objectId)
    {
        ObjectId = objectId;
    }

    public FightTeamMemberInformations()
    {
    }

    public virtual short TypeId => Id;

    public double ObjectId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ObjectId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadDouble();
    }
}