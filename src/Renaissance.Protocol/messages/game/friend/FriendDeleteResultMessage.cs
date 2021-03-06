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
	public class FriendDeleteResultMessage : IDofusMessage
	{
		public  const int NetworkId = 5601;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Success { get; set; }

		public string Name { get; set; }


		public FriendDeleteResultMessage() { }


		public FriendDeleteResultMessage InitFriendDeleteResultMessage(bool _success, string _name)
		{

			this.Success = _success;
			this.Name = _name;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Success);
			size += DofusBinaryFactory.Sizing.SizeOf(Name);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Success);
			writer.WriteData(this.Name);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Success = reader.Read<bool>();
			this.Name = reader.Read<string>();

		}


	}
}
