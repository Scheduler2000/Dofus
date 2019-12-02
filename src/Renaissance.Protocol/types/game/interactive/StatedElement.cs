//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:28.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.interactive
{
	public class StatedElement : IDofusType
	{
		public  const int NetworkId = 108;
		public  int ProtocolId { get { return NetworkId; } }

		public int ElementId { get; set; }

		public CustomVar<short> ElementCellId { get; set; }

		public CustomVar<int> ElementState { get; set; }

		public bool OnCurrentMap { get; set; }


		public StatedElement() { }


		public StatedElement InitStatedElement(int _elementid, CustomVar<short> _elementcellid, CustomVar<int> _elementstate, bool _oncurrentmap)
		{

			this.ElementId = _elementid;
			this.ElementCellId = _elementcellid;
			this.ElementState = _elementstate;
			this.OnCurrentMap = _oncurrentmap;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ElementId);
			writer.Write(this.ElementCellId);
			writer.Write(this.ElementState);
			writer.Write(this.OnCurrentMap);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ElementId = reader.Read<int>();
			this.ElementCellId = reader.Read<CustomVar<short>>();
			this.ElementState = reader.Read<CustomVar<int>>();
			this.OnCurrentMap = reader.Read<bool>();

		}


	}
}