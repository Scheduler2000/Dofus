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

namespace Renaissance.Protocol.datacenter.challenges
{
	[D2OClass("Challenge", "com.ankamagames.dofus.datacenter.challenges")]
	public class ChallengeData : IDataCenter
	{

		private int m_id;
		private uint m_nameId;
		private uint m_descriptionId;
		private Boolean m_dareAvailable;
		private List<uint> m_incompatibleChallenges;

		public int Id
		{
			get => m_id;
			set => m_id = value;
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

		public Boolean DareAvailable
		{
			get => m_dareAvailable;
			set => m_dareAvailable = value;
		}

		public List<uint> IncompatibleChallenges
		{
			get => m_incompatibleChallenges;
			set => m_incompatibleChallenges = value;
		}


	}
}
