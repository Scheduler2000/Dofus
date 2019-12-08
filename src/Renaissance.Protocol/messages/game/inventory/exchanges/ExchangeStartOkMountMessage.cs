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
using    Renaissance.Protocol.types.game.mount;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage, IDofusMessage
	{
		public new const int NetworkId = 5979;
		public new int ProtocolId { get { return NetworkId; } }

		public MountClientData[] PaddockedMountsDescription { get; set; }


		public ExchangeStartOkMountMessage() { }


		public ExchangeStartOkMountMessage InitExchangeStartOkMountMessage(MountClientData[] _paddockedmountsdescription)
		{

			this.PaddockedMountsDescription = _paddockedmountsdescription;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.PaddockedMountsDescription.Length));
			var memory1 = new Memory<byte>[PaddockedMountsDescription.Length];
			for(int i = 0; i < PaddockedMountsDescription.Length; i++)
			{
				memory1[i] = this.PaddockedMountsDescription[i].Serialize();
				size += memory1[i].Length;
			}
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(this.PaddockedMountsDescription.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int PaddockedMountsDescription_length = reader.Read<short>();
			this.PaddockedMountsDescription = new MountClientData[PaddockedMountsDescription_length];
			for(int i = 0; i < PaddockedMountsDescription_length; i++)
			{
				this.PaddockedMountsDescription[i] = new MountClientData();
				this.PaddockedMountsDescription[i].Deserialize(reader);
			}

		}


	}
}
