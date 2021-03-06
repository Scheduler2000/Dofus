//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:52.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeTypesExchangerDescriptionForUserMessage : IDofusMessage
	{
		public  const int NetworkId = 5765;
		public  int ProtocolId { get { return NetworkId; } }

		public int ObjectType { get; set; }

		public CustomVar<int>[] TypeDescription { get; set; }


		public ExchangeTypesExchangerDescriptionForUserMessage() { }


		public ExchangeTypesExchangerDescriptionForUserMessage InitExchangeTypesExchangerDescriptionForUserMessage(int _objecttype, CustomVar<int>[] _typedescription)
		{

			this.ObjectType = _objecttype;
			this.TypeDescription = _typedescription;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObjectType);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.TypeDescription.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(TypeDescription);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ObjectType);
			writer.WriteData((short)(this.TypeDescription.Length));
			writer.WriteDatas(TypeDescription);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObjectType = reader.Read<int>();
			int TypeDescription_length = reader.Read<short>();
			this.TypeDescription = new CustomVar<int>[TypeDescription_length];
			for(int i = 0; i < TypeDescription_length; i++)
				this.TypeDescription[i] = reader.Read<CustomVar<int>>();

		}


	}
}
