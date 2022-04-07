using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdolPartyRegisterRequestMessage : Message
{
    public const uint Id = 868;

    public IdolPartyRegisterRequestMessage(bool register)
    {
        Register = register;
    }

    public IdolPartyRegisterRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Register { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Register);
    }

    public override void Deserialize(IDataReader reader)
    {
        Register = reader.ReadBoolean();
    }
}