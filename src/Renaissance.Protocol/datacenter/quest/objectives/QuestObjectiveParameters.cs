//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:24.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;
using Renaissance.Protocol.datacenter.other;

namespace Renaissance.Protocol.datacenter.quest.objectives
{
	public class QuestObjectiveParametersData : ProxyData
	{

		private uint m_numParams;
		private Boolean m_dungeonOnly;

		public uint NumParams
		{
			get => m_numParams;
			set => m_numParams = value;
		}

		public Boolean DungeonOnly
		{
			get => m_dungeonOnly;
			set => m_dungeonOnly = value;
		}


	}
}
