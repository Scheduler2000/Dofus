using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AccountHouseMessage : Message
{
    public const uint Id = 7236;

    public AccountHouseMessage(IEnumerable<AccountHouseInformations> houses)
    {
        Houses = houses;
    }

    public AccountHouseMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AccountHouseInformations> Houses { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Houses.Count());
        foreach (AccountHouseInformations objectToSend in Houses) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort housesCount = reader.ReadUShort();
        var houses_ = new AccountHouseInformations[housesCount];

        for (var housesIndex = 0; housesIndex < housesCount; housesIndex++)
        {
            var objectToAdd = new AccountHouseInformations();
            objectToAdd.Deserialize(reader);
            houses_[housesIndex] = objectToAdd;
        }
        Houses = houses_;
    }
}