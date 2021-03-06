//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:01.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.data.items
{
	public class ObjectItemGenericQuantity : Item, IDofusType
	{
		public new const int NetworkId = 483;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> ObjectGID { get; set; }

		public CustomVar<int> Quantity { get; set; }


		public ObjectItemGenericQuantity() { }


		public ObjectItemGenericQuantity InitObjectItemGenericQuantity(CustomVar<short> _objectgid, CustomVar<int> _quantity)
		{

			this.ObjectGID = _objectgid;
			this.Quantity = _quantity;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObjectGID);
			size += DofusBinaryFactory.Sizing.SizeOf(Quantity);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.ObjectGID);
			writer.WriteData(this.Quantity);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ObjectGID = reader.Read<CustomVar<short>>();
			this.Quantity = reader.Read<CustomVar<int>>();

		}


	}
}
