//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:59.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightCommonInformations : IDofusType
	{
		public  const int NetworkId = 43;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> FightId { get; set; }

		public byte FightType { get; set; }

		public FightTeamInformations[] FightTeams { get; set; }

		public CustomVar<short>[] FightTeamsPositions { get; set; }

		public FightOptionsInformations[] FightTeamsOptions { get; set; }


		public FightCommonInformations() { }


		public FightCommonInformations InitFightCommonInformations(CustomVar<short> _fightid, byte _fighttype, FightTeamInformations[] _fightteams, CustomVar<short>[] _fightteamspositions, FightOptionsInformations[] _fightteamsoptions)
		{

			this.FightId = _fightid;
			this.FightType = _fighttype;
			this.FightTeams = _fightteams;
			this.FightTeamsPositions = _fightteamspositions;
			this.FightTeamsOptions = _fightteamsoptions;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(FightId);
			size += DofusBinaryFactory.Sizing.SizeOf(FightType);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.FightTeams.Length));
			var memory1 = new Memory<byte>[FightTeams.Length];
			for(int i = 0; i < FightTeams.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.FightTeams[i].ProtocolId));
				memory1[i] = this.FightTeams[i].Serialize();
				size += memory1[i].Length;
			}
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.FightTeamsPositions.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(FightTeamsPositions);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.FightTeamsOptions.Length));
			var memory2 = new Memory<byte>[FightTeamsOptions.Length];
			for(int i = 0; i < FightTeamsOptions.Length; i++)
			{
				memory2[i] = this.FightTeamsOptions[i].Serialize();
				size += memory2[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.FightId);
			writer.WriteData(this.FightType);
			writer.WriteData((short)(this.FightTeams.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteData((short)(FightTeams[i].ProtocolId));
				writer.WriteDatas(memory1[i]);
			}
			writer.WriteData((short)(this.FightTeamsPositions.Length));
			writer.WriteDatas(FightTeamsPositions);
			writer.WriteData((short)(this.FightTeamsOptions.Length));
			for(int i = 0; i < memory2.Length; i++)
			{
				writer.WriteDatas(memory2[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FightId = reader.Read<CustomVar<short>>();
			this.FightType = reader.Read<byte>();
			int FightTeams_length = reader.Read<short>();
			this.FightTeams = new FightTeamInformations[FightTeams_length];
			for(int i = 0; i < FightTeams_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.FightTeams[i] = new FightTeamInformations();
				this.FightTeams[i].Deserialize(reader);
			}
			int FightTeamsPositions_length = reader.Read<short>();
			this.FightTeamsPositions = new CustomVar<short>[FightTeamsPositions_length];
			for(int i = 0; i < FightTeamsPositions_length; i++)
				this.FightTeamsPositions[i] = reader.Read<CustomVar<short>>();
			int FightTeamsOptions_length = reader.Read<short>();
			this.FightTeamsOptions = new FightOptionsInformations[FightTeamsOptions_length];
			for(int i = 0; i < FightTeamsOptions_length; i++)
			{
				this.FightTeamsOptions[i] = new FightOptionsInformations();
				this.FightTeamsOptions[i].Deserialize(reader);
			}

		}


	}
}
