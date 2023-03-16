using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip hitSound; 
    private RestartGame restartButton;
    public int Kills = 0;
    public int Money = 0;
    public int Health = 0;
    private Animator animator;

    private void Awake()
    {
        restartButton = GameObject.Find("Canvas/RESTART").GetComponent<RestartGame>();
        restartButton.EnableButton();
    }
    private void Start()
    {
        Health = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void GetDamage(int damage)
    {
        if (Health - damage > 0)
        {
            Health -= damage;
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 1);
        }
        else
        {
            Health = 0;
            print(Health);
            death();
        }
    }

    public void AddKillPoint(int points)
    {
        Kills+=points;
    }

    public void GetHealPoints(int healPoints)
    {
        if (Health + healPoints <= maxHealth)
        {
            Health += healPoints;
        }
        else
        {
            Health = maxHealth;
        }
    }

    private void death()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isDying", true);
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        AudioSource.PlayClipAtPoint(loseSound, transform.position, 1);
        restartButton.EnableButton();
    }
}
