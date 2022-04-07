using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismsInfoValidMessage : Message
{
    public const uint Id = 9294;

    public PrismsInfoValidMessage(IEnumerable<PrismFightersInformation> fights)
    {
        Fights = fights;
    }

    public PrismsInfoValidMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<PrismFightersInformation> Fights { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Fights.Count());
        foreach (PrismFightersInformation objectToSend in Fights) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort fightsCount = reader.ReadUShort();
        var fights_ = new PrismFightersInformation[fightsCount];

        for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
        {
            var objectToAdd = new PrismFightersInformation();
            objectToAdd.Deserialize(reader);
            fights_[fightsIndex] = objectToAdd;
        }
        Fights = fights_;
    }
}