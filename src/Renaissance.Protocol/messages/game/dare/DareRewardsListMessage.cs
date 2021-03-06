//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:44.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.dare;

namespace Renaissance.Protocol.messages.game.dare
{
	public class DareRewardsListMessage : IDofusMessage
	{
		public  const int NetworkId = 6677;
		public  int ProtocolId { get { return NetworkId; } }

		public DareReward[] Rewards { get; set; }


		public DareRewardsListMessage() { }


		public DareRewardsListMessage InitDareRewardsListMessage(DareReward[] _rewards)
		{

			this.Rewards = _rewards;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Rewards.Length));
			var memory1 = new Memory<byte>[Rewards.Length];
			for(int i = 0; i < Rewards.Length; i++)
			{
				memory1[i] = this.Rewards[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Rewards.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Rewards_length = reader.Read<short>();
			this.Rewards = new DareReward[Rewards_length];
			for(int i = 0; i < Rewards_length; i++)
			{
				this.Rewards[i] = new DareReward();
				this.Rewards[i].Deserialize(reader);
			}

		}


	}
}
