//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 24/12/2019 10:59:12.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;
using    Renaissance.Protocol.datacenter.effects;

namespace Renaissance.Protocol.datacenter.items
{
    [D2OClass("ItemSet", "com.ankamagames.dofus.datacenter.items")]
    public class ItemSetData : IDataCenter
    {
        private uint m_id;
        private List<uint> m_items;
        private uint m_nameId;
        private List<List<EffectInstanceData>> m_effects;
        private bool m_bonusIsSecret;

        public uint Id { get => m_id; set => m_id = value; }

        public List<uint> Items { get => m_items; set => m_items = value; }

        public uint NameId { get => m_nameId; set => m_nameId = value; }

        public List<List<EffectInstanceData>> Effects { get => m_effects; set => m_effects = value; }

        public bool BonusIsSecret { get => m_bonusIsSecret; set => m_bonusIsSecret = value; }

    }
}