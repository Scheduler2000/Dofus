using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiBuyValidationMessage : HaapiValidationMessage
{
    public new const uint Id = 9648;

    public HaapiBuyValidationMessage(sbyte action, sbyte code, ulong amount, string email)
    {
        Action = action;
        Code = code;
        Amount = amount;
        Email = email;
    }

    public HaapiBuyValidationMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Amount { get; set; }

    public string Email { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Amount);
        writer.WriteUTF(Email);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Amount = reader.ReadVarULong();
        Email = reader.ReadUTF();
    }
}