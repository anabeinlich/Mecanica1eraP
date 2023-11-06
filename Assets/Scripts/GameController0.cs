using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController0 : MonoBehaviour
{
    public int remainingEnemies;
    public float timer = 40;
    [SerializeField] private TextMeshProUGUI remainingEnemiesText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI loseText;


    void Start()
    {
        remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        winText.text = "";
        loseText.text = "";
        
        UpdateUI();

    }

    private void UpdateUI()
    {
        remainingEnemiesText.text = remainingEnemies.ToString();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "" + timer.ToString("f0");

        LoseCondition();
    }


    public void EnemiesKilled()
    {
        remainingEnemies--;
        UpdateUI();

        if (remainingEnemies <= 0) {

            winText.text = "you win";
            Time.timeScale = 0;
        }

    }

    public void LoseCondition()
    {
        if (timer <= 0)
        {
            loseText.text = "time is up you lose";
            Time.timeScale = 0;
        }
    }
}
