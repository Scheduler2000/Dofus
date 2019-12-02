//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:25.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using Renaissance.Binary;
using Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.party
{
    public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage, IDofusMessage
	{
		public new const int NetworkId = 6262;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> DungeonId { get; set; }

		public bool[] PlayersDungeonReady { get; set; }


		public PartyInvitationDungeonDetailsMessage() { }


		public PartyInvitationDungeonDetailsMessage InitPartyInvitationDungeonDetailsMessage(CustomVar<short> _dungeonid, bool[] _playersdungeonready)
		{

			this.DungeonId = _dungeonid;
			this.PlayersDungeonReady = _playersdungeonready;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.DungeonId);
			writer.Write((short)(this.PlayersDungeonReady.Length));
			foreach(var item in PlayersDungeonReady)
				writer.Write(item);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.DungeonId = reader.Read<CustomVar<short>>();
			int PlayersDungeonReady_length = reader.Read<short>();
			this.PlayersDungeonReady = new bool[PlayersDungeonReady_length];
			for(int i = 0; i < PlayersDungeonReady_length; i++)
				this.PlayersDungeonReady[i] = reader.Read<bool>();

		}


	}
}
