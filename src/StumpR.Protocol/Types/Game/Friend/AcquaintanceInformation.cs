using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AcquaintanceInformation : AbstractContactInformations
{
    public new const short Id = 6223;

    public AcquaintanceInformation(int accountId, AccountTagInformation accountTag, sbyte playerState)
    {
        AccountId = accountId;
        AccountTag = accountTag;
        PlayerState = playerState;
    }

    public AcquaintanceInformation()
    {
    }

    public override short TypeId => Id;

    public sbyte PlayerState { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(PlayerState);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerState = reader.ReadSByte();
    }
}