//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:24.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.havenbag
{
	public class HavenBagPackListMessage : IDofusMessage
	{
		public  const int NetworkId = 6620;
		public  int ProtocolId { get { return NetworkId; } }

		public byte[] PackIds { get; set; }


		public HavenBagPackListMessage() { }


		public HavenBagPackListMessage InitHavenBagPackListMessage(byte[] _packids)
		{

			this.PackIds = _packids;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.PackIds.Length));
			foreach(var item in PackIds)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int PackIds_length = reader.Read<short>();
			this.PackIds = new byte[PackIds_length];
			for(int i = 0; i < PackIds_length; i++)
				this.PackIds[i] = reader.Read<byte>();

		}


	}
}