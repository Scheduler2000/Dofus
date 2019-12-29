//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:21.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.monsters
{
	[D2OClass("Companion", "com.ankamagames.dofus.datacenter.monsters")]
	public class CompanionData : IDataCenter
	{

		private int m_id;
		private uint m_nameId;
		private String m_look;
		private Boolean m_webDisplay;
		private uint m_descriptionId;
		private uint m_startingSpellLevelId;
		private uint m_assetId;
		private List<uint> m_characteristics;
		private List<uint> m_spells;
		private int m_creatureBoneId;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public String Look
		{
			get => m_look;
			set => m_look = value;
		}

		public Boolean WebDisplay
		{
			get => m_webDisplay;
			set => m_webDisplay = value;
		}

		public uint DescriptionId
		{
			get => m_descriptionId;
			set => m_descriptionId = value;
		}

		public uint StartingSpellLevelId
		{
			get => m_startingSpellLevelId;
			set => m_startingSpellLevelId = value;
		}

		public uint AssetId
		{
			get => m_assetId;
			set => m_assetId = value;
		}

		public List<uint> Characteristics
		{
			get => m_characteristics;
			set => m_characteristics = value;
		}

		public List<uint> Spells
		{
			get => m_spells;
			set => m_spells = value;
		}

		public int CreatureBoneId
		{
			get => m_creatureBoneId;
			set => m_creatureBoneId = value;
		}


	}
}