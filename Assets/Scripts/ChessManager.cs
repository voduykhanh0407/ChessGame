using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChessManager : MonoBehaviour
{
    public Chess mainPlayer;
    public List<Chess> enemies = new List<Chess>();

    public bool enemyTurn = false;

    public static ChessManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator PlayerMoveTurn()
    {
        yield return new WaitForSeconds(0.2f);

        mainPlayer.ChessMove(mainPlayer);
    }

    public IEnumerator EnemyMoveTurn()
    {
        if (enemyTurn)
        {
            foreach (var enemy in enemies)
            {
                yield return new WaitForSeconds(0.5f);

                enemy.ChessMove(enemy);

                yield return new WaitForSeconds(0.5f);
            }
            enemyTurn = false;
        } 
    }
}
