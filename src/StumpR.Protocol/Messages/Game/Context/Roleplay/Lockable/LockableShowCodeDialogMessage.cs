using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LockableShowCodeDialogMessage : Message
{
    public const uint Id = 3045;

    public LockableShowCodeDialogMessage(bool changeOrUse, sbyte codeSize)
    {
        ChangeOrUse = changeOrUse;
        CodeSize = codeSize;
    }

    public LockableShowCodeDialogMessage()
    {
    }

    public override uint MessageId => Id;

    public bool ChangeOrUse { get; set; }

    public sbyte CodeSize { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(ChangeOrUse);
        writer.WriteSByte(CodeSize);
    }

    public override void Deserialize(IDataReader reader)
    {
        ChangeOrUse = reader.ReadBoolean();
        CodeSize = reader.ReadSByte();
    }
}