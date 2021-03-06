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
using    Renaissance.Protocol.types.game.context.fight;
using    Renaissance.Protocol.types.game.context.roleplay.party;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightEndMessage : IDofusMessage
	{
		public  const int NetworkId = 720;
		public  int ProtocolId { get { return NetworkId; } }

		public int Duration { get; set; }

		public CustomVar<short> RewardRate { get; set; }

		public short LootShareLimitMalus { get; set; }

		public FightResultListEntry[] Results { get; set; }

		public NamedPartyTeamWithOutcome[] NamedPartyTeamsOutcomes { get; set; }


		public GameFightEndMessage() { }


		public GameFightEndMessage InitGameFightEndMessage(int _duration, CustomVar<short> _rewardrate, short _lootsharelimitmalus, FightResultListEntry[] _results, NamedPartyTeamWithOutcome[] _namedpartyteamsoutcomes)
		{

			this.Duration = _duration;
			this.RewardRate = _rewardrate;
			this.LootShareLimitMalus = _lootsharelimitmalus;
			this.Results = _results;
			this.NamedPartyTeamsOutcomes = _namedpartyteamsoutcomes;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Duration);
			size += DofusBinaryFactory.Sizing.SizeOf(RewardRate);
			size += DofusBinaryFactory.Sizing.SizeOf(LootShareLimitMalus);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Results.Length));
			var memory1 = new Memory<byte>[Results.Length];
			for(int i = 0; i < Results.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Results[i].ProtocolId));
				memory1[i] = this.Results[i].Serialize();
				size += memory1[i].Length;
			}
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.NamedPartyTeamsOutcomes.Length));
			var memory2 = new Memory<byte>[NamedPartyTeamsOutcomes.Length];
			for(int i = 0; i < NamedPartyTeamsOutcomes.Length; i++)
			{
				memory2[i] = this.NamedPartyTeamsOutcomes[i].Serialize();
				size += memory2[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Duration);
			writer.WriteData(this.RewardRate);
			writer.WriteData(this.LootShareLimitMalus);
			writer.WriteData((short)(this.Results.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteData((short)(Results[i].ProtocolId));
				writer.WriteDatas(memory1[i]);
			}
			writer.WriteData((short)(this.NamedPartyTeamsOutcomes.Length));
			for(int i = 0; i < memory2.Length; i++)
			{
				writer.WriteDatas(memory2[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Duration = reader.Read<int>();
			this.RewardRate = reader.Read<CustomVar<short>>();
			this.LootShareLimitMalus = reader.Read<short>();
			int Results_length = reader.Read<short>();
			this.Results = new FightResultListEntry[Results_length];
			for(int i = 0; i < Results_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.Results[i] = new FightResultListEntry();
				this.Results[i].Deserialize(reader);
			}
			int NamedPartyTeamsOutcomes_length = reader.Read<short>();
			this.NamedPartyTeamsOutcomes = new NamedPartyTeamWithOutcome[NamedPartyTeamsOutcomes_length];
			for(int i = 0; i < NamedPartyTeamsOutcomes_length; i++)
			{
				this.NamedPartyTeamsOutcomes[i] = new NamedPartyTeamWithOutcome();
				this.NamedPartyTeamsOutcomes[i].Deserialize(reader);
			}

		}


	}
}
