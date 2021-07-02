using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool loop = true;

    private void Start()
    {
        StartCoroutine(Timing());
    }

    public IEnumerator Timing()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.5f);
        while (loop)
        {
            yield return waitTime;

            if (ChessManager.Instance.enemyTurn == false)
            {
                StartCoroutine(ChessManager.Instance.PlayerMoveTurn());

                ChessManager.Instance.enemyTurn = true;
            }

            //yield return new WaitForSeconds(2f);

            //StartCoroutine(ChessManager.Instance.EnemyMoveTurn());
        }
    }
}
