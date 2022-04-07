using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorListMessage : AbstractTaxCollectorListMessage
{
    public new const uint Id = 4811;

    public TaxCollectorListMessage(IEnumerable<TaxCollectorInformations> informations,
        sbyte nbcollectorMax,
        IEnumerable<TaxCollectorFightersInformation> fightersInformations,
        sbyte infoType)
    {
        Informations = informations;
        NbcollectorMax = nbcollectorMax;
        FightersInformations = fightersInformations;
        InfoType = infoType;
    }

    public TaxCollectorListMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte NbcollectorMax { get; set; }

    public IEnumerable<TaxCollectorFightersInformation> FightersInformations { get; set; }

    public sbyte InfoType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(NbcollectorMax);
        writer.WriteShort((short) FightersInformations.Count());
        foreach (TaxCollectorFightersInformation objectToSend in FightersInformations) objectToSend.Serialize(writer);
        writer.WriteSByte(InfoType);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        NbcollectorMax = reader.ReadSByte();
        ushort fightersInformationsCount = reader.ReadUShort();
        var fightersInformations_ = new TaxCollectorFightersInformation[fightersInformationsCount];

        for (var fightersInformationsIndex = 0; fightersInformationsIndex < fightersInformationsCount; fightersInformationsIndex++)
        {
            var objectToAdd = new TaxCollectorFightersInformation();
            objectToAdd.Deserialize(reader);
            fightersInformations_[fightersInformationsIndex] = objectToAdd;
        }
        FightersInformations = fightersInformations_;
        InfoType = reader.ReadSByte();
    }
}