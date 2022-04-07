﻿using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SpawnInformation
{
    public const short Id = 5149;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}