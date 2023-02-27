using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float delay = 1f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private Sprite deadSptite;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;
    
    [SerializeField] private GameObject[] prefabsMoney;

    private IEnumerator attackCourutine;

    public void GetDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            death();
        }

        AudioSource.PlayClipAtPoint(hitSound, transform.position, 1);
    }

    private void dropMoney()
    {
        var maxCounter = Random.Range(1, 5);
        for (int i = 0; i < maxCounter; i++)
        {
            Vector2 position = new Vector2(transform.position.x + Random.Range(-0.3f, 0.3f),
                transform.position.y + Random.Range(-0.3f, 0.3f));

            GameObject newGameObject = Instantiate(
                prefabsMoney[Random.Range(0, prefabsMoney.Length)],
                position,
                new Quaternion());
        }
    }

    private IEnumerator attack(Player player)
    {
        while(true)
        {
            if(!player)
            {
                yield break;
            }

            player.GetDamage(attackDamage);
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            attackCourutine = attack(player);
            StartCoroutine(attackCourutine);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {   
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            StopCoroutine(attackCourutine);
        }
    }

    private void death()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<EnemyMover>());
        Destroy(GetComponent<Animator>());
        dropMoney();

        AudioSource.PlayClipAtPoint(deathSound, transform.position, 1);
        
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(player)
        {
            player.AddKillPoint(1);
        }
        GetComponent<SpriteRenderer>().sortingOrder = 5;
        GetComponent<SpriteRenderer>().sprite = deadSptite;
        gameObject.tag = "DeadEnemy";
    }
}
