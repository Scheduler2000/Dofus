//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class LivingObjectMessageRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6066;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> MsgId { get; set; }

		public string[] Parameters { get; set; }

		public CustomVar<int> LivingObject { get; set; }


		public LivingObjectMessageRequestMessage() { }


		public LivingObjectMessageRequestMessage InitLivingObjectMessageRequestMessage(CustomVar<short> _msgid, string[] _parameters, CustomVar<int> _livingobject)
		{

			this.MsgId = _msgid;
			this.Parameters = _parameters;
			this.LivingObject = _livingobject;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MsgId);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Parameters.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Parameters);
			size += DofusBinaryFactory.Sizing.SizeOf(LivingObject);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.MsgId);
			writer.WriteData((short)(this.Parameters.Length));
			writer.WriteDatas(Parameters);
			writer.WriteData(this.LivingObject);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MsgId = reader.Read<CustomVar<short>>();
			int Parameters_length = reader.Read<short>();
			this.Parameters = new string[Parameters_length];
			for(int i = 0; i < Parameters_length; i++)
				this.Parameters[i] = reader.Read<string>();
			this.LivingObject = reader.Read<CustomVar<int>>();

		}


	}
}
