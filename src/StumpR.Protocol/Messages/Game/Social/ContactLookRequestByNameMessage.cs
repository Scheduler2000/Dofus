using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ContactLookRequestByNameMessage : ContactLookRequestMessage
{
    public new const uint Id = 4808;

    public ContactLookRequestByNameMessage(byte requestId, sbyte contactType, string playerName)
    {
        RequestId = requestId;
        ContactType = contactType;
        PlayerName = playerName;
    }

    public ContactLookRequestByNameMessage()
    {
    }

    public override uint MessageId => Id;

    public string PlayerName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(PlayerName);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerName = reader.ReadUTF();
    }
}