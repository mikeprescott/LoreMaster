using UnityEngine;
using System.Collections;
using Generator;
using System.IO;
using Generation;
using System.Text.RegularExpressions;

public class SeedNameTextBox : MonoBehaviour {

	private string textFieldString = "";

	void OnGUI(){
		textFieldString = GUI.TextField (new Rect (Screen.width * 0.5f - 50, Screen.height * 0.5f - 20, 100, 30), textFieldString, 30);
		if(GUI.Button (new Rect (Screen.width * 0.5f - 25, Screen.height * 0.5f + 20, 50, 30), "Seed")){
			SubmitSeed();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SubmitSeed(){
		//Verify no special characters \/:*?"<>|
		print (textFieldString);
		print ("Initializing World Generation...");

		MainWorld MW = new MainWorld (textFieldString);
		
		print ("Done!");
		print ("Printing World...");
		MW.PrintGrid();

		InitializeWorldMap(MW);

	}

	//For Test Purposes
	void InitializeWorldMap( MainWorld World){
		//Path For Reference
		string Path = Application.dataPath + "/" + textFieldString;
		
		//Find out if the directory exists
		bool exists = System.IO.Directory.Exists(Path);
		if (!exists) {
			System.IO.Directory.CreateDirectory (Path);
		}

		Map MyMap;
		for (int b = 0; b < World.Biomes.Length; b++) {

			//Create Map Object
			MyMap = new Map ();
			MyMap.biome (World.Biomes[b]);

			//Serialize the Map to XML, then create the XML file
			System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer (typeof(Map));
			System.IO.StreamWriter file = new System.IO.StreamWriter (Path + "/Biome_" + b + ".xml");
			writer.Serialize (file, MyMap);
			file.Close ();

			//Reopen the file and remove the "Junk" elements.
			TextReader reader = File.OpenText (Path + "/Biome_" + b + ".xml");
			string WorldMapXML = reader.ReadToEnd ();
			string pattern = "\\s*</?remove\\d+>";
			string replacement = "";
			Regex rgx = new Regex (pattern);
			WorldMapXML = rgx.Replace (WorldMapXML, replacement);
			reader.Close ();
			File.WriteAllText (Path + "/Biome_" + b + ".xml", WorldMapXML);

			Debug.Log ("File written: " + Path + "/Biome_" + b + ".xml");

		}
	}

	
	//For Test Purposes
	void MakeAndPrintAnXMLMap(){
		//Path For Reference
		string Path = Application.dataPath + "/" + textFieldString;

		//Find out if the directory exists
		bool exists = System.IO.Directory.Exists(Path);
		if (!exists) {
			System.IO.Directory.CreateDirectory (Path);
		}

		//Create Map Object
		Map MyMap = new Map ();
		MyMap.equalize ();

		//Serialize the Map to XML, then create the XML file
		System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Map));
		System.IO.StreamWriter file = new System.IO.StreamWriter(Path + "/WorldMap.xml");
		writer.Serialize(file, MyMap);
		file.Close();

		//Reopen the file and remove the "Junk" elements.
		TextReader reader = File.OpenText(Path + "/WorldMap.xml");
		string WorldMapXML = reader.ReadToEnd();
		string pattern = "\\s*</?remove\\d+>";
		string replacement = "";
		Regex rgx = new Regex(pattern);
		WorldMapXML = rgx.Replace(WorldMapXML, replacement);
		reader.Close();
		File.WriteAllText(Path + "/WorldMap.xml", WorldMapXML);


		Debug.Log("File written: " + Path + "/WorldMap.xml");
	}

	void CreateXML() { 
		StreamWriter writer; 
		FileInfo t = new FileInfo(Application.dataPath + "\\WorldData.xml" ); 
		if(!t.Exists){ 
			writer = t.CreateText(); 
		} else { 
			t.Delete(); 
			writer = t.CreateText(); 
		} 
		//writer.Write(SerializeObject()); 
		writer.Close(); 
		Debug.Log("File written."); 
	} 
}























