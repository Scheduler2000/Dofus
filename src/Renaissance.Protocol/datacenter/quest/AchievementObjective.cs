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

namespace Renaissance.Protocol.datacenter.quest
{
	[D2OClass("AchievementObjective", "com.ankamagames.dofus.datacenter.quest")]
	public class AchievementObjectiveData : IDataCenter
	{

		private uint m_id;
		private uint m_achievementId;
		private uint m_order;
		private uint m_nameId;
		private String m_criterion;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint AchievementId
		{
			get => m_achievementId;
			set => m_achievementId = value;
		}

		public uint Order
		{
			get => m_order;
			set => m_order = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public String Criterion
		{
			get => m_criterion;
			set => m_criterion = value;
		}


	}
}
