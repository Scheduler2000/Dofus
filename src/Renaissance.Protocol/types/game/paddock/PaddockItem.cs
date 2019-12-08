//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:58.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;
using    Renaissance.Protocol.types.game.mount;

namespace Renaissance.Protocol.types.game.paddock
{
	public class PaddockItem : ObjectItemInRolePlay, IDofusType
	{
		public new const int NetworkId = 185;
		public new int ProtocolId { get { return NetworkId; } }

		public ItemDurability Durability { get; set; }


		public PaddockItem() { }


		public PaddockItem InitPaddockItem(ItemDurability _durability)
		{

			this.Durability = _durability;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Durability.Serialize();
			size += serialized1.Length;
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Durability = new ItemDurability();
			this.Durability.Deserialize(reader);

		}


	}
}
