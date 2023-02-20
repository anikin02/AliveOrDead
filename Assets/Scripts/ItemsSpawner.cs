using UnityEngine;
using System.Collections; 

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float delay = 10;

    private void Start()
    {
        StartCoroutine(spawnPrefab());
    }

    private IEnumerator spawnPrefab()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);

            Vector2 position = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(-10.0f, 10.0f));
            GameObject newGameObject = Instantiate(
                prefabs[Random.Range(0, prefabs.Length)],
                position,
                new Quaternion());
        }
    }
}
