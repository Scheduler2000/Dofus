//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.bonus.criterion
{
	[D2OClass("BonusCriterion", "com.ankamagames.dofus.datacenter.bonus.criterion")]
	public class BonusCriterionData : IDataCenter
	{

		private int m_id;
		private uint m_type;
		private int m_value;

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

		public int Value
		{
			get => m_value;
			set => m_value = value;
		}


	}
}
