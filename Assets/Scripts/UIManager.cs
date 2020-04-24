using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text scoreText;
    public Text speedText;
    public Text gameOverText;
    public Text tryAgainText;   
    public Image healthBar;
    public Sprite[] healthBarImages;
    
    private int healthBarCounter = 0;

    public void LoseHealthUI()
    {
        healthBarCounter++;
        healthBar.sprite = healthBarImages[healthBarCounter];
        StartCoroutine(LoseHealthRoutine());
    }

    IEnumerator LoseHealthRoutine()
    {
        yield return new WaitForSeconds(.25f);
        healthBarCounter++;
        healthBar.sprite = healthBarImages[healthBarCounter];
    }
}
