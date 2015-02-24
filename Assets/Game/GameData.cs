using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameData : MonoBehaviour {

	public static GameData instance;
	public ShuffleIntValue money;
	public GameSaveDataV0 gameSavedata;


	// Use this for initialization
	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			DestroyObject(this.gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		money.Value = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI()
	{
		if (GUILayout.Button("save"))
		{
			SaveGameDataXML();
		}
		if (GUILayout.Button("load"))
		{
			LoadGameDataXML();
		}
		
		if (GUILayout.Button("Money+"))
		{
			money.Value = money.Value + 100;
			Debug.Log(money.Value);
			Debug.Log(money.myValue);
		}
		if (GUILayout.Button("Money-"))
		{
			money.Value = money.Value - 100;
			Debug.Log(money.Value);
			Debug.Log(money.myValue);
		}
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
	
	void SaveGameDataXML()
	{
		Debug.Log("Save:" + Application.persistentDataPath + "/save.bin");
		gameSavedata.WriteToXML(Application.persistentDataPath + "/save.bin");
	}
	void LoadGameDataXML()
	{
		Debug.Log("Load:" + Application.persistentDataPath + "/save.bin");
		gameSavedata.ReadFromXML(Application.persistentDataPath + "/save.bin");
	}

	void SaveGameData()
	{
		gameSavedata.ReadFromXML(Application.persistentDataPath + "/save.bin");
	}

	void LoadGameData()
	{
		if (!File.Exists(Application.persistentDataPath + "/save.bin"))
		{
			return;
		}

		FileStream fs = new FileStream(Application.persistentDataPath + "/save.bin", FileMode.Open);
		try 
		{
			BinaryFormatter formatter = new BinaryFormatter();
			
			// Deserialize the hashtable from the file and 
			// assign the reference to the local variable.
			GameSaveDataBase basesave = (GameSaveDataBase)formatter.Deserialize(fs);
			Debug.Log("SaveLoad ver:" + basesave.version);

			SaveDataConvert(ref basesave);
		}
		catch (System.Runtime.Serialization.SerializationException e) 
		{

		}
	
		fs.Close();
	}


	void SaveDataConvert(ref GameSaveDataBase basesave)
	{
	
		if (basesave.version == 0)
		{
			GameSaveDataBase.SaveDataConvert0to0(ref basesave);
			//SaveDataConvert0to1(ref basesave);
		}

//		if (basesave.version == 1)
//		{
//			SaveDataConvert1to2(ref basesave);
//		}

		gameSavedata = (GameSaveDataV0)basesave;
	}

}
