//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:21.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage, IDofusMessage
	{
		public new const int NetworkId = 6236;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> StorageMaxSlot { get; set; }


		public ExchangeStartedWithStorageMessage() { }


		public ExchangeStartedWithStorageMessage InitExchangeStartedWithStorageMessage(CustomVar<int> _storagemaxslot)
		{

			this.StorageMaxSlot = _storagemaxslot;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.StorageMaxSlot);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.StorageMaxSlot = reader.Read<CustomVar<int>>();

		}


	}
}
