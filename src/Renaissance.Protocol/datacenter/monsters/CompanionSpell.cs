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

namespace Renaissance.Protocol.datacenter.monsters
{
	[D2OClass("CompanionSpell", "com.ankamagames.dofus.datacenter.monsters")]
	public class CompanionSpellData : IDataCenter
	{

		private int m_id;
		private int m_spellId;
		private int m_companionId;
		private String m_gradeByLevel;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public int SpellId
		{
			get => m_spellId;
			set => m_spellId = value;
		}

		public int CompanionId
		{
			get => m_companionId;
			set => m_companionId = value;
		}

		public String GradeByLevel
		{
			get => m_gradeByLevel;
			set => m_gradeByLevel = value;
		}


	}
}
