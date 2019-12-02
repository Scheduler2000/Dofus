//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:32.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.data.items.effects
{
	public class ObjectEffectLadder : ObjectEffectCreature, IDofusType
	{
		public new const int NetworkId = 81;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> MonsterCount { get; set; }


		public ObjectEffectLadder() { }


		public ObjectEffectLadder InitObjectEffectLadder(CustomVar<int> _monstercount)
		{

			this.MonsterCount = _monstercount;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.MonsterCount);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.MonsterCount = reader.Read<CustomVar<int>>();

		}


	}
}