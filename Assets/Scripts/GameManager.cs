using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int color = -1;

    public static int kill = -1;

    public Vector3 killPos = Vector3.zero;

    public static GameManager Instance;

    public Chess enemyBox;

    public Chess playerBox;

    private void Awake()
    {
        Instance = this;

    }

    public void CheckColor(Chess chess)
    {
        if (chess.isPlayer)
        {
            color = 1;
        }
        else
            color = -1;
    }

    public void CheckKill()
    {
        if (color == 1)
        {
            UIController.Instance.AddPlayerScore();
            GridManager.Instance.SpawnRandomChess(enemyBox);
        }
        else
        {
            UIController.Instance.AddEnemyScore();
            GridManager.Instance.SpawnRandomChess(playerBox);
        }
    }

    public void ShowColor(List<Vector2> vector2)
    {
        if (color == 1)
        {
            GridManager.Instance.ShowChessPossibleMove(vector2);
            OnPlayerKill(vector2);
        }
        else
        {
            GridManager.Instance.ShowChessPossibleDamage(vector2);
            OnEnemyKill(vector2);
        }
    }

    public void OnPlayerKill(List<Vector2> vector2s)
    {
        foreach (var vector2 in vector2s)
        {
            foreach (var enemy in ChessManager.Instance.enemies)
            {
                if ( vector2 == new Vector2(enemy.transform.position.x, enemy.transform.position.y))
                {
                    kill = 1;
                    killPos = new Vector3(vector2.x, vector2.y, 0);
                    enemyBox = enemy;
                    Debug.Log("Destroy enemy");
                    break;
                }
            }
        }
    }

    public void OnEnemyKill(List<Vector2> vector2s)
    {
        Vector2 playerPos = new Vector2(ChessManager.Instance.mainPlayer.transform.position.x, ChessManager.Instance.mainPlayer.transform.position.y);
        foreach (var vector2 in vector2s)
        {
            if (vector2 == playerPos)
            {
                kill = 1;
                killPos = new Vector3(playerPos.x, playerPos.y, 0);
                playerBox = ChessManager.Instance.mainPlayer;
                Debug.Log("Destroy player");
            }
        }
    }
}
