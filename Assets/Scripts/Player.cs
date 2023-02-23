using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip hitSound; 
    private RestartGame restartButton;
    public int Kills = 0;
    private int health = 0;

    private void Awake()
    {
        restartButton = GameObject.Find("Canvas/RESTART").GetComponent<RestartGame>();
        restartButton.EnableButton();
    }
    private void Start()
    {
        health = maxHealth;
    }

    public void GetDamage(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 1);
        }
        else
        {
            health = 0;
            print(health);
            death();
        }
    }

    public void AddKillPoint(int points)
    {
        Kills+=points;
    }

    public void GetHealPoints(int healPoints)
    {
        if (health + healPoints <= maxHealth)
        {
            health += healPoints;
        }
        else
        {
            health = maxHealth;
        }
    }

    private void death()
    {
        AudioSource.PlayClipAtPoint(loseSound, transform.position, 1);
        restartButton.EnableButton();
        Destroy(gameObject);
    }
}
