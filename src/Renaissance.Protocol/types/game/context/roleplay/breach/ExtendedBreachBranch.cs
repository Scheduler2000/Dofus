//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:31.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.types.game.context.roleplay.breach
{
	public class ExtendedBreachBranch : BreachBranch, IDofusType
	{
		public new const int NetworkId = 560;
		public new int ProtocolId { get { return NetworkId; } }

		public MonsterInGroupLightInformations[] Monsters { get; set; }

		public BreachReward[] Rewards { get; set; }

		public CustomVar<int> Modifier { get; set; }

		public CustomVar<int> Prize { get; set; }


		public ExtendedBreachBranch() { }


		public ExtendedBreachBranch InitExtendedBreachBranch(MonsterInGroupLightInformations[] _monsters, BreachReward[] _rewards, CustomVar<int> _modifier, CustomVar<int> _prize)
		{

			this.Monsters = _monsters;
			this.Rewards = _rewards;
			this.Modifier = _modifier;
			this.Prize = _prize;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write((short)(this.Monsters.Length));
			foreach(var obj in Monsters)
			{
				writer.Write(obj.Serialize());
			}
			writer.Write((short)(this.Rewards.Length));
			foreach(var obj in Rewards)
			{
				writer.Write(obj.Serialize());
			}
			writer.Write(this.Modifier);
			writer.Write(this.Prize);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int Monsters_length = reader.Read<short>();
			this.Monsters = new MonsterInGroupLightInformations[Monsters_length];
			for(int i = 0; i < Monsters_length; i++)
			{
				this.Monsters[i] = new MonsterInGroupLightInformations();
				this.Monsters[i].Deserialize(reader);
			}
			int Rewards_length = reader.Read<short>();
			this.Rewards = new BreachReward[Rewards_length];
			for(int i = 0; i < Rewards_length; i++)
			{
				this.Rewards[i] = new BreachReward();
				this.Rewards[i].Deserialize(reader);
			}
			this.Modifier = reader.Read<CustomVar<int>>();
			this.Prize = reader.Read<CustomVar<int>>();

		}


	}
}