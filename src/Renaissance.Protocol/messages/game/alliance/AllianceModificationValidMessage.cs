//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:09.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.guild;

namespace Renaissance.Protocol.messages.game.alliance
{
	public class AllianceModificationValidMessage : IDofusMessage
	{
		public  const int NetworkId = 6450;
		public  int ProtocolId { get { return NetworkId; } }

		public string AllianceName { get; set; }

		public string AllianceTag { get; set; }

		public GuildEmblem Alliancemblem { get; set; }


		public AllianceModificationValidMessage() { }


		public AllianceModificationValidMessage InitAllianceModificationValidMessage(string _alliancename, string _alliancetag, GuildEmblem _alliancemblem)
		{

			this.AllianceName = _alliancename;
			this.AllianceTag = _alliancetag;
			this.Alliancemblem = _alliancemblem;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.AllianceName);
			writer.Write(this.AllianceTag);
			writer.Write(this.Alliancemblem.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.AllianceName = reader.Read<string>();
			this.AllianceTag = reader.Read<string>();
			this.Alliancemblem = new GuildEmblem();
			this.Alliancemblem.Deserialize(reader);

		}


	}
}