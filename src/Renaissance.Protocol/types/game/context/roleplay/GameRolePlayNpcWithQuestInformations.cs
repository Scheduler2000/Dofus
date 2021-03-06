//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:00.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context;
using    Renaissance.Protocol.types.game.context.roleplay.quest;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations, IDofusType
	{
		public new const int NetworkId = 383;
		public new int ProtocolId { get { return NetworkId; } }

		public GameRolePlayNpcQuestFlag QuestFlag { get; set; }


		public GameRolePlayNpcWithQuestInformations() { }


		public GameRolePlayNpcWithQuestInformations InitGameRolePlayNpcWithQuestInformations(CustomVar<short> _npcid, bool _sex, CustomVar<short> _specialartworkid, EntityLook _look, double _contextualid, EntityDispositionInformations _disposition, GameRolePlayNpcQuestFlag _questflag)
		{

			base.NpcId = _npcid;
			base.Sex = _sex;
			base.SpecialArtworkId = _specialartworkid;
			base.Look = _look;
			base.ContextualId = _contextualid;
			base.Disposition = _disposition;
			this.QuestFlag = _questflag;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.QuestFlag.Serialize();
			size += serialized1.Length;
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.QuestFlag = new GameRolePlayNpcQuestFlag();
			this.QuestFlag.Deserialize(reader);

		}


	}
}
