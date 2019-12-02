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
	public class AchievementAchievedRewardable : AchievementAchieved, IDofusType
	{
		public new const int NetworkId = 515;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Finishedlevel { get; set; }


		public AchievementAchievedRewardable() { }


		public AchievementAchievedRewardable InitAchievementAchievedRewardable(CustomVar<short> _finishedlevel)
		{

			this.Finishedlevel = _finishedlevel;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Finishedlevel);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Finishedlevel = reader.Read<CustomVar<short>>();

		}


	}
}