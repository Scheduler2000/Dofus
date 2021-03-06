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
using    Renaissance.Protocol.types.game.guild;

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildModificationEmblemValidMessage : IDofusMessage
	{
		public  const int NetworkId = 6328;
		public  int ProtocolId { get { return NetworkId; } }

		public GuildEmblem GuildEmblem { get; set; }


		public GuildModificationEmblemValidMessage() { }


		public GuildModificationEmblemValidMessage InitGuildModificationEmblemValidMessage(GuildEmblem _guildemblem)
		{

			this.GuildEmblem = _guildemblem;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.GuildEmblem.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.GuildEmblem = new GuildEmblem();
			this.GuildEmblem.Deserialize(reader);

		}


	}
}
