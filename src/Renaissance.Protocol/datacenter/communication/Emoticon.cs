//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:19.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.communication
{
	[D2OClass("Emoticon", "com.ankamagames.dofus.datacenter.communication")]
	public class EmoticonData : IDataCenter
	{

		private uint m_id;
		private uint m_nameId;
		private uint m_shortcutId;
		private uint m_order;
		private String m_defaultAnim;
		private Boolean m_persistancy;
		private Boolean m_eight_directions;
		private Boolean m_aura;
		private List<String> m_anims;
		private uint m_cooldown;
		private uint m_duration;
		private uint m_weight;
		private uint m_spellLevelId;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public uint ShortcutId
		{
			get => m_shortcutId;
			set => m_shortcutId = value;
		}

		public uint Order
		{
			get => m_order;
			set => m_order = value;
		}

		public String DefaultAnim
		{
			get => m_defaultAnim;
			set => m_defaultAnim = value;
		}

		public Boolean Persistancy
		{
			get => m_persistancy;
			set => m_persistancy = value;
		}

		public Boolean Eight_directions
		{
			get => m_eight_directions;
			set => m_eight_directions = value;
		}

		public Boolean Aura
		{
			get => m_aura;
			set => m_aura = value;
		}

		public List<String> Anims
		{
			get => m_anims;
			set => m_anims = value;
		}

		public uint Cooldown
		{
			get => m_cooldown;
			set => m_cooldown = value;
		}

		public uint Duration
		{
			get => m_duration;
			set => m_duration = value;
		}

		public uint Weight
		{
			get => m_weight;
			set => m_weight = value;
		}

		public uint SpellLevelId
		{
			get => m_spellLevelId;
			set => m_spellLevelId = value;
		}


	}
}
