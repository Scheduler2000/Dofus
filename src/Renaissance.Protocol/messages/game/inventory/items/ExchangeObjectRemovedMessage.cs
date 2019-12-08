//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:52.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.inventory.exchanges;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class ExchangeObjectRemovedMessage : ExchangeObjectMessage, IDofusMessage
	{
		public new const int NetworkId = 5517;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ObjectUID { get; set; }


		public ExchangeObjectRemovedMessage() { }


		public ExchangeObjectRemovedMessage InitExchangeObjectRemovedMessage(bool _remote, CustomVar<int> _objectuid)
		{

			base.Remote = _remote;
			this.ObjectUID = _objectuid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObjectUID);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.ObjectUID);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ObjectUID = reader.Read<CustomVar<int>>();

		}


	}
}
