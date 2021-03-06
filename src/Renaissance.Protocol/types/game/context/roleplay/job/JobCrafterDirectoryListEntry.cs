//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:01.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay.job
{
	public class JobCrafterDirectoryListEntry : IDofusType
	{
		public  const int NetworkId = 196;
		public  int ProtocolId { get { return NetworkId; } }

		public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }

		public JobCrafterDirectoryEntryJobInfo JobInfo { get; set; }


		public JobCrafterDirectoryListEntry() { }


		public JobCrafterDirectoryListEntry InitJobCrafterDirectoryListEntry(JobCrafterDirectoryEntryPlayerInfo _playerinfo, JobCrafterDirectoryEntryJobInfo _jobinfo)
		{

			this.PlayerInfo = _playerinfo;
			this.JobInfo = _jobinfo;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.PlayerInfo.Serialize();
			size += serialized1.Length;
			var serialized2 = this.JobInfo.Serialize();
			size += serialized2.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);
			writer.WriteDatas(serialized2);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
			this.PlayerInfo.Deserialize(reader);
			this.JobInfo = new JobCrafterDirectoryEntryJobInfo();
			this.JobInfo.Deserialize(reader);

		}


	}
}
