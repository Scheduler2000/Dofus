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

namespace Renaissance.Protocol.datacenter.misc
{
	[D2OClass("OptionalFeature", "com.ankamagames.dofus.datacenter.misc")]
	public class OptionalFeatureData : IDataCenter
	{

		private int m_id;
		private String m_keyword;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public String Keyword
		{
			get => m_keyword;
			set => m_keyword = value;
		}


	}
}
