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
using    Renaissance.Protocol.types.game.character.status;

namespace Renaissance.Protocol.types.game.context.roleplay.job
{
	public class JobCrafterDirectoryEntryPlayerInfo : IDofusType
	{
		public  const int NetworkId = 194;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PlayerId { get; set; }

		public string PlayerName { get; set; }

		public byte AlignmentSide { get; set; }

		public byte Breed { get; set; }

		public bool Sex { get; set; }

		public bool IsInWorkshop { get; set; }

		public short WorldX { get; set; }

		public short WorldY { get; set; }

		public double MapId { get; set; }

		public CustomVar<short> SubAreaId { get; set; }

		public PlayerStatus Status { get; set; }


		public JobCrafterDirectoryEntryPlayerInfo() { }


		public JobCrafterDirectoryEntryPlayerInfo InitJobCrafterDirectoryEntryPlayerInfo(CustomVar<long> _playerid, string _playername, byte _alignmentside, byte _breed, bool _sex, bool _isinworkshop, short _worldx, short _worldy, double _mapid, CustomVar<short> _subareaid, PlayerStatus _status)
		{

			this.PlayerId = _playerid;
			this.PlayerName = _playername;
			this.AlignmentSide = _alignmentside;
			this.Breed = _breed;
			this.Sex = _sex;
			this.IsInWorkshop = _isinworkshop;
			this.WorldX = _worldx;
			this.WorldY = _worldy;
			this.MapId = _mapid;
			this.SubAreaId = _subareaid;
			this.Status = _status;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.PlayerId);
			writer.Write(this.PlayerName);
			writer.Write(this.AlignmentSide);
			writer.Write(this.Breed);
			writer.Write(this.Sex);
			writer.Write(this.IsInWorkshop);
			writer.Write(this.WorldX);
			writer.Write(this.WorldY);
			writer.Write(this.MapId);
			writer.Write(this.SubAreaId);
			writer.Write((short)(Status.ProtocolId));
			writer.Write(this.Status.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PlayerId = reader.Read<CustomVar<long>>();
			this.PlayerName = reader.Read<string>();
			this.AlignmentSide = reader.Read<byte>();
			this.Breed = reader.Read<byte>();
			this.Sex = reader.Read<bool>();
			this.IsInWorkshop = reader.Read<bool>();
			this.WorldX = reader.Read<short>();
			this.WorldY = reader.Read<short>();
			this.MapId = reader.Read<double>();
			this.SubAreaId = reader.Read<CustomVar<short>>();
reader.Skip(2); // skip read short
			this.Status = new PlayerStatus();
			this.Status.Deserialize(reader);

		}


	}
}