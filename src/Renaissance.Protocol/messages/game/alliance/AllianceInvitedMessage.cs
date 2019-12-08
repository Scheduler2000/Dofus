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
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.messages.game.alliance
{
	public class AllianceInvitedMessage : IDofusMessage
	{
		public  const int NetworkId = 6397;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> RecruterId { get; set; }

		public string RecruterName { get; set; }

		public BasicNamedAllianceInformations AllianceInfo { get; set; }


		public AllianceInvitedMessage() { }


		public AllianceInvitedMessage InitAllianceInvitedMessage(CustomVar<long> _recruterid, string _recrutername, BasicNamedAllianceInformations _allianceinfo)
		{

			this.RecruterId = _recruterid;
			this.RecruterName = _recrutername;
			this.AllianceInfo = _allianceinfo;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(RecruterId);
			size += DofusBinaryFactory.Sizing.SizeOf(RecruterName);
			var serialized1 = this.AllianceInfo.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.RecruterId);
			writer.WriteData(this.RecruterName);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.RecruterId = reader.Read<CustomVar<long>>();
			this.RecruterName = reader.Read<string>();
			this.AllianceInfo = new BasicNamedAllianceInformations();
			this.AllianceInfo.Deserialize(reader);

		}


	}
}
