using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private RestartGame restartButton;
    public int Kills = 0;
    private int health = 0;

    private void Start()
    {
        health = maxHealth;
    }

    public void GetDamage(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
            print(health);
        }
        else
        {
            health = 0;
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
        restartButton.EnableButton();
        Destroy(gameObject);
    }
}
