using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private bool side = false; 
    
    private int damage;
    private void Update()
    {
        move();
    }
    
    private void FixedUpdate()
    {
        cheackDistance();
    }

    public void SetTale(int _damage, bool flipY)
    {
        damage = _damage;
        side = flipY;
        transform.rotation = Quaternion.Euler(0, 0, 90);
        GetComponent<SpriteRenderer>().flipY = !flipY;
    }

    private void move()
    {
        var horizontalPosition = moveSpeed * Time.deltaTime;

        if (side)
        {
            transform.Translate(0, horizontalPosition, 0);
        }
        else
        {
            transform.Translate(0, -horizontalPosition, 0);
        }
    }

    private void cheackDistance()
    {
        if ((transform.position.x > 50) || (transform.position.x < -50) || (transform.position.y < -50) || (transform.position.y > 50))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
