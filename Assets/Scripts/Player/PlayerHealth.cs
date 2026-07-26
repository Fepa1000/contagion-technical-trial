using UnityEngine;
using UnityEngine.UI; 
public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Death UI")]
    public Image deathScreen;

    void Start()
    {
        currentHealth = maxHealth;

        // This makes the death screen invisible when the game starts
        if (deathScreen != null)
        {
            Color c = deathScreen.color;
            c.a = 0f; // Alpha set to 0 (fully transparent)
            deathScreen.color = c;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("You got hit! Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Game Over!");

        if (deathScreen != null)
        {
            Color c = deathScreen.color;
            c.a = 0.5f; 
            deathScreen.color = c;
        }

        // This freezes the entire game
        Time.timeScale = 0f;

        gameObject.SetActive(false);
    }
}