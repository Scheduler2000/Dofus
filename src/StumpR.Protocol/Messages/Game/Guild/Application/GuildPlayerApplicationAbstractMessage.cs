﻿using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildPlayerApplicationAbstractMessage : Message
{
    public const uint Id = 5896;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}