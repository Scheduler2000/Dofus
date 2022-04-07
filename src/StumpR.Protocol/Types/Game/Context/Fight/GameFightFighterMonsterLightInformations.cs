using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightFighterMonsterLightInformations : GameFightFighterLightInformations
{
    public new const short Id = 4254;

    public GameFightFighterMonsterLightInformations(bool sex,
        bool alive,
        double objectId,
        sbyte wave,
        ushort level,
        sbyte breed,
        ushort creatureGenericId)
    {
        Sex = sex;
        Alive = alive;
        ObjectId = objectId;
        Wave = wave;
        Level = level;
        Breed = breed;
        CreatureGenericId = creatureGenericId;
    }

    public GameFightFighterMonsterLightInformations()
    {
    }

    public override short TypeId => Id;

    public ushort CreatureGenericId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(CreatureGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CreatureGenericId = reader.ReadVarUShort();
    }
}