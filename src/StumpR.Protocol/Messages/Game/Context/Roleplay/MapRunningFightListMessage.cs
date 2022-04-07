using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapRunningFightListMessage : Message
{
    public const uint Id = 1018;

    public MapRunningFightListMessage(IEnumerable<FightExternalInformations> fights)
    {
        Fights = fights;
    }

    public MapRunningFightListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<FightExternalInformations> Fights { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Fights.Count());
        foreach (FightExternalInformations objectToSend in Fights) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort fightsCount = reader.ReadUShort();
        var fights_ = new FightExternalInformations[fightsCount];

        for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
        {
            var objectToAdd = new FightExternalInformations();
            objectToAdd.Deserialize(reader);
            fights_[fightsIndex] = objectToAdd;
        }
        Fights = fights_;
    }
}