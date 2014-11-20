using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;


namespace Generator{
	public class Gennie{


		public string HashSeed(string input){

			MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			
			// step 2, convert byte array to hex string
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++){
				sb.Append(hash[i].ToString("X2"));
			}
			return sb.ToString();
		}

		public int Ran( string Hash, int Max, int Key ){
			//D41D8CD98F00B204E9800998ECF8427E
			//12345678901234567890123456789012
			string ShiftedHash;
			int NewMax;
			int MaxLengthInHex;
			float UnpolishedRandom;
			int PseudoRandom;

			MaxLengthInHex = Max.ToString("X").Length;
			NewMax = (int)(System.Math.Pow(16, MaxLengthInHex));
			Key = Key % 32;
			ShiftedHash = Hash + Hash;
			ShiftedHash = ShiftedHash.Substring (Key, MaxLengthInHex);
			UnpolishedRandom = (float)int.Parse(ShiftedHash, System.Globalization.NumberStyles.HexNumber);

			//return (float)((UnpolishedRandom / NewMax) * Max);
			//The Unpolished number (Direct HEX to Float value @ Key) is divided by the potential max. Then multiplied by the max.
			PseudoRandom = (int)(System.Math.Ceiling(((UnpolishedRandom / NewMax) * Max)));
			PseudoRandom = (PseudoRandom < 1) ? 1 : PseudoRandom;
			PseudoRandom = (PseudoRandom > Max) ? Max : PseudoRandom;


			return PseudoRandom;
		}
	}
}