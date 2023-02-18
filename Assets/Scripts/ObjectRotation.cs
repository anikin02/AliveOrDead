using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private FixedJoystick fixedJoystick;
    private float vertical;
    private float horizontal;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fixedJoystick = GameObject.FindGameObjectWithTag("AttackController").GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        rotation();
    }

    private void rotation()
    {
        vertical = fixedJoystick.Vertical;
        horizontal = fixedJoystick.Horizontal;

        if (horizontal < 0)
        {
            flip(true);
        }
        else if (horizontal > 0)
        {
            flip(false);
        }
    }

    private void flip(bool isFliping)
    {
        spriteRenderer.flipX = isFliping;
    }
}
