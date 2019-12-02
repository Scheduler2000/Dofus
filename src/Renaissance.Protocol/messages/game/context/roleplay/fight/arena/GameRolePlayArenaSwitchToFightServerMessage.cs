//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:26.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.fight.arena
{
	public class GameRolePlayArenaSwitchToFightServerMessage : IDofusMessage
	{
		public  const int NetworkId = 6575;
		public  int ProtocolId { get { return NetworkId; } }

		public string Address { get; set; }

		public short[] Ports { get; set; }

		public byte[] Ticket { get; set; }


		public GameRolePlayArenaSwitchToFightServerMessage() { }


		public GameRolePlayArenaSwitchToFightServerMessage InitGameRolePlayArenaSwitchToFightServerMessage(string _address, short[] _ports, byte[] _ticket)
		{

			this.Address = _address;
			this.Ports = _ports;
			this.Ticket = _ticket;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Address);
			writer.Write((short)(this.Ports.Length));
			foreach(var item in Ports)
				writer.Write(item);
			writer.Write((CustomVar<int>)(this.Ticket.Length));
			foreach(var item in Ticket)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Address = reader.Read<string>();
			int Ports_length = reader.Read<short>();
			this.Ports = new short[Ports_length];
			for(int i = 0; i < Ports_length; i++)
				this.Ports[i] = reader.Read<short>();
			int Ticket_length = reader.Read<CustomVar<int>>();
			this.Ticket = new byte[Ticket_length];
			for(int i = 0; i < Ticket_length; i++)
				this.Ticket[i] = reader.Read<byte>();

		}


	}
}