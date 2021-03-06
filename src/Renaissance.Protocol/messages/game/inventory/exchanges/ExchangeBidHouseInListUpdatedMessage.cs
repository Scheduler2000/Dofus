//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:51.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.data.items.effects;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage, IDofusMessage
	{
		public new const int NetworkId = 6337;
		public new int ProtocolId { get { return NetworkId; } }


		public ExchangeBidHouseInListUpdatedMessage() { }


		public ExchangeBidHouseInListUpdatedMessage InitExchangeBidHouseInListUpdatedMessage(int _itemuid, CustomVar<short> _objectgid, int _objecttype, ObjectEffect[] _effects, CustomVar<long>[] _prices)
		{

			base.ItemUID = _itemuid;
			base.ObjectGID = _objectgid;
			base.ObjectType = _objecttype;
			base.Effects = _effects;
			base.Prices = _prices;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);

		}


	}
}
