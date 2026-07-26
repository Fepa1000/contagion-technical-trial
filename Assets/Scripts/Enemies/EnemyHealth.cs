using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount, Vector2 hitDirection)
    {
        currentHealth -= amount;

        Knockback(hitDirection);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.RegisterKill();
        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }

    public void Knockback(Vector2 hitDirection)
    {
        transform.position += (Vector3)(hitDirection * 0.3f);
    }
}
