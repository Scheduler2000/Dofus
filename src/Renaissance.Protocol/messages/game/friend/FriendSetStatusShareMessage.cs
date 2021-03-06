//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:44.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.friend
{
	public class FriendSetStatusShareMessage : IDofusMessage
	{
		public  const int NetworkId = 6822;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Share { get; set; }


		public FriendSetStatusShareMessage() { }


		public FriendSetStatusShareMessage InitFriendSetStatusShareMessage(bool _share)
		{

			this.Share = _share;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Share);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Share);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Share = reader.Read<bool>();

		}


	}
}
