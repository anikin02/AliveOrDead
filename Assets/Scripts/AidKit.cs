using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private int healthPoints = 50;
    [SerializeField] private AudioClip takeSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            AudioSource.PlayClipAtPoint(takeSound, transform.position, 1);
            player.GetHealPoints(healthPoints);
            Destroy(gameObject);
        }
    }
}
