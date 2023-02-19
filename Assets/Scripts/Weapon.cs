using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float delay = 1;
    [SerializeField] private int damage = 10;
    [SerializeField] private GameObject bullet;
    private FixedJoystick fixedJoystick;
    private bool isShooting = false;
    private float vertical;
    private float horizontal;
    private IEnumerator shootingCoroutine;

    private void Start()
    {
        shootingCoroutine = shooting();
        fixedJoystick = GameObject.FindGameObjectWithTag("AttackController").GetComponent<FixedJoystick>();
        
    }

    private void Update()
    {
        cheackShoot();
    }

    private IEnumerator shooting()
    {
        while(true)
        {
            shot();
            yield return new WaitForSeconds(delay);
        }
    }
    private void shot()
    {
        GameObject newbullet = Instantiate(
                bullet,
                transform.position,
                new Quaternion());

        newbullet.GetComponent<Bullet>().SetTale(damage, horizontal < 0);
    }

    private void cheackShoot()
    {
        horizontal = fixedJoystick.Horizontal;
        vertical = fixedJoystick.Vertical;

        if ((horizontal == 0) && (vertical == 0))
        {
            StopAllCoroutines();
            isShooting = false;
        }
        else
        {
            if (!isShooting)
            {
                isShooting = true;
                StartCoroutine(shootingCoroutine);
            }
        }
    }
}
