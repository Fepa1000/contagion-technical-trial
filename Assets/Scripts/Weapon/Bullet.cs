using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
        // Need to make it so that I can deactivate the Game Object rather than destroy it

    }

    void Update()
    {
        // transform.right automatically moves the object in the direction it is facing
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Vector2 hitDir = (collision.transform.position - transform.position).normalized;
            collision.GetComponent<EnemyHealth>()?.TakeDamage(25,hitDir);
            Destroy(gameObject);
        }
    }
}