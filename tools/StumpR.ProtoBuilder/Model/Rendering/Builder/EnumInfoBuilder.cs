namespace StumpR.ProtoBuilder.Model.Rendering.Builder;

public class EnumInfoBuilder : EntityInfoBuilder<EnumInfo>
{
    public EnumInfoBuilder() : base(new EnumInfo())
    { }

    public EnumInfoBuilder AddEnum(EnumItemInfo enumItem)
    {
        Underlying.Elements.Add(enumItem);
        return this;
    }

    public EnumInfo Build()
    {
        return Underlying;
    }
}