using Renaissance.Protocol.enums;
using Renaissance.Protocol.types.game.look;

namespace Renaissance.World.Game.Actors.Look
{
    public class ContextSubEntity
    {
        public SubEntityBindingPointCategoryEnum Category { get; set; }

        public byte BindingPointIndex { get; set; }

        public ContextActorLook SubActorLook { get; set; }


        public ContextSubEntity(SubEntity subentity)
        {
            this.Category = (SubEntityBindingPointCategoryEnum)subentity.BindingPointCategory;
            this.BindingPointIndex = subentity.BindingPointIndex;
            this.SubActorLook = new ContextActorLook(subentity.SubEntityLook);
        }

        public ContextSubEntity(SubEntityBindingPointCategoryEnum category, byte bindingPointIndex,
            ContextActorLook subActorLook)
        {
            this.Category = category;
            this.BindingPointIndex = bindingPointIndex;
            this.SubActorLook = subActorLook;
        }
        public override bool Equals(object obj)
        {
            return !(obj is ContextSubEntity subEntity)
                ? false
                : subEntity.BindingPointIndex == this.BindingPointIndex && subEntity.Category == this.Category &&
                    subEntity.SubActorLook == this.SubActorLook;
        }
        public ContextSubEntity Clone()
        { return new ContextSubEntity(Category, BindingPointIndex, SubActorLook.Clone()); }

        public SubEntity ToSubEntity()
        { return new SubEntity().InitSubEntity((byte)Category, BindingPointIndex, SubActorLook.ToEntityLook()); }

    }
}
