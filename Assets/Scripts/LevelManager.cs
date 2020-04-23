using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Player player;
    public int score = 0;

    private void Start()
    {
        UIManager.Instance.scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UIManager.Instance.scoreText.text = score.ToString();
    }
}
