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
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildInvitedMessage : IDofusMessage
	{
		public  const int NetworkId = 5552;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> RecruterId { get; set; }

		public string RecruterName { get; set; }

		public BasicGuildInformations GuildInfo { get; set; }


		public GuildInvitedMessage() { }


		public GuildInvitedMessage InitGuildInvitedMessage(CustomVar<long> _recruterid, string _recrutername, BasicGuildInformations _guildinfo)
		{

			this.RecruterId = _recruterid;
			this.RecruterName = _recrutername;
			this.GuildInfo = _guildinfo;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(RecruterId);
			size += DofusBinaryFactory.Sizing.SizeOf(RecruterName);
			var serialized1 = this.GuildInfo.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.RecruterId);
			writer.WriteData(this.RecruterName);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.RecruterId = reader.Read<CustomVar<long>>();
			this.RecruterName = reader.Read<string>();
			this.GuildInfo = new BasicGuildInformations();
			this.GuildInfo.Deserialize(reader);

		}


	}
}
