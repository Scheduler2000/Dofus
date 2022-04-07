using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
{
    public new const short Id = 6139;

    public GameFightFighterTaxCollectorLightInformations(bool sex,
        bool alive,
        double objectId,
        sbyte wave,
        ushort level,
        sbyte breed,
        ushort firstNameId,
        ushort lastNameId)
    {
        Sex = sex;
        Alive = alive;
        ObjectId = objectId;
        Wave = wave;
        Level = level;
        Breed = breed;
        FirstNameId = firstNameId;
        LastNameId = lastNameId;
    }

    public GameFightFighterTaxCollectorLightInformations()
    {
    }

    public override short TypeId => Id;

    public ushort FirstNameId { get; set; }

    public ushort LastNameId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(FirstNameId);
        writer.WriteVarUShort(LastNameId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        FirstNameId = reader.ReadVarUShort();
        LastNameId = reader.ReadVarUShort();
    }
}