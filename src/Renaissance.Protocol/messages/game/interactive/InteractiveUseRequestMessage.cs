//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.interactive
{
	public class InteractiveUseRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5001;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ElemId { get; set; }

		public CustomVar<int> SkillInstanceUid { get; set; }


		public InteractiveUseRequestMessage() { }


		public InteractiveUseRequestMessage InitInteractiveUseRequestMessage(CustomVar<int> _elemid, CustomVar<int> _skillinstanceuid)
		{

			this.ElemId = _elemid;
			this.SkillInstanceUid = _skillinstanceuid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ElemId);
			writer.Write(this.SkillInstanceUid);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ElemId = reader.Read<CustomVar<int>>();
			this.SkillInstanceUid = reader.Read<CustomVar<int>>();

		}


	}
}