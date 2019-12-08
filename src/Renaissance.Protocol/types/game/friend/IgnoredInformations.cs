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
	public class IgnoredInformations : AbstractContactInformations, IDofusType
	{
		public new const int NetworkId = 106;
		public new int ProtocolId { get { return NetworkId; } }


		public IgnoredInformations() { }


		public IgnoredInformations InitIgnoredInformations(int _accountid, string _accountname)
		{

			base.AccountId = _accountid;
			base.AccountName = _accountname;

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
