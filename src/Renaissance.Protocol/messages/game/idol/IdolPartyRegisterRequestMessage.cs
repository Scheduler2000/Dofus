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

namespace Renaissance.Protocol.messages.game.idol
{
	public class IdolPartyRegisterRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6582;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Register { get; set; }


		public IdolPartyRegisterRequestMessage() { }


		public IdolPartyRegisterRequestMessage InitIdolPartyRegisterRequestMessage(bool _register)
		{

			this.Register = _register;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Register);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Register);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Register = reader.Read<bool>();

		}


	}
}
