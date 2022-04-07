﻿using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendSpouseFollowWithCompassRequestMessage : Message
{
    public const uint Id = 8825;

    public FriendSpouseFollowWithCompassRequestMessage(bool enable)
    {
        Enable = enable;
    }

    public FriendSpouseFollowWithCompassRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Enable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(IDataReader reader)
    {
        Enable = reader.ReadBoolean();
    }
}