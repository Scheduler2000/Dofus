//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class GoldAddedMessage : IDofusMessage
	{
		public  const int NetworkId = 6030;
		public  int ProtocolId { get { return NetworkId; } }

		public GoldItem Gold { get; set; }


		public GoldAddedMessage() { }


		public GoldAddedMessage InitGoldAddedMessage(GoldItem _gold)
		{

			this.Gold = _gold;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Gold.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Gold = new GoldItem();
			this.Gold.Deserialize(reader);

		}


	}
}