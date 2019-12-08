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
using    Renaissance.Protocol.types.game.social;

namespace Renaissance.Protocol.messages.game.alliance
{
	public class AlliancePartialListMessage : AllianceListMessage, IDofusMessage
	{
		public new const int NetworkId = 6427;
		public new int ProtocolId { get { return NetworkId; } }


		public AlliancePartialListMessage() { }


		public AlliancePartialListMessage InitAlliancePartialListMessage(AllianceFactSheetInformations[] _alliances)
		{

			base.Alliances = _alliances;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);

		}


	}
}
