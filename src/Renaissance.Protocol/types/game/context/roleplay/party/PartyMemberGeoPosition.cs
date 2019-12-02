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

namespace Renaissance.Protocol.types.game.context.roleplay.party
{
	public class PartyMemberGeoPosition : IDofusType
	{
		public  const int NetworkId = 378;
		public  int ProtocolId { get { return NetworkId; } }

		public int MemberId { get; set; }

		public short WorldX { get; set; }

		public short WorldY { get; set; }

		public double MapId { get; set; }

		public CustomVar<short> SubAreaId { get; set; }


		public PartyMemberGeoPosition() { }


		public PartyMemberGeoPosition InitPartyMemberGeoPosition(int _memberid, short _worldx, short _worldy, double _mapid, CustomVar<short> _subareaid)
		{

			this.MemberId = _memberid;
			this.WorldX = _worldx;
			this.WorldY = _worldy;
			this.MapId = _mapid;
			this.SubAreaId = _subareaid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.MemberId);
			writer.Write(this.WorldX);
			writer.Write(this.WorldY);
			writer.Write(this.MapId);
			writer.Write(this.SubAreaId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MemberId = reader.Read<int>();
			this.WorldX = reader.Read<short>();
			this.WorldY = reader.Read<short>();
			this.MapId = reader.Read<double>();
			this.SubAreaId = reader.Read<CustomVar<short>>();

		}


	}
}