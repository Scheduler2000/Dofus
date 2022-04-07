using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AcquaintancesListMessage : Message
{
    public const uint Id = 2842;

    public AcquaintancesListMessage(IEnumerable<AcquaintanceInformation> acquaintanceList)
    {
        AcquaintanceList = acquaintanceList;
    }

    public AcquaintancesListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AcquaintanceInformation> AcquaintanceList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) AcquaintanceList.Count());

        foreach (AcquaintanceInformation objectToSend in AcquaintanceList)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort acquaintanceListCount = reader.ReadUShort();
        var acquaintanceList_ = new AcquaintanceInformation[acquaintanceListCount];

        for (var acquaintanceListIndex = 0; acquaintanceListIndex < acquaintanceListCount; acquaintanceListIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<AcquaintanceInformation>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            acquaintanceList_[acquaintanceListIndex] = objectToAdd;
        }
        AcquaintanceList = acquaintanceList_;
    }
}