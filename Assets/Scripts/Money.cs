using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int volume = 1;

    private void getMoney(Player player)
    {
        DataHolder.Money += volume;
        player.Money += volume;
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            getMoney(player);
        }
    }
}
