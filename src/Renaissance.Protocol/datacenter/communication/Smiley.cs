//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 24/12/2019 10:59:11.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Renaissance.Protocol.datacenter.effects;
using Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.communication
{
    [D2OClass("Smiley", "com.ankamagames.dofus.datacenter.communication")]
    public class Smiley : IDataCenter
    {
        private uint m_id;
        private uint m_order;
        private string m_gfxId;
        private bool m_forPlayers;
        private List<string> m_triggers;
        private uint m_referenceId;
        private uint m_categoryId;

        public uint Id { get => m_id; set => m_id = value; }

        public uint Order { get => m_order; set => m_order = value; }

        public string GfxId { get => m_gfxId; set => m_gfxId = value; }

        public bool ForPlayers { get => m_forPlayers; set => m_forPlayers = value; }

        public List<string> Triggers { get => m_triggers; set => m_triggers = value; }

        public uint ReferenceId { get => m_referenceId; set => m_referenceId = value; }

        public uint CategoryId { get => m_categoryId; set => m_categoryId = value; }
    }
}
