using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        GameManager.Instance.OnKillCountChanged += UpdateScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = GameManager.Instance.score.ToString();
    }
}
