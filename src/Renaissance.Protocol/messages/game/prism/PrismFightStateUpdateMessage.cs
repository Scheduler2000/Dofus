//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismFightStateUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6040;
		public  int ProtocolId { get { return NetworkId; } }

		public byte State { get; set; }


		public PrismFightStateUpdateMessage() { }


		public PrismFightStateUpdateMessage InitPrismFightStateUpdateMessage(byte _state)
		{

			this.State = _state;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(State);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.State);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.State = reader.Read<byte>();

		}


	}
}
