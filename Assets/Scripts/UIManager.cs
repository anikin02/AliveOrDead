using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text kills;
    [SerializeField] private Text wave;
    [SerializeField] private EnemySpawner spawner;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        changeValues();
    }

    private void changeValues()
    {
        if (player)
        {
            kills.text = player.GetComponent<Player>().Kills.ToString();
            wave.text = spawner.Wave.ToString();
        }
        else
        {
            kills.text = "0";
            wave.text = "0";
        }
    }
}
