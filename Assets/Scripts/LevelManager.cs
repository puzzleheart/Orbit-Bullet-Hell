using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public Player player;
    public EnemySpawner enemySpawner;
    public int score = 0;
    public GameObject enemyToAdd;

    private int levelSpeed = 1;
    private bool gameOver = false;

    private void Start()
    {
        UIManager.Instance.scoreText.text = score.ToString();
        Cursor.visible = false;

    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UIManager.Instance.scoreText.text = score.ToString();

        // Level Progression
        if (levelSpeed == 1 && score >= 100)
        {
            levelSpeed = 2;
            UIManager.Instance.speedText.text = levelSpeed.ToString();
            enemySpawner.ChangeTiming(.8f, 1.6f);
        }
        else if (levelSpeed == 2 && score >= 200)
        {
            enemySpawner.AddEnemyToSpawnList(enemyToAdd);
            levelSpeed = 3;
            UIManager.Instance.speedText.text = levelSpeed.ToString();
            enemySpawner.ChangeTiming(.8f, 1.4f);
        }
        else if (levelSpeed == 3 && score >= 300)
        {
            levelSpeed = 4;
            UIManager.Instance.speedText.text = levelSpeed.ToString();
            enemySpawner.ChangeTiming(.6f, 1.2f);
        }
        else if (levelSpeed == 4 && score >= 450)
        {
            levelSpeed = 5;
            UIManager.Instance.speedText.text = levelSpeed.ToString();
            enemySpawner.ChangeTiming(.6f, 1f);
        }
        else if (levelSpeed == 5 && score >= 600)
        {
            levelSpeed = 6;
            UIManager.Instance.speedText.text = levelSpeed.ToString();
            enemySpawner.ChangeTiming(.5f, .8f);
        }
        else if (levelSpeed == 6 && score >= 700)
        {
            levelSpeed = 7;
            UIManager.Instance.speedText.text = levelSpeed.ToString();
            enemySpawner.ChangeTiming(.5f, .6f);
        }
        else if (levelSpeed == 7 && score >= 900)
        {
            levelSpeed = 8;
            UIManager.Instance.speedText.text = levelSpeed.ToString();
            enemySpawner.ChangeTiming(.35f, .45f);
        }
    }

    public void SetGameOver()
    {
        gameOver = true;
    }


    // Some good timings for level progression
    // 0-100 score: 1 - 2
    // 100-200 score: .8 - 1.6
    // 200-300 score: new enemy, .8 - 1.4
    // 300-450 score: .6 - 1.2
    // 450-600 score: .6 - 1
    // 600-700 score: .5 - .8
    // 700-900 score: .5 - .6
}
