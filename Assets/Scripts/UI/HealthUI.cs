using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthUI;

    }

    void UpdateHealthUI(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}