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

namespace Renaissance.Protocol.datacenter.bonus
{
	[D2OClass("Bonus", "com.ankamagames.dofus.datacenter.bonus")]
	public class BonusData : IDataCenter
	{

		private int m_id;
		private uint m_type;
		private int m_amount;
		private List<int> m_criterionsIds;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint Type
		{
			get => m_type;
			set => m_type = value;
		}

		public int Amount
		{
			get => m_amount;
			set => m_amount = value;
		}

		public List<int> CriterionsIds
		{
			get => m_criterionsIds;
			set => m_criterionsIds = value;
		}


	}
}