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
using    Renaissance.Protocol.types.game.context.fight;

namespace Renaissance.Protocol.messages.game.context.roleplay
{
	public class MapRunningFightListMessage : IDofusMessage
	{
		public  const int NetworkId = 5743;
		public  int ProtocolId { get { return NetworkId; } }

		public FightExternalInformations[] Fights { get; set; }


		public MapRunningFightListMessage() { }


		public MapRunningFightListMessage InitMapRunningFightListMessage(FightExternalInformations[] _fights)
		{

			this.Fights = _fights;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Fights.Length));
			var memory1 = new Memory<byte>[Fights.Length];
			for(int i = 0; i < Fights.Length; i++)
			{
				memory1[i] = this.Fights[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Fights.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Fights_length = reader.Read<short>();
			this.Fights = new FightExternalInformations[Fights_length];
			for(int i = 0; i < Fights_length; i++)
			{
				this.Fights[i] = new FightExternalInformations();
				this.Fights[i].Deserialize(reader);
			}

		}


	}
}
