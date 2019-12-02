//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:24.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.job
{
	public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage, IDofusMessage
	{
		public new const int NetworkId = 5747;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PlayerId { get; set; }

		public CustomVar<short>[] Skills { get; set; }


		public JobMultiCraftAvailableSkillsMessage() { }


		public JobMultiCraftAvailableSkillsMessage InitJobMultiCraftAvailableSkillsMessage(CustomVar<long> _playerid, CustomVar<short>[] _skills)
		{

			this.PlayerId = _playerid;
			this.Skills = _skills;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.PlayerId);
			writer.Write((short)(this.Skills.Length));
			foreach(var item in Skills)
				writer.Write(item);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.PlayerId = reader.Read<CustomVar<long>>();
			int Skills_length = reader.Read<short>();
			this.Skills = new CustomVar<short>[Skills_length];
			for(int i = 0; i < Skills_length; i++)
				this.Skills[i] = reader.Read<CustomVar<short>>();

		}


	}
}
