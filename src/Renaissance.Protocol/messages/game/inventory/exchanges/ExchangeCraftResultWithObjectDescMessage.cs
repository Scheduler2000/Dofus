//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:20.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage, IDofusMessage
	{
		public new const int NetworkId = 5999;
		public new int ProtocolId { get { return NetworkId; } }

		public ObjectItemNotInContainer ObjectInfo { get; set; }


		public ExchangeCraftResultWithObjectDescMessage() { }


		public ExchangeCraftResultWithObjectDescMessage InitExchangeCraftResultWithObjectDescMessage(ObjectItemNotInContainer _objectinfo)
		{

			this.ObjectInfo = _objectinfo;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.ObjectInfo.Serialize());

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ObjectInfo = new ObjectItemNotInContainer();
			this.ObjectInfo.Deserialize(reader);

		}


	}
}
