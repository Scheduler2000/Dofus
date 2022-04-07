using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightSynchronizeMessage : Message
{
    public const uint Id = 3028;

    public GameFightSynchronizeMessage(IEnumerable<GameFightFighterInformations> fighters)
    {
        Fighters = fighters;
    }

    public GameFightSynchronizeMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameFightFighterInformations> Fighters { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Fighters.Count());

        foreach (GameFightFighterInformations objectToSend in Fighters)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort fightersCount = reader.ReadUShort();
        var fighters_ = new GameFightFighterInformations[fightersCount];

        for (var fightersIndex = 0; fightersIndex < fightersCount; fightersIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            fighters_[fightersIndex] = objectToAdd;
        }
        Fighters = fighters_;
    }
}