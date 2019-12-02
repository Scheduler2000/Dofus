//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:12.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildInvitationStateRecrutedMessage : IDofusMessage
	{
		public  const int NetworkId = 5548;
		public  int ProtocolId { get { return NetworkId; } }

		public byte InvitationState { get; set; }


		public GuildInvitationStateRecrutedMessage() { }


		public GuildInvitationStateRecrutedMessage InitGuildInvitationStateRecrutedMessage(byte _invitationstate)
		{

			this.InvitationState = _invitationstate;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.InvitationState);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.InvitationState = reader.Read<byte>();

		}


	}
}