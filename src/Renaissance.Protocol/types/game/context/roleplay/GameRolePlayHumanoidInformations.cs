//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:30.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations, IDofusType
	{
		public new const int NetworkId = 159;
		public new int ProtocolId { get { return NetworkId; } }

		public HumanInformations HumanoidInfo { get; set; }

		public int AccountId { get; set; }


		public GameRolePlayHumanoidInformations() { }


		public GameRolePlayHumanoidInformations InitGameRolePlayHumanoidInformations(HumanInformations _humanoidinfo, int _accountid)
		{

			this.HumanoidInfo = _humanoidinfo;
			this.AccountId = _accountid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write((short)(HumanoidInfo.ProtocolId));
			writer.Write(this.HumanoidInfo.Serialize());
			writer.Write(this.AccountId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
reader.Skip(2); // skip read short
			this.HumanoidInfo = new HumanInformations();
			this.HumanoidInfo.Deserialize(reader);
			this.AccountId = reader.Read<int>();

		}


	}
}
