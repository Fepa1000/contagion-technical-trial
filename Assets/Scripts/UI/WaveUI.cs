using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;

    // Need to change the other events to OnEnable and OnDisable to follow the Observer Design Pattern properly
    void OnEnable()
    {
        EnemySpawner.OnWaveChanged += UpdateWaveUI;
    }

    void OnDisable()
    {
        EnemySpawner.OnWaveChanged -= UpdateWaveUI;
    }

    void UpdateWaveUI(int currentWave)
    {
        if (waveText != null)
        {
            waveText.text = currentWave.ToString();
        }
    }
}