using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text kills;
    [SerializeField] private Text enemies;

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
            enemies.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
        }
    }
}
