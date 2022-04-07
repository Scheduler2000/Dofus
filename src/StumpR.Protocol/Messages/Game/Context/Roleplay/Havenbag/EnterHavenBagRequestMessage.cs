using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EnterHavenBagRequestMessage : Message
{
    public const uint Id = 8214;

    public EnterHavenBagRequestMessage(ulong havenBagOwner)
    {
        HavenBagOwner = havenBagOwner;
    }

    public EnterHavenBagRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong HavenBagOwner { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(HavenBagOwner);
    }

    public override void Deserialize(IDataReader reader)
    {
        HavenBagOwner = reader.ReadVarULong();
    }
}