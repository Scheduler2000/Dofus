using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterReplayWithRemodelRequestMessage : CharacterReplayRequestMessage
{
    public new const uint Id = 3832;

    public CharacterReplayWithRemodelRequestMessage(ulong characterId, RemodelingInformation remodel)
    {
        CharacterId = characterId;
        Remodel = remodel;
    }

    public CharacterReplayWithRemodelRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public RemodelingInformation Remodel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Remodel.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Remodel = new RemodelingInformation();
        Remodel.Deserialize(reader);
    }
}