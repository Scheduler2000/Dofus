//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:12.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Register);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Register = reader.Read<bool>();

		}


	}
}
