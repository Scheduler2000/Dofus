//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:47.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.web.haapi
{
	public class HaapiTokenMessage : IDofusMessage
	{
		public  const int NetworkId = 6767;
		public  int ProtocolId { get { return NetworkId; } }

		public string Token { get; set; }


		public HaapiTokenMessage() { }


		public HaapiTokenMessage InitHaapiTokenMessage(string _token)
		{

			this.Token = _token;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Token);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Token);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Token = reader.Read<string>();

		}


	}
}
