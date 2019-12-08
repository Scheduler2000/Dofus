//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:49.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class MountEquipedErrorMessage : IDofusMessage
	{
		public  const int NetworkId = 5963;
		public  int ProtocolId { get { return NetworkId; } }

		public byte ErrorType { get; set; }


		public MountEquipedErrorMessage() { }


		public MountEquipedErrorMessage InitMountEquipedErrorMessage(byte _errortype)
		{

			this.ErrorType = _errortype;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ErrorType);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ErrorType);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ErrorType = reader.Read<byte>();

		}


	}
}
