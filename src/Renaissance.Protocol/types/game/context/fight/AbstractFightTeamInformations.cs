//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class AbstractFightTeamInformations : IDofusType
	{
		public  const int NetworkId = 116;
		public  int ProtocolId { get { return NetworkId; } }

		public byte TeamId { get; set; }

		public double LeaderId { get; set; }

		public byte TeamSide { get; set; }

		public byte TeamTypeId { get; set; }

		public byte NbWaves { get; set; }


		public AbstractFightTeamInformations() { }


		public AbstractFightTeamInformations InitAbstractFightTeamInformations(byte _teamid, double _leaderid, byte _teamside, byte _teamtypeid, byte _nbwaves)
		{

			this.TeamId = _teamid;
			this.LeaderId = _leaderid;
			this.TeamSide = _teamside;
			this.TeamTypeId = _teamtypeid;
			this.NbWaves = _nbwaves;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.TeamId);
			writer.Write(this.LeaderId);
			writer.Write(this.TeamSide);
			writer.Write(this.TeamTypeId);
			writer.Write(this.NbWaves);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.TeamId = reader.Read<byte>();
			this.LeaderId = reader.Read<double>();
			this.TeamSide = reader.Read<byte>();
			this.TeamTypeId = reader.Read<byte>();
			this.NbWaves = reader.Read<byte>();

		}


	}
}
