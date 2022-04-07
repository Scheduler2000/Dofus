using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AccountCapabilitiesMessage : Message
{
    public const uint Id = 8644;

    public AccountCapabilitiesMessage(bool tutorialAvailable,
        bool canCreateNewCharacter,
        int accountId,
        uint breedsVisible,
        uint breedsAvailable,
        sbyte status)
    {
        TutorialAvailable = tutorialAvailable;
        CanCreateNewCharacter = canCreateNewCharacter;
        AccountId = accountId;
        BreedsVisible = breedsVisible;
        BreedsAvailable = breedsAvailable;
        Status = status;
    }

    public AccountCapabilitiesMessage()
    {
    }

    public override uint MessageId => Id;

    public bool TutorialAvailable { get; set; }

    public bool CanCreateNewCharacter { get; set; }

    public int AccountId { get; set; }

    public uint BreedsVisible { get; set; }

    public uint BreedsAvailable { get; set; }

    public sbyte Status { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, TutorialAvailable);
        flag = BooleanByteWrapper.SetFlag(flag, 1, CanCreateNewCharacter);
        writer.WriteByte(flag);
        writer.WriteInt(AccountId);
        writer.WriteVarUInt(BreedsVisible);
        writer.WriteVarUInt(BreedsAvailable);
        writer.WriteSByte(Status);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        TutorialAvailable = BooleanByteWrapper.GetFlag(flag, 0);
        CanCreateNewCharacter = BooleanByteWrapper.GetFlag(flag, 1);
        AccountId = reader.ReadInt();
        BreedsVisible = reader.ReadVarUInt();
        BreedsAvailable = reader.ReadVarUInt();
        Status = reader.ReadSByte();
    }
}