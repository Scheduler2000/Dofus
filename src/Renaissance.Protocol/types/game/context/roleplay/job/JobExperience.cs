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

namespace Renaissance.Protocol.types.game.context.roleplay.job
{
	public class JobExperience : IDofusType
	{
		public  const int NetworkId = 98;
		public  int ProtocolId { get { return NetworkId; } }

		public byte JobId { get; set; }

		public byte JobLevel { get; set; }

		public CustomVar<long> JobXP { get; set; }

		public CustomVar<long> JobXpLevelFloor { get; set; }

		public CustomVar<long> JobXpNextLevelFloor { get; set; }


		public JobExperience() { }


		public JobExperience InitJobExperience(byte _jobid, byte _joblevel, CustomVar<long> _jobxp, CustomVar<long> _jobxplevelfloor, CustomVar<long> _jobxpnextlevelfloor)
		{

			this.JobId = _jobid;
			this.JobLevel = _joblevel;
			this.JobXP = _jobxp;
			this.JobXpLevelFloor = _jobxplevelfloor;
			this.JobXpNextLevelFloor = _jobxpnextlevelfloor;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(JobId);
			size += DofusBinaryFactory.Sizing.SizeOf(JobLevel);
			size += DofusBinaryFactory.Sizing.SizeOf(JobXP);
			size += DofusBinaryFactory.Sizing.SizeOf(JobXpLevelFloor);
			size += DofusBinaryFactory.Sizing.SizeOf(JobXpNextLevelFloor);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.JobId);
			writer.WriteData(this.JobLevel);
			writer.WriteData(this.JobXP);
			writer.WriteData(this.JobXpLevelFloor);
			writer.WriteData(this.JobXpNextLevelFloor);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.JobId = reader.Read<byte>();
			this.JobLevel = reader.Read<byte>();
			this.JobXP = reader.Read<CustomVar<long>>();
			this.JobXpLevelFloor = reader.Read<CustomVar<long>>();
			this.JobXpNextLevelFloor = reader.Read<CustomVar<long>>();

		}


	}
}
