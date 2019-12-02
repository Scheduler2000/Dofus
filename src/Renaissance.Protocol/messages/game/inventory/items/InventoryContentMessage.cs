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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Objects.Length));
			foreach(var obj in Objects)
			{
				writer.Write(obj.Serialize());
			}
			writer.Write(this.Kamas);

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