//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:08.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.connection.register
{
	public class NicknameRegistrationMessage : IDofusMessage
	{
		public  const int NetworkId = 5640;
		public  int ProtocolId { get { return NetworkId; } }


		public NicknameRegistrationMessage() { }


		public NicknameRegistrationMessage InitNicknameRegistrationMessage()
		{


			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();


			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{


		}


	}
}
