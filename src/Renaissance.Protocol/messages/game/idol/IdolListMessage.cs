//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:12.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.idol;

namespace Renaissance.Protocol.messages.game.idol
{
	public class IdolListMessage : IDofusMessage
	{
		public  const int NetworkId = 6585;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] ChosenIdols { get; set; }

		public CustomVar<short>[] PartyChosenIdols { get; set; }

		public PartyIdol[] PartyIdols { get; set; }


		public IdolListMessage() { }


		public IdolListMessage InitIdolListMessage(CustomVar<short>[] _chosenidols, CustomVar<short>[] _partychosenidols, PartyIdol[] _partyidols)
		{

			this.ChosenIdols = _chosenidols;
			this.PartyChosenIdols = _partychosenidols;
			this.PartyIdols = _partyidols;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.ChosenIdols.Length));
			foreach(var item in ChosenIdols)
				writer.Write(item);
			writer.Write((short)(this.PartyChosenIdols.Length));
			foreach(var item in PartyChosenIdols)
				writer.Write(item);
			writer.Write((short)(this.PartyIdols.Length));
			foreach(var obj in PartyIdols)
			{
				writer.Write((short)(obj.ProtocolId));
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int ChosenIdols_length = reader.Read<short>();
			this.ChosenIdols = new CustomVar<short>[ChosenIdols_length];
			for(int i = 0; i < ChosenIdols_length; i++)
				this.ChosenIdols[i] = reader.Read<CustomVar<short>>();
			int PartyChosenIdols_length = reader.Read<short>();
			this.PartyChosenIdols = new CustomVar<short>[PartyChosenIdols_length];
			for(int i = 0; i < PartyChosenIdols_length; i++)
				this.PartyChosenIdols[i] = reader.Read<CustomVar<short>>();
			int PartyIdols_length = reader.Read<short>();
			this.PartyIdols = new PartyIdol[PartyIdols_length];
			for(int i = 0; i < PartyIdols_length; i++)
			{
reader.Skip(2); // skip read short for protocolManager.GetInstance(short)
				this.PartyIdols[i] = new PartyIdol();
				this.PartyIdols[i].Deserialize(reader);
			}

		}


	}
}