//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class MimicryObjectEraseRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6457;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> HostUID { get; set; }

		public byte HostPos { get; set; }


		public MimicryObjectEraseRequestMessage() { }


		public MimicryObjectEraseRequestMessage InitMimicryObjectEraseRequestMessage(CustomVar<int> _hostuid, byte _hostpos)
		{

			this.HostUID = _hostuid;
			this.HostPos = _hostpos;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(HostUID);
			size += DofusBinaryFactory.Sizing.SizeOf(HostPos);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.HostUID);
			writer.WriteData(this.HostPos);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.HostUID = reader.Read<CustomVar<int>>();
			this.HostPos = reader.Read<byte>();

		}


	}
}
