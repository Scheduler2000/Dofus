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
using    Renaissance.Protocol.types.connection;

namespace Renaissance.Protocol.messages.connection
{
	public class ServersListMessage : IDofusMessage
	{
		public  const int NetworkId = 30;
		public  int ProtocolId { get { return NetworkId; } }

		public GameServerInformations[] Servers { get; set; }

		public CustomVar<short> AlreadyConnectedToServerId { get; set; }

		public bool CanCreateNewCharacter { get; set; }


		public ServersListMessage() { }


		public ServersListMessage InitServersListMessage(GameServerInformations[] _servers, CustomVar<short> _alreadyconnectedtoserverid, bool _cancreatenewcharacter)
		{

			this.Servers = _servers;
			this.AlreadyConnectedToServerId = _alreadyconnectedtoserverid;
			this.CanCreateNewCharacter = _cancreatenewcharacter;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Servers.Length));
			foreach(var obj in Servers)
			{
				writer.Write(obj.Serialize());
			}
			writer.Write(this.AlreadyConnectedToServerId);
			writer.Write(this.CanCreateNewCharacter);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Servers_length = reader.Read<short>();
			this.Servers = new GameServerInformations[Servers_length];
			for(int i = 0; i < Servers_length; i++)
			{
				this.Servers[i] = new GameServerInformations();
				this.Servers[i].Deserialize(reader);
			}
			this.AlreadyConnectedToServerId = reader.Read<CustomVar<short>>();
			this.CanCreateNewCharacter = reader.Read<bool>();

		}


	}
}