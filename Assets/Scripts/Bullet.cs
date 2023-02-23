using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private int side;
    
    private int damage;
    private void Update()
    {
        move();
    }
    
    private void FixedUpdate()
    {
        cheackDistance();
    }

    public void SetTale(int _damage, int _side, int _sideX)
    {
        damage = _damage;
        side = _side;
        transform.rotation = Quaternion.Euler(0, 0, 90*_sideX);
        GetComponent<SpriteRenderer>().flipY = side > 0;
    }

    private void move()
    {
        var move = moveSpeed * Time.deltaTime;
        transform.Translate(0, -move * side, 0);
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
