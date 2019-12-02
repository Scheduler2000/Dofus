//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:15.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.web.haapi
{
	public class HaapiShopApiKeyMessage : IDofusMessage
	{
		public  const int NetworkId = 6858;
		public  int ProtocolId { get { return NetworkId; } }

		public string Token { get; set; }


		public HaapiShopApiKeyMessage() { }


		public HaapiShopApiKeyMessage InitHaapiShopApiKeyMessage(string _token)
		{

			this.Token = _token;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Token);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Token = reader.Read<string>();

		}


	}
}
