//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:42.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.achievement
{
	public class AchievementRewardRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6377;
		public  int ProtocolId { get { return NetworkId; } }

		public short AchievementId { get; set; }


		public AchievementRewardRequestMessage() { }


		public AchievementRewardRequestMessage InitAchievementRewardRequestMessage(short _achievementid)
		{

			this.AchievementId = _achievementid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(AchievementId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.AchievementId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.AchievementId = reader.Read<short>();

		}


	}
}
