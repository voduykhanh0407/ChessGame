using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool enemyTurn = false;

    public bool loop = true;

    public static Timer Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        enemyTurn = false;
        StartCoroutine(Timing());
    }

    public IEnumerator Timing()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.5f);
        while (loop)
        {
            yield return waitTime;

            StartCoroutine(ChessManager.Instance.PlayerMoveTurn());

            //yield return new WaitForSeconds(2f);

            //StartCoroutine(ChessManager.Instance.EnemyMoveTurn());
        }
    }
}
