using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdolSelectedMessage : Message
{
    public const uint Id = 7348;

    public IdolSelectedMessage(bool activate, bool party, ushort idolId)
    {
        Activate = activate;
        Party = party;
        IdolId = idolId;
    }

    public IdolSelectedMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Activate { get; set; }

    public bool Party { get; set; }

    public ushort IdolId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Activate);
        flag = BooleanByteWrapper.SetFlag(flag, 1, Party);
        writer.WriteByte(flag);
        writer.WriteVarUShort(IdolId);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        Activate = BooleanByteWrapper.GetFlag(flag, 0);
        Party = BooleanByteWrapper.GetFlag(flag, 1);
        IdolId = reader.ReadVarUShort();
    }
}