using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeMountsPaddockAddMessage : Message
{
    public const uint Id = 3903;

    public ExchangeMountsPaddockAddMessage(IEnumerable<MountClientData> mountDescription)
    {
        MountDescription = mountDescription;
    }

    public ExchangeMountsPaddockAddMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<MountClientData> MountDescription { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) MountDescription.Count());
        foreach (MountClientData objectToSend in MountDescription) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort mountDescriptionCount = reader.ReadUShort();
        var mountDescription_ = new MountClientData[mountDescriptionCount];

        for (var mountDescriptionIndex = 0; mountDescriptionIndex < mountDescriptionCount; mountDescriptionIndex++)
        {
            var objectToAdd = new MountClientData();
            objectToAdd.Deserialize(reader);
            mountDescription_[mountDescriptionIndex] = objectToAdd;
        }
        MountDescription = mountDescription_;
    }
}