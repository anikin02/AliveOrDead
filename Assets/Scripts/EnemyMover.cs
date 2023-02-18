using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Transform playerTransform;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        if (!playerTransform)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(
            transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

        if (transform.position.x < playerTransform.position.x)
        {
            flip(false);
        }
        else if (transform.position.x > playerTransform.position.x)
        {
            flip(true);
        }
    }

    private void flip(bool isFliping)
    {
        spriteRenderer.flipX = isFliping;
    }
}
