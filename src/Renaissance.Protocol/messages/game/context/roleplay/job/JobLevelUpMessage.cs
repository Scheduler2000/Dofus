//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:24.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay.job;

namespace Renaissance.Protocol.messages.game.context.roleplay.job
{
	public class JobLevelUpMessage : IDofusMessage
	{
		public  const int NetworkId = 5656;
		public  int ProtocolId { get { return NetworkId; } }

		public byte NewLevel { get; set; }

		public JobDescription JobsDescription { get; set; }


		public JobLevelUpMessage() { }


		public JobLevelUpMessage InitJobLevelUpMessage(byte _newlevel, JobDescription _jobsdescription)
		{

			this.NewLevel = _newlevel;
			this.JobsDescription = _jobsdescription;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.NewLevel);
			writer.Write(this.JobsDescription.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.NewLevel = reader.Read<byte>();
			this.JobsDescription = new JobDescription();
			this.JobsDescription.Deserialize(reader);

		}


	}
}