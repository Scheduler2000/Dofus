using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class EntityLook
{
    public const short Id = 9546;

    public EntityLook(ushort bonesId,
        IEnumerable<ushort> skins,
        IEnumerable<int> indexedColors,
        IEnumerable<short> scales,
        IEnumerable<SubEntity> subentities)
    {
        BonesId = bonesId;
        Skins = skins;
        IndexedColors = indexedColors;
        Scales = scales;
        Subentities = subentities;
    }

    public EntityLook()
    {
    }

    public virtual short TypeId => Id;

    public ushort BonesId { get; set; }

    public IEnumerable<ushort> Skins { get; set; }

    public IEnumerable<int> IndexedColors { get; set; }

    public IEnumerable<short> Scales { get; set; }

    public IEnumerable<SubEntity> Subentities { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(BonesId);
        writer.WriteShort((short) Skins.Count());
        foreach (ushort objectToSend in Skins) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) IndexedColors.Count());
        foreach (int objectToSend in IndexedColors) writer.WriteInt(objectToSend);
        writer.WriteShort((short) Scales.Count());
        foreach (short objectToSend in Scales) writer.WriteVarShort(objectToSend);
        writer.WriteShort((short) Subentities.Count());
        foreach (SubEntity objectToSend in Subentities) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        BonesId = reader.ReadVarUShort();
        ushort skinsCount = reader.ReadUShort();
        var skins_ = new ushort[skinsCount];
        for (var skinsIndex = 0; skinsIndex < skinsCount; skinsIndex++) skins_[skinsIndex] = reader.ReadVarUShort();
        Skins = skins_;
        ushort indexedColorsCount = reader.ReadUShort();
        var indexedColors_ = new int[indexedColorsCount];

        for (var indexedColorsIndex = 0; indexedColorsIndex < indexedColorsCount; indexedColorsIndex++)
            indexedColors_[indexedColorsIndex] = reader.ReadInt();
        IndexedColors = indexedColors_;
        ushort scalesCount = reader.ReadUShort();
        var scales_ = new short[scalesCount];
        for (var scalesIndex = 0; scalesIndex < scalesCount; scalesIndex++) scales_[scalesIndex] = reader.ReadVarShort();
        Scales = scales_;
        ushort subentitiesCount = reader.ReadUShort();
        var subentities_ = new SubEntity[subentitiesCount];

        for (var subentitiesIndex = 0; subentitiesIndex < subentitiesCount; subentitiesIndex++)
        {
            var objectToAdd = new SubEntity();
            objectToAdd.Deserialize(reader);
            subentities_[subentitiesIndex] = objectToAdd;
        }
        Subentities = subentities_;
    }
}