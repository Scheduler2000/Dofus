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
	public class GuildListMessage : IDofusMessage
	{
		public  const int NetworkId = 6413;
		public  int ProtocolId { get { return NetworkId; } }

		public GuildInformations[] Guilds { get; set; }


		public GuildListMessage() { }


		public GuildListMessage InitGuildListMessage(GuildInformations[] _guilds)
		{

			this.Guilds = _guilds;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Guilds.Length));
			var memory1 = new Memory<byte>[Guilds.Length];
			for(int i = 0; i < Guilds.Length; i++)
			{
				memory1[i] = this.Guilds[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Guilds.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Guilds_length = reader.Read<short>();
			this.Guilds = new GuildInformations[Guilds_length];
			for(int i = 0; i < Guilds_length; i++)
			{
				this.Guilds[i] = new GuildInformations();
				this.Guilds[i].Deserialize(reader);
			}

		}


	}
}
