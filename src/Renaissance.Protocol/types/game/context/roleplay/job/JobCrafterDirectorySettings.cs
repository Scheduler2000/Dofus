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
	public class JobCrafterDirectorySettings : IDofusType
	{
		public  const int NetworkId = 97;
		public  int ProtocolId { get { return NetworkId; } }

		public byte JobId { get; set; }

		public byte MinLevel { get; set; }

		public bool Free { get; set; }


		public JobCrafterDirectorySettings() { }


		public JobCrafterDirectorySettings InitJobCrafterDirectorySettings(byte _jobid, byte _minlevel, bool _free)
		{

			this.JobId = _jobid;
			this.MinLevel = _minlevel;
			this.Free = _free;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(JobId);
			size += DofusBinaryFactory.Sizing.SizeOf(MinLevel);
			size += DofusBinaryFactory.Sizing.SizeOf(Free);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.JobId);
			writer.WriteData(this.MinLevel);
			writer.WriteData(this.Free);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.JobId = reader.Read<byte>();
			this.MinLevel = reader.Read<byte>();
			this.Free = reader.Read<bool>();

		}


	}
}
