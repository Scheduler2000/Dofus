//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:47.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.web.haapi
{
	public class HaapiConfirmationMessage : IDofusMessage
	{
		public  const int NetworkId = 6848;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Kamas { get; set; }

		public CustomVar<long> Amount { get; set; }

		public CustomVar<short> Rate { get; set; }

		public byte Action { get; set; }

		public string Transaction { get; set; }


		public HaapiConfirmationMessage() { }


		public HaapiConfirmationMessage InitHaapiConfirmationMessage(CustomVar<long> _kamas, CustomVar<long> _amount, CustomVar<short> _rate, byte _action, string _transaction)
		{

			this.Kamas = _kamas;
			this.Amount = _amount;
			this.Rate = _rate;
			this.Action = _action;
			this.Transaction = _transaction;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Kamas);
			size += DofusBinaryFactory.Sizing.SizeOf(Amount);
			size += DofusBinaryFactory.Sizing.SizeOf(Rate);
			size += DofusBinaryFactory.Sizing.SizeOf(Action);
			size += DofusBinaryFactory.Sizing.SizeOf(Transaction);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Kamas);
			writer.WriteData(this.Amount);
			writer.WriteData(this.Rate);
			writer.WriteData(this.Action);
			writer.WriteData(this.Transaction);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Kamas = reader.Read<CustomVar<long>>();
			this.Amount = reader.Read<CustomVar<long>>();
			this.Rate = reader.Read<CustomVar<short>>();
			this.Action = reader.Read<byte>();
			this.Transaction = reader.Read<string>();

		}


	}
}
