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
using    Renaissance.Protocol.datacenter.characteristics;

namespace Renaissance.Protocol.datacenter.monsters
{
	[D2OClass("CompanionCharacteristic", "com.ankamagames.dofus.datacenter.monsters")]
	public class CompanionCharacteristicData : IDataCenter
	{

		private int m_id;
		private int m_caracId;
		private int m_companionId;
		private int m_order;
		private List<List<double>> m_statPerLevelRange;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public int CaracId
		{
			get => m_caracId;
			set => m_caracId = value;
		}

		public int CompanionId
		{
			get => m_companionId;
			set => m_companionId = value;
		}

		public int Order
		{
			get => m_order;
			set => m_order = value;
		}

		public List<List<double>> StatPerLevelRange
		{
			get => m_statPerLevelRange;
			set => m_statPerLevelRange = value;
		}


	}
}
