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
	public class FightResultExperienceData : FightResultAdditionalData, IDofusType
	{
		public new const int NetworkId = 192;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Experience { get; set; }

		public WrappedBool ShowExperience { get; set; }

		public CustomVar<long> ExperienceLevelFloor { get; set; }

		public WrappedBool ShowExperienceLevelFloor { get; set; }

		public CustomVar<long> ExperienceNextLevelFloor { get; set; }

		public WrappedBool ShowExperienceNextLevelFloor { get; set; }

		public CustomVar<long> ExperienceFightDelta { get; set; }

		public WrappedBool ShowExperienceFightDelta { get; set; }

		public CustomVar<long> ExperienceForGuild { get; set; }

		public WrappedBool ShowExperienceForGuild { get; set; }

		public CustomVar<long> ExperienceForMount { get; set; }

		public WrappedBool ShowExperienceForMount { get; set; }

		public WrappedBool IsIncarnationExperience { get; set; }

		public byte RerollExperienceMul { get; set; }


		public FightResultExperienceData() { }


		public FightResultExperienceData InitFightResultExperienceData(CustomVar<long> _experience, WrappedBool _showexperience, CustomVar<long> _experiencelevelfloor, WrappedBool _showexperiencelevelfloor, CustomVar<long> _experiencenextlevelfloor, WrappedBool _showexperiencenextlevelfloor, CustomVar<long> _experiencefightdelta, WrappedBool _showexperiencefightdelta, CustomVar<long> _experienceforguild, WrappedBool _showexperienceforguild, CustomVar<long> _experienceformount, WrappedBool _showexperienceformount, WrappedBool _isincarnationexperience, byte _rerollexperiencemul)
		{

			this.Experience = _experience;
			this.ShowExperience = _showexperience;
			this.ExperienceLevelFloor = _experiencelevelfloor;
			this.ShowExperienceLevelFloor = _showexperiencelevelfloor;
			this.ExperienceNextLevelFloor = _experiencenextlevelfloor;
			this.ShowExperienceNextLevelFloor = _showexperiencenextlevelfloor;
			this.ExperienceFightDelta = _experiencefightdelta;
			this.ShowExperienceFightDelta = _showexperiencefightdelta;
			this.ExperienceForGuild = _experienceforguild;
			this.ShowExperienceForGuild = _showexperienceforguild;
			this.ExperienceForMount = _experienceformount;
			this.ShowExperienceForMount = _showexperienceformount;
			this.IsIncarnationExperience = _isincarnationexperience;
			this.RerollExperienceMul = _rerollexperiencemul;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Experience);
			size++;
			size += DofusBinaryFactory.Sizing.SizeOf(ExperienceLevelFloor);
			size++;
			size += DofusBinaryFactory.Sizing.SizeOf(ExperienceNextLevelFloor);
			size++;
			size += DofusBinaryFactory.Sizing.SizeOf(ExperienceFightDelta);
			size++;
			size += DofusBinaryFactory.Sizing.SizeOf(ExperienceForGuild);
			size++;
			size += DofusBinaryFactory.Sizing.SizeOf(ExperienceForMount);
			size++;
			size++;
			size += DofusBinaryFactory.Sizing.SizeOf(RerollExperienceMul);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			byte box = 0;
			box = writer.SetFlag(box,0,this.ShowExperience);
			box = writer.SetFlag(box,1,this.ShowExperienceLevelFloor);
			box = writer.SetFlag(box,2,this.ShowExperienceNextLevelFloor);
			box = writer.SetFlag(box,3,this.ShowExperienceFightDelta);
			box = writer.SetFlag(box,4,this.ShowExperienceForGuild);
			box = writer.SetFlag(box,5,this.ShowExperienceForMount);
			box = writer.SetFlag(box,6,this.IsIncarnationExperience);
			writer.WriteData(box);
			writer.WriteData(this.Experience);
			writer.WriteData(this.ExperienceLevelFloor);
			writer.WriteData(this.ExperienceNextLevelFloor);
			writer.WriteData(this.ExperienceFightDelta);
			writer.WriteData(this.ExperienceForGuild);
			writer.WriteData(this.ExperienceForMount);
			writer.WriteData(this.RerollExperienceMul);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			byte box = reader.Read<byte>();
			this.ShowExperience = reader.ReadFlag(box,0);
			this.ShowExperienceLevelFloor = reader.ReadFlag(box,1);
			this.ShowExperienceNextLevelFloor = reader.ReadFlag(box,2);
			this.ShowExperienceFightDelta = reader.ReadFlag(box,3);
			this.ShowExperienceForGuild = reader.ReadFlag(box,4);
			this.ShowExperienceForMount = reader.ReadFlag(box,5);
			this.IsIncarnationExperience = reader.ReadFlag(box,6);
			this.Experience = reader.Read<CustomVar<long>>();
			this.ExperienceLevelFloor = reader.Read<CustomVar<long>>();
			this.ExperienceNextLevelFloor = reader.Read<CustomVar<long>>();
			this.ExperienceFightDelta = reader.Read<CustomVar<long>>();
			this.ExperienceForGuild = reader.Read<CustomVar<long>>();
			this.ExperienceForMount = reader.Read<CustomVar<long>>();
			this.RerollExperienceMul = reader.Read<byte>();

		}


	}
}
