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
using Renaissance.Protocol.datacenter.other;

namespace Renaissance.Protocol.datacenter.npcs
{
	[D2OClass("AnimFunNpcData", "com.ankamagames.dofus.types.data")]
	public class AnimFunNpcData : AnimFunData
	{
		private List<AnimFunNpcData> m_subAnimFunData;

		public List<AnimFunNpcData> SubAnimFunData { get => this.m_subAnimFunData; set => this.m_subAnimFunData = value; }
	}
}
