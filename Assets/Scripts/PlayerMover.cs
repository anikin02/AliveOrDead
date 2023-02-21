using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;

    private FixedJoystick fixedJoystick;
    private float vertical;
    private float horizontal;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fixedJoystick = GameObject.FindGameObjectWithTag("GameController").GetComponent<FixedJoystick>();
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

        if ((verticalPosition != 0) || (horizontalPosition != 0))
        {
            animator.SetBool("isRunning", true);

            if (((transform.position.x + horizontalPosition) < 15) && ((transform.position.x + horizontalPosition) > -15))
            {
                transform.Translate(horizontalPosition, 0, 0); 
            }
            if (((transform.position.y + verticalPosition) < 10) && ((transform.position.y + verticalPosition) > -10))
            {
                transform.Translate(0, verticalPosition, 0); 
            }
        }
        else 
        {
            animator.SetBool("isRunning", false);
        }
    }
}
