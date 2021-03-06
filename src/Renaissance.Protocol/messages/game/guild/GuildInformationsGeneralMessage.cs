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

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildInformationsGeneralMessage : IDofusMessage
	{
		public  const int NetworkId = 5557;
		public  int ProtocolId { get { return NetworkId; } }

		public bool AbandonnedPaddock { get; set; }

		public byte Level { get; set; }

		public CustomVar<long> ExpLevelFloor { get; set; }

		public CustomVar<long> Experience { get; set; }

		public CustomVar<long> ExpNextLevelFloor { get; set; }

		public int CreationDate { get; set; }

		public CustomVar<short> NbTotalMembers { get; set; }

		public CustomVar<short> NbConnectedMembers { get; set; }


		public GuildInformationsGeneralMessage() { }


		public GuildInformationsGeneralMessage InitGuildInformationsGeneralMessage(bool _abandonnedpaddock, byte _level, CustomVar<long> _explevelfloor, CustomVar<long> _experience, CustomVar<long> _expnextlevelfloor, int _creationdate, CustomVar<short> _nbtotalmembers, CustomVar<short> _nbconnectedmembers)
		{

			this.AbandonnedPaddock = _abandonnedpaddock;
			this.Level = _level;
			this.ExpLevelFloor = _explevelfloor;
			this.Experience = _experience;
			this.ExpNextLevelFloor = _expnextlevelfloor;
			this.CreationDate = _creationdate;
			this.NbTotalMembers = _nbtotalmembers;
			this.NbConnectedMembers = _nbconnectedmembers;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(AbandonnedPaddock);
			size += DofusBinaryFactory.Sizing.SizeOf(Level);
			size += DofusBinaryFactory.Sizing.SizeOf(ExpLevelFloor);
			size += DofusBinaryFactory.Sizing.SizeOf(Experience);
			size += DofusBinaryFactory.Sizing.SizeOf(ExpNextLevelFloor);
			size += DofusBinaryFactory.Sizing.SizeOf(CreationDate);
			size += DofusBinaryFactory.Sizing.SizeOf(NbTotalMembers);
			size += DofusBinaryFactory.Sizing.SizeOf(NbConnectedMembers);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.AbandonnedPaddock);
			writer.WriteData(this.Level);
			writer.WriteData(this.ExpLevelFloor);
			writer.WriteData(this.Experience);
			writer.WriteData(this.ExpNextLevelFloor);
			writer.WriteData(this.CreationDate);
			writer.WriteData(this.NbTotalMembers);
			writer.WriteData(this.NbConnectedMembers);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.AbandonnedPaddock = reader.Read<bool>();
			this.Level = reader.Read<byte>();
			this.ExpLevelFloor = reader.Read<CustomVar<long>>();
			this.Experience = reader.Read<CustomVar<long>>();
			this.ExpNextLevelFloor = reader.Read<CustomVar<long>>();
			this.CreationDate = reader.Read<int>();
			this.NbTotalMembers = reader.Read<CustomVar<short>>();
			this.NbConnectedMembers = reader.Read<CustomVar<short>>();

		}


	}
}
