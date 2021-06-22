using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public int playerScore;
    public int enemyScore;

    public Text playerText;
    public Text enemyText;

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
            Debug.Log("Victory");
            SceneManager.LoadScene(1);
        }
        if (enemyScore == 3)
        {
            Debug.Log("Defeat");
            SceneManager.LoadScene(2);
        }
    }
}
