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
	public class HaapiValidationMessage : IDofusMessage
	{
		public  const int NetworkId = 6844;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Action { get; set; }

		public CustomVar<short> Code { get; set; }


		public HaapiValidationMessage() { }


		public HaapiValidationMessage InitHaapiValidationMessage(byte _action, CustomVar<short> _code)
		{

			this.Action = _action;
			this.Code = _code;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Action);
			writer.Write(this.Code);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Action = reader.Read<byte>();
			this.Code = reader.Read<CustomVar<short>>();

		}


	}
}