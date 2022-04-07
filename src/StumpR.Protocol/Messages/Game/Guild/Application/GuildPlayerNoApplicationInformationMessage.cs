using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildPlayerNoApplicationInformationMessage : GuildPlayerApplicationAbstractMessage
{
    public new const uint Id = 5345;


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