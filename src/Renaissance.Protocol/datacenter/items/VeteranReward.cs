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

namespace Renaissance.Protocol.datacenter.items
{
	[D2OClass("VeteranReward", "com.ankamagames.dofus.datacenter.items")]
	public class VeteranRewardData : IDataCenter
	{

		private int m_id;
		private uint m_requiredSubDays;
		private uint m_itemGID;
		private uint m_itemQuantity;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint RequiredSubDays
		{
			get => m_requiredSubDays;
			set => m_requiredSubDays = value;
		}

		public uint ItemGID
		{
			get => m_itemGID;
			set => m_itemGID = value;
		}

		public uint ItemQuantity
		{
			get => m_itemQuantity;
			set => m_itemQuantity = value;
		}


	}
}