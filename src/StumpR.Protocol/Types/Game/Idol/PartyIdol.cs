using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PartyIdol : Idol
{
    public new const short Id = 563;

    public PartyIdol(ushort objectId, ushort xpBonusPercent, ushort dropBonusPercent, IEnumerable<ulong> ownersIds)
    {
        ObjectId = objectId;
        XpBonusPercent = xpBonusPercent;
        DropBonusPercent = dropBonusPercent;
        OwnersIds = ownersIds;
    }

    public PartyIdol()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<ulong> OwnersIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) OwnersIds.Count());
        foreach (ulong objectToSend in OwnersIds) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort ownersIdsCount = reader.ReadUShort();
        var ownersIds_ = new ulong[ownersIdsCount];

        for (var ownersIdsIndex = 0; ownersIdsIndex < ownersIdsCount; ownersIdsIndex++)
            ownersIds_[ownersIdsIndex] = reader.ReadVarULong();
        OwnersIds = ownersIds_;
    }
}