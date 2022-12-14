using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public SaveData activeSave;
    public static SaveManager instance;
    public bool hasLoaded;

    void Awake()
    {
        instance = this;
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.maizeHarvest + activeSave.carrotHarvest + activeSave.beetHarvest + activeSave.bellHarvest + activeSave.melonHarvest + activeSave.cabbageHarvest + activeSave.tomatoesHarvest + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        print("saved");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if (File.Exists(dataPath + "/" + activeSave.maizeHarvest + activeSave.carrotHarvest + activeSave.beetHarvest + activeSave.bellHarvest + activeSave.melonHarvest + activeSave.cabbageHarvest + activeSave.tomatoesHarvest + ".save")) {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.maizeHarvest + activeSave.carrotHarvest + activeSave.beetHarvest + activeSave.bellHarvest + activeSave.melonHarvest + activeSave.cabbageHarvest + activeSave.tomatoesHarvest + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            print("close");

            hasLoaded = true;
        }
    }

    public void Delete()
    {
        string dataPath = Application.persistentDataPath;

        if (File.Exists(dataPath + "/" + activeSave.maizeHarvest + activeSave.carrotHarvest + activeSave.beetHarvest + activeSave.bellHarvest + activeSave.melonHarvest + activeSave.cabbageHarvest + activeSave.tomatoesHarvest + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.maizeHarvest + activeSave.carrotHarvest + activeSave.beetHarvest + activeSave.bellHarvest + activeSave.melonHarvest + activeSave.cabbageHarvest + activeSave.tomatoesHarvest + ".save");
            print("delete");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int maizeHarvest;
    public int carrotHarvest;
    public int beetHarvest;
    public int bellHarvest;
    public int melonHarvest;
    public int cabbageHarvest;
    public int tomatoesHarvest;
    public int profit;

    public TextMeshProUGUI maizeHarvestText;
    public TextMeshProUGUI tomatoesHarvestText;
    public TextMeshProUGUI carrotHarvestText;
    public TextMeshProUGUI beetHarvestText;
    public TextMeshProUGUI bellHarvestText;
    public TextMeshProUGUI melonHarvestText;
    public TextMeshProUGUI cabbageHarvestText;
}
