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

namespace Renaissance.Protocol.datacenter.appearance
{
	[D2OClass("Ornament", "com.ankamagames.dofus.datacenter.appearance")]
	public class OrnamentData : IDataCenter
	{

		private int m_id;
		private uint m_nameId;
		private Boolean m_visible;
		private int m_assetId;
		private int m_iconId;
		private int m_rarity;
		private int m_order;

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

		public Boolean Visible
		{
			get => m_visible;
			set => m_visible = value;
		}

		public int AssetId
		{
			get => m_assetId;
			set => m_assetId = value;
		}

		public int IconId
		{
			get => m_iconId;
			set => m_iconId = value;
		}

		public int Rarity
		{
			get => m_rarity;
			set => m_rarity = value;
		}

		public int Order
		{
			get => m_order;
			set => m_order = value;
		}


	}
}