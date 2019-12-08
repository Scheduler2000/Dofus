//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:49.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.idol;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightStartMessage : IDofusMessage
	{
		public  const int NetworkId = 712;
		public  int ProtocolId { get { return NetworkId; } }

		public Idol[] Idols { get; set; }


		public GameFightStartMessage() { }


		public GameFightStartMessage InitGameFightStartMessage(Idol[] _idols)
		{

			this.Idols = _idols;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Idols.Length));
			var memory1 = new Memory<byte>[Idols.Length];
			for(int i = 0; i < Idols.Length; i++)
			{
				memory1[i] = this.Idols[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Idols.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Idols_length = reader.Read<short>();
			this.Idols = new Idol[Idols_length];
			for(int i = 0; i < Idols_length; i++)
			{
				this.Idols[i] = new Idol();
				this.Idols[i].Deserialize(reader);
			}

		}


	}
}
