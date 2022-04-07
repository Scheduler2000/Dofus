using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameMapChangeOrientationsMessage : Message
{
    public const uint Id = 5656;

    public GameMapChangeOrientationsMessage(IEnumerable<ActorOrientation> orientations)
    {
        Orientations = orientations;
    }

    public GameMapChangeOrientationsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ActorOrientation> Orientations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Orientations.Count());
        foreach (ActorOrientation objectToSend in Orientations) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort orientationsCount = reader.ReadUShort();
        var orientations_ = new ActorOrientation[orientationsCount];

        for (var orientationsIndex = 0; orientationsIndex < orientationsCount; orientationsIndex++)
        {
            var objectToAdd = new ActorOrientation();
            objectToAdd.Deserialize(reader);
            orientations_[orientationsIndex] = objectToAdd;
        }
        Orientations = orientations_;
    }
}