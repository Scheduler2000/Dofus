//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class MountInformationInPaddockRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5975;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> MapRideId { get; set; }


		public MountInformationInPaddockRequestMessage() { }


		public MountInformationInPaddockRequestMessage InitMountInformationInPaddockRequestMessage(CustomVar<int> _maprideid)
		{

			this.MapRideId = _maprideid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.MapRideId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MapRideId = reader.Read<CustomVar<int>>();

		}


	}
}