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
using    Renaissance.Protocol.types.game.social;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class BasicAllianceInformations : AbstractSocialGroupInfos, IDofusType
	{
		public new const int NetworkId = 419;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> AllianceId { get; set; }

		public string AllianceTag { get; set; }


		public BasicAllianceInformations() { }


		public BasicAllianceInformations InitBasicAllianceInformations(CustomVar<int> _allianceid, string _alliancetag)
		{

			this.AllianceId = _allianceid;
			this.AllianceTag = _alliancetag;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.AllianceId);
			writer.Write(this.AllianceTag);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.AllianceId = reader.Read<CustomVar<int>>();
			this.AllianceTag = reader.Read<string>();

		}


	}
}
