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
using    Renaissance.Protocol.types.game.interactive.skill;

namespace Renaissance.Protocol.types.game.context.roleplay.job
{
	public class JobDescription : IDofusType
	{
		public  const int NetworkId = 101;
		public  int ProtocolId { get { return NetworkId; } }

		public byte JobId { get; set; }

		public SkillActionDescription[] Skills { get; set; }


		public JobDescription() { }


		public JobDescription InitJobDescription(byte _jobid, SkillActionDescription[] _skills)
		{

			this.JobId = _jobid;
			this.Skills = _skills;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(JobId);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Skills.Length));
			var memory1 = new Memory<byte>[Skills.Length];
			for(int i = 0; i < Skills.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Skills[i].ProtocolId));
				memory1[i] = this.Skills[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.JobId);
			writer.WriteData((short)(this.Skills.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteData((short)(Skills[i].ProtocolId));
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.JobId = reader.Read<byte>();
			int Skills_length = reader.Read<short>();
			this.Skills = new SkillActionDescription[Skills_length];
			for(int i = 0; i < Skills_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.Skills[i] = new SkillActionDescription();
				this.Skills[i].Deserialize(reader);
			}

		}


	}
}
