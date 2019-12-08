//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:57.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.havenbag.meeting
{
	public class TeleportHavenBagRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6647;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> GuestId { get; set; }


		public TeleportHavenBagRequestMessage() { }


		public TeleportHavenBagRequestMessage InitTeleportHavenBagRequestMessage(CustomVar<long> _guestid)
		{

			this.GuestId = _guestid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(GuestId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.GuestId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.GuestId = reader.Read<CustomVar<long>>();

		}


	}
}
