//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:28.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.character.status;
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.types.game.friend
{
	public class FriendOnlineInformations : FriendInformations, IDofusType
	{
		public new const int NetworkId = 92;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PlayerId { get; set; }

		public string PlayerName { get; set; }

		public CustomVar<short> Level { get; set; }

		public byte AlignmentSide { get; set; }

		public byte Breed { get; set; }

		public WrappedBool Sex { get; set; }

		public GuildInformations GuildInfo { get; set; }

		public CustomVar<short> MoodSmileyId { get; set; }

		public PlayerStatus Status { get; set; }

		public WrappedBool HavenBagShared { get; set; }


		public FriendOnlineInformations() { }


		public FriendOnlineInformations InitFriendOnlineInformations(CustomVar<long> _playerid, string _playername, CustomVar<short> _level, byte _alignmentside, byte _breed, WrappedBool _sex, GuildInformations _guildinfo, CustomVar<short> _moodsmileyid, PlayerStatus _status, WrappedBool _havenbagshared)
		{

			this.PlayerId = _playerid;
			this.PlayerName = _playername;
			this.Level = _level;
			this.AlignmentSide = _alignmentside;
			this.Breed = _breed;
			this.Sex = _sex;
			this.GuildInfo = _guildinfo;
			this.MoodSmileyId = _moodsmileyid;
			this.Status = _status;
			this.HavenBagShared = _havenbagshared;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			byte box = 0;
			box = writer.SetFlag(box,0,this.Sex);
			box = writer.SetFlag(box,1,this.HavenBagShared);
			writer.Write(box);
			writer.Write(this.PlayerId);
			writer.Write(this.PlayerName);
			writer.Write(this.Level);
			writer.Write(this.AlignmentSide);
			writer.Write(this.Breed);
			writer.Write(this.GuildInfo.Serialize());
			writer.Write(this.MoodSmileyId);
			writer.Write((short)(Status.ProtocolId));
			writer.Write(this.Status.Serialize());

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			byte box = reader.Read<byte>();
			this.Sex = reader.ReadFlag(box,0);
			this.HavenBagShared = reader.ReadFlag(box,1);
			this.PlayerId = reader.Read<CustomVar<long>>();
			this.PlayerName = reader.Read<string>();
			this.Level = reader.Read<CustomVar<short>>();
			this.AlignmentSide = reader.Read<byte>();
			this.Breed = reader.Read<byte>();
			this.GuildInfo = new GuildInformations();
			this.GuildInfo.Deserialize(reader);
			this.MoodSmileyId = reader.Read<CustomVar<short>>();
reader.Skip(2); // skip read short
			this.Status = new PlayerStatus();
			this.Status.Deserialize(reader);

		}


	}
}
