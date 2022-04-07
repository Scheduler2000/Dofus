using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInformationsPaddocksMessage : Message
{
    public const uint Id = 178;

    public GuildInformationsPaddocksMessage(sbyte nbPaddockMax, IEnumerable<PaddockContentInformations> paddocksInformations)
    {
        NbPaddockMax = nbPaddockMax;
        PaddocksInformations = paddocksInformations;
    }

    public GuildInformationsPaddocksMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte NbPaddockMax { get; set; }

    public IEnumerable<PaddockContentInformations> PaddocksInformations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(NbPaddockMax);
        writer.WriteShort((short) PaddocksInformations.Count());
        foreach (PaddockContentInformations objectToSend in PaddocksInformations) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        NbPaddockMax = reader.ReadSByte();
        ushort paddocksInformationsCount = reader.ReadUShort();
        var paddocksInformations_ = new PaddockContentInformations[paddocksInformationsCount];

        for (var paddocksInformationsIndex = 0; paddocksInformationsIndex < paddocksInformationsCount; paddocksInformationsIndex++)
        {
            var objectToAdd = new PaddockContentInformations();
            objectToAdd.Deserialize(reader);
            paddocksInformations_[paddocksInformationsIndex] = objectToAdd;
        }
        PaddocksInformations = paddocksInformations_;
    }
}