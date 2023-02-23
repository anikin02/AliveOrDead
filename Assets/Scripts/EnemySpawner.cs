using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int enemyMultiplier = 0;
    [SerializeField] private float durationMultiplier = 0;
    [SerializeField] private float WaveDuration = 10;
    [SerializeField] private AudioClip waveSound;
    public int Wave = 0;
    private float delayBetween = 5;
    private bool isWave = false;
    private IEnumerator newWaveCoroutine;

    private void Start()
    {
        newWaveCoroutine = newWave();
    }

    private void FixedUpdate()
    {
        if ((!isWave) && (GameObject.FindGameObjectsWithTag("Enemy").Length == 0))
        {
            StopCoroutine(newWaveCoroutine);
            StartCoroutine(newWaveCoroutine);
        }
    }

    private IEnumerator newWave()
    {
        while(true)
        {
            isWave = true;
            yield return new WaitForSeconds(delayBetween);
            Wave++;
            WaveDuration += Wave * durationMultiplier;
            spawnEnemies(Wave * enemyMultiplier);
            isWave = false;
            yield return new WaitForSeconds(WaveDuration);
        }
    }

    private void spawnEnemies(int countEnemies)
    {
        AudioSource.PlayClipAtPoint(waveSound, transform.position, 1);
        for (int i = 0; i < countEnemies; i++)
        {
            Vector2 position = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(5.0f, 10.0f));
            GameObject newGameObject = Instantiate(
                enemies[Random.Range(0, enemies.Length)],
                position,
                new Quaternion());
        }
    }
}
