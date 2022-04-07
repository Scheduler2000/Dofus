using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightFighterNamedLightInformations : GameFightFighterLightInformations
{
    public new const short Id = 2754;

    public GameFightFighterNamedLightInformations(bool sex,
        bool alive,
        double objectId,
        sbyte wave,
        ushort level,
        sbyte breed,
        string name)
    {
        Sex = sex;
        Alive = alive;
        ObjectId = objectId;
        Wave = wave;
        Level = level;
        Breed = breed;
        Name = name;
    }

    public GameFightFighterNamedLightInformations()
    {
    }

    public override short TypeId => Id;

    public string Name { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Name);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUTF();
    }
}