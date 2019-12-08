//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:45.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.idol;

namespace Renaissance.Protocol.messages.game.idol
{
	public class IdolFightPreparationUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6586;
		public  int ProtocolId { get { return NetworkId; } }

		public byte IdolSource { get; set; }

		public Idol[] Idols { get; set; }


		public IdolFightPreparationUpdateMessage() { }


		public IdolFightPreparationUpdateMessage InitIdolFightPreparationUpdateMessage(byte _idolsource, Idol[] _idols)
		{

			this.IdolSource = _idolsource;
			this.Idols = _idols;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(IdolSource);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Idols.Length));
			var memory1 = new Memory<byte>[Idols.Length];
			for(int i = 0; i < Idols.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Idols[i].ProtocolId));
				memory1[i] = this.Idols[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.IdolSource);
			writer.WriteData((short)(this.Idols.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteData((short)(Idols[i].ProtocolId));
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.IdolSource = reader.Read<byte>();
			int Idols_length = reader.Read<short>();
			this.Idols = new Idol[Idols_length];
			for(int i = 0; i < Idols_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.Idols[i] = new Idol();
				this.Idols[i].Deserialize(reader);
			}

		}


	}
}
