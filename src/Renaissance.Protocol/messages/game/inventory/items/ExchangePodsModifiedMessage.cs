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
	public class ExchangePodsModifiedMessage : ExchangeObjectMessage, IDofusMessage
	{
		public new const int NetworkId = 6670;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> CurrentWeight { get; set; }

		public CustomVar<int> MaxWeight { get; set; }


		public ExchangePodsModifiedMessage() { }


		public ExchangePodsModifiedMessage InitExchangePodsModifiedMessage(bool _remote, CustomVar<int> _currentweight, CustomVar<int> _maxweight)
		{

			base.Remote = _remote;
			this.CurrentWeight = _currentweight;
			this.MaxWeight = _maxweight;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(CurrentWeight);
			size += DofusBinaryFactory.Sizing.SizeOf(MaxWeight);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.CurrentWeight);
			writer.WriteData(this.MaxWeight);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.CurrentWeight = reader.Read<CustomVar<int>>();
			this.MaxWeight = reader.Read<CustomVar<int>>();

		}


	}
}
