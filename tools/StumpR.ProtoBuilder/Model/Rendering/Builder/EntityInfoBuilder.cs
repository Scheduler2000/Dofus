namespace StumpR.ProtoBuilder.Model.Rendering.Builder;

public abstract class EntityInfoBuilder<TEntity> where TEntity : EntityInfo
{
    protected readonly TEntity Underlying;

    protected EntityInfoBuilder(TEntity entity)
    {
        Underlying = entity;
    }

    public EntityInfoBuilder<TEntity> SetName(string name)
    {
        Underlying.Name = name;
        return this;
    }

    public EntityInfoBuilder<TEntity> SetNamespace(string @namespace)
    {
        Underlying.Namespace = @namespace;
        return this;
    }

    public EntityInfoBuilder<TEntity> AddDirective(DirectiveInfo directive)
    {
        Underlying.Directives.Add(directive);
        return this;
    }
}