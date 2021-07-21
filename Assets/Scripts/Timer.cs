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
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        while (loop)
        {
            yield return waitTime;
            if (ChessManager.Instance.enemyTurn == false)
            {
                StartCoroutine(ChessManager.Instance.PlayerMoveTurn());

                ChessManager.Instance.enemyTurn = true;
            }

            yield return new WaitForSeconds(1.5f);

            StartCoroutine(ChessManager.Instance.EnemyMoveTurn());
        }
    }
}
