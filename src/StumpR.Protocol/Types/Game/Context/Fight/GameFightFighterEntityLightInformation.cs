using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightFighterEntityLightInformation : GameFightFighterLightInformations
{
    public new const short Id = 4268;

    public GameFightFighterEntityLightInformation(bool sex,
        bool alive,
        double objectId,
        sbyte wave,
        ushort level,
        sbyte breed,
        sbyte entityModelId,
        double masterId)
    {
        Sex = sex;
        Alive = alive;
        ObjectId = objectId;
        Wave = wave;
        Level = level;
        Breed = breed;
        EntityModelId = entityModelId;
        MasterId = masterId;
    }

    public GameFightFighterEntityLightInformation()
    {
    }

    public override short TypeId => Id;

    public sbyte EntityModelId { get; set; }

    public double MasterId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(EntityModelId);
        writer.WriteDouble(MasterId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        EntityModelId = reader.ReadSByte();
        MasterId = reader.ReadDouble();
    }
}