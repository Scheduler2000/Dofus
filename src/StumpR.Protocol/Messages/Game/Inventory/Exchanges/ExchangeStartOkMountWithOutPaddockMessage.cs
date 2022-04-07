using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartOkMountWithOutPaddockMessage : Message
{
    public const uint Id = 9985;

    public ExchangeStartOkMountWithOutPaddockMessage(IEnumerable<MountClientData> stabledMountsDescription)
    {
        StabledMountsDescription = stabledMountsDescription;
    }

    public ExchangeStartOkMountWithOutPaddockMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<MountClientData> StabledMountsDescription { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) StabledMountsDescription.Count());
        foreach (MountClientData objectToSend in StabledMountsDescription) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort stabledMountsDescriptionCount = reader.ReadUShort();
        var stabledMountsDescription_ = new MountClientData[stabledMountsDescriptionCount];

        for (var stabledMountsDescriptionIndex = 0;
             stabledMountsDescriptionIndex < stabledMountsDescriptionCount;
             stabledMountsDescriptionIndex++)
        {
            var objectToAdd = new MountClientData();
            objectToAdd.Deserialize(reader);
            stabledMountsDescription_[stabledMountsDescriptionIndex] = objectToAdd;
        }
        StabledMountsDescription = stabledMountsDescription_;
    }
}