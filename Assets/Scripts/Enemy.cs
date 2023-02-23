using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float delay = 1f;
    [SerializeField] private int attackDamage = 10;
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

        AudioSource.PlayClipAtPoint(deathSound, transform.position, 1);
        
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(player)
        {
            player.AddKillPoint(1);
        }

        
        gameObject.tag = "DeadEnemy";

        // new sprite


    }
}
