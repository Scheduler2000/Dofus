//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:00.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class GameContextSummonsInformation : IDofusType
	{
		public  const int NetworkId = 567;
		public  int ProtocolId { get { return NetworkId; } }

		public SpawnInformation SpawnInformation { get; set; }

		public byte Wave { get; set; }

		public EntityLook Look { get; set; }

		public GameFightMinimalStats Stats { get; set; }

		public GameContextBasicSpawnInformation[] Summons { get; set; }


		public GameContextSummonsInformation() { }


		public GameContextSummonsInformation InitGameContextSummonsInformation(SpawnInformation _spawninformation, byte _wave, EntityLook _look, GameFightMinimalStats _stats, GameContextBasicSpawnInformation[] _summons)
		{

			this.SpawnInformation = _spawninformation;
			this.Wave = _wave;
			this.Look = _look;
			this.Stats = _stats;
			this.Summons = _summons;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += 2;
			var serialized1 = this.SpawnInformation.Serialize();
			size += serialized1.Length;
			size += DofusBinaryFactory.Sizing.SizeOf(Wave);
			var serialized2 = this.Look.Serialize();
			size += serialized2.Length;
			size += 2;
			var serialized3 = this.Stats.Serialize();
			size += serialized3.Length;
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Summons.Length));
			var memory1 = new Memory<byte>[Summons.Length];
			for(int i = 0; i < Summons.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Summons[i].ProtocolId));
				memory1[i] = this.Summons[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(SpawnInformation.ProtocolId));
			writer.WriteDatas(serialized1);
			writer.WriteData(this.Wave);
			writer.WriteDatas(serialized2);
			writer.WriteData((short)(Stats.ProtocolId));
			writer.WriteDatas(serialized3);
			writer.WriteData((short)(this.Summons.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteData((short)(Summons[i].ProtocolId));
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			reader.Skip(2); // skip protocolManager.GetInstance(short)
			this.SpawnInformation = new SpawnInformation();
			this.SpawnInformation.Deserialize(reader);
			this.Wave = reader.Read<byte>();
			this.Look = new EntityLook();
			this.Look.Deserialize(reader);
			reader.Skip(2); // skip protocolManager.GetInstance(short)
			this.Stats = new GameFightMinimalStats();
			this.Stats.Deserialize(reader);
			int Summons_length = reader.Read<short>();
			this.Summons = new GameContextBasicSpawnInformation[Summons_length];
			for(int i = 0; i < Summons_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.Summons[i] = new GameContextBasicSpawnInformation();
				this.Summons[i].Deserialize(reader);
			}

		}


	}
}
