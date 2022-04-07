using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterSelectionWithRemodelMessage : CharacterSelectionMessage
{
    public new const uint Id = 2652;

    public CharacterSelectionWithRemodelMessage(ulong objectId, RemodelingInformation remodel)
    {
        ObjectId = objectId;
        Remodel = remodel;
    }

    public CharacterSelectionWithRemodelMessage()
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