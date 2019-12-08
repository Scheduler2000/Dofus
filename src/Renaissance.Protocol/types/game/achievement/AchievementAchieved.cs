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
	public class AchievementAchieved : IDofusType
	{
		public  const int NetworkId = 514;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Id { get; set; }

		public CustomVar<long> AchievedBy { get; set; }


		public AchievementAchieved() { }


		public AchievementAchieved InitAchievementAchieved(CustomVar<short> _id, CustomVar<long> _achievedby)
		{

			this.Id = _id;
			this.AchievedBy = _achievedby;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Id);
			size += DofusBinaryFactory.Sizing.SizeOf(AchievedBy);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Id);
			writer.WriteData(this.AchievedBy);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<CustomVar<short>>();
			this.AchievedBy = reader.Read<CustomVar<long>>();

		}


	}
}
