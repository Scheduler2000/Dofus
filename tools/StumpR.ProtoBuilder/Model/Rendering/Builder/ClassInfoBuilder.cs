namespace StumpR.ProtoBuilder.Model.Rendering.Builder;

public class ClassInfoBuilder : EntityInfoBuilder<ClassInfo>
{
    public ClassInfoBuilder() : base(new ClassInfo())
    { }


    public ClassInfoBuilder AddProperty(PropertyInfo property)
    {
        Underlying.Properties.Add(property);
        return this;
    }

    public ClassInfoBuilder AddParentProperty(PropertyInfo property)
    {
        /* Ensure property does not exist in class properties . */
        if (Underlying.Properties.Find(prop => prop.Equals(property)) == null)
            Underlying.ParentProperties.Add(property);

        return this;
    }

    public ClassInfoBuilder SetParent(string parent)
    {
        Underlying.HasParent = true;
        Underlying.Parent = parent;
        return this;
    }

    public ClassInfo Build()
    {
        return Underlying;
    }
}