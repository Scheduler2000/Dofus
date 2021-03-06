//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:58.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.friend
{
	public class IgnoredOnlineInformations : IgnoredInformations, IDofusType
	{
		public new const int NetworkId = 105;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PlayerId { get; set; }

		public string PlayerName { get; set; }

		public byte Breed { get; set; }

		public bool Sex { get; set; }


		public IgnoredOnlineInformations() { }


		public IgnoredOnlineInformations InitIgnoredOnlineInformations(int _accountid, string _accountname, CustomVar<long> _playerid, string _playername, byte _breed, bool _sex)
		{

			base.AccountId = _accountid;
			base.AccountName = _accountname;
			this.PlayerId = _playerid;
			this.PlayerName = _playername;
			this.Breed = _breed;
			this.Sex = _sex;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PlayerId);
			size += DofusBinaryFactory.Sizing.SizeOf(PlayerName);
			size += DofusBinaryFactory.Sizing.SizeOf(Breed);
			size += DofusBinaryFactory.Sizing.SizeOf(Sex);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.PlayerId);
			writer.WriteData(this.PlayerName);
			writer.WriteData(this.Breed);
			writer.WriteData(this.Sex);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.PlayerId = reader.Read<CustomVar<long>>();
			this.PlayerName = reader.Read<string>();
			this.Breed = reader.Read<byte>();
			this.Sex = reader.Read<bool>();

		}


	}
}
