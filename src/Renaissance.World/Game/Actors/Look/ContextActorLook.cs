using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract.Extensions;
using Renaissance.Binary.Definition;
using Renaissance.Protocol.enums;
using Renaissance.Protocol.types.game.look;
using Renaissance.World.IoC;
using Renaissance.World.Manager.Game.EntityLook;

namespace Renaissance.World.Game.Actors.Look
{
    public class ContextActorLook
    {
        private EntityLookManager m_lookManager;

        public const short PET_SIZE = 80;

        public const short AURA_SIZE = 90;

        public short BonesId { get; private set; }

        public List<short> Skins { get; private set; }

        public List<int> Colors { get; private set; }

        public List<short> Scales { get; private set; }

        public short Scale { get => (short)(Scales.Count == 0 ? 100 : Scales[0]); }

        public List<ContextSubEntity> SubEntities { get; private set; }

        public bool IsRiding
        {
            get => this.SubEntities
                    .Find(x => x.Category == SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_MOUNT_DRIVER) != null;
        }

        public ContextActorLook()
        {
            this.Skins = new List<short>();
            this.Colors = new List<int>();
            this.Scales = new List<short>();
            this.SubEntities = new List<ContextSubEntity>();
            this.m_lookManager = ServiceLocator.Provider.GetService<EntityLookManager>();
        }

        public ContextActorLook(short bonesId, List<short> skins, List<int> colors, List<short> scales,
                                List<ContextSubEntity> subEntity)
        {
            this.BonesId = bonesId;
            this.Skins = skins;
            this.Colors = colors;
            this.Scales = scales;
            this.SubEntities = subEntity;
            this.m_lookManager = ServiceLocator.Provider.GetService<EntityLookManager>();
        }

        public ContextActorLook(EntityLook look)
        {
            this.BonesId = BonesId;
            this.Skins = look.Skins.Select(x => x.Value).ToList();
            this.Colors = look.IndexedColors.ToList();
            this.Scales = look.Scales.Select(x => x.Value).ToList();
            this.SubEntities = look.SubEntities.ToList().ConvertAll(x => new ContextSubEntity(x));
            this.m_lookManager = ServiceLocator.Provider.GetService<EntityLookManager>();
        }

        public void SetSkins(List<short> value)
        { ActiveLook().Skins = value; }

        public void AddSkin(short value)
        {
            var look = ActiveLook();
            if (!look.Skins.Contains(value))
                look.Skins.Add(value);
        }
        public void AddScale(short value)
        { SetScale((short)(Scale + value)); }

        public void SetScale(short value)
        {
            var look = ActiveLook();

            if (look.Scales.Count == 0)
                look.Scales.Add(value);
            else
                ActiveLook().Scales[0] = value;

        }
        public void RemoveSkin(short value)
        { ActiveLook().Skins.RemoveAll(x => x == value); }

        public void SetBones(short value)
        { ActiveLook().BonesId = value; }

        public void SetColors(List<int> colors)
        { ActiveLook().Colors = colors; }

        public int RemoveSubEntities(ContextActorLook look, SubEntityBindingPointCategoryEnum category)
        { return SubEntities.RemoveAll(x => x.Category == category); }

        public ContextSubEntity GetSubEntity(SubEntityBindingPointCategoryEnum category)
        { return SubEntities.Find(x => x.Category == category); }

        public void AddPetSkin(short skinId, short scale)
        {
            ActiveLook().SubEntities
                        .Add(new ContextSubEntity(SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_PET, 0, m_lookManager.GetBonesLook(skinId, scale)));
        }

        public void RemovePetSkin()
        {
            ActiveLook().SubEntities
                        .RemoveAll(x => x.Category == SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_PET);
        }
        public void AddAura(short bonesId)
        {
            this.SubEntities.Add(new ContextSubEntity(SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_BASE_FOREGROUND,
                0, m_lookManager.GetBonesLook(bonesId, AURA_SIZE)));
        }
        public bool RemoveAura()
        {
            return this.RemoveSubEntities(this, SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_BASE_FOREGROUND) > 0;
        }

        public ContextActorLook GetMountLook(ContextActorLook mountLook)
        {
            ContextActorLook newLook = mountLook.Clone();
            newLook.Colors = m_lookManager.GetConvertedColors(mountLook.Colors.ToArray()).ToList();
            var actorSub = new ContextSubEntity(SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_MOUNT_DRIVER, 0,
                new ContextActorLook(2, this.Skins, this.Colors, this.Scales, this.SubEntities));
            newLook.SubEntities.Add(actorSub);
            return newLook;
        }

        public ContextActorLook GetMountDriverLook()
        {
            return !this.IsRiding ? null
                   : this.GetSubEntity(SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_MOUNT_DRIVER).SubActorLook;
        }

        public override bool Equals(object obj)
        {
            var look = obj as ContextActorLook;

            return obj == null
                ? false
                : look.BonesId == this.BonesId && look.Colors.SequenceEqual(look.Colors) && look.Scales.SequenceEqual(this.Scales) && look.Skins.SequenceEqual(this.Skins)
                 && this.SubEntities.SequenceEqual(this.SubEntities);
        }
        public ContextActorLook ActiveLook()
        { return !IsRiding ? (this) : GetMountDriverLook(); }

        public EntityLook ToEntityLook()
        {
            return new EntityLook()
                  .InitEntityLook(new CustomVar<short>(BonesId),
                  Skins.Select(x => new CustomVar<short>(x)).ToArray(), Colors.ToArray(),
                  Scales.Select(x => new CustomVar<short>(x)).ToArray(),
                  SubEntities.ConvertAll(x => x.ToSubEntity()).ToArray()); ;
        }

        public ContextActorLook Clone()
        {
            var subentities = new List<ContextSubEntity>();

            foreach (var sub in SubEntities)
                subentities.Add(sub.Clone());

            return new ContextActorLook(BonesId, new List<short>(Skins), new List<int>(Colors),
                new List<short>(Scales), new List<ContextSubEntity>(subentities));
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            int num = 0;
            stringBuilder.Append(BonesId);

            if (Skins == null || !Skins.Any())
                num++;
            else
            {
                stringBuilder.Append("|".ConcatCopy(num + 1));
                num = 0;
                stringBuilder.Append(string.Join(",", Skins));
            }
            if (Colors == null)
                num++;
            else
            {
                stringBuilder.Append("|".ConcatCopy(num + 1));
                num = 0;

                var values = new List<string>();

                int i = 0;
                foreach (var color in Colors)
                {
                    i++;
                    values.Add(i + "=" + color);
                }

                stringBuilder.Append(string.Join(",", values));

            }
            if (Scales == null)
                num++;
            else
            {
                stringBuilder.Append("|".ConcatCopy(num + 1));
                num = 0;
                stringBuilder.Append(string.Join(",", Scales));
            }
            if (SubEntities.Count() == 0)
                num++;

            else
            {
                var subEntitiesAsString = new List<string>();
                foreach (var sub in SubEntities)
                {
                    var subBuilter = new StringBuilder();
                    subBuilter.Append((sbyte)sub.Category);
                    subBuilter.Append("@");
                    subBuilter.Append(sub.BindingPointIndex);
                    subBuilter.Append("=");
                    subBuilter.Append(sub.SubActorLook.ToString());
                    subEntitiesAsString.Add(subBuilter.ToString());
                }
                stringBuilder.Append("|".ConcatCopy(num + 1));
                stringBuilder.Append(string.Join<string>(",",
                    from entry in subEntitiesAsString
                    select entry));
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}
