//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:07.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.connection
{
	public class SelectedServerRefusedMessage : IDofusMessage
	{
		public  const int NetworkId = 41;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> ServerId { get; set; }

		public byte Error { get; set; }

		public byte ServerStatus { get; set; }


		public SelectedServerRefusedMessage() { }


		public SelectedServerRefusedMessage InitSelectedServerRefusedMessage(CustomVar<short> _serverid, byte _error, byte _serverstatus)
		{

			this.ServerId = _serverid;
			this.Error = _error;
			this.ServerStatus = _serverstatus;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ServerId);
			writer.Write(this.Error);
			writer.Write(this.ServerStatus);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ServerId = reader.Read<CustomVar<short>>();
			this.Error = reader.Read<byte>();
			this.ServerStatus = reader.Read<byte>();

		}


	}
}
