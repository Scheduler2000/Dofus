using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
{
    public new const uint Id = 7534;

    public GameFightShowFighterRandomStaticPoseMessage(GameFightFighterInformations informations)
    {
        Informations = informations;
    }

    public GameFightShowFighterRandomStaticPoseMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}