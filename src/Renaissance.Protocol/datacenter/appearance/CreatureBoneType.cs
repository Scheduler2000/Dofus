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

namespace Renaissance.Protocol.datacenter.appearance
{
	[D2OClass("CreatureBoneType", "com.ankamagames.dofus.datacenter.appearance")]
	public class CreatureBoneTypeData : IDataCenter
	{

		private int m_id;
		private int m_creatureBoneId;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public int CreatureBoneId
		{
			get => m_creatureBoneId;
			set => m_creatureBoneId = value;
		}


	}
}
