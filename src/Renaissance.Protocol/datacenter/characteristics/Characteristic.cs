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

namespace Renaissance.Protocol.datacenter.characteristics
{
	[D2OClass("Characteristic", "com.ankamagames.dofus.datacenter.characteristics")]
	public class CharacteristicData : IDataCenter
	{

		private int m_id;
		private String m_keyword;
		private uint m_nameId;
		private String m_asset;
		private int m_categoryId;
		private Boolean m_visible;
		private int m_order;
		private Boolean m_upgradable;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public String Keyword
		{
			get => m_keyword;
			set => m_keyword = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public String Asset
		{
			get => m_asset;
			set => m_asset = value;
		}

		public int CategoryId
		{
			get => m_categoryId;
			set => m_categoryId = value;
		}

		public Boolean Visible
		{
			get => m_visible;
			set => m_visible = value;
		}

		public int Order
		{
			get => m_order;
			set => m_order = value;
		}

		public Boolean Upgradable
		{
			get => m_upgradable;
			set => m_upgradable = value;
		}


	}
}