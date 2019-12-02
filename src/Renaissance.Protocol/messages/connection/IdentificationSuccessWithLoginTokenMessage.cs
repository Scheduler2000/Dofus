//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:07.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.connection
{
	public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage, IDofusMessage
	{
		public new const int NetworkId = 6209;
		public new int ProtocolId { get { return NetworkId; } }

		public string LoginToken { get; set; }


		public IdentificationSuccessWithLoginTokenMessage() { }


		public IdentificationSuccessWithLoginTokenMessage InitIdentificationSuccessWithLoginTokenMessage(string _logintoken)
		{

			this.LoginToken = _logintoken;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.LoginToken);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.LoginToken = reader.Read<string>();

		}


	}
}