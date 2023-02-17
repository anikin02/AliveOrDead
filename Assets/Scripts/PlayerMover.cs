using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private float moveSpeed = 0;
    private float vertical;
    private float horizontal;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        vertical = fixedJoystick.Vertical;
        horizontal = fixedJoystick.Horizontal; 
        var verticalPosition = vertical * moveSpeed * Time.deltaTime;
        var horizontalPosition = horizontal * moveSpeed * Time.deltaTime;

        transform.Translate(horizontalPosition, verticalPosition, 0);

        if ((verticalPosition != 0) || (horizontalPosition != 0))
        {
            animator.SetBool("isRunning", true);
        }
        else 
        {
            animator.SetBool("isRunning", false);
        }

        if (horizontalPosition < 0)
        {
            flip(true);
        }
        else if (horizontalPosition > 0)
        {
            flip(false);
        }
    }

    private void flip(bool isFliping)
    {
        spriteRenderer.flipX = isFliping;
    }
}
