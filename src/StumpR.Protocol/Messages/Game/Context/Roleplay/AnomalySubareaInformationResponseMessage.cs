using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AnomalySubareaInformationResponseMessage : Message
{
    public const uint Id = 6030;

    public AnomalySubareaInformationResponseMessage(IEnumerable<AnomalySubareaInformation> subareas)
    {
        Subareas = subareas;
    }

    public AnomalySubareaInformationResponseMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AnomalySubareaInformation> Subareas { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Subareas.Count());
        foreach (AnomalySubareaInformation objectToSend in Subareas) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort subareasCount = reader.ReadUShort();
        var subareas_ = new AnomalySubareaInformation[subareasCount];

        for (var subareasIndex = 0; subareasIndex < subareasCount; subareasIndex++)
        {
            var objectToAdd = new AnomalySubareaInformation();
            objectToAdd.Deserialize(reader);
            subareas_[subareasIndex] = objectToAdd;
        }
        Subareas = subareas_;
    }
}