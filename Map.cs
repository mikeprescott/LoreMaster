//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Xml;
using System.Xml.Serialization;


using UnityEngine;
using System.IO;

namespace Generation
{
	[XmlRoot("map")]
	public class Map{		
		[XmlAttribute("version")]
		public string version = "1.0";

		[XmlAttribute("orientation")]
		public string orientation = "orthogonal";
		
		[XmlAttribute("width")]
		public int width = 64;
		
		[XmlAttribute("height")]
		public int height = 64;

		[XmlAttribute("tilewidth")]
		public int tilewidth = 32;

		[XmlAttribute("tileheight")]
		public int tileheight = 32;

		[XmlArray("remove1")]
		[XmlArrayItem("tileset")]
		public tileset[] tileset = new tileset[1];

		[XmlArray("remove2")]
		[XmlArrayItem("layer")]
		public layer[] layer = new layer[1];

		public Map(){
		}

		public void equalize(){			
			for (int i = 0; i < tileset.Length; i++) {
				tileset[i] = new tileset();
				tileset[i].tilewidth = tilewidth;
				tileset[i].tileheight = tileheight;				
				tileset[i].image = new image[1];
				for (int j = 0; j < tileset[i].image.Length; j++) {
					tileset[i].image[j] = new image();
				}
			}

			for (int i = 0; i < layer.Length; i++) {
				layer[i] = new layer();
				layer[i].width = width;
				layer[i].height = height;
				layer[i].data = new tile[width * height];
				for (int j = 0; j < layer[i].data.Length; j++) {
					layer[i].data[j] = new tile();
					layer[i].data[j].gid = 0;
				}				
			}
		}
		
		public void biome(Biome B){			
			int t;

			if(B.GetShape() == "Tall"){
				width = B.SectionLength;
				height = B.SectionLength * 4;
			} else if(B.GetShape() == "Long"){
				width = B.SectionLength * 4;
				height = B.SectionLength;
			} else {
				width = B.SectionLength * 2;
				height = B.SectionLength * 2;
			}
			
			for (int i = 0; i < tileset.Length; i++) {
				tileset[i] = new tileset();
				tileset[i].tilewidth = tilewidth;
				tileset[i].tileheight = tileheight;	
				tileset[i].name = B.GetBiomeType();			
				tileset[i].image = new image[1];
				for (int j = 0; j < tileset[i].image.Length; j++) {
					tileset[i].image[j] = new image();
					tileset[i].image[j].name = B.GetBiomeType() + ".png";
				}
			}

			for (int i = 0; i < layer.Length; i++) {
				layer[i] = new layer();
				
				layer[i].width = width;
				layer[i].height = height;
				layer[i].data = new tile[width * height];
				for (int j = 0; j < layer[i].data.Length; j++) {
					layer[i].data[j] = new tile();
					layer[i].data[j].gid = 0;
				}				
			}

			t = 0;
			for (int x = 0; x < B.Grid.GetLength(0); x++) {
				for (int y = 0; y < B.Grid.GetLength(1); y++) {
					layer[0].data[t] = new tile();
					layer[0].data[t].gid = B.Grid[x,y];
					t++;
				}
			}
		}
	}

	public class tileset{		
		[XmlAttribute("firstgid")]
		public string firstgid = "1";
		
		[XmlAttribute("name")]
		public string name = "grassland";
		
		[XmlAttribute("tilewidth")]
		public int tilewidth = 32;
		
		[XmlAttribute("tileheight")]
		public int tileheight = 32;

		[XmlArray("remove3")]
		[XmlArrayItem("image")]
		public image[] image;
	}

	public class image{		
		[XmlAttribute("source")]
		public string name = "grassland.png";
		
		[XmlAttribute("width")]
		public int width = 64;
		
		[XmlAttribute("height")]
		public int height = 64;
	}

	public class layer{		
		[XmlAttribute("name")]
		public string name = "Tile Layer 1";

		[XmlAttribute("width")]
		public int width = 64;
		
		[XmlAttribute("height")]
		public int height = 64;

		public tile[] data;

		public layer(){
			data = new tile [width * height];
		}
	}

	public class tile{		
		[XmlAttribute("gid")]
		public int gid = 1;
	}
}

