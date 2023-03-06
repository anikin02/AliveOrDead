using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int volume = 1;
    [SerializeField] private AudioClip takeSound;

    private void getMoney(Player player)
    {
        DataHolder.Money += volume;
        player.Money += volume;
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();

        if (player)
        {
            AudioSource.PlayClipAtPoint(takeSound, transform.position, 5);
            getMoney(player);
        }
    }
}
