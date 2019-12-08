//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:45.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.interactive
{
	public class InteractiveUseErrorMessage : IDofusMessage
	{
		public  const int NetworkId = 6384;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ElemId { get; set; }

		public CustomVar<int> SkillInstanceUid { get; set; }


		public InteractiveUseErrorMessage() { }


		public InteractiveUseErrorMessage InitInteractiveUseErrorMessage(CustomVar<int> _elemid, CustomVar<int> _skillinstanceuid)
		{

			this.ElemId = _elemid;
			this.SkillInstanceUid = _skillinstanceuid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ElemId);
			size += DofusBinaryFactory.Sizing.SizeOf(SkillInstanceUid);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ElemId);
			writer.WriteData(this.SkillInstanceUid);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ElemId = reader.Read<CustomVar<int>>();
			this.SkillInstanceUid = reader.Read<CustomVar<int>>();

		}


	}
}
