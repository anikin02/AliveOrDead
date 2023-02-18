using UnityEngine;

public class Weapon : MonoBehaviour
{
    private FixedJoystick fixedJoystick;
    private float vertical;
    private float horizontal;

    private void Start()
    {
        fixedJoystick = GameObject.FindGameObjectWithTag("AttackController").GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        rotation();
    }

    private void rotation()
    {

    }
}
