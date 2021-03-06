//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:02.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay.party
{
	public class NamedPartyTeam : IDofusType
	{
		public  const int NetworkId = 469;
		public  int ProtocolId { get { return NetworkId; } }

		public byte TeamId { get; set; }

		public string PartyName { get; set; }


		public NamedPartyTeam() { }


		public NamedPartyTeam InitNamedPartyTeam(byte _teamid, string _partyname)
		{

			this.TeamId = _teamid;
			this.PartyName = _partyname;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(TeamId);
			size += DofusBinaryFactory.Sizing.SizeOf(PartyName);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.TeamId);
			writer.WriteData(this.PartyName);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.TeamId = reader.Read<byte>();
			this.PartyName = reader.Read<string>();

		}


	}
}
