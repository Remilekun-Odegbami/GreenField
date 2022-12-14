using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public SaveData activeSave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.maizeHarvest + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        print("saved");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + activeSave.maizeHarvest + ".save") {
            var serializer = new XmlSerializer(typeof(SaveData));   
            var stream = new FileStream(dataPath + "/" + activeSave.maizeHarvest + ".save", FileMode.Create);
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string Name;
    public int maizeHarvest;
    public int carrotHarvest;
    public int beetHarvest;
    public int bellHarvest;
    public int melonHarvest;
    public int cabbageHarvest;
    public int tomatoesHarvest;
    public int profit;
}
