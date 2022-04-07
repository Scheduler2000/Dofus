using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class UpdateMapPlayersAgressableStatusMessage : Message
{
    public const uint Id = 3658;

    public UpdateMapPlayersAgressableStatusMessage(IEnumerable<ulong> playerIds, IEnumerable<byte> enable)
    {
        PlayerIds = playerIds;
        Enable = enable;
    }

    public UpdateMapPlayersAgressableStatusMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ulong> PlayerIds { get; set; }

    public IEnumerable<byte> Enable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) PlayerIds.Count());
        foreach (ulong objectToSend in PlayerIds) writer.WriteVarULong(objectToSend);
        writer.WriteShort((short) Enable.Count());
        foreach (byte objectToSend in Enable) writer.WriteByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort playerIdsCount = reader.ReadUShort();
        var playerIds_ = new ulong[playerIdsCount];

        for (var playerIdsIndex = 0; playerIdsIndex < playerIdsCount; playerIdsIndex++)
            playerIds_[playerIdsIndex] = reader.ReadVarULong();
        PlayerIds = playerIds_;
        ushort enableCount = reader.ReadUShort();
        var enable_ = new byte[enableCount];
        for (var enableIndex = 0; enableIndex < enableCount; enableIndex++) enable_[enableIndex] = reader.ReadByte();
        Enable = enable_;
    }
}