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
    
    private void OnTriggernEnter2D(Collider2D collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();

        if (player)
        {
            getMoney(player);
        }
    }
}
