using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HavenBagFurnituresMessage : Message
{
    public const uint Id = 6373;

    public HavenBagFurnituresMessage(IEnumerable<HavenBagFurnitureInformation> furnituresInfos)
    {
        FurnituresInfos = furnituresInfos;
    }

    public HavenBagFurnituresMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<HavenBagFurnitureInformation> FurnituresInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) FurnituresInfos.Count());
        foreach (HavenBagFurnitureInformation objectToSend in FurnituresInfos) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort furnituresInfosCount = reader.ReadUShort();
        var furnituresInfos_ = new HavenBagFurnitureInformation[furnituresInfosCount];

        for (var furnituresInfosIndex = 0; furnituresInfosIndex < furnituresInfosCount; furnituresInfosIndex++)
        {
            var objectToAdd = new HavenBagFurnitureInformation();
            objectToAdd.Deserialize(reader);
            furnituresInfos_[furnituresInfosIndex] = objectToAdd;
        }
        FurnituresInfos = furnituresInfos_;
    }
}