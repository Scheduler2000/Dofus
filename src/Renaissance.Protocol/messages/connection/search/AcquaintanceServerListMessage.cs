//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:08.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.connection.search
{
	public class AcquaintanceServerListMessage : IDofusMessage
	{
		public  const int NetworkId = 6142;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] Servers { get; set; }


		public AcquaintanceServerListMessage() { }


		public AcquaintanceServerListMessage InitAcquaintanceServerListMessage(CustomVar<short>[] _servers)
		{

			this.Servers = _servers;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Servers.Length));
			foreach(var item in Servers)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Servers_length = reader.Read<short>();
			this.Servers = new CustomVar<short>[Servers_length];
			for(int i = 0; i < Servers_length; i++)
				this.Servers[i] = reader.Read<CustomVar<short>>();

		}


	}
}