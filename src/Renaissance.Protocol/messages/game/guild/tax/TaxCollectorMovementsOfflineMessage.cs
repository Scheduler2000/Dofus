//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:50.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.guild.tax;

namespace Renaissance.Protocol.messages.game.guild.tax
{
	public class TaxCollectorMovementsOfflineMessage : IDofusMessage
	{
		public  const int NetworkId = 6611;
		public  int ProtocolId { get { return NetworkId; } }

		public TaxCollectorMovement[] Movements { get; set; }


		public TaxCollectorMovementsOfflineMessage() { }


		public TaxCollectorMovementsOfflineMessage InitTaxCollectorMovementsOfflineMessage(TaxCollectorMovement[] _movements)
		{

			this.Movements = _movements;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Movements.Length));
			var memory1 = new Memory<byte>[Movements.Length];
			for(int i = 0; i < Movements.Length; i++)
			{
				memory1[i] = this.Movements[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Movements.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Movements_length = reader.Read<short>();
			this.Movements = new TaxCollectorMovement[Movements_length];
			for(int i = 0; i < Movements_length; i++)
			{
				this.Movements[i] = new TaxCollectorMovement();
				this.Movements[i].Deserialize(reader);
			}

		}


	}
}
