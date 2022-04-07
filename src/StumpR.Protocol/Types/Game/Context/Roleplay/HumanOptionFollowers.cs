using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionFollowers : HumanOption
{
    public new const short Id = 77;

    public HumanOptionFollowers(IEnumerable<IndexedEntityLook> followingCharactersLook)
    {
        FollowingCharactersLook = followingCharactersLook;
    }

    public HumanOptionFollowers()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<IndexedEntityLook> FollowingCharactersLook { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) FollowingCharactersLook.Count());
        foreach (IndexedEntityLook objectToSend in FollowingCharactersLook) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort followingCharactersLookCount = reader.ReadUShort();
        var followingCharactersLook_ = new IndexedEntityLook[followingCharactersLookCount];

        for (var followingCharactersLookIndex = 0;
             followingCharactersLookIndex < followingCharactersLookCount;
             followingCharactersLookIndex++)
        {
            var objectToAdd = new IndexedEntityLook();
            objectToAdd.Deserialize(reader);
            followingCharactersLook_[followingCharactersLookIndex] = objectToAdd;
        }
        FollowingCharactersLook = followingCharactersLook_;
    }
}