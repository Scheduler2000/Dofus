using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorInformations
{
    public const short Id = 3820;

    public TaxCollectorInformations(double uniqueId,
        ushort firtNameId,
        ushort lastNameId,
        AdditionalTaxCollectorInformations additionalInfos,
        short worldX,
        short worldY,
        ushort subAreaId,
        sbyte state,
        EntityLook look,
        IEnumerable<TaxCollectorComplementaryInformations> complements)
    {
        UniqueId = uniqueId;
        FirtNameId = firtNameId;
        LastNameId = lastNameId;
        AdditionalInfos = additionalInfos;
        WorldX = worldX;
        WorldY = worldY;
        SubAreaId = subAreaId;
        State = state;
        Look = look;
        Complements = complements;
    }

    public TaxCollectorInformations()
    {
    }

    public virtual short TypeId => Id;

    public double UniqueId { get; set; }

    public ushort FirtNameId { get; set; }

    public ushort LastNameId { get; set; }

    public AdditionalTaxCollectorInformations AdditionalInfos { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public ushort SubAreaId { get; set; }

    public sbyte State { get; set; }

    public EntityLook Look { get; set; }

    public IEnumerable<TaxCollectorComplementaryInformations> Complements { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(UniqueId);
        writer.WriteVarUShort(FirtNameId);
        writer.WriteVarUShort(LastNameId);
        AdditionalInfos.Serialize(writer);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteSByte(State);
        Look.Serialize(writer);
        writer.WriteShort((short) Complements.Count());

        foreach (TaxCollectorComplementaryInformations objectToSend in Complements)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public virtual void Deserialize(IDataReader reader)
    {
        UniqueId = reader.ReadDouble();
        FirtNameId = reader.ReadVarUShort();
        LastNameId = reader.ReadVarUShort();
        AdditionalInfos = new AdditionalTaxCollectorInformations();
        AdditionalInfos.Deserialize(reader);
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        SubAreaId = reader.ReadVarUShort();
        State = reader.ReadSByte();
        Look = new EntityLook();
        Look.Deserialize(reader);
        ushort complementsCount = reader.ReadUShort();
        var complements_ = new TaxCollectorComplementaryInformations[complementsCount];

        for (var complementsIndex = 0; complementsIndex < complementsCount; complementsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<TaxCollectorComplementaryInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            complements_[complementsIndex] = objectToAdd;
        }
        Complements = complements_;
    }
}