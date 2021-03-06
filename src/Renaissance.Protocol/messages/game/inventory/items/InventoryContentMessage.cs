//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class InventoryContentMessage : IDofusMessage
	{
		public  const int NetworkId = 3016;
		public  int ProtocolId { get { return NetworkId; } }

		public ObjectItem[] Objects { get; set; }

		public CustomVar<long> Kamas { get; set; }


		public InventoryContentMessage() { }


		public InventoryContentMessage InitInventoryContentMessage(ObjectItem[] _objects, CustomVar<long> _kamas)
		{

			this.Objects = _objects;
			this.Kamas = _kamas;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Objects.Length));
			var memory1 = new Memory<byte>[Objects.Length];
			for(int i = 0; i < Objects.Length; i++)
			{
				memory1[i] = this.Objects[i].Serialize();
				size += memory1[i].Length;
			}
			size += DofusBinaryFactory.Sizing.SizeOf(Kamas);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Objects.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}
			writer.WriteData(this.Kamas);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Objects_length = reader.Read<short>();
			this.Objects = new ObjectItem[Objects_length];
			for(int i = 0; i < Objects_length; i++)
			{
				this.Objects[i] = new ObjectItem();
				this.Objects[i].Deserialize(reader);
			}
			this.Kamas = reader.Read<CustomVar<long>>();

		}


	}
}
