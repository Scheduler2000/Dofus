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

namespace Renaissance.Protocol.datacenter.alignments
{
	[D2OClass("AlignmentBalance", "com.ankamagames.dofus.datacenter.alignments")]
	public class AlignmentBalanceData : IDataCenter
	{

		private int m_id;
		private int m_startValue;
		private int m_endValue;
		private uint m_nameId;
		private uint m_descriptionId;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public int StartValue
		{
			get => m_startValue;
			set => m_startValue = value;
		}

		public int EndValue
		{
			get => m_endValue;
			set => m_endValue = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public uint DescriptionId
		{
			get => m_descriptionId;
			set => m_descriptionId = value;
		}


	}
}
