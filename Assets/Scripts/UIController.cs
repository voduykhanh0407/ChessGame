using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public int playerScore = 0;
    public int enemyScore = 0;

    public Text playerText;
    public Text enemyText;

    int x = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerScore = 0;
        enemyScore = 0;
    }

    private void Update()
    {
        OnEndGame();
        playerText.text = "Player: " + playerScore;
        enemyText.text = "Enemy: " + enemyScore;
        x++;
    }

    public void AddPlayerScore()
    {
        playerScore += 1;
    }

    public void AddEnemyScore()
    {
        enemyScore += 1;
    }

    public void OnEndGame()
    {
        if (playerScore == 3)
        {
            playerScore = 0;
            // Victory
            LoadSceneManager.Instance.LoadScene(1);
        }
        if (enemyScore == 3)
        {
            enemyScore = 0;
            // Defeat
            LoadSceneManager.Instance.LoadScene(2);
        }
    }
}
