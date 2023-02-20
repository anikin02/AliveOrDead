using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        if(player)
        {
            var position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            transform.position = position;
        }
    }
}
