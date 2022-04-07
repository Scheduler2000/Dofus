using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NpcDialogQuestionMessage : Message
{
    public const uint Id = 8384;

    public NpcDialogQuestionMessage(uint messageId, IEnumerable<string> dialogParams, IEnumerable<uint> visibleReplies)
    {
        this.messageId = messageId;
        DialogParams = dialogParams;
        VisibleReplies = visibleReplies;
    }

    public NpcDialogQuestionMessage()
    {
    }

    public override uint MessageId => Id;

    public uint messageId { get; set; }

    public IEnumerable<string> DialogParams { get; set; }

    public IEnumerable<uint> VisibleReplies { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(messageId);
        writer.WriteShort((short) DialogParams.Count());
        foreach (string objectToSend in DialogParams) writer.WriteUTF(objectToSend);
        writer.WriteShort((short) VisibleReplies.Count());
        foreach (uint objectToSend in VisibleReplies) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        messageId = reader.ReadVarUInt();
        ushort dialogParamsCount = reader.ReadUShort();
        var dialogParams_ = new string[dialogParamsCount];

        for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
            dialogParams_[dialogParamsIndex] = reader.ReadUTF();
        DialogParams = dialogParams_;
        ushort visibleRepliesCount = reader.ReadUShort();
        var visibleReplies_ = new uint[visibleRepliesCount];

        for (var visibleRepliesIndex = 0; visibleRepliesIndex < visibleRepliesCount; visibleRepliesIndex++)
            visibleReplies_[visibleRepliesIndex] = reader.ReadVarUInt();
        VisibleReplies = visibleReplies_;
    }
}