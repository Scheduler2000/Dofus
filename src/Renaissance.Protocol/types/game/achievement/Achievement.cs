//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:27.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Id);
			writer.Write((short)(this.FinishedObjective.Length));
			foreach(var obj in FinishedObjective)
			{
				writer.Write(obj.Serialize());
			}
			writer.Write((short)(this.StartedObjectives.Length));
			foreach(var obj in StartedObjectives)
			{
				writer.Write(obj.Serialize());
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
