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

namespace Renaissance.Protocol.datacenter.idols
{
	[D2OClass("IdolsPresetIcon", "com.ankamagames.dofus.datacenter.idols")]
	public class IdolsPresetIconData : IDataCenter
	{
		private int m_id;
		private int order;

		public int Id { get => this.m_id; set => this.m_id = value; }
		public int Order { get => this.order; set => this.order = value; }
	}
}
