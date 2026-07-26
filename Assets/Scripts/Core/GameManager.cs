using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameTimer = 0f;
    public int score = 0;

    public event Action OnKillCountChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        gameTimer += Time.deltaTime;
    }

    public void RegisterKill()
    {
        score++;
        OnKillCountChanged?.Invoke();
    }
}
