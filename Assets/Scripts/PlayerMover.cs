using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private float moveSpeed = 0;
    private float vertical;
    private float horizontal;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
    } 
}
