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

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildInvitationByNameMessage : IDofusMessage
	{
		public  const int NetworkId = 6115;
		public  int ProtocolId { get { return NetworkId; } }

		public string Name { get; set; }


		public GuildInvitationByNameMessage() { }


		public GuildInvitationByNameMessage InitGuildInvitationByNameMessage(string _name)
		{

			this.Name = _name;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Name);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Name);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Name = reader.Read<string>();

		}


	}
}
