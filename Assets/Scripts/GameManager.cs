using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int kill = -1;

    //public Vector3 killPos = Vector3.zero;

    public Vector3 targetPosBox = Vector3.zero;

    public static GameManager Instance;

    public Chess enemyBox;

    public Chess playerBox;

    public static bool isExplode = false;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckKill(Chess chess)
    {
        if (chess.isPlayer)
        {
            UIController.Instance.AddPlayerScore();
            GridManager.Instance.RandomSpawn(enemyBox);

            CheckDestroyBullet();
        }
        else
        {
            UIController.Instance.AddEnemyScore();
            GridManager.Instance.RandomSpawn(playerBox);

            CheckDestroyBullet();
        }
    }

    public void OnPlayerKill(List<Vector2> vector2s)
    {
        foreach (var vector2 in vector2s)
        {
            foreach (var enemy in ChessManager.Instance.enemies)
            {
                if (vector2 == new Vector2(enemy.transform.position.x, enemy.transform.position.y))
                {
                    kill = 1;
                    //killPos = new Vector3(vector2.x, vector2.y, 0);

                    targetPosBox = new Vector3(enemy.transform.position.x, enemy.transform.position.y,0);

                    enemyBox = enemy;

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
                //killPos = new Vector3(playerPos.x, playerPos.y, 0);

                targetPosBox = new Vector3(ChessManager.Instance.mainPlayer.transform.position.x, ChessManager.Instance.mainPlayer.transform.position.y, 0);

                playerBox = ChessManager.Instance.mainPlayer;
            }
        }
    }

    public void Shoot(Chess chess)
    {
        SpawnProjectiles.Instance.SpawnVFX(chess);
        ProjectileMove.Instance.targetPos = targetPosBox;
    }

    void CheckDestroyBullet()
    {
        ProjectileMove.Instance.DestroyBullet(isExplode);
        isExplode = false;
    }
}
