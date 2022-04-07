using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
{
    public new const uint Id = 3448;

    public HouseLockFromInsideRequestMessage(string code)
    {
        Code = code;
    }

    public HouseLockFromInsideRequestMessage()
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