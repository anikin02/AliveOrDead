using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private int healthPoints = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.GetHealPoints(healthPoints);
            Destroy(gameObject);
        }
    }
}
