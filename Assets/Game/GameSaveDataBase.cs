using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

[Serializable]
public class GameSaveDataBase
{
	public bool useCrypto = false;
	public bool dumpReadData = false;

	public int version = 0;
	
	public static void SaveDataConvert0to0(ref GameSaveDataBase basesave)
	{
		GameSaveDataV0 sn = (GameSaveDataV0)basesave;			
		basesave = sn;
	}
	
	public static void SaveDataConvert0to1(ref GameSaveDataBase basesave)
	{
		GameSaveDataV0 sb = (GameSaveDataV0)basesave;		
		GameSaveDataV1 sn = new GameSaveDataV1();
		sn.version = 1;
		sn.gold = sb.gold;
		sn.glory = sb.glory;
		sn.playtime = 0;

		basesave = sn;
	}
	
	public static void SaveDataConvert1to2(ref GameSaveDataBase basesave)
	{
		GameSaveDataV1 sb = (GameSaveDataV1)basesave;		
		GameSaveDataV2 sn = new GameSaveDataV2();
		sn.version = 2;
		sn.gold = sb.gold;
		sn.glory = sb.glory;
		sn.playtime = sb.playtime;
		sn.kills = 0;
		
		basesave = sn;
	}


	void WriteCB(StreamWriter writer)
	{
		XmlWriterSettings settings = new XmlWriterSettings();
		settings.Indent = true;
		settings.Encoding = System.Text.Encoding.UTF8;
		
		
		//寫檔.		
		XmlWriter xmlwriter = XmlWriter.Create(writer, settings);
		xmlwriter.WriteStartDocument();		
		xmlwriter.WriteStartElement("GameSaveFile");
		xmlwriter.WriteAttributeString("version", version.ToString());		
		
		xmlwriter.WriteStartElement("Data");
		xmlwriter.WriteAttributeString("gold", GameData.instance.gameSavedata.gold.ToString());		
		
		xmlwriter.WriteEndElement();//caption.		
		
		
		xmlwriter.WriteEndElement();//caption.		
		xmlwriter.WriteEndDocument();
		
		xmlwriter.Close();
		xmlwriter = null;

		writer.Flush();
		
		Debug.Log("XML write finish");
	}
	
	private byte[] ToByteArray(object source)
	{
		var formatter = new BinaryFormatter();
		using (var stream = new MemoryStream())
		{
			formatter.Serialize(stream, source);                
			return stream.ToArray();
		}
	}

	void WriteBinCB(BinaryWriter writer, MemoryStream fileStream, CryptoStream cryptoStream)
	{
		byte[] bt = ToByteArray(GameData.instance.gameSavedata);
		writer.Write(bt);

	}

	void ReadCB(StreamReader reader)
	{
		XmlReader xr = XmlReader.Create(reader);
		
		XmlParseSaveFile(xr);
		xr.Close();
		Debug.Log("XML Read finish");
	}
	
	void ReadBinCB(BinaryReader reader, FileStream fileStream, CryptoStream cryptoStream)
	{
		
		BinaryFormatter formatter = new BinaryFormatter();
		if (useCrypto)
		{
			GameData.instance.gameSavedata = (GameSaveDataV0)formatter.Deserialize(cryptoStream);
		}
		else
		{
			GameData.instance.gameSavedata = (GameSaveDataV0)formatter.Deserialize(fileStream);

		}

		//Debug.Log("binleng:" + fileStream.Length.ToString());
		//byte[] bt = reader.ReadBytes(fileStream.Length);



		Debug.Log("XML Read finish");
	}
	public void WriteToXML(string filepathname)
	{
		GameCrypto.WriteText(filepathname, WriteCB, useCrypto, filepathname+"c");
		//GameCrypto.WriteBin(filepathname, WriteBinCB, useCrypto, filepathname+"c");

	}



	public void ReadFromXML(string filepathname)
	{
		GameCrypto.ReadText(filepathname, ReadCB, useCrypto, filepathname+"c");
		//GameCrypto.ReadBin(filepathname, ReadBinCB, useCrypto, filepathname+"c");
	}

	
	void XmlParseSaveFile(XmlReader xr)
	{
		while(xr.Read())
		{
			if (xr.IsStartElement())
			{
				Debug.Log(xr.Name + " " + xr.Value);
				if (xr.NodeType == XmlNodeType.Element)
				{
					//Debug.Log("XmlParseASFile node type:" + xr.NodeType + " name:" + xr.Name);
					
					while (xr.MoveToNextAttribute())
					{
						if (xr.Name == "version")
						{
							//Debug.Log(xr.Value);
						}
					}
					xr.MoveToElement();								
				}
			}
		}
		
	}

}
