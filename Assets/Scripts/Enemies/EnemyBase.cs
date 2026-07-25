using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float moveSpeed = 2f;
    protected Transform player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.Translate(dir * moveSpeed * Time.deltaTime);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy has hit the Player.");
        }
    }
}
