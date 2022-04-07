using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachBranchesMessage : Message
{
    public const uint Id = 2907;

    public BreachBranchesMessage(IEnumerable<ExtendedBreachBranch> branches)
    {
        Branches = branches;
    }

    public BreachBranchesMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ExtendedBreachBranch> Branches { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Branches.Count());

        foreach (ExtendedBreachBranch objectToSend in Branches)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort branchesCount = reader.ReadUShort();
        var branches_ = new ExtendedBreachBranch[branchesCount];

        for (var branchesIndex = 0; branchesIndex < branchesCount; branchesIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<ExtendedBreachBranch>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            branches_[branchesIndex] = objectToAdd;
        }
        Branches = branches_;
    }
}