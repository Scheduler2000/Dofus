﻿using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WrapperObjectAssociatedMessage : SymbioticObjectAssociatedMessage
{
    public new const uint Id = 3987;

    public WrapperObjectAssociatedMessage(uint hostUID)
    {
        HostUID = hostUID;
    }

    public WrapperObjectAssociatedMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}