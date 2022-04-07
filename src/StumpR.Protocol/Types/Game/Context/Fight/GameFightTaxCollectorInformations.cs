using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightTaxCollectorInformations : GameFightAIInformations
{
    public new const short Id = 5235;

    public GameFightTaxCollectorInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        GameContextBasicSpawnInformation spawnInfo,
        sbyte wave,
        GameFightCharacteristics stats,
        IEnumerable<ushort> previousPositions,
        ushort firstNameId,
        ushort lastNameId,
        byte level)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        SpawnInfo = spawnInfo;
        Wave = wave;
        Stats = stats;
        PreviousPositions = previousPositions;
        FirstNameId = firstNameId;
        LastNameId = lastNameId;
        Level = level;
    }

    public GameFightTaxCollectorInformations()
    {
    }

    public override short TypeId => Id;

    public ushort FirstNameId { get; set; }

    public ushort LastNameId { get; set; }

    public byte Level { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(FirstNameId);
        writer.WriteVarUShort(LastNameId);
        writer.WriteByte(Level);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        FirstNameId = reader.ReadVarUShort();
        LastNameId = reader.ReadVarUShort();
        Level = reader.ReadByte();
    }
}