using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildPaddockBoughtMessage : Message
{
    public const uint Id = 6217;

    public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo)
    {
        PaddockInfo = paddockInfo;
    }

    public GuildPaddockBoughtMessage()
    {
    }

    public override uint MessageId => Id;

    public PaddockContentInformations PaddockInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        PaddockInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        PaddockInfo = new PaddockContentInformations();
        PaddockInfo.Deserialize(reader);
    }
}