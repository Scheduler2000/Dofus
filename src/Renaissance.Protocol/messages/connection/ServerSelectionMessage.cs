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
	public class ServerSelectionMessage : IDofusMessage
	{
		public  const int NetworkId = 40;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> ServerId { get; set; }


		public ServerSelectionMessage() { }


		public ServerSelectionMessage InitServerSelectionMessage(CustomVar<short> _serverid)
		{

			this.ServerId = _serverid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ServerId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ServerId = reader.Read<CustomVar<short>>();

		}


	}
}
