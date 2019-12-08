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
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class ExchangeObjectsModifiedMessage : ExchangeObjectMessage, IDofusMessage
	{
		public new const int NetworkId = 6533;
		public new int ProtocolId { get { return NetworkId; } }

		public ObjectItem[] Object { get; set; }


		public ExchangeObjectsModifiedMessage() { }


		public ExchangeObjectsModifiedMessage InitExchangeObjectsModifiedMessage(bool _remote, ObjectItem[] _object)
		{

			base.Remote = _remote;
			this.Object = _object;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Object.Length));
			var memory1 = new Memory<byte>[Object.Length];
			for(int i = 0; i < Object.Length; i++)
			{
				memory1[i] = this.Object[i].Serialize();
				size += memory1[i].Length;
			}
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(this.Object.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int Object_length = reader.Read<short>();
			this.Object = new ObjectItem[Object_length];
			for(int i = 0; i < Object_length; i++)
			{
				this.Object[i] = new ObjectItem();
				this.Object[i].Deserialize(reader);
			}

		}


	}
}
