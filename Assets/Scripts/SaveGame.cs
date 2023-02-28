using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{
    private string path;
    private Save save;

    private void Start()
    {
        save = new Save();
        path = Path.Combine(Application.persistentDataPath, "SaveGame.json");
    }

    private void saveRecord()
    {
        save.CounterAidKit = DataHolder.CounterAidKit;
        save.Money = DataHolder.Money;
        save.players = DataHolder.players;
        save.Wave = DataHolder.Wave;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            saveRecord();
            File.WriteAllText(path, JsonUtility.ToJson(save));
        }   
    }
}
