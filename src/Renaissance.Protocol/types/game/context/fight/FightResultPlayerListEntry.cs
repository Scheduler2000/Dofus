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

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightResultPlayerListEntry : FightResultFighterListEntry, IDofusType
	{
		public new const int NetworkId = 24;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Level { get; set; }

		public FightResultAdditionalData[] Additional { get; set; }


		public FightResultPlayerListEntry() { }


		public FightResultPlayerListEntry InitFightResultPlayerListEntry(double _id, bool _alive, CustomVar<short> _outcome, byte _wave, FightLoot _rewards, CustomVar<short> _level, FightResultAdditionalData[] _additional)
		{

			base.Id = _id;
			base.Alive = _alive;
			base.Outcome = _outcome;
			base.Wave = _wave;
			base.Rewards = _rewards;
			this.Level = _level;
			this.Additional = _additional;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Level);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Additional.Length));
			var memory1 = new Memory<byte>[Additional.Length];
			for(int i = 0; i < Additional.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Additional[i].ProtocolId));
				memory1[i] = this.Additional[i].Serialize();
				size += memory1[i].Length;
			}
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.Level);
			writer.WriteData((short)(this.Additional.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteData((short)(Additional[i].ProtocolId));
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Level = reader.Read<CustomVar<short>>();
			int Additional_length = reader.Read<short>();
			this.Additional = new FightResultAdditionalData[Additional_length];
			for(int i = 0; i < Additional_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.Additional[i] = new FightResultAdditionalData();
				this.Additional[i].Deserialize(reader);
			}

		}


	}
}
