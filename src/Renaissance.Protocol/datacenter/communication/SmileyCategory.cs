//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:20.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.communication
{
	[D2OClass("SmileyCategory", "com.ankamagames.dofus.datacenter.communication")]
	public class SmileyCategoryData : IDataCenter
	{

		private int m_id;
		private uint m_order;
		private String m_gfxId;
		private Boolean m_isFake;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint Order
		{
			get => m_order;
			set => m_order = value;
		}

		public String GfxId
		{
			get => m_gfxId;
			set => m_gfxId = value;
		}

		public Boolean IsFake
		{
			get => m_isFake;
			set => m_isFake = value;
		}


	}
}
