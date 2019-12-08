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
	public class MountReleasedMessage : IDofusMessage
	{
		public  const int NetworkId = 6308;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> MountId { get; set; }


		public MountReleasedMessage() { }


		public MountReleasedMessage InitMountReleasedMessage(CustomVar<int> _mountid)
		{

			this.MountId = _mountid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MountId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.MountId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MountId = reader.Read<CustomVar<int>>();

		}


	}
}
