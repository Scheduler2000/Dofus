//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:48.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.chat.community
{
	public class ChatCommunityChannelSetCommunityRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6729;
		public  int ProtocolId { get { return NetworkId; } }

		public short CommunityId { get; set; }


		public ChatCommunityChannelSetCommunityRequestMessage() { }


		public ChatCommunityChannelSetCommunityRequestMessage InitChatCommunityChannelSetCommunityRequestMessage(short _communityid)
		{

			this.CommunityId = _communityid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(CommunityId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.CommunityId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.CommunityId = reader.Read<short>();

		}


	}
}
