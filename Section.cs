//------------------------------------------------------------------------------
// Section is an object of Biome.
//------------------------------------------------------------------------------
using System;
namespace Generation {
	public class Section {
		public int Biome = 0;
		public int Number = 0;
		public int X = 0;    //Reference to the Biome Map, not the Tile Map
		public int Y = 0;
		public Neighbor North = new Neighbor();
		public Neighbor East = new Neighbor();
		public Neighbor South = new Neighbor();
		public Neighbor West = new Neighbor();
	}
}