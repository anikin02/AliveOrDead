using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!player)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }

    private void updateImage()
    {
        float newScale = player.Health;

    }
}
