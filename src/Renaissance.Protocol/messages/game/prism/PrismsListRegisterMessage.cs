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
	public class PrismsListRegisterMessage : IDofusMessage
	{
		public  const int NetworkId = 6441;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Listen { get; set; }


		public PrismsListRegisterMessage() { }


		public PrismsListRegisterMessage InitPrismsListRegisterMessage(byte _listen)
		{

			this.Listen = _listen;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Listen);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Listen);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Listen = reader.Read<byte>();

		}


	}
}
