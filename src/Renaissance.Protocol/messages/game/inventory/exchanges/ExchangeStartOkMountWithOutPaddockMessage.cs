//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:21.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.mount;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeStartOkMountWithOutPaddockMessage : IDofusMessage
	{
		public  const int NetworkId = 5991;
		public  int ProtocolId { get { return NetworkId; } }

		public MountClientData[] StabledMountsDescription { get; set; }


		public ExchangeStartOkMountWithOutPaddockMessage() { }


		public ExchangeStartOkMountWithOutPaddockMessage InitExchangeStartOkMountWithOutPaddockMessage(MountClientData[] _stabledmountsdescription)
		{

			this.StabledMountsDescription = _stabledmountsdescription;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.StabledMountsDescription.Length));
			foreach(var obj in StabledMountsDescription)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int StabledMountsDescription_length = reader.Read<short>();
			this.StabledMountsDescription = new MountClientData[StabledMountsDescription_length];
			for(int i = 0; i < StabledMountsDescription_length; i++)
			{
				this.StabledMountsDescription[i] = new MountClientData();
				this.StabledMountsDescription[i].Deserialize(reader);
			}

		}


	}
}
