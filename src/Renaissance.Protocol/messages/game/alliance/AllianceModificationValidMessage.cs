//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:42.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(AllianceName);
			size += DofusBinaryFactory.Sizing.SizeOf(AllianceTag);
			var serialized1 = this.Alliancemblem.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.AllianceName);
			writer.WriteData(this.AllianceTag);
			writer.WriteDatas(serialized1);

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
