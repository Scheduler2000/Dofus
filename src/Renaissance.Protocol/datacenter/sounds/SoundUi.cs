//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.sounds
{
	[D2OClass("SoundUi", "com.ankamagames.dofus.datacenter.sounds")]
	public class SoundUiData : IDataCenter
	{

		private uint m_id;
		private String m_uiName;
		private String m_openFile;
		private String m_closeFile;
		private List<SoundUiElementData> m_subElements;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public String UiName
		{
			get => m_uiName;
			set => m_uiName = value;
		}

		public String OpenFile
		{
			get => m_openFile;
			set => m_openFile = value;
		}

		public String CloseFile
		{
			get => m_closeFile;
			set => m_closeFile = value;
		}

		public List<SoundUiElementData> SubElements
		{
			get => m_subElements;
			set => m_subElements = value;
		}


	}
}
