using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChessManager : MonoBehaviour
{
    public Chess mainPlayer = null;
    public List<Chess> enemies = new List<Chess>();

    public bool enemyTurn = false;

    public static ChessManager Instance;

    private void Awake()
    {
        Instance = this;

        var chesses = GameObject.FindObjectsOfType<Chess>();
        mainPlayer = chesses.FirstOrDefault(s => s.isPlayer);
        enemies = chesses.Where(w => !w.isPlayer).Select(s => s).ToList();
    }
     

    

    public void OnChessDied(Chess chess)
    {
        if (chess.isPlayer)
        {
            //TODO: player dies.
        }

        else
        {
            //TODO: chess which not player dies.
            if (enemies.Contains(chess))
            {
                enemies.Remove(chess);
            }
        }
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null)
            {
                Chess chess = hit.collider.GetComponent<Chess>();
                if (chess != null)
                {
                    if (chess.isPlayer)
                    {
                        //chess.PlayerShowMove();
                        mainPlayer = chess;
                        return;
                    }
                        
                }
            }
            mainPlayer = null;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mainPlayer != null)
            {
                mainPlayer.ChessMove();
                enemyTurn = true;
            }
            if (enemyTurn)
            {
                StartCoroutine(EnemyMoveTurn());
                enemyTurn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(EnemyMoveTurn());
        }
    }

    public IEnumerator PlayerMoveTurn()
    {
        if (!enemyTurn)
        {
            yield return new WaitForSeconds(0.2f);

            mainPlayer.PlayerShowMove(mainPlayer);

            enemyTurn = true;
        }
        
    }

    public IEnumerator EnemyMoveTurn()
    {
        if (enemyTurn)
        {
            foreach (var enemy in enemies)
            {
                yield return new WaitForSeconds(0.3f);

                enemy.EnemyShowMove(enemy);
            }
            enemyTurn = false;
        }
            
    }

}
