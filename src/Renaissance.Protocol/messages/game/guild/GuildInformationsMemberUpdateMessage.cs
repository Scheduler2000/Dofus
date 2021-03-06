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
	public class GuildInformationsMemberUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 5597;
		public  int ProtocolId { get { return NetworkId; } }

		public GuildMember Member { get; set; }


		public GuildInformationsMemberUpdateMessage() { }


		public GuildInformationsMemberUpdateMessage InitGuildInformationsMemberUpdateMessage(GuildMember _member)
		{

			this.Member = _member;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Member.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Member = new GuildMember();
			this.Member.Deserialize(reader);

		}


	}
}
