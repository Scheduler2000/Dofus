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
	public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage, IDofusMessage
	{
		public new const int NetworkId = 6532;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int>[] ObjectUID { get; set; }


		public ExchangeObjectsRemovedMessage() { }


		public ExchangeObjectsRemovedMessage InitExchangeObjectsRemovedMessage(bool _remote, CustomVar<int>[] _objectuid)
		{

			base.Remote = _remote;
			this.ObjectUID = _objectuid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.ObjectUID.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(ObjectUID);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(this.ObjectUID.Length));
			writer.WriteDatas(ObjectUID);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int ObjectUID_length = reader.Read<short>();
			this.ObjectUID = new CustomVar<int>[ObjectUID_length];
			for(int i = 0; i < ObjectUID_length; i++)
				this.ObjectUID[i] = reader.Read<CustomVar<int>>();

		}


	}
}
