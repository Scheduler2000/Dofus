using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class BreachReward
{
    public const short Id = 2317;

    public BreachReward(uint objectId, IEnumerable<byte> buyLocks, string buyCriterion, int remainingQty, uint price)
    {
        ObjectId = objectId;
        BuyLocks = buyLocks;
        BuyCriterion = buyCriterion;
        RemainingQty = remainingQty;
        Price = price;
    }

    public BreachReward()
    {
    }

    public virtual short TypeId => Id;

    public uint ObjectId { get; set; }

    public IEnumerable<byte> BuyLocks { get; set; }

    public string BuyCriterion { get; set; }

    public int RemainingQty { get; set; }

    public uint Price { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectId);
        writer.WriteShort((short) BuyLocks.Count());
        foreach (byte objectToSend in BuyLocks) writer.WriteByte(objectToSend);
        writer.WriteUTF(BuyCriterion);
        writer.WriteVarInt(RemainingQty);
        writer.WriteVarUInt(Price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUInt();
        ushort buyLocksCount = reader.ReadUShort();
        var buyLocks_ = new byte[buyLocksCount];
        for (var buyLocksIndex = 0; buyLocksIndex < buyLocksCount; buyLocksIndex++) buyLocks_[buyLocksIndex] = reader.ReadByte();
        BuyLocks = buyLocks_;
        BuyCriterion = reader.ReadUTF();
        RemainingQty = reader.ReadVarInt();
        Price = reader.ReadVarUInt();
    }
}