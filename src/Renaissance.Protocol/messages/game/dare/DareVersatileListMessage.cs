//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:44.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.dare;

namespace Renaissance.Protocol.messages.game.dare
{
	public class DareVersatileListMessage : IDofusMessage
	{
		public  const int NetworkId = 6657;
		public  int ProtocolId { get { return NetworkId; } }

		public DareVersatileInformations[] Dares { get; set; }


		public DareVersatileListMessage() { }


		public DareVersatileListMessage InitDareVersatileListMessage(DareVersatileInformations[] _dares)
		{

			this.Dares = _dares;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Dares.Length));
			var memory1 = new Memory<byte>[Dares.Length];
			for(int i = 0; i < Dares.Length; i++)
			{
				memory1[i] = this.Dares[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Dares.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Dares_length = reader.Read<short>();
			this.Dares = new DareVersatileInformations[Dares_length];
			for(int i = 0; i < Dares_length; i++)
			{
				this.Dares[i] = new DareVersatileInformations();
				this.Dares[i].Deserialize(reader);
			}

		}


	}
}
