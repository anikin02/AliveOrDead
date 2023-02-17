using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int enemyMultiplier = 0;
    [SerializeField] private float durationMultiplier = 0;
    [SerializeField] private float waveDuration = 10;
    private int wave = 0;
    private IEnumerator newWaveCoroutine;

    private void Start()
    {
        newWaveCoroutine = newWave();
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StopCoroutine(newWaveCoroutine);
            StartCoroutine(newWaveCoroutine);
        }
    }

    private IEnumerator newWave()
    {
        while(true)
        {
            wave++;
            waveDuration += wave * durationMultiplier;
            spawnEnemies(wave * enemyMultiplier);
            yield return new WaitForSeconds(waveDuration);
        }
    }

    private void spawnEnemies(int countEnemies)
    {
        for (int i = 0; i < countEnemies; i++)
        {
            Vector2 position = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f));
            GameObject newGameObject = Instantiate(
                enemies[Random.Range(0, enemies.Length)],
                position,
                new Quaternion());
        }
    }
}
