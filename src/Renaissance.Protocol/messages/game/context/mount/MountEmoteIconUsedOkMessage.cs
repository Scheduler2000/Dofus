//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:49.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class MountEmoteIconUsedOkMessage : IDofusMessage
	{
		public  const int NetworkId = 5978;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> MountId { get; set; }

		public byte ReactionType { get; set; }


		public MountEmoteIconUsedOkMessage() { }


		public MountEmoteIconUsedOkMessage InitMountEmoteIconUsedOkMessage(CustomVar<int> _mountid, byte _reactiontype)
		{

			this.MountId = _mountid;
			this.ReactionType = _reactiontype;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MountId);
			size += DofusBinaryFactory.Sizing.SizeOf(ReactionType);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.MountId);
			writer.WriteData(this.ReactionType);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MountId = reader.Read<CustomVar<int>>();
			this.ReactionType = reader.Read<byte>();

		}


	}
}
