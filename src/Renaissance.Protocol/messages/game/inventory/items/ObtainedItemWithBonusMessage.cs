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

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class ObtainedItemWithBonusMessage : ObtainedItemMessage, IDofusMessage
	{
		public new const int NetworkId = 6520;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> BonusQuantity { get; set; }


		public ObtainedItemWithBonusMessage() { }


		public ObtainedItemWithBonusMessage InitObtainedItemWithBonusMessage(CustomVar<int> _bonusquantity)
		{

			this.BonusQuantity = _bonusquantity;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.BonusQuantity);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.BonusQuantity = reader.Read<CustomVar<int>>();

		}


	}
}