using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
{
    public new const uint Id = 9690;

    public ExchangeStartOkMountMessage(IEnumerable<MountClientData> stabledMountsDescription,
        IEnumerable<MountClientData> paddockedMountsDescription)
    {
        StabledMountsDescription = stabledMountsDescription;
        PaddockedMountsDescription = paddockedMountsDescription;
    }

    public ExchangeStartOkMountMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<MountClientData> PaddockedMountsDescription { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) PaddockedMountsDescription.Count());
        foreach (MountClientData objectToSend in PaddockedMountsDescription) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort paddockedMountsDescriptionCount = reader.ReadUShort();
        var paddockedMountsDescription_ = new MountClientData[paddockedMountsDescriptionCount];

        for (var paddockedMountsDescriptionIndex = 0;
             paddockedMountsDescriptionIndex < paddockedMountsDescriptionCount;
             paddockedMountsDescriptionIndex++)
        {
            var objectToAdd = new MountClientData();
            objectToAdd.Deserialize(reader);
            paddockedMountsDescription_[paddockedMountsDescriptionIndex] = objectToAdd;
        }
        PaddockedMountsDescription = paddockedMountsDescription_;
    }
}