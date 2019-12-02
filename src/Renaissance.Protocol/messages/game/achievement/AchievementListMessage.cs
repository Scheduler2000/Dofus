//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:08.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.achievement;

namespace Renaissance.Protocol.messages.game.achievement
{
	public class AchievementListMessage : IDofusMessage
	{
		public  const int NetworkId = 6205;
		public  int ProtocolId { get { return NetworkId; } }

		public AchievementAchieved[] FinishedAchievements { get; set; }


		public AchievementListMessage() { }


		public AchievementListMessage InitAchievementListMessage(AchievementAchieved[] _finishedachievements)
		{

			this.FinishedAchievements = _finishedachievements;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.FinishedAchievements.Length));
			foreach(var obj in FinishedAchievements)
			{
				writer.Write((short)(obj.ProtocolId));
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int FinishedAchievements_length = reader.Read<short>();
			this.FinishedAchievements = new AchievementAchieved[FinishedAchievements_length];
			for(int i = 0; i < FinishedAchievements_length; i++)
			{
reader.Skip(2); // skip read short for protocolManager.GetInstance(short)
				this.FinishedAchievements[i] = new AchievementAchieved();
				this.FinishedAchievements[i].Deserialize(reader);
			}

		}


	}
}