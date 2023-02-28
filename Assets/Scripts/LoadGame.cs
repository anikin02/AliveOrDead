using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    private Save save;
    private string path;

    private void Awake()
    {
        if (DataHolder.FirstRun)
        {
            path = Path.Combine(Application.persistentDataPath, "SaveGame.json");
            loadSave();
            DataHolder.FirstRun = false;
        }
    }

    private void Update()
    {
        enablePlayer();
    }

    private void loadSave()
    {
        if (File.Exists(path))
        {   
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            DataHolder.CounterAidKit = save.CounterAidKit;
            DataHolder.players = save.players;
            DataHolder.Money = save.Money;
            DataHolder.Wave = save.Wave;
        }
    }

    private void enablePlayer()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].GetComponent<Button>().interactable = DataHolder.players[i];
        }
    }
}