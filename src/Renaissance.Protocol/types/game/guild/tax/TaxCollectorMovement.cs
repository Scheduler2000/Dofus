//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:31.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.guild.tax
{
	public class TaxCollectorMovement : IDofusType
	{
		public  const int NetworkId = 493;
		public  int ProtocolId { get { return NetworkId; } }

		public byte MovementType { get; set; }

		public TaxCollectorBasicInformations BasicInfos { get; set; }

		public CustomVar<long> PlayerId { get; set; }

		public string PlayerName { get; set; }


		public TaxCollectorMovement() { }


		public TaxCollectorMovement InitTaxCollectorMovement(byte _movementtype, TaxCollectorBasicInformations _basicinfos, CustomVar<long> _playerid, string _playername)
		{

			this.MovementType = _movementtype;
			this.BasicInfos = _basicinfos;
			this.PlayerId = _playerid;
			this.PlayerName = _playername;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.MovementType);
			writer.Write(this.BasicInfos.Serialize());
			writer.Write(this.PlayerId);
			writer.Write(this.PlayerName);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MovementType = reader.Read<byte>();
			this.BasicInfos = new TaxCollectorBasicInformations();
			this.BasicInfos.Deserialize(reader);
			this.PlayerId = reader.Read<CustomVar<long>>();
			this.PlayerName = reader.Read<string>();

		}


	}
}
