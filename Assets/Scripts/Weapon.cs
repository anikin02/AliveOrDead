using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float delay = 1;
    [SerializeField] private int damage = 10;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip shotSound;
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
        var side = 0;
        var sideX = 0;

        if ((horizontal <= 1) && (horizontal >= 0.7) && (vertical < 0.7) && (vertical > -0.7))
        {
            side = 1;
            sideX = 1;
        }
        else if ((horizontal >= -1) && (horizontal <= -0.7)  && (vertical < 0.7) && (vertical > -0.7))
        {
            side = -1;
            sideX = 1;
        }
        else if ((horizontal < 0.7) && (horizontal > -0.7) && (vertical >= 0.7) && (vertical <= 1))
        {
            side = -1;
        }
        else if ((horizontal < 0.7) && (horizontal > -0.7) && (vertical <= -0.7) && (vertical >= -1))
        {
            side =  1;
        }

        if (side == 0)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(shotSound, transform.position, 1);

        GameObject newbullet = Instantiate(
                bullet,
                transform.position,
                new Quaternion());

        newbullet.GetComponent<Bullet>().SetTale(
            damage,
            side,
            sideX);
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
