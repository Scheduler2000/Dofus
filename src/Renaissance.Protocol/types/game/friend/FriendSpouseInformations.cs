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
using    Renaissance.Protocol.types.game.context.roleplay;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.friend
{
	public class FriendSpouseInformations : IDofusType
	{
		public  const int NetworkId = 77;
		public  int ProtocolId { get { return NetworkId; } }

		public int SpouseAccountId { get; set; }

		public CustomVar<long> SpouseId { get; set; }

		public string SpouseName { get; set; }

		public CustomVar<short> SpouseLevel { get; set; }

		public byte Breed { get; set; }

		public byte Sex { get; set; }

		public EntityLook SpouseEntityLook { get; set; }

		public GuildInformations GuildInfo { get; set; }

		public byte AlignmentSide { get; set; }


		public FriendSpouseInformations() { }


		public FriendSpouseInformations InitFriendSpouseInformations(int _spouseaccountid, CustomVar<long> _spouseid, string _spousename, CustomVar<short> _spouselevel, byte _breed, byte _sex, EntityLook _spouseentitylook, GuildInformations _guildinfo, byte _alignmentside)
		{

			this.SpouseAccountId = _spouseaccountid;
			this.SpouseId = _spouseid;
			this.SpouseName = _spousename;
			this.SpouseLevel = _spouselevel;
			this.Breed = _breed;
			this.Sex = _sex;
			this.SpouseEntityLook = _spouseentitylook;
			this.GuildInfo = _guildinfo;
			this.AlignmentSide = _alignmentside;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SpouseAccountId);
			writer.Write(this.SpouseId);
			writer.Write(this.SpouseName);
			writer.Write(this.SpouseLevel);
			writer.Write(this.Breed);
			writer.Write(this.Sex);
			writer.Write(this.SpouseEntityLook.Serialize());
			writer.Write(this.GuildInfo.Serialize());
			writer.Write(this.AlignmentSide);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SpouseAccountId = reader.Read<int>();
			this.SpouseId = reader.Read<CustomVar<long>>();
			this.SpouseName = reader.Read<string>();
			this.SpouseLevel = reader.Read<CustomVar<short>>();
			this.Breed = reader.Read<byte>();
			this.Sex = reader.Read<byte>();
			this.SpouseEntityLook = new EntityLook();
			this.SpouseEntityLook.Deserialize(reader);
			this.GuildInfo = new GuildInformations();
			this.GuildInfo.Deserialize(reader);
			this.AlignmentSide = reader.Read<byte>();

		}


	}
}