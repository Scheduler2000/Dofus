//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:57.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.achievement
{
	public class Achievement : IDofusType
	{
		public  const int NetworkId = 363;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Id { get; set; }

		public AchievementObjective[] FinishedObjective { get; set; }

		public AchievementStartedObjective[] StartedObjectives { get; set; }


		public Achievement() { }


		public Achievement InitAchievement(CustomVar<short> _id, AchievementObjective[] _finishedobjective, AchievementStartedObjective[] _startedobjectives)
		{

			this.Id = _id;
			this.FinishedObjective = _finishedobjective;
			this.StartedObjectives = _startedobjectives;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Id);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.FinishedObjective.Length));
			var memory1 = new Memory<byte>[FinishedObjective.Length];
			for(int i = 0; i < FinishedObjective.Length; i++)
			{
				memory1[i] = this.FinishedObjective[i].Serialize();
				size += memory1[i].Length;
			}
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.StartedObjectives.Length));
			var memory2 = new Memory<byte>[StartedObjectives.Length];
			for(int i = 0; i < StartedObjectives.Length; i++)
			{
				memory2[i] = this.StartedObjectives[i].Serialize();
				size += memory2[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Id);
			writer.WriteData((short)(this.FinishedObjective.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}
			writer.WriteData((short)(this.StartedObjectives.Length));
			for(int i = 0; i < memory2.Length; i++)
			{
				writer.WriteDatas(memory2[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<CustomVar<short>>();
			int FinishedObjective_length = reader.Read<short>();
			this.FinishedObjective = new AchievementObjective[FinishedObjective_length];
			for(int i = 0; i < FinishedObjective_length; i++)
			{
				this.FinishedObjective[i] = new AchievementObjective();
				this.FinishedObjective[i].Deserialize(reader);
			}
			int StartedObjectives_length = reader.Read<short>();
			this.StartedObjectives = new AchievementStartedObjective[StartedObjectives_length];
			for(int i = 0; i < StartedObjectives_length; i++)
			{
				this.StartedObjectives[i] = new AchievementStartedObjective();
				this.StartedObjectives[i].Deserialize(reader);
			}

		}


	}
}
