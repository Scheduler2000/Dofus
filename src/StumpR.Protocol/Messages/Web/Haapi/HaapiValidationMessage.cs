using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiValidationMessage : Message
{
    public const uint Id = 8710;

    public HaapiValidationMessage(sbyte action, sbyte code)
    {
        Action = action;
        Code = code;
    }

    public HaapiValidationMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Action { get; set; }

    public sbyte Code { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Action);
        writer.WriteSByte(Code);
    }

    public override void Deserialize(IDataReader reader)
    {
        Action = reader.ReadSByte();
        Code = reader.ReadSByte();
    }
}