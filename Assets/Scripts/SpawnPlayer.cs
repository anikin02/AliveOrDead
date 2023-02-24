using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    private void Awake()
    {
        spawnPlayer();
    }
    private void spawnPlayer()
    {
        var position = new Vector3(0, 0, 0);
        print(ChoicePlayer.numberPlayer);
        GameObject player = Instantiate(
                playerPrefabs[ChoicePlayer.numberPlayer - 1],
                position,
                new Quaternion());
    }
}
