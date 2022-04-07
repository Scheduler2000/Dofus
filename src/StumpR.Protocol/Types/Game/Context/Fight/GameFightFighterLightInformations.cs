using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightFighterLightInformations
{
    public const short Id = 6482;

    public GameFightFighterLightInformations(bool sex, bool alive, double objectId, sbyte wave, ushort level, sbyte breed)
    {
        Sex = sex;
        Alive = alive;
        ObjectId = objectId;
        Wave = wave;
        Level = level;
        Breed = breed;
    }

    public GameFightFighterLightInformations()
    {
    }

    public virtual short TypeId => Id;

    public bool Sex { get; set; }

    public bool Alive { get; set; }

    public double ObjectId { get; set; }

    public sbyte Wave { get; set; }

    public ushort Level { get; set; }

    public sbyte Breed { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Sex);
        flag = BooleanByteWrapper.SetFlag(flag, 1, Alive);
        writer.WriteByte(flag);
        writer.WriteDouble(ObjectId);
        writer.WriteSByte(Wave);
        writer.WriteVarUShort(Level);
        writer.WriteSByte(Breed);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        Sex = BooleanByteWrapper.GetFlag(flag, 0);
        Alive = BooleanByteWrapper.GetFlag(flag, 1);
        ObjectId = reader.ReadDouble();
        Wave = reader.ReadSByte();
        Level = reader.ReadVarUShort();
        Breed = reader.ReadSByte();
    }
}