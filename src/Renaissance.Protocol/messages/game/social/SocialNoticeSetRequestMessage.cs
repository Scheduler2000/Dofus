//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.social
{
	public class SocialNoticeSetRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6686;
		public  int ProtocolId { get { return NetworkId; } }


		public SocialNoticeSetRequestMessage() { }


		public SocialNoticeSetRequestMessage InitSocialNoticeSetRequestMessage()
		{


			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;



			using DofusWriter writer = new DofusWriter(size);


			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{


		}


	}
}
